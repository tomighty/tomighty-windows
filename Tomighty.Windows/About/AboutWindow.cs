//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Tomighty.Windows.About
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            titleLabel.Text = $"Tomighty {version.Major}.{version.Minor}.{version.Build}";
            licenseTextBox.Text = File.ReadAllText(@"LICENSE.txt");
            productVersionTextBox.Text = Version.Product;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
