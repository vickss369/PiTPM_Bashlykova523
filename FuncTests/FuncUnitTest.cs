using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PiTPM_Bashlykova523.Pages;

namespace FuncTests
{
    [TestClass]
    public class FuncUnitTest
    {
        /*[TestMethod]
        public void TestMethod1()
        {
            int res = 2 + 2;
            Assert.AreEqual(res, 4);
            Assert.AreNotEqual(res, 5);
            Assert.IsFalse(res > 5);
            Assert.IsTrue(res < 5);
        }*/

        [TestMethod]
        public void TestFunc1_Value1() 
        {
            var pF1 = new PageF1();

            bool ans = pF1.CalculateF1(1, 1, 0, out double answer, out string error);

            Assert.IsTrue(ans);
            Assert.AreEqual(0, answer, 0.0001);
        }

        [TestMethod]
        public void TestFunc1_Value2()
        {
            var pF1 = new PageF1();

            bool ans = pF1.CalculateF1(4, 1, 0.5, out double answer, out string error);

            Assert.AreEqual(answer, -69);
            Assert.IsFalse(answer < 0);
        }

        [TestMethod]
        public void TestFunc1_InvalidZ_ShouldShowMessage()
        {
            var page = new PageF1();

            bool res = page.CalculateF1(1, 1, 2, out double result, out string error);

            Assert.IsFalse(res);
            Assert.AreEqual("Арксинус определён только для значений от -1 до 1!", error);
        }
    }
}
