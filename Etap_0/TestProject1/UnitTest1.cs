using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Etap_0.Calculator x = new Etap_0.Calculator();
            int y = x.Multiplication(4, 1);
            Assert.AreEqual(4, y);
        }
    }
}