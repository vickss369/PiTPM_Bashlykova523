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

namespace PiTPM_Bashlykova523
{
    /// <summary>
    /// Логика взаимодействия для OmPage.xaml
    /// </summary>
    public partial class OmPage : Page
    {
        public OmPage()
        {
            InitializeComponent();
            buttonEnabled();
        }

        private void buttonEnabled()
        {
            if (countBtn == null)
                return;

            if (!string.IsNullOrWhiteSpace(firstTB.Text) &&
                !string.IsNullOrWhiteSpace(secondTB.Text) &&
                (amperageRB.IsChecked == true || voltageRB.IsChecked == true || resistRB.IsChecked == true))
            {
                countBtn.IsEnabled = true;
            }
            else
            {
                countBtn.IsEnabled = false;
            }
        }

        private void EnterTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]);
        }

        private void EnterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            buttonEnabled();
        }

        private void calculatedValue_Checked(object sender, RoutedEventArgs e)
        {
            buttonEnabled();

            if (resTBL == null)
                return;

            if (amperageRB.IsChecked == true)
            {
                firstTBL.Text = "Напряжение (Вольт)";
                secondTBL.Text = "Сопротивление (Ом)";
                resTBL.Text = "Сила тока = ";
            }
            else if (voltageRB.IsChecked == true)
            {
                firstTBL.Text = "Сила тока (Ампер)";
                secondTBL.Text = "Сопротивление (Ом)";
                resTBL.Text = "Напряжение = ";
            }
            else if (resistRB.IsChecked == true)
            {
                firstTBL.Text = "Напряжение (Вольт)";
                secondTBL.Text = "Сила тока (Ампер)";
                resTBL.Text = "Сопротивление = ";
            }
        }

        /// <summary>
        /// Вычисляет значение по закону Ома
        /// </summary>
        /// <param name="first">Первое значение (верхнее поле)</param>
        /// <param name="second">Второе значение (нижнее поле)</param>
        /// <param name="selectedFunc">Выбранная величина</param>
        /// <param name="ans">Результат</param>
        /// <param name="error">Ошибка</param>
        /// <returns>True, если вычисление успешно</returns>
        public bool CalculateValue(double first, double second, string selectedFunc, out double ans, out string error)
        {
            ans = 0;
            error = string.Empty;

            if (string.IsNullOrEmpty(selectedFunc))
            {
                error = "Выберите функцию!";
                return false;
            }

            if (second == 0 && (selectedFunc == "Сила тока" || selectedFunc == "Сопротивление"))
            {
                error = "Деление на ноль!";
                return false;
            }

            switch (selectedFunc)
            {
                case "Сила тока":
                    ans = first / second;
                    break;

                case "Напряжение":
                    ans = first * second;
                    break;

                case "Сопротивление":
                    ans = first / second;
                    break;

                default:
                    error = "Неизвестная функция!";
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Обработчик кнопки "Вычислить"
        /// </summary>
        private void countBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(firstTB.Text, out double first) ||
                !double.TryParse(secondTB.Text, out double second))
            {
                MessageBox.Show("Введите корректные числа!");
                return;
            }

            string selectedFunc = "";
            if (amperageRB.IsChecked == true) selectedFunc = "Сила тока";
            else if (voltageRB.IsChecked == true) selectedFunc = "Напряжение";
            else if (resistRB.IsChecked == true) selectedFunc = "Сопротивление";

            if (!CalculateValue(first, second, selectedFunc, out double ans, out string error))
            {
                MessageBox.Show(error);
                return;
            }

            answerTBL.Text = ans.ToString();
        }
    }
}
