using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicApi
    {
        
        public static LogicApi CreateLayer(DataApi data = default(DataApi))
        {
            return new BusinessLogic(data == null ? DataApi.Create() : data);
        }
        
        public abstract void StartMovingBalls();
        public abstract void StopMovingBalls();


        private class BusinessLogic : LogicApi
        {
            public  Task positionUpdater { get; private set; }
            public Board map = new Board(300);
            private readonly DataApi DataLayer;
            private bool running;


            public BusinessLogic(DataApi dataLayerAPI)
            {
                DataLayer = dataLayerAPI;
            }

            public override void StartMovingBalls()
            {
                this.running = true;
                positionUpdater = new Task(MoveBallsInLoop);
                positionUpdater.Start();
            }


            private void MoveBallsInLoop()
            {
                while (this.running)
                {
                    map.MoveBalls();
                    Thread.Sleep(10);
                }
            }

            public override void StopMovingBalls()
            {
                this.running = false;
            }

        }

    }
}
