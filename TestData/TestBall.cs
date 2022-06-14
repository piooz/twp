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
            Ball ball = new Ball(1, 2.3, 3.6, 4.1,1);

            Assert.AreEqual(ball.X, 1);
            Assert.AreEqual(ball.Y, 2.3);
            Assert.AreEqual(ball.R, 3.6);
            Assert.AreEqual(ball.mass, 4.1);

            ball.X = (10);
            ball.Y = (10);
            ball.R = (2);
            ball.mass = (2.2);

            Assert.AreEqual(ball.X, 10);
            Assert.AreEqual(ball.Y, 10);
            Assert.AreEqual(ball.R, 2);
            Assert.AreEqual(ball.mass, 2.2);

            ball.Move();

            Assert.IsTrue(ball.X == 10 + ball.VelX);
            Assert.IsTrue(ball.Y == 10 + ball.VelY);


        }
    }
}