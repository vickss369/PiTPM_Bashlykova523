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

namespace PiTPM_Bashlykova523.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageF1.xaml
    /// </summary>
    public partial class PageF1 : Page
    {
        public PageF1()
        {
            InitializeComponent();
            buttonEnabled();
        }

        private void nextFuncBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageF2());
        }

        private void buttonEnabled()
        {
            if (string.IsNullOrWhiteSpace(xEnterTB.Text) || string.IsNullOrWhiteSpace(yEnterTB.Text) || string.IsNullOrWhiteSpace(zEnterTB.Text))
            {
                countBtn.IsEnabled = false;
                clearBtn.IsEnabled = false;
            }
            else
            {
                countBtn.IsEnabled = true;
                clearBtn.IsEnabled = true;
            }
        }

        private void EnterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            buttonEnabled();
        }

        private void EnterTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            char ch = e.Text[0];

            if (char.IsDigit(ch))
            {
                e.Handled = false;
                return;
            }

            if (ch == ',')
            {
                if (tb.Text.Contains(','))
                    e.Handled = true;
                else
                    e.Handled = false;

                return;
            }

            e.Handled = true;
        }

        private void countBtn_Click(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToDouble(xEnterTB.Text);
            double y = Convert.ToDouble(yEnterTB.Text);
            double z = Convert.ToDouble(zEnterTB.Text);

            double ans = Math.Sqrt(10 * (Math.Pow(x, 1 / 3) + Math.Pow(x, y + 2))) * (Math.Pow(Math.Asin(z), 2) - Math.Abs(x - y));
            ansTB.Text = ans.ToString();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            xEnterTB.Text = "";
            yEnterTB.Text = "";
            zEnterTB.Text = "";
            ansTB.Text = "";
        }
    }
}
