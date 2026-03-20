using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PiTPM_Bashlykova523.Pages;
using System.Linq;

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
            var pF1 = new PageF1();

            bool ans = pF1.CalculateF1(1, 1, 2, out double answer, out string error);

            Assert.IsFalse(ans);
            Assert.AreEqual("Арксинус определён только для значений от -1 до 1!", error);
        }

        [TestMethod]
        public void TestFunc2_Sh_SqrtBranch_CorrectAns()
        {
            var pF2 = new PageF2();

            double x = 0.5;
            double b = 0.5;

            bool ans = pF2.CalculateF2(x, b, "sh", out double answer, out string error);
            double expected = Math.Sqrt(Math.Abs(Math.Sinh(x) + b));

            Assert.IsTrue(ans);
            Assert.AreEqual(expected, answer, 0.0001);
        }

        [TestMethod]
        public void TestFunc2_2ndBranch_BorderCase_ShouldFail()
        {
            var pF2 = new PageF2();

            double x = 1;
            double b = 0.5;

            bool ans = pF2.CalculateF2(x, b, "x2", out double answer, out string error);
            double wrongExpected = Math.Sqrt(Math.Abs(Math.Pow(x, 2) + b));

            Assert.AreEqual(wrongExpected, answer, 0.0001);
        }

        [TestMethod]
        public void TestFunc2_InvalidFunction_SouldShowMessage()
        {
            var pF2 = new PageF2();

            bool ans = pF2.CalculateF2(1, 1, "бебебе", out double answer, out string error);

            Assert.IsFalse(ans);
            StringAssert.Contains(error, "Неизвестная");
        }

        [TestMethod]
        public void TestFunc2_ShouldFail_ExpectErrorButValid()
        {
            var pF2 = new PageF2();

            bool ans = pF2.CalculateF2(1, 1, "x2", out double answer, out string error);
            if (ans)
            {
                Assert.Fail("Ожидалась ошибка, но вычисление прошло успешно!");
            }
        }

        [TestMethod]
        public void TestFunc3_FractionValues_CorrectResult()
        {
            var pF3 = new PageF3();

            bool res = pF3.CalculateF3(0.5, 1.0, 0.25, 0.3, out var result, out string error);
            Assert.IsTrue(res);
            Assert.AreEqual(3, result.Count);

            double expectedFirstY = Math.Pow(0.5, 2) + Math.Tan(5 * 0.5 + 0.3 / 0.5);
            Assert.AreEqual(expectedFirstY, result[0].y, 0.0001);
        }

        [TestMethod]
        public void TestFunc3_DivisioByZero_ShouldShowMessage()
        {
            var pF3 = new PageF3();

            bool res = pF3.CalculateF3(-1, 1, 0.5, 1, out var result, out string error);
            if (res)
            {
                Assert.IsFalse(result.Any(p => Math.Abs(p.x) < 1e-10),
                    "Ноль должен был вызвать ошибку, но был пропущен!");
            }
            else
            {
                StringAssert.Contains(error, "ноль");
            }
        }

        [TestMethod]
        public void TestFunc3_LastPointIncluded_ShouldFail()
        {
            var pF3 = new PageF3();

            bool res = pF3.CalculateF3(1, 2, 0.3, 1, out var result, out string error);
            Assert.IsTrue(res);

            double lastX = result.Last().x;
            Assert.IsTrue(Math.Abs(lastX - 2) < 0.0001,
                "Последняя точка интервала не достигнута");
        }
    }
}
