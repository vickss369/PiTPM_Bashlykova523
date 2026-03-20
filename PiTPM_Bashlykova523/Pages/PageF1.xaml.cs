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
            if (!string.IsNullOrWhiteSpace(xEnterTB.Text) && xEnterTB.Text.Any(char.IsDigit) &&
                !string.IsNullOrWhiteSpace(yEnterTB.Text) && yEnterTB.Text.Any(char.IsDigit) &&
                !string.IsNullOrWhiteSpace(zEnterTB.Text) && zEnterTB.Text.Any(char.IsDigit))
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
                e.Handled = tb.Text.Contains(',');
                return;
            }

            if (ch == '-') 
            {
                e.Handled = tb.Text.Contains('-') || tb.SelectionStart != 0;
                return;
            }

            e.Handled = true;
        }

        /// <summary>
        /// Выполняет вычисление функции 1.
        /// </summary>
        /// <param name="x">Значение X</param>
        /// <param name="y">Значение Y</param>
        /// <param name="z">Значение Z</param>
        /// <param name="ans">Результат вычисления</param>
        /// <param name="error">Сообщение об ошибке</param>
        /// <returns>True, если вычисление успешно, иначе False</returns>
        public bool CalculateF1(double x, double y, double z, out double ans, out string error)
        {
            ans = 0;
            error = string.Empty;

            if (z < -1 || z > 1)
            {
                error = "Арксинус определён только для значений от -1 до 1!";
                return false;
            }

            double sqrtExpression = 10 * (Math.Pow(x, 1.0 / 3.0) + Math.Pow(x, y + 2));

            if (sqrtExpression < 0)
            {
                error = "Подкоренное выражение не должно быть отрицательным!";
                return false;
            }

            ans = Math.Sqrt(sqrtExpression) * (Math.Pow(Math.Asin(z), 2) - Math.Abs(x - y));
            return true;
        }

        /// <summary>
        /// Обработчик кнопки "Вычислить"
        /// </summary>
        private void countBtn_Click(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToDouble(xEnterTB.Text.Replace(" ", ""));
            double y = Convert.ToDouble(yEnterTB.Text.Replace(" ", ""));
            double z = Convert.ToDouble(zEnterTB.Text.Replace(" ", ""));

            if (CalculateF1(x, y, z, out double result, out string error))
            {
                ansTB.Text = result.ToString();
            }
            else
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                if (error.Contains("Арксинус"))
                {
                    zEnterTB.Focus();
                    zEnterTB.SelectAll();
                }
                else if (error.Contains("Подкоренное"))
                {
                    xEnterTB.Focus();
                    xEnterTB.SelectAll();
                }
            }
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
