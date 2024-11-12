using AnonLeaks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AnonLeaks.Models.SubDomainModel;

namespace AnonLeaks
{
    public class SearchSystem
    {
        public static async Task SearchEmail(HttpClientHandler handler, string api, string token, string email, TextBox output, Button searchButton)
        {
            searchButton.Enabled = false;

            try
            {
                if (handler == null || output == null || searchButton == null)
                {
                    MessageBox.Show($"Error: null objects", "Error");
                    return;
                }

                var result = await TorConnection.SendRequest(handler, $"{api}/email/{token}/{email}", output);
                if (result == null || result.Content == null)
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text = "Null response from the server.";
                    }));
                    return;
                }

                var jsonRes = await result.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonRes))
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text = "Null response from the server.";
                    }));
                    return;
                }

                if (jsonRes.Contains("Insufficient queries"))
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text += "Error: Invalid token, buy with support!";
                    }));
                    return;
                }

                if (jsonRes.Contains("Token invalid"))
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text += "Error: Invalid token!";
                    }));
                    return;
                }

                if (jsonRes.Contains("Not found") || result.StatusCode == HttpStatusCode.Unauthorized || result.StatusCode == HttpStatusCode.NotFound)
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text = "No results found!";
                    }));
                    return;
                }

                var deserialized = JsonSerializer.Deserialize<EmailModel.LogData>(jsonRes);

                // DubachDell@utc.com
                if (deserialized != null)
                {
                    if (deserialized.Document1 != null)
                    {
                        foreach (var item in deserialized.Document1)
                        {
                            if (item != null)
                            {
                                output.Invoke((Action)(() =>
                                {
                                    output.AppendText($"Mail: {item.User} {Environment.NewLine}");
                                    output.AppendText($"Pass: {item.Pass} {Environment.NewLine}");
                                    output.AppendText($"-------------------------------- {Environment.NewLine}");
                                }));
                            }
                        }
                    }

                    if (deserialized.Document2 != null)
                    {
                        foreach (var item in deserialized.Document2)
                        {
                            if (item != null)
                            {
                                output.Invoke((Action)(() =>
                                {
                                    output.AppendText($"Url: {item.Host}/{item.Path} {Environment.NewLine}");
                                    output.AppendText($"Mail: {item.User} {Environment.NewLine}");
                                    output.AppendText($"Pass: {item.Pass} {Environment.NewLine}");
                                    output.AppendText($"-------------------------------- {Environment.NewLine}");
                                }));
                            }
                        }
                    }
                }
            }
            finally
            {
                searchButton.Enabled = true;
            }
        }

        public static async Task SearchUrl(HttpClientHandler handler, string api, string token, string url, TextBox output, Button searchButton)
        {
            searchButton.Enabled = false;

            try
            {
                var result = await TorConnection.SendRequest(handler, $"{api}/url/{token}/{url}", output);
                if (result == null)
                {
                    output.Text += "Error: Null result received from request." + Environment.NewLine;
                    return;
                }

                var jsonRes = await result.Content.ReadAsStringAsync();

                if (jsonRes.Contains("Insufficient queries"))
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text += "Error: Insufficient queries, buy with support!";
                    }));
                    return;
                }

                if (jsonRes.Contains("Token invalid"))
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text += "Error: Invalid token, buy with support!";
                    }));
                    return;
                }

                if (result.StatusCode == HttpStatusCode.Unauthorized || result.StatusCode == HttpStatusCode.NotFound)
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text = "No results found." + Environment.NewLine;
                    }));
                    return;
                }

                /*if (string.IsNullOrEmpty(jsonRes))
                {
                    MessageBox.Show("Error: Empty response received.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                var deserialized = JsonSerializer.Deserialize<List<UrlModel>>(jsonRes);
                if (deserialized == null || result.StatusCode == HttpStatusCode.Unauthorized || result.StatusCode == HttpStatusCode.NotFound)
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text = "No results found." + Environment.NewLine;
                    }));
                    return;
                }

                output.Text = "";

                foreach (var item in deserialized)
                {
                    output.Invoke((Action)(() =>
                    {
                        output.AppendText($"Host: {item.host}/{item.path}" + System.Environment.NewLine);
                        output.AppendText($"User: {item.user}" + System.Environment.NewLine);
                        output.AppendText($"Pass: {item.pass}" + System.Environment.NewLine);
                        output.AppendText("----------------------------" + System.Environment.NewLine);
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}" + Environment.NewLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                searchButton.Enabled = true;
            }
        }

        public static async Task SearchSubdomain(HttpClientHandler handler, string api, string token, string url, TextBox output, Button searchButton)
        {
            searchButton.Enabled = false;

            try
            {
                var result = await TorConnection.SendRequest(handler, $"{api}/subdomain/{token}/{url}", output);
                if (result == null)
                {
                    output.Text += "Error: Null result received from request." + Environment.NewLine;
                    return;
                }

                var jsonRes = await result.Content.ReadAsStringAsync();

                if (jsonRes.Contains("Insufficient queries"))
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text += "Error: Insufficient queries, buy with support!";
                    }));
                    return;
                }

                if (jsonRes.Contains("Token invalid"))
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text += "Error: Invalid token, buy with support!";
                    }));
                    return;
                }

                if (string.IsNullOrEmpty(jsonRes))
                {
                    MessageBox.Show("Error: Empty response received.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var jsonDes = JsonSerializer.Deserialize<SubDomainModel.Root>(jsonRes);

                if (result.StatusCode == HttpStatusCode.Unauthorized || result.StatusCode == HttpStatusCode.NotFound)
                {
                    output.Invoke((Action)(() =>
                    {
                        output.Text = "No results found." + Environment.NewLine;
                    }));
                    return;
                }

                if (jsonDes == null)
                {
                    MessageBox.Show("Error: Failed to deserialize JSON.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                output.Invoke((Action)(() =>
                {
                    output.Text = "";
                }));

                if (jsonDes.Document1 != null)
                {
                    output.Invoke((Action)(() =>
                    {
                        output.AppendText($"Subdomains here: {Environment.NewLine}");
                    }));

                    foreach (var data in jsonDes.Document1)
                    {
                        output.Invoke((Action)(() =>
                        {
                            output.AppendText($"{data.SubdomainName}" + Environment.NewLine);
                            output.AppendText("----------------------------" + Environment.NewLine);
                        }));
                    }
                }

                if (jsonDes.Document2 != null)
                {
                    output.Invoke((Action)(() =>
                    {
                        output.AppendText($"Logins here: {Environment.NewLine}");
                    }));

                    foreach (var data in jsonDes.Document2)
                    {
                        foreach (var data2 in data)
                        {
                            output.Invoke((Action)(() =>
                            {
                                output.AppendText($"Host: {data2.Host}/{data2.Path} {Environment.NewLine}");
                                output.AppendText($"User: {data2.User} {Environment.NewLine}");
                                output.AppendText($"Pass: {data2.Pass} {Environment.NewLine}");
                                output.AppendText("----------------------------" + Environment.NewLine);
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                searchButton.Enabled = true;
            }
        }
    }
}
