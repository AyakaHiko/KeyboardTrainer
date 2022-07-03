using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyboardTrainer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (_isCapitalKey)
                _toUpperLetters();
            _setColors();
        }
        private bool _isCapitalKey => System.Windows.Input.Keyboard.IsKeyToggled(Key.CapsLock);
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var button in Keyboard.GetKeys())
            {
                if (button.Name != e.Key.ToString()) continue;
                SolidColorBrush b = button.Background as SolidColorBrush;
                Color newColor = Color.FromArgb(b.Color.A,
                    Convert.ToByte(b.Color.R / 2),
                    Convert.ToByte(b.Color.G / 2),
                    Convert.ToByte(b.Color.B * 3 / 4));

                button.Opacity = 0.5;
                if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                    _toUpperExtended();

                if (e.Key == Key.Capital)
                {
                    if (!_isCapitalKey)
                        _upDownLetters(false);
                    else
                        _toUpperLetters();
                }
                break;
            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (var button in Keyboard.GetKeys())
            {
                if (button.Name != e.Key.ToString()) continue;
                button.Opacity = 1; break;
            }
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                if (_isCapitalKey)
                    _upDownSymbols(false);
                else
                    _toLowerExtended();
            }
        }
        private void _toUpperLetters()
        {
            foreach (var button in Keyboard.GetKeys())
            {
                if (button.Tag.ToString() != "print" || button.Name == "Space") continue;
                button.Content = button.Content.ToString().ToUpper();
            }
        }
        private void _toUpperExtended()
        {
            _upDownLetters();
            _upDownSymbols();
        }
        private void _toLowerExtended()
        {
            _upDownSymbols(false);
            _upDownLetters(false);
        }
        private void _upDownSymbols(bool toUpper = true)
        {
            foreach (var button in Keyboard.GetKeys())
            {
                if (button.Tag.ToString() != "print" || button.Name == "Space") continue;
                switch (button.Name)
                {
                    case "D1":
                        if (toUpper)
                        {
                            button.Content = "!";
                            break;
                        }
                        button.Content = "1"; break;
                    case "D2":
                        if (toUpper)
                        {
                            button.Content = "@";
                            break;
                        }
                        button.Content = "2"; break;
                    case "D3":
                        if (toUpper)
                        {
                            button.Content = "#";
                            break;
                        }
                        button.Content = "3"; break;
                    case "D4":
                        if (toUpper)
                        {
                            button.Content = "$";
                            break;
                        }
                        button.Content = "4"; break;
                    case "D5":
                        if (toUpper)
                        {
                            button.Content = "%";
                            break;
                        }
                        button.Content = "5"; break;
                    case "D6":
                        if (toUpper)
                        {
                            button.Content = "^";
                            break;
                        }

                        button.Content = "6"; break;
                    case "D7":
                        if (toUpper)
                        {
                            button.Content = "&";
                            break;
                        }
                        button.Content = "7"; break;
                    case "D8":
                        if (toUpper)
                        {
                            button.Content = "*";
                            break;
                        }
                        button.Content = "8"; break;
                    case "D9":
                        if (toUpper)
                        {
                            button.Content = "(";
                            break;
                        }
                        button.Content = "9"; break;
                    case "D0":
                        if (toUpper)
                        {
                            button.Content = ")";
                            break;
                        }
                        button.Content = "0"; break;
                    case "OemMinus":
                        if (toUpper)
                        {
                            button.Content = "_";
                            break;
                        }
                        button.Content = "-"; break;
                    case "OemPlus":
                        if (toUpper)
                        {
                            button.Content = "+";
                            break;
                        }
                        button.Content = "="; break;
                    case "OemOpenBrackets":
                        if (toUpper)
                        {
                            button.Content = "{";
                            break;
                        }
                        button.Content = "["; break;
                    case "Oem6":
                        if (toUpper)
                        {
                            button.Content = "}";
                            break;
                        }
                        button.Content = "]"; break;
                    case "Oem5":
                        if (toUpper)
                        {
                            button.Content = "|";
                            break;
                        }
                        button.Content = "\\"; break;
                    case "Oem1":
                        if (toUpper)
                        {
                            button.Content = ":";
                            break;
                        }
                        button.Content = ";"; break;
                    case "Oem3":
                        if (toUpper)
                        {
                            button.Content = "~";
                            break;
                        }

                        button.Content = "`"; break;
                    case "OemQuotes":
                        if (toUpper)
                        {
                            button.Content = "\"";
                            break;
                        }
                        button.Content = "'"; break;
                    case "OemComma":
                        if (toUpper)
                        {
                            button.Content = "<";
                            break;
                        }
                        button.Content = ","; break;
                    case "OemPeriod":
                        if (toUpper)
                        {
                            button.Content = ">";
                            break;
                        }
                        button.Content = "."; break;
                    case "OemQuestion":
                        if (toUpper)
                        {
                            button.Content = "?";
                            break;
                        }
                        button.Content = "/"; break;
                }
            }
        }
        private void _upDownLetters(bool toUpper = true)
        {
            foreach (var button in Keyboard.GetKeys())
            {
                if (button.Tag.ToString() != "print" || button.Name == "Space") continue;
                button.Content = toUpper ? button.Content.ToString().ToUpper() : button.Content.ToString().ToLower();
            }
        }
        private void _setColors()
        {
            foreach (var button in Keyboard.GetKeys())
            {
                switch (button.Name)
                {
                    case "OemMinus":
                    case "OemPlus":
                    case "P":
                    case "E":
                    case "D":
                    case "C":
                    case "D4":
                    case "OemOpenBrackets":
                    case "Oem6":
                    case "Oem5":
                    case "Oem1":
                    case "OemQuotes":
                    case "OemQuestion":
                        button.Background = Brushes.PaleGreen; break;
                    case "OemPeriod":
                    case "D3":
                    case "D0":
                    case "W":
                    case "O":
                    case "L":
                    case "S":
                    case "X":
                        button.Background = Brushes.Khaki; break;
                    case "OemComma":
                    case "D1":
                    case "D2":
                    case "D9":
                    case "Q":
                    case "I":
                    case "K":
                    case "A":
                    case "Z":
                    case "Oem3":
                        button.Background = Brushes.Tomato; break;
                    case "M":
                    case "D7":
                    case "D8":
                    case "Y":
                    case "U":
                    case "H":
                    case "J":
                    case "N":
                        button.Background = Brushes.MediumPurple; break;
                    case "B":
                    case "V":
                    case "F":
                    case "G":
                    case "R":
                    case "T":
                    case "D5":
                    case "D6":
                        button.Background = Brushes.Aqua; break;
                    case "Space":
                        button.Background = Brushes.Orange; break;
                    default:
                        button.Background = Brushes.Gray; break;
                }
            }
        }
        private void _rebootKb()
        {
            foreach (var button in Keyboard.GetKeys())
            {
                button.Opacity = 1;
            }
        }
        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            _rebootKb();
        }
    }
}
