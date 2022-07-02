using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace KeyboardTrainer
{
    /// <summary>
    /// Логика взаимодействия для Trainer.xaml
    /// </summary>
    public partial class Trainer : UserControl
    {
        public Trainer()
        {
            InitializeComponent();
            _updater.Interval = 100;
            _updater.Tick += _updateFails;
            _updater.Tick += _updateIndicator;
            _updater.Tick += _updateSpeed;
        }

        private Timer _updater = new Timer();
        private Stopwatch _watch = new Stopwatch();
        private int buttonClick = 0;
        private int _fails
        {
            get
            {
                int fail = 0;
                for (int i = 0; i < TaskText.Text.Length; i++)
                {
                    if (TextEnter.Text.Length <= i) return fail;
                    if (TaskText.Text[i] != TextEnter.Text[i]) fail++;
                }
                return fail;
            }
        }
        private Brush _correct { get; set; } = Brushes.PaleGreen;
        private Brush _incorrect { get; set; } = Brushes.Tomato;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            buttonClick++;
            if (TextEnter.Text.Length > 0)
                if (TextEnter.Text.Length == TaskText.Text.Length)
                    Stop_Click(null, null);
        }
        private void _updateIndicator(object sender, EventArgs e)
        {
            Indicator.Width = TextEnter.ExtentWidth;
            Indicator.Background = _checkText() ? _correct : _incorrect;
        }
        private void _updateFails(object sender, EventArgs e)
        {
            Fails.Text = _fails.ToString();
        }
        private void _updateSpeed(object sender, EventArgs e)
        {
            if (_watch == null) return;
            if (TextEnter.Text.Length > 0)
            {
                Speed.Text = Math.Round(((double)buttonClick * 1000 / _watch.ElapsedMilliseconds * 60)).ToString();
            }
        }
        private bool _checkText()
        {
            return _fails == 0;
        }
        private string _generateText()
        {
            Random random = new Random();
            int count = 0;
            string text = "";
            for (int i = 0; i < DifficultySlider.Value * 50; i++)
            {
                if (i > 0 &&
                    text[i - 1] != ' ' &&
                    random.Next((int)DifficultySlider.Value + 1) == 0)
                {
                    text += " ";
                    continue;
                }
                char newChar = (char)random.Next(97, 122);
                if ((bool)Sensitive.IsChecked)
                {
                    if (random.Next(2) == 0)
                    {
                        text += newChar.ToString().ToUpper();
                        continue;
                    }
                }
                text += newChar.ToString();
            }
            text = text.Trim();
            TextEnter.MaxLength = text.Length;
            return text;

        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            _start();
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            _finish();
        }
        private void _start()
        {
            buttonClick = 0;
            _updater.Start();
            TextEnter.IsEnabled = true;
            StopBtn.IsEnabled = true;
            Sensitive.IsEnabled = false;
            DifficultySlider.IsEnabled = false;
            StartBtn.IsEnabled = false;
            TaskText.Text = _generateText();
            TextEnter.Focus();
            _watch.Start();
        }
        private void _finish()
        {
            _watch.Stop();
            _updater.Stop();
            _watch.Reset();
            _statistic();
            Clear();

            TextEnter.IsEnabled = false;
            StopBtn.IsEnabled = false;
            Sensitive.IsEnabled = true;
            DifficultySlider.IsEnabled = true;
            StartBtn.IsEnabled = true;
        }
        
        private void _statistic()
        {
            string stats = "";
            int fails = _fails;
            if (fails == 0)
                stats += "Great!";
            else if (fails < 5)
                stats += "Norm.";
            else
            {
                stats += "Bad";
            }

            stats += $"\nFails: {fails}";
            MessageBox.Show(stats, "Statistic", MessageBoxButton.OK);
        }
        public void Clear()
        {
            Speed.Text = "0";
            Fails.Text = "0";
            Indicator.Width = 0;
            TaskText.Text = "";
            TextEnter.Text = "";
        }
    }
}
