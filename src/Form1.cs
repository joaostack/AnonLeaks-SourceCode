using AnonLeaks.Models;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace AnonLeaks
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public HttpClientHandler handler;
        private static string token = "";
        private static string apiUrl = "";
        private Form activeFrm;
        public TextBox TextBox1 => textBox1;
        public string LastUrl = "";
        public bool LastRadioChecked = false;
        public int LastRadioButtonIndex { get; set; } = -1;
        public Form1()
        {
            InitializeComponent();

            this.MinimumSize = new Size(800, 600);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            panel1.Dock = DockStyle.Left;

            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.ScrollBars = ScrollBars.Vertical;

            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            InitializeTorConnection();

            var configFile = MyProgram.StartConfig();

            // Create config if not exists
            if (configFile == null || string.IsNullOrEmpty(configFile.token))
            {
                configFile = new ConfigModel { token = "BuyToken" };
                string json = JsonSerializer.Serialize(configFile);
                File.WriteAllText("config.json", json);
                textBox1.Text += "Config file was missing or incomplete, creating with default values." + Environment.NewLine;
            }

            if (configFile == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(configFile.token.Trim()))
            {
                textBox1.Text += "Token not configured, check config.json!";
                return;
            }

            handler = handler ?? new HttpClientHandler();

            apiUrl = "http://ta4mzqiwvuxqbg7ionktbq4pj3p6k62fd4t6qlpq2uydxghmuslpjyyd.onion";
            token = configFile.token;
        }

        public void LoadForm(Form frm)
        {
            if (activeFrm != null)
            {
                activeFrm.Hide();
            }

            activeFrm = frm;
            activeFrm.TopLevel = false;
            activeFrm.Dock = DockStyle.Fill;
            this.Controls.Add(activeFrm);

            activeFrm.Show();
        }

        private void ActiveFormClose()
        {
            if (activeFrm != null)
            {
                activeFrm.Close();
            }
        }

        private async void InitializeTorConnection()
        {
            if (!TorManager.IsTorRunning)
            {
                TorManager.Handler = await TorConnection.Connection(textBox1);
                TorManager.IsTorRunning = true;
            }
            else
            {
                MessageBox.Show("Tor is now running!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            await UpdateStats();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (handler == null)
            {
                handler = new HttpClientHandler();
            }

            if (TorManager.Handler == null)
            {
                MessageBox.Show("O Tor doesn't started, please wait!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await TorConnection.TestApi(handler, textBox1);
            }
            catch (Exception ex)
            {
                textBox1.Invoke((Action)(() =>
                {
                    textBox1.AppendText($"Error: {ex.Message}" + Environment.NewLine);
                }));
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (handler == null)
            {
                handler = new HttpClientHandler();
            }

            if (TorManager.Handler == null)
            {
                MessageBox.Show("O Tor doesn't started, please wait!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await TorConnection.TorTest(handler, textBox1);
            }
            catch (Exception ex)
            {
                textBox1.Invoke((Action)(() =>
                {
                    textBox1.AppendText($"Error: {ex.Message}" + Environment.NewLine);
                }));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button3.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

            if (TorManager.Handler == null)
            {
                TorManager.Handler = new HttpClientHandler();
            }

            LoadForm(new Form2(this, TorManager.Handler, TorManager.IsTorRunning));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button3.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;

            ActiveFormClose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button3.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

            LoadForm(new Form3());
        }

        public async Task UpdateStats()
        {
            var configFile = MyProgram.StartConfig();
            token = configFile.token;

            await TorConnection.GetMe(handler, $"{apiUrl}/{token}/getme", textBox1, label5, label4);
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            await UpdateStats();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button3.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

            LoadForm(new Form4());
        }
    }
}
