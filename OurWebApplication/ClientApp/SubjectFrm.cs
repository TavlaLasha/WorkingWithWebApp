using ClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class SubjectFrm : Form
    {
        public string Code="";
        string BaseURL = ConfigurationSettings.AppSettings["BaseURL"];
        static HttpClient client = new HttpClient();
        public SubjectFrm()
        {
            InitializeComponent();
            InitializeRequest();
        }
        public SubjectFrm(string code)
        {
            InitializeComponent();
            InitializeRequest();
            Code = code;
            Text = "Update Subject";
            textBox_code.Enabled = false;
            FillForm();
        }

        private async void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                Subject sb = new Subject();
                if (!Code.Equals(""))
                    sb.Code = Code;

                sb.Name = textBox_name.Text;
                sb.Description = textBox_desc.Text;
                sb.Code = textBox_code.Text;
                sb.Credits = Convert.ToInt32(numericUpDown_credits.Value);
                sb.Hours = Convert.ToInt32(numericUpDown_hours.Value);

                string output = JsonConvert.SerializeObject(sb);
                var stringContent = new StringContent(output, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage request;
                if (Code.Equals(""))
                {
                    request = await client.PostAsync("Subject", stringContent);
                }
                else
                {
                    request = await client.PutAsync("Subject?code=" + Code, stringContent);
                }

                string info = (!Code.Equals("")) ? "Updated" : "Added";
                MessageBox.Show($"Subject Has Been Successfully {info}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
        public async void FillForm()
        {
            var result = await client.GetStringAsync("Subject?code=" + Code);
            Subject sb = JsonConvert.DeserializeObject<Subject>(result);

            textBox_name.Text = sb.Name;
            textBox_desc.Text = sb.Description;
            textBox_code.Text = sb.Code;
            numericUpDown_credits.Value = sb.Credits;
            numericUpDown_hours.Value = (sb.Hours.HasValue) ? sb.Hours.Value : 0;
        }
        public void InitializeRequest()
        {
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
