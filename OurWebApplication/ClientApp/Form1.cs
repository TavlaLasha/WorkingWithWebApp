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
    public partial class Form1 : Form
    {
        string BaseURL = ConfigurationSettings.AppSettings["BaseURL"];
        static HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await client.GetStringAsync("Subject");
                List<Subject> ct = JsonConvert.DeserializeObject<List<Subject>>(result);
                dataGridView1.DataSource = ct;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            SubjectFrm sfrm = new SubjectFrm();
            sfrm.Show();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            string Code = (string)row.Cells["Code"].Value;
            SubjectFrm sfrm = new SubjectFrm(Code);
            sfrm.Show();
        }

        private async void button_delete_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            string Code = (string)row.Cells["Code"].Value;
            DialogResult decision = MessageBox.Show("Are you sure?", "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (decision == DialogResult.Yes)
            {
                try
                {
                    var result = await client.DeleteAsync("Subject?code=" + Code);
                    
                    MessageBox.Show("Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
