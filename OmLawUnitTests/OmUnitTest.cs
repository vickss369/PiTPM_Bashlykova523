using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiTPM_Bashlykova523;
using System;

namespace OmLawUnitTests
{
    [TestClass]
    public class OmUnitTest
    {
        [TestMethod]
        public void Test_Om_AllCalculations_Correct()
        {
            var page = new OmPage();

            bool ans1 = page.CalculateValue(10, 5, "Сила тока", out double a1, out string e1);
            bool ans2 = page.CalculateValue(2, 5, "Напряжение", out double a2, out string e2);
            bool ans3 = page.CalculateValue(10, 2, "Сопротивление", out double a3, out string e3);

            Assert.IsTrue(ans1);
            Assert.AreEqual(2, a1, 0.0001);

            Assert.IsTrue(ans2);
            Assert.AreEqual(10, a2, 0.0001);

            Assert.IsTrue(ans3);
            Assert.AreEqual(5, a3, 0.0001);
        }

        [TestMethod]
        public void Test_Om_Errors_ShouldReturnMessages()
        {
            var page = new OmPage();

            bool ans1 = page.CalculateValue(10, 0, "Сила тока", out double a1, out string e1);
            bool ans2 = page.CalculateValue(10, 5, "", out double a2, out string e2);
            bool ans3 = page.CalculateValue(10, 5, "123", out double a3, out string e3);

            Assert.IsFalse(ans1);
            StringAssert.Contains(e1, "Деление");

            Assert.IsFalse(ans2);
            StringAssert.Contains(e2, "Выберите");

            Assert.IsFalse(ans3);
            StringAssert.Contains(e3, "Неизвестная");
        }

        [TestMethod]
        public void Test_Om_WrongExpected_ShouldFail()
        {
            var page = new OmPage();

            bool ans = page.CalculateValue(10, 5, "Сила тока", out double answer, out string error);

            double wrongExpected = 2.5;

            Assert.IsTrue(ans);
            Assert.AreEqual(wrongExpected, answer, 0.0001);
        }
    }
}
