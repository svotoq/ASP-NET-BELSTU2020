using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            getResponseAsync();
        }

        private async Task getResponseAsync()
        {
            string url = "https://localhost:44399/PSY/Sum";
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection();
                pars.Add("X", textBoxX.Text);
                pars.Add("Y", textBoxY.Text);
                var response = webClient.UploadValues(url, pars);
                string str = System.Text.Encoding.UTF8.GetString(response);
                ResultLable.Text = str;
            }
        }
      
    }
}
