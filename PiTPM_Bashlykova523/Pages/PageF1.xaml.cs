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
        }

        private void nextFuncBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageF2());
        }
    }
}
