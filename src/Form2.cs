using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnonLeaks
{
    public partial class Form2 : Form
    {
        private bool isTorRunning;
        private string apiUrl = "http://ta4mzqiwvuxqbg7ionktbq4pj3p6k62fd4t6qlpq2uydxghmuslpjyyd.onion";
        private string token = "";
        private Form1 form1Instance;
        HttpClientHandler handler = new HttpClientHandler();
        public Form2(Form1 form1, HttpClientHandler handler, bool isTorRunning)
        {
            InitializeComponent();
            this.MinimumSize = new Size(800, 600);
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.form1Instance = form1;
            TorManager.Handler = handler;
            TorManager.IsTorRunning = isTorRunning;

            var configFile = MyProgram.StartConfig();
            token = configFile.token;

            if (string.IsNullOrWhiteSpace(apiUrl) || string.IsNullOrWhiteSpace(token))
            {
                MessageBox.Show("API URL or Token is not set!", "Error");
                return;
            }

            this.AcceptButton = button3;

            textBox2.Text = form1Instance.LastUrl;
            switch (form1Instance.LastRadioButtonIndex)
            {
                case 1:
                    radioButton1.Checked = true;
                    break;
                case 2:
                    radioButton2.Checked = true;
                    break;
                case 3:
                    radioButton3.Checked = true;
                    break;
            }
        }

        // SEARCH LOGS
        private async void button3_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Select a option!", "Error");
                return;
            }

            if (radioButton2.Checked)
            {
                if (textBox2.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Error: Type a mail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidEmail(textBox2.Text))
                {
                    MessageBox.Show("Error: Is a invalid mail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBox2.Text = textBox2.Text.Trim();

                form1Instance.TextBox1.Text = $"Scanning for logs on {textBox2.Text}..." + System.Environment.NewLine;
                try
                {
                    await SearchSystem.SearchEmail(TorManager.Handler ?? this.handler, apiUrl, token, textBox2.Text, form1Instance.TextBox1, button3);
                }
                catch (Exception ex)
                {
                    form1Instance.TextBox1.Text = $"Error: {ex.Message}" + Environment.NewLine;
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (radioButton1.Checked)
            {
                if (textBox2.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Error: Type a URL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidUrl(textBox2.Text.Trim()))
                {
                    MessageBox.Show("Error: Invalid URL Format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBox2.Text = textBox2.Text.Trim();

                if (textBox2.Text.Contains("/"))
                {
                    MessageBox.Show("Invalid format! use www.sample.com", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                form1Instance.TextBox1.Text = $"Scanning for logs on {textBox2.Text}..." + System.Environment.NewLine;
                await SearchSystem.SearchUrl(this.handler, apiUrl, token, textBox2.Text, form1Instance.TextBox1, button3);
            }

            if (radioButton3.Checked)
            {
                if (textBox2.Text.Trim().Length == 0)
                {
                    MessageBox.Show($"Error: Write a domain!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidUrl(textBox2.Text.Trim()))
                {
                    MessageBox.Show($"Error: Invalid domain format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBox2.Text = textBox2.Text.Trim();

                if (textBox2.Text.Contains("/"))
                {
                    MessageBox.Show($"Error: Invalid format! use sample.com", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                form1Instance.TextBox1.Text = $"Scanning for domains on {textBox2.Text}..." + System.Environment.NewLine;
                await SearchSystem.SearchSubdomain(this.handler, apiUrl, token, textBox2.Text, form1Instance.TextBox1, button3);
            }
        }

        private static readonly Regex emailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            return emailRegex.IsMatch(email);
        }

        private static readonly string UrlPattern = @"^(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}(?:[\/\w-]*)*(?:\?[a-zA-Z0-9-]+=[a-zA-Z0-9-]+(?:&[a-zA-Z0-9-]+=[a-zA-Z0-9-]+)*)?$";
        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            var regex = new Regex(UrlPattern);
            return regex.IsMatch(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    DefaultExt = ".txt",
                    Title = "Save an log File",
                    RestoreDirectory = true,
                    FileName = $"{textBox2.Text}.txt",
                    Filter = "Text Files (*.txt)|*.txt"
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                    {
                        writer.Write(form1Instance.TextBox1.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Error: Write a url or mail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            form1Instance.LastUrl = textBox2.Text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.Text = form1Instance.LastUrl;

            switch (form1Instance.LastRadioButtonIndex)
            {
                case 1:
                    radioButton1.Checked = true;
                    break;
                case 2:
                    radioButton2.Checked = true;
                    break;
                case 3:
                    radioButton3.Checked = true;
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                form1Instance.LastRadioButtonIndex = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                form1Instance.LastRadioButtonIndex = 2;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                form1Instance.LastRadioButtonIndex = 3;
            }
        }
    }
}
