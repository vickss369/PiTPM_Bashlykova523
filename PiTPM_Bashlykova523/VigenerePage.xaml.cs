using PiTPM_Bashlykova523.Classes;
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
    /// Логика взаимодействия для VigenerePage.xaml
    /// </summary>
    public partial class VigenerePage : Page
    {
        private VigenereCipherEncrypt encrypter = new VigenereCipherEncrypt();
        private VigenereCipherDecrypt decrypter = new VigenereCipherDecrypt();

        public VigenerePage()
        {
            InitializeComponent();
        }

        private bool IsInputValid()
        {
            if (string.IsNullOrWhiteSpace(textEnterTB.Text) || string.IsNullOrWhiteSpace(keyEnterTB.Text)) return false;

            return true;
        }
        private string InputError()
        {
            if (string.IsNullOrWhiteSpace(textEnterTB.Text)) return "Текст не должен быть пустым!";
            if (string.IsNullOrWhiteSpace(keyEnterTB.Text)) return "Ключ не должен быть пустым!";

            return "";
        }

        private void EnterTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = char.IsDigit(e.Text[0]);
        }

        private void encryptBtn_Click(object sender, RoutedEventArgs e)
        {
            string text = textEnterTB.Text;
            string key = keyEnterTB.Text;

            if (!IsInputValid())
            {
                MessageBox.Show(InputError(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string result = encrypter.EncryptVigenere(text, key);

            resTextTBl.Text = "Зашифрованный текст:";
            resultTBl.Text = result;
        }

        private void decryptBtn_Click(object sender, RoutedEventArgs e)
        {
            string text = textEnterTB.Text;
            string key = keyEnterTB.Text;

            if (!IsInputValid())
            {
                MessageBox.Show(InputError(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string result = decrypter.DecryptVigenere(text, key);

            resTextTBl.Text = "Расшифрованный текст:";
            resultTBl.Text = result;
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            textEnterTB.Text = "";
            keyEnterTB.Text = "";

            resTextTBl.Text = "текст:";
            resultTBl.Text = "—";
        }
    }
}
