using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace TestData
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {

            Board board = new Board(1000, 800);
            Ball ball = new Ball(10, 20, 10, 10);
            Ball ball2 = new Ball(200, 200, 8.4, 9.2);

            Assert.AreEqual(1000, board.Height);
            Assert.AreEqual(800, board.Width);

            Assert.ThrowsException<System.ArgumentException>(() => new Board(-100, 200));
            Assert.ThrowsException<System.ArgumentException>(() => new Board(100, 0));


            Assert.AreEqual(0, board.GetBalls().Count);

            board.AddBall(ball);
            board.AddBall(ball);

            Assert.AreEqual(2, board.GetBalls().Count);


        }
    }
}