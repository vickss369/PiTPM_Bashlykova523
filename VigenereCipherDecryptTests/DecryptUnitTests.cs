using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PiTPM_Bashlykova523.Classes;

namespace VigenereCipherDecryptTests
{
    
    [TestClass]
    public class DecryptUnitTests
    {
        private readonly VigenereCipherEncrypt text = new VigenereCipherEncrypt();
        private readonly VigenereCipherDecrypt cipher = new VigenereCipherDecrypt();

        [TestMethod]
        public void TC02_RussianDecrypt_ShouldDecryptCorrectly()
        {
            string encrypted = text.EncryptVigenere("ДЕШИФР", "КЛЮЧ");
            string decrypted = cipher.DecryptVigenere(encrypted, "КЛЮЧ");

            Assert.AreEqual("ДЕШИФР", decrypted);
        }

        [TestMethod]
        public void TC05_EmptyKey_ShouldNotReturnValidResult()
        {
            string decrypted = cipher.DecryptVigenere("пусто", " ");
            Assert.AreNotEqual("пусто", decrypted);
        }

        [TestMethod]
        public void TC09_EmptyKey_ShouldReturnErrorMessage()
        {
            string encrypted = text.EncryptVigenere("пусто", " ");
            string decrypted = cipher.DecryptVigenere(encrypted, " ");

            StringAssert.Contains("ключ не", decrypted.ToLower());
        }

        [TestMethod]
        public void TCDecrypt_ShouldPreserveCase()
        {
            string encrypted = text.EncryptVigenere("ДЕШИФР", "КЛЮЧ");
            string result = cipher.DecryptVigenere(encrypted, "КЛЮЧ");

            Assert.AreEqual("ДЕШИФР", result);
            Assert.AreNotEqual("дешифр", result);
        }
    }
}
