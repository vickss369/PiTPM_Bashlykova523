using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FuncTests
{
    [TestClass]
    public class FuncUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int res = 2 + 2;
            Assert.AreEqual(res, 4);
            Assert.AreNotEqual(res, 5);
            Assert.IsFalse(res > 5);
            Assert.IsTrue(res < 5);
        }
    }
}
