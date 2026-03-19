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
            if (!string.IsNullOrWhiteSpace(xEnterTB.Text) && xEnterTB.Text.Any(char.IsDigit) &&
                !string.IsNullOrWhiteSpace(bEnterTB.Text) && bEnterTB.Text.Any(char.IsDigit) && 
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

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void nextFuncBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageF3());
        }

        /// <summary>
        /// Вычисляет значение функции в зависимости от выбранного режима.
        /// </summary>
        /// <param name="x">Значение X</param>
        /// <param name="b">Значение B</param>
        /// <param name="chosenFunc">Выбранная функция: "sh", "x2", "exp"</param>
        /// <param name="ans">Результат вычисления</param>
        /// <param name="error">Сообщение об ошибке</param>
        /// <returns>True, если вычисление прошло успешно</returns>
        public bool CalculateF2(double x, double b, string chosenFunc, out double ans, out string error)
        {
            ans = 0;
            error = string.Empty;

            if (string.IsNullOrEmpty(chosenFunc))
            {
                error = "Функция не выбрана!";
                return false;
            }

            double fx;

            switch (chosenFunc)
            {
                case "sh": fx = Math.Sinh(x); break;

                case "x2": fx = Math.Pow(x, 2); break;

                case "exp": fx = Math.Exp(x); break;

                default: error = "Неизвестная функция!"; return false;
            }

            double xb = x * b;
            if (xb > 0.5 && xb < 10)
            {
                ans = Math.Exp(fx - Math.Abs(b));
            }
            else if (xb > 0.1 && xb < 0.5)
            {
                ans = Math.Sqrt(Math.Abs(fx + b));
            }
            else
            {
                ans = 2 * Math.Pow(fx, 2);
            }

            return true;
        }

        /// <summary>
        /// Обработчик кнопки "Вычислить"
        /// </summary>
        private void countBtn_Click(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToDouble(xEnterTB.Text.Replace(" ", ""));
            double b = Convert.ToDouble(bEnterTB.Text.Replace(" ", ""));

            string chosenFunc = "";
            if (shFuncRB.IsChecked == true) chosenFunc = "sh";
            else if (x2FuncRB.IsChecked == true) chosenFunc = "x2";
            else if (exFuncRB.IsChecked == true) chosenFunc = "exp";

            if (CalculateF2(x, b, chosenFunc, out double ans, out string error))
            {
                ansTB.Text = ans.ToString();
            }
            else
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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
