using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для Trainer.xaml
    /// </summary>
    public partial class Trainer : UserControl
    {
        public Trainer()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Indicator.Width = TextEnter.ActualWidth;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            TextEnter.IsEnabled = true;
            StopBtn.IsEnabled = true;
            StartBtn.IsEnabled = false;
            TextEnter.Focus();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            TextEnter.IsEnabled = false;
            StopBtn.IsEnabled = false;
            StartBtn.IsEnabled = true;
        }
    }
}
