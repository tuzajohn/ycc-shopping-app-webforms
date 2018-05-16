using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ycc_test
{
    [TestClass]
    public class BasicTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            new ShoppingLibrary.Processing().ReduceItemUnitQuantity("1", 4);
        }
    }
}
