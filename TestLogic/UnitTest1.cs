using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;


namespace TestLogic
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void LogicLayerTests()
        {

            logic LogicAPI = logic.CreateLayer();

            LogicAPI.CreateBoard(200, 100, 3, 2);

            Assert.AreEqual(3, LogicAPI.GetBalls().Count);

            foreach (BallConnector ball in LogicAPI.GetBalls())
            {
                Assert.AreEqual(2, ball.R);
            }


        }
    }
}