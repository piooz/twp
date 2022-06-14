using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace TestData
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod3()
        {

            DataApi dataLayer = DataApi.Create();

            dataLayer.CreateBoard(1000, 800, 3, 3);

            Board board = dataLayer.GetBoard();
            List<IBall> balls = board.GetBalls();

            Assert.AreEqual(board.Height, 1000);
            Assert.AreEqual(board.Width, 800);
            Assert.AreEqual(balls.Count, 3);

            foreach (Ball ball in balls)
            {
                Assert.AreEqual(ball.R, 3);
            }

        }

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