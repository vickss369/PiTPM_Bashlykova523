using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiTPM_Bashlykova523.Classes
{
    /// <summary>
    /// Класс дешифрования текста методом Виженера.
    /// Поддерживает русский (33 буквы с Ё) и английский алфавиты, сохраняет регистр букв и специальные символы.
    /// </summary>
    public class VigenereCipherDecrypt
    {
        private const string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Расшифровывает текст, зашифрованный методом Виженера.
        /// </summary>
        /// <param name="cipher">Зашифрованный текст.</param>
        /// <param name="key">Ключ, использованный при шифровании.</param>
        /// <returns>Исходный расшифрованный текст. Регистр исходных букв сохраняется, 
        /// специальные символы (пробелы, знаки препинания) остаются без изменений и не влияют на сдвиги.</returns>
        public string DecryptVigenere(string cipher, string key)
        {
            if (string.IsNullOrWhiteSpace(cipher) || string.IsNullOrWhiteSpace(key))
                return "Ошибка: текст или ключ не должны быть пустыми";

            string result = "";
            key = key.ToUpper();
            int keyIndex = 0;

            foreach (char symbol in cipher)
            {
                if (char.IsLetter(symbol))
                {
                    string alphabet = RussianAlphabet.Contains(char.ToUpper(symbol))
                        ? RussianAlphabet : EnglishAlphabet;

                    char upperSymbol = char.ToUpper(symbol);
                    int cipherPos = alphabet.IndexOf(upperSymbol);

                    char keyChar = key[keyIndex % key.Length];
                    int keyPos = alphabet.IndexOf(keyChar);

                    if (cipherPos == -1 || keyPos == -1) result += symbol;
                    
                    else
                    {
                        int newPos = (cipherPos - keyPos + alphabet.Length) % alphabet.Length;
                        char decrypted = alphabet[newPos];

                        result += char.IsUpper(symbol) ? decrypted : char.ToLower(decrypted);
                        keyIndex++;
                    }
                }

                else result += symbol;
            }

            return result;
        }
    }
}
