//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tomighty.Windows.Timer
{
    public partial class TimerWindow : Form
    {
        public static readonly Color DarkGray = Color.FromArgb(41, 41, 41);
        public static readonly Color Red = Color.FromArgb(168, 32, 41);
        public static readonly Color Green = Color.FromArgb(26, 102, 41);
        public static readonly Color Blue = Color.FromArgb(22, 57, 101);

        private ColorScheme currentColorScheme;
        private Action currentTimerAction;

        private readonly Action<string> UpdateTimeDisplayDelegate;
        private readonly Action<string> UpdateTitleDelegate;
        private readonly Action<string, Action> UpdateTimerButtonTextDelegate;

        public TimerWindow()
        {
            InitializeComponent();

            currentColorScheme = CreateColorScheme(DarkGray);

            SetTransparentBackground(pinButton);
            SetTransparentBackground(closeButton);
            Icon = Properties.Resources.icon_tomato_red;

            timeLabel.Font = new Font(SystemFonts.DefaultFont.FontFamily, 32f);

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

        public void UpdateColorScheme(Color color)
        {
            currentColorScheme = CreateColorScheme(color);
            Invalidate();
        }

        public void UpdatePinButtonState(bool pinned)
        {
            pinButton.Image = pinned ? Properties.Resources.image_pinned : Properties.Resources.image_unpinned;
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
        
        public ColorScheme CreateColorScheme(Color color)
        {
            return new ColorScheme
            (
                fill: CreateGradientBrush(color),
                border: new Pen(Darker(color), 1f)
            );
        }

        private Brush CreateGradientBrush(Color color)
        {
            return new LinearGradientBrush(
                new Point(),
                new Point(0, Height),
                Brighter(color),
                Darker(color)
            );
        }

        private Color Darker(Color color)
        {
            return AdjustBrightness(color, -40);
        }

        private Color Brighter(Color color)
        {
            return AdjustBrightness(color, 20);
        }

        private static Color AdjustBrightness(Color color, int offset)
        {
            var r = Math.Max(0, color.R + offset);
            var g = Math.Max(0, color.G + offset);
            var b = Math.Max(0, color.B + offset);
            return Color.FromArgb(r, g, b);
        }
    }

    public class ColorScheme
    {
        public ColorScheme(Brush fill, Pen border)
        {
            Fill = fill;
            Border = border;
        }

        public Brush Fill { get; }
        public Pen Border { get; }
    }
}
