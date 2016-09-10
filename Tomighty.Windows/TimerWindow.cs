//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tomighty.Windows
{
    public partial class TimerWindow : Form
    {
        public static readonly ColorScheme DarkGrayColorScheme = new ColorScheme
        (
            fill: new SolidBrush(Color.FromArgb(31, 31, 31)),
            border: new Pen(Color.FromArgb(41, 41, 41), 1f)
        );

        public static readonly ColorScheme RedColorScheme = new ColorScheme
        (
            fill: new SolidBrush(Color.FromArgb(92, 13, 11)),
            border: new Pen(Color.FromArgb(95, 21, 13), 1f)
        );

        public static readonly ColorScheme GreenColorScheme = new ColorScheme
        (
            fill: new SolidBrush(Color.FromArgb(26, 102, 41)),
            border: new Pen(Color.FromArgb(46, 103, 45), 1f)
        );

        public static readonly ColorScheme BlueColorScheme = new ColorScheme
        (
            fill: new SolidBrush(Color.FromArgb(22, 57, 101)),
            border: new Pen(Color.FromArgb(22, 70, 101), 1f)
        );

        private ColorScheme currentColorScheme = DarkGrayColorScheme;
        private Action currentTimerAction;

        private readonly Action<string> UpdateTimeDisplayDelegate;
        private readonly Action<string> UpdateTitleDelegate;
        private readonly Action<string, Action> UpdateTimerButtonTextDelegate;

        public TimerWindow()
        {
            InitializeComponent();
            SetTransparentBackground(pinButton);
            SetTransparentBackground(closeButton);
            Icon = Properties.Resources.Icon_RedTomato;

            timeLabel.Font = new Font(SystemFonts.DefaultFont.FontFamily, 22f);

            UpdateTimeDisplayDelegate = (text) => timeLabel.Text = text;
            UpdateTitleDelegate = (text) => titleLabel.Text = text;
            UpdateTimerButtonTextDelegate = (text, action) => timerButton.Text = text;
        }

        public Button PinButton => pinButton;
        public Button CloseButton => closeButton;

        public void UpdateTitle(string text)
        {
            if (IsHandleCreated)
                timeLabel.BeginInvoke(UpdateTitleDelegate, text);
            else
                UpdateTitleDelegate(text);
        }

        public void SetTimerAction(string text, Action action)
        {
            currentTimerAction = action;

            if (IsHandleCreated)
                timerButton.BeginInvoke(UpdateTimerButtonTextDelegate, text, action);
            else
                UpdateTimerButtonTextDelegate(text, action);
        }

        public void UpdateTimeDisplay(string text)
        {
            if (IsHandleCreated)
                timeLabel.BeginInvoke(UpdateTimeDisplayDelegate, text);
            else
                UpdateTimeDisplayDelegate(text);
        }

        public void UpdateColorScheme(ColorScheme newColorScheme)
        {
            if (newColorScheme != currentColorScheme)
            {
                currentColorScheme = newColorScheme;
                Invalidate();
            }
        }

        public void UpdatePinButtonState(bool pinned)
        {
            pinButton.Image = pinned ? Properties.Resources.Image_Pinned : Properties.Resources.Image_Unpinned;
        }

        public void Show(Point location)
        {
            Location = location;
            Show();
        }

        private static void SetTransparentBackground(Button button)
        {
            button.BackColor = Color.Transparent;
            button.FlatAppearance.CheckedBackColor = Color.Transparent;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var background = new Rectangle(0, 0, Width, Height);
            var border = new Rectangle(0, 0, Width - 1, Height - 1);
            e.Graphics.FillRectangle(currentColorScheme.Fill, background);
            e.Graphics.DrawRectangle(currentColorScheme.Border, border);
        }

        private class TransparentLabel : Label
        {
            private const int WM_NCHITTEST = 0x0084;
            private const int HTTRANSPARENT = (-1);

            public TransparentLabel()
            {
                BackColor = Color.Transparent;
            }

            protected override void WndProc(ref Message m)
            {
                // Bubble up mouse events to the parent component so as to
                // allow the timer window to be dragged around even when
                // the user clicks on and moves the mouse over this label
                if (m.Msg == WM_NCHITTEST)
                {
                    m.Result = (IntPtr)HTTRANSPARENT;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
        }

        private void OnTimerButtonClick(object sender, EventArgs e)
        {
            currentTimerAction?.Invoke();
        }
    }

    public class ColorScheme
    {
        public ColorScheme(SolidBrush fill, Pen border)
        {
            Fill = fill;
            Border = border;
        }

        public SolidBrush Fill { get; }
        public Pen Border { get; }
    }
}
