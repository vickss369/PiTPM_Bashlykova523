using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetStartedDebugging_Letters
{
    internal class Program
    {
        /// <summary>
        /// программа создаёт массив букв, формирует из них имя и вызывает метод SendMessage для каждого шага.
        /// </summary>
        static void Main()
        {
            char[] letters = { 'f', 'r', 'e', 'd', ' ', 's', 'm', 'i', 't', 'h' };
            string name = "";
            int[] a = new int[10];
            for (int i = 0; i < letters.Length; i++)
            {
                name += letters[i];
                a[i] = i + 1;
                SendMessage(name, a[i]);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод выводит приветственное сообщение с именем и числом.
        /// Используется для демонстрации передачи параметров в метод.
        /// </summary>
        /// <param name="name">Имя человека, которое формируется по буквам.</param>
        /// <param name="msg">Число, которое показывает текущий счёт (сколько букв уже добавлено).</param>
        static void SendMessage(string name, int msg)
        {
            Console.WriteLine("Hello, " + name + "! Count to " + msg);
        }
    }
}
