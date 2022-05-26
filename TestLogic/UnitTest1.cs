using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Data;

namespace TestLogic
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void LogicLayerTests()
        {
            DataApi dataApi = DataApi.Create();
            logic LogicAPI = logic.CreateLayer(dataApi);

            LogicAPI.CreateBoard(200, 100, 3, 2);

            Assert.AreEqual(3, LogicAPI.GetBalls().Count);

            foreach (BallConnector ball in LogicAPI.GetBalls())
            {
                Assert.AreEqual(2, ball.R);
            }


        }
    }
}