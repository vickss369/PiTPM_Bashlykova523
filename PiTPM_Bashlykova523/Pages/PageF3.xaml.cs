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

        private void countBtn_Click(object sender, RoutedEventArgs e)
        {
            double x0 = Convert.ToDouble(x0EnterTB.Text.Replace(" ", ""));
            double xk = Convert.ToDouble(xkEnterTB.Text.Replace(" ", ""));
            double dx = Convert.ToDouble(dxEnterTB.Text.Replace(" ", ""));
            double d = Convert.ToDouble(dEnterTB.Text.Replace(" ", ""));

            if (x0 >= xk)
            {
                MessageBox.Show("Начало отрезка должно быть меньше конца отрезка!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                x0EnterTB.Focus();
                x0EnterTB.SelectAll();
                return;
            }

            if (dx == 0)
            {
                MessageBox.Show("Шаг приращения не должен быть равен нулю!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                dxEnterTB.Focus();
                dxEnterTB.SelectAll();
                return;
            }

            if (Math.Abs(dx) > Math.Abs(xk - x0))
            {
                MessageBox.Show("Шаг приращения не должен превышать длину заданного интервала!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                dxEnterTB.Focus();
                dxEnterTB.SelectAll();
                return;
            }

            double pointCount = Math.Abs((xk - x0) / dx) + 1;
            if (pointCount > 10000)
            {
                var result = MessageBox.Show(
                    $"Количество точек для построения графика очень большое ({pointCount:F0}). Это может привести к зависанию программыл.\nПродолжить?",
                    "Предупреждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                    return;
            }

            resultTB.Text = "";
            Func3Chart.Series[0].Points.Clear();

            for (double xi = x0; xi <= xk; xi += dx)
            {
                if (xi == 0)
                {
                    MessageBox.Show("При x = 0 происходит деление на ноль. Построение остановлено.", "Ошибка вычисления", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double yi = Math.Pow(xi, 2) + Math.Tan(5 * xi + d / xi);

                resultTB.AppendText($"x = {xi:F4}\ny = {yi:F4}\n\n");
                Func3Chart.Series[0].Points.AddXY(xi, yi);
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
