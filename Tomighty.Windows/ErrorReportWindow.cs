using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;

namespace Tomighty.Windows
{
    public partial class ErrorReportWindow : Form
    {
        public ErrorReportWindow(Exception exception)
        {
            InitializeComponent();
            errorDescription.Text = exception.ToString();
        }

        private void ErrorReportWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            reportButton.Enabled = false;
            progressLabel.Text = "Sending error report, please wait...";
            progressLabel.ForeColor = Color.Blue;
            progressLabel.Visible = true;

            var worker = new BackgroundWorker();
            worker.DoWork += SendErrorReport;
            worker.RunWorkerCompleted += OnErrorReportSent;
            worker.RunWorkerAsync();
        }

        private void SendErrorReport(object sender, EventArgs e)
        {
            var data = GetReportData();
            var client = new HttpClient();
            var json = ToJson(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PostAsync("https://tomighty-errors.herokuapp.com", content);

            task.Wait();

            if (task.Exception != null)
                throw new Exception("Failed to send error report", task.Exception);
        }

        private static string ToJson(ReportData data)
        {
            var serializer = new DataContractJsonSerializer(typeof(ReportData));
            var stream = new MemoryStream();
            serializer.WriteObject(stream, data);
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private ReportData GetReportData()
        {
            return new ReportData
            {
                version = Version.Product,
                machine_id = "foo",
                error = errorDescription.Text
            };
        }

        private void OnErrorReportSent(object sender, RunWorkerCompletedEventArgs e)
        {
            var success = e.Error == null;
            if (success)
            {
                progressLabel.Text = "Done";
                progressLabel.ForeColor = Color.Green;
                MessageBox.Show(this, "Thanks for sending the error report. Bye!", "Error Report Sent", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Application.Exit();
            }
            else
            {
                reportButton.Enabled = true;
                progressLabel.Text = "Failed to send report. Try again later.";
                progressLabel.ForeColor = Color.Red;
            }
        }

        [DataContract]
        private class ReportData
        {
            [DataMember] public string version { get; set; }
            [DataMember] public string machine_id { get; set; }
            [DataMember] public string error { get; set; }
        }
    }
}
