using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tomighty.Windows
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            titleLabel.Text = $"Tomighty {version.Major}.{version.Minor}.{version.Build}";
            licenseTextBox.Text = File.ReadAllText(@"LICENSE.txt");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
