using AnonLeaks.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnonLeaks
{
    public static class TorManager
    {
        public static HttpClientHandler? Handler { get; set; }
        public static bool IsTorRunning { get; set; } = false;
    }
    public class TorConnection
    {
        private static Process? _torProcess;
        private static HttpClient? _httpClient;
        private static string apiUrl = "http://ta4mzqiwvuxqbg7ionktbq4pj3p6k62fd4t6qlpq2uydxghmuslpjyyd.onion";
        public TorConnection()
        {
            _httpClient = new HttpClient();
        }

        public static async Task<HttpClientHandler?> Connection(TextBox output)
        {
            string torPath = Path.Combine("./", "Tor", "tor.exe");
            if (!File.Exists(torPath))
            {
                output.Text += "Error: tor.exe not found." + System.Environment.NewLine;
                return null;
            }

            output.Text = "Starting tor... please wait." + System.Environment.NewLine;

            if (_torProcess == null || _torProcess.HasExited)
            {
                _torProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = torPath,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                _torProcess.Start();
                await Task.Delay(2000);
            }

            output.Text += "Tor Ok!" + System.Environment.NewLine;

            var handler = new HttpClientHandler
            {
                Proxy = new WebProxy(new Uri("socks5://127.0.0.1:9050")),
                UseProxy = true,
            };

            if (_httpClient == null)
            {
                _httpClient = new HttpClient(handler);
            }

            return handler;
        }

        public static async Task<HttpResponseMessage?> SendRequest(HttpClientHandler handler, string url, TextBox output)
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient(handler);
            }

            try
            {
                var result = await _httpClient.GetAsync(url);
                var content = await result.Content.ReadAsStringAsync();

                if (content.Contains("Insufficient queries"))
                {
                    output.Invoke((Action)(() =>
                    {
                        output.AppendText("Error: Insufficient queries buy with support!" + Environment.NewLine);
                    }));
                    return null;
                }

                if (content.Contains("Token invalid"))
                {
                    output.Invoke((Action)(() =>
                    {
                        output.AppendText("Error: Invalid token!" + Environment.NewLine);
                    }));
                    return null;
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}" + Environment.NewLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output.Text += "Finished." + Environment.NewLine;
                return null;
            }
        }

        public static async Task TorTest(HttpClientHandler handler, TextBox output)
        {
            var url = "https://check.torproject.org/api/ip";

            output.Text += "Testing tor..." + System.Environment.NewLine;

            try
            {
                var response = await TorConnection.SendRequest(handler, url, output);
                if (response == null)
                {
                    output.Text += "Error: No response received from the server." + Environment.NewLine;
                    return;
                }

                output.Text += await response.Content.ReadAsStringAsync() + System.Environment.NewLine;
            }
            catch (Exception ex)
            {
                output.Text += $"Error: {ex.Message}" + Environment.NewLine;
            }
        }

        public static async Task GetMe(HttpClientHandler handler, string url, TextBox output, Label totalQueriesMade, Label availableQueries)
        {
            try
            {
                var response = await TorConnection.SendRequest(handler, url, output);
                if (response == null)
                {
                    output.Text += "Error: No response received from the server." + Environment.NewLine;
                    return;
                }

                var content = await response.Content.ReadAsStringAsync();
                var deserialized = JsonSerializer.Deserialize<GetMeModel.Root>(content);
                if (totalQueriesMade != null && availableQueries != null)
                {
                    totalQueriesMade.Text = "Total queries made: " + deserialized?.total_queries_made.ToString();
                    availableQueries.Text = "Available queries: " + deserialized?.queries.ToString();
                }
            }
            catch
            {
                availableQueries.Text = $"Stats not loaded, check your token.";
            }
        }

        public static async Task TestApi(HttpClientHandler handler, TextBox output)
        {
            var configFile = MyProgram.StartConfig();

            output.Text += "Testing Api..." + System.Environment.NewLine;
            try
            {
                var response = await TorConnection.SendRequest(handler, apiUrl, output);
                if (response == null)
                {
                    output.Text += "Error: No response received from the server." + Environment.NewLine;
                    return;
                }

                output.Text += "STATUS CODE: " + (int)response.StatusCode + System.Environment.NewLine;
            }
            catch (Exception ex)
            {
                output.Text += $"Error: {ex.Message}" + Environment.NewLine;
            }
        }

        public static void StopTor()
        {
            if (_torProcess != null && !_torProcess.HasExited)
            {
                _torProcess.StandardInput.WriteLine("exit");
                _torProcess.WaitForExit(5000);
                if (!_torProcess.HasExited)
                {
                    _torProcess.Kill();
                }
                _torProcess.Dispose();
                _torProcess = null;
            }
        }
    }
}
