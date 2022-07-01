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
            if (System.Windows.Input.Keyboard.IsKeyToggled(Key.CapsLock))
                _toUpperLetters();
            _setColors();
        }

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
                    if (!System.Windows.Input.Keyboard.IsKeyToggled(Key.CapsLock))
                        _toLower();
                    else
                        _toUpperLetters();

                }

            }

        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (var button in Keyboard.GetKeys())
            {
                if (button.Name != e.Key.ToString())continue;
                    button.Opacity = 1;
            }
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                _toLower();
        }

        private void _toUpperSymbols()
        {
            foreach (var button in Keyboard.GetKeys())
            {
                if (button.Tag.ToString() != "print") continue;
                switch (button.Name)
                {
                    case "D1":
                        button.Content = "!"; break;
                    case "D2":
                        button.Content = "@"; break;
                    case "D3":
                        button.Content = "#"; break;
                    case "D4":
                        button.Content = "$"; break;
                    case "D5":
                        button.Content = "%"; break;
                    case "D6":
                        button.Content = "^"; break;
                    case "D7":
                        button.Content = "&"; break;
                    case "D8":
                        button.Content = "*"; break;
                    case "D9":
                        button.Content = "("; break;
                    case "D0":
                        button.Content = ")"; break;
                    case "OemMinus":
                        button.Content = "_"; break;
                    case "OemPlus":
                        button.Content = "+"; break;
                    case "OemOpenBrackets":
                        button.Content = "{"; break;
                    case "Oem6":
                        button.Content = "}"; break;
                    case "Oem5":
                        button.Content = "|"; break;
                    case "Oem1":
                        button.Content = ":"; break;
                    case "Oem3":
                        button.Content = "~"; break;
                    case "OemQuotes":
                        button.Content = "\""; break;
                    case "OemComma":
                        button.Content = "<"; break;
                    case "OemPeriod":
                        button.Content = ">"; break;
                    case "OemQuestion":
                        button.Content = "?"; break;
                }
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
            _toUpperLetters();
            _toUpperSymbols();
        }
        private void _toLower()
        {
            foreach (var button in Keyboard.GetKeys())
            {
                if (button.Tag.ToString() != "print" || button.Name == "Space") continue;
                switch (button.Name)
                {
                    case "D1":
                        button.Content = "1"; break;
                    case "D2":
                        button.Content = "2"; break;
                    case "D3":
                        button.Content = "3"; break;
                    case "D4":
                        button.Content = "4"; break;
                    case "D5":
                        button.Content = "5"; break;
                    case "D6":
                        button.Content = "6"; break;
                    case "D7":
                        button.Content = "7"; break;
                    case "D8":
                        button.Content = "8"; break;
                    case "D9":
                        button.Content = "9"; break;
                    case "D0":
                        button.Content = "0"; break;
                    case "OemMinus":
                        button.Content = "-"; break;
                    case "OemPlus":
                        button.Content = "="; break;
                    case "OemOpenBrackets":
                        button.Content = "["; break;
                    case "Oem6":
                        button.Content = "]"; break;
                    case "Oem5":
                        button.Content = "\\"; break;
                    case "Oem1":
                        button.Content = ";"; break;
                    case "Oem3":
                        button.Content = "`"; break;
                    case "OemQuotes":
                        button.Content = "'"; break;
                    case "OemComma":
                        button.Content = ","; break;
                    case "OemPeriod":
                        button.Content = "."; break;
                    case "OemQuestion":
                        button.Content = "/"; break;
                    default: button.Content = button.Content.ToString().ToLower(); break;
                }
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


    }
}
