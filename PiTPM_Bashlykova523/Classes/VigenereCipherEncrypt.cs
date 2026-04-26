using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiTPM_Bashlykova523.Classes
{
    /// <summary>
    /// Класс шифрования текста методом Виженера.
    /// Поддерживает русский (33 буквы с Ё) и английский алфавиты, сохраняет регистр букв и специальные символы.
    /// </summary>
    public class VigenereCipherEncrypt
    {
        private const string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Шифрует текст с помощью шифра Виженера.
        /// </summary>
        /// <param name="text">Текст, который нужно зашифровать.</param>
        /// <param name="key">Ключ шифрования.</param>
        /// <returns>Зашифрованный текст. Регистр исходных букв сохраняется, 
        /// специальные символы (пробелы, знаки препинания) остаются без изменений и не влияют на сдвиги.</returns>
        public string EncryptVigenere(string text, string key)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(key))
                return "Ошибка: текст или ключ не должны быть пустыми";

            string result = "";
            key = key.ToUpper();
            int keyIndex = 0;

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    string alphabet = RussianAlphabet.Contains(char.ToUpper(symbol))
                        ? RussianAlphabet : EnglishAlphabet;

                    char upperSymbol = char.ToUpper(symbol);
                    int textPos = alphabet.IndexOf(upperSymbol);

                    char keyChar = key[keyIndex % key.Length];
                    int keyPos = alphabet.IndexOf(keyChar);

                    if (textPos == -1 || keyPos == -1) result += symbol;

                    else
                    {
                        int newPos = (textPos + keyPos) % alphabet.Length;
                        char encrypted = alphabet[newPos];

                        result += char.IsUpper(symbol) ? encrypted : char.ToLower(encrypted);
                        keyIndex++;
                    }
                }

                else result += symbol;
            }

            return result;
        }
    }
}