using AnonLeaks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnonLeaks
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.MinimumSize = new Size(800, 600);
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            var configFile = MyProgram.StartConfig();

            textBox2.Text = configFile.token;
            this.AcceptButton = button3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Insert token!", "Error");
                return;
            }

            string existingJson = File.ReadAllText("config.json");
            var configModel = JsonSerializer.Deserialize<ConfigModel>(existingJson);
            configModel.token = textBox2.Text;

            string json = JsonSerializer.Serialize(configModel);
            File.WriteAllText("config.json", json);

            MessageBox.Show("Configuration file updated!", "Saved");
        }
    }
}
