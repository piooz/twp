using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace TestData
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Ball ball = new Ball(1, 2.3, 3.6, 4.1);

            Assert.AreEqual(ball.GetX(), 1);
            Assert.AreEqual(ball.GetY(), 2.3);
            Assert.AreEqual(ball.GetR(), 3.6);
            Assert.AreEqual(ball.GetMass(), 4.1);

            ball.SetX(10);
            ball.SetY(10);
            ball.SetR(2);
            ball.SetMass(2.2);

            Assert.AreEqual(ball.GetX(), 10);
            Assert.AreEqual(ball.GetY(), 10);
            Assert.AreEqual(ball.GetR(), 2);
            Assert.AreEqual(ball.GetMass(), 2.2);

            ball.Move();

            Assert.IsTrue(ball.X == 10 + ball.GetVelX());
            Assert.IsTrue(ball.Y == 10 + ball.GetVelY());


        }
    }
}