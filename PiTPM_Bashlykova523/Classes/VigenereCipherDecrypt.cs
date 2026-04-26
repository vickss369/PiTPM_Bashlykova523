using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiTPM_Bashlykova523.Classes
{
    /// <summary>
    /// Класс дешифрования методом Виженера.
    /// </summary>
    public class VigenereCipherDecrypt
    {
        private const string RussianAlphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string DecryptVigenere(string cipher, string key)
        {
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
