using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
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

            Func3Chart.ChartAreas.Add(new ChartArea("Main"));
            var series = new Series("y = x² + tan(5x + d/x)")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                IsValueShownAsLabel = false
            };
            Func3Chart.Series.Add(series);
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void buttonEnabled()
        {
            if (!string.IsNullOrWhiteSpace(x0EnterTB.Text) && x0EnterTB.Text.Any(char.IsDigit) &&
                !string.IsNullOrWhiteSpace(xkEnterTB.Text) && xkEnterTB.Text.Any(char.IsDigit) &&
                !string.IsNullOrWhiteSpace(dxEnterTB.Text) && dxEnterTB.Text.Any(char.IsDigit) &&
                !string.IsNullOrWhiteSpace(dEnterTB.Text) && dEnterTB.Text.Any(char.IsDigit))
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
        /// Вычисляет значения функции y = x² + tan(5x + d/x) на интервале.
        /// </summary>
        /// <param name="x0">Начало интервала</param>
        /// <param name="xk">Конец интервала</param>
        /// <param name="dx">Шаг</param>
        /// <param name="d">Параметр d</param>
        /// <param name="result">Список точек (x, y)</param>
        /// <param name="error">Сообщение об ошибке</param>
        /// <returns>True, если вычисление успешно</returns>
        public bool CalculateF3(double x0, double xk, double dx, double d,
                              out List<(double x, double y)> result,
                              out string error)
        {
            result = new List<(double, double)>();
            error = string.Empty;

            if (x0 >= xk)
            {
                error = "Начало отрезка должно быть меньше конца!";
                return false;
            }

            if (dx == 0)
            {
                error = "Шаг не должен быть равен нулю!";
                return false;
            }

            if (Math.Abs(dx) > Math.Abs(xk - x0))
            {
                error = "Шаг превышает длину интервала!";
                return false;
            }

            for (double x = x0; x <= xk; x += dx)
            {
                if (x == 0)
                {
                    error = "Деление на ноль (x = 0)!";
                    return false;
                }

                double y = Math.Pow(x, 2) + Math.Tan(5 * x + d / x);
                result.Add((x, y));
            }

            return true;
        }

        /// <summary>
        /// Обработчик кнопки "Вычислить"
        /// </summary>
        private void countBtn_Click(object sender, RoutedEventArgs e)
        {
            double x0 = Convert.ToDouble(x0EnterTB.Text.Replace(" ", ""));
            double xk = Convert.ToDouble(xkEnterTB.Text.Replace(" ", ""));
            double dx = Convert.ToDouble(dxEnterTB.Text.Replace(" ", ""));
            double d = Convert.ToDouble(dEnterTB.Text.Replace(" ", ""));

            if (CalculateF3(x0, xk, dx, d, out var points, out string error))
            {
                resultTB.Text = "";
                Func3Chart.Series[0].Points.Clear();

                foreach (var p in points)
                {
                    resultTB.AppendText($"x = {p.x:F4}\ny = {p.y:F4}\n\n");
                    Func3Chart.Series[0].Points.AddXY(p.x, p.y);
                }
            }
            else
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            x0EnterTB.Text = "";
            xkEnterTB.Text = "";
            dxEnterTB.Text = "";
            dEnterTB.Text = "";
            resultTB.Text = "";

            Func3Chart.Series[0].Points.Clear();
        }
    }
}
