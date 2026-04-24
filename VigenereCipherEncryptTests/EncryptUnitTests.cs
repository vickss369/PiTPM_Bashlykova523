using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PiTPM_Bashlykova523.Classes;

namespace VigenereCipherEncryptTests
{
    [TestClass]
    public class EncryptUnitTests
    {
        private readonly VigenereCipherEncrypt cipher = new VigenereCipherEncrypt();

        [TestMethod]
        public void TC01_EnglishEncrypt_ShouldReturnCorrectResult()
        {
            string expectedText = "RIJVS";
            string result = cipher.EncryptVigenere("HELLO", "KEY");

            Assert.AreEqual(expectedText, result);
        }

        [TestMethod]
        public void TC03_WithSpaces_ShouldPreserveSpaces()
        {
            string result = cipher.EncryptVigenere("Поддержка и тестирование программных модулей", "ключ");
            Assert.AreEqual("Щьнрпйщфкз и ьмпьцмьмйп гёьрьзмшёяьз мьзрпшйж", result);
        }

        [TestMethod]
        public void TC04_EmptyText_ShouldReturnErrorMessage()
        {
            string result = cipher.EncryptVigenere(" ", "пусто");
            StringAssert.Contains("текст не", result.ToLower());
        }

        [TestMethod]
        public void TC06_WithPunctuation_ShouldPreserveSymbols()
        {
            string result = cipher.EncryptVigenere("всем привет, меня зовут Вика!)", "вика");

            StringAssert.Contains(",", result);
            StringAssert.Contains("!", result);
            StringAssert.Contains(")", result);
        }

        [TestMethod]
        public void TC07_LongKey_ShouldBeTrimmed()
        {
            var result = cipher.EncryptVigenere("пример", "ключевой");
            Assert.AreEqual("суздмф", result);
        }
    }
}
