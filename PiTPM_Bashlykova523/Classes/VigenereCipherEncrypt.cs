using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiTPM_Bashlykova523.Classes
{
    /// <summary>
    /// Класс шифрования методом Виженера.
    /// </summary>
    public class VigenereCipherEncrypt
    {
        private const string RussianAlphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string EncryptVigenere(string text, string key)
        {
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
