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
    /// Логика взаимодействия для PageF2.xaml
    /// </summary>
    public partial class PageF2 : Page
    {
        public PageF2()
        {
            InitializeComponent();
            buttonEnabled();
        }

        private void buttonEnabled()
        {
            if (!string.IsNullOrWhiteSpace(xEnterTB.Text) && !string.IsNullOrWhiteSpace(bEnterTB.Text) && 
                (shFuncRB.IsChecked == true || x2FuncRB.IsChecked == true || exFuncRB.IsChecked == true))
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

        private void FuncRB_Checked(object sender, RoutedEventArgs e)
        {
            buttonEnabled();
        }

        private void EnterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            buttonEnabled();
        }

        private void EnterTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]);
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void nextFuncBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageF3());
        }

        private void countBtn_Click(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToDouble(xEnterTB.Text);
            double b = Convert.ToDouble(bEnterTB.Text);
            double ans;

            string selectedFunc = "";
            if (shFuncRB.IsChecked == true) selectedFunc = "sh(x)";
            else if (x2FuncRB.IsChecked == true) selectedFunc = "x²";
            else if (exFuncRB.IsChecked == true) selectedFunc = "eˣ";
            else
            {
                MessageBox.Show("Выберите функцию!");
                return;
            }

            switch (selectedFunc)
            {
                case "sh(x)":
                    if (x * b > 0.5 && x * b < 10)
                        ans = Math.Exp(Math.Sinh(x) - Math.Abs(b));
                    else if (x * b > 0.1 && x * b < 0.5)
                        ans = Math.Sqrt(Math.Abs(Math.Sinh(x) + b));
                    else
                        ans = 2 * Math.Pow(Math.Sinh(x), 2);
                    break;

                case "x²":
                    if (x * b > 0.5 && x * b < 10)
                        ans = Math.Exp(Math.Pow(x, 2) - Math.Abs(b));
                    else if (x * b > 0.1 && x * b < 0.5)
                        ans = Math.Sqrt(Math.Abs(Math.Pow(x, 2) + b));
                    else
                        ans = 2 * Math.Pow(Math.Pow(x, 2), 2);
                    break;

                case "eˣ":
                    if (x * b > 0.5 && x * b < 10)
                        ans = Math.Exp(Math.Exp(x) - Math.Abs(b));
                    else if (x * b > 0.1 && x * b < 0.5)
                        ans = Math.Sqrt(Math.Abs(Math.Exp(x) + b));
                    else
                        ans = 2 * Math.Pow(Math.Exp(x), 2);
                    break;

                default:
                    ans = 0;
                    break;
            }

            ansTB.Text = ans.ToString();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            xEnterTB.Text = "";
            bEnterTB.Text = "";

            shFuncRB.IsChecked = false;
            x2FuncRB.IsChecked = false;
            exFuncRB.IsChecked = false;

            ansTB.Text = "";
        }
    }
}
