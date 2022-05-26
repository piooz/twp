using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace TestData
{
    [TestClass]
    internal class TestDataApi
    {
        [TestMethod]
        public void TestMethod1()
        {

            DataApi dataLayer = DataApi.Create();

            dataLayer.CreateBoard(1000, 800, 3, 3);

            Board board = dataLayer.GetBoard();
            List<Ball> balls = board.GetBalls();

            Assert.AreEqual(board.Height, 1000);
            Assert.AreEqual(board.Width, 800);
            Assert.AreEqual(balls.Count, 3);

            foreach (Ball ball in balls)
            {
                Assert.AreEqual(ball.GetR(), 3);
            }

        }
    }
}
