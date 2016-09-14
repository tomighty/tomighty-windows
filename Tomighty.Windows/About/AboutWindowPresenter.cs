//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System.Windows.Forms;

namespace Tomighty.Windows.About
{
    internal class AboutWindowPresenter
    {
        private AboutWindow window;

        public void Show()
        {
            if (window == null)
            {
                window = new AboutWindow();
                window.FormClosed += OnWindowClosed;
            }

            if (window.Visible)
            {
                window.Focus();
            }
            else
            {
                window.ShowDialog();
            }
        }

        private void OnWindowClosed(object sender, FormClosedEventArgs e)
        {
            window.Dispose();
            window = null;
        }
    }
}
