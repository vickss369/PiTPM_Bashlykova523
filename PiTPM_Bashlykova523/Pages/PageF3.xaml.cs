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
    /// Логика взаимодействия для PageF3.xaml
    /// </summary>
    public partial class PageF3 : Page
    {
        public PageF3()
        {
            InitializeComponent();
            buttonEnabled();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void buttonEnabled()
        {
            if (!string.IsNullOrWhiteSpace(x0EnterTB.Text) && !string.IsNullOrWhiteSpace(xkEnterTB.Text) && !string.IsNullOrWhiteSpace(dxEnterTB.Text) && !string.IsNullOrWhiteSpace(dEnterTB.Text))
            {
                countBtn.IsEnabled = true;
                clearBtn.IsEnabled = true;
            }
            else
            {
                countBtn.IsEnabled = false;
                clearBtn.IsEnabled = false;
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

        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            x0EnterTB.Text = "";
            xkEnterTB.Text = "";
            dxEnterTB.Text = "";
            dEnterTB.Text = "";
            resultTB.Text = "";

            //Func3Chart.Series[0].Points.Clear();
        }
    }
}
