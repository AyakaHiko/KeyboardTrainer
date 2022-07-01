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
    /// Логика взаимодействия для LetterButton.xaml
    /// </summary>
    public partial class LetterButton : UserControl
    {
        public LetterButton()
        {
            InitializeComponent();
        }

        private char _letter = 'a';
        public char Letter
        {
            get => _letter;
            set
            {
                if (!Char.IsLetterOrDigit(value) || !char.IsPunctuation(value)) return;
                _letter = value;
                LetterBlock.Text = _letter.ToString();
            }
        }

        private void Base_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (Base.Width < Base.Height)
            //    Base.Width = Base.Height;
            //else
            //    Base.Height = Base.Width;
        }
        private void _updateLetterSize()=> LetterBlock.FontSize = Base.Width / 3;
    }
}
