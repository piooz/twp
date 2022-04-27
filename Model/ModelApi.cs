using System;
using System.Collections.Generic;
using Logic;

namespace Model
{
    public  abstract class ModelApi
    {
        private LogicApi logic;
        public static ModelApi CreateLayer(Logic.LogicApi Lapi = default(LogicApi))
        {
            return new Model(Lapi == null ? LogicApi.CreateLayer() : Lapi);
        }
        
        public abstract void StartMoving();
        public abstract void StopMoving();

        public abstract List<Ball> getBalls();
        public abstract int getBoardSize();

        
        // implementacja Api
        private class Model : ModelApi
        {

            public Model(LogicApi logika)
            {
                logic = logika;
            }

            override public void StartMoving()
            {
                logic.StartMovingBalls();
            }

            public override void StopMoving()
            {
                logic.StopMovingBalls();
            }

            override public List<Ball> getBalls()
            {
                return logic.BallCollenction();
            }
            override public int getBoardSize()
            {
                return logic.BoardSize();
            }
        }
    }
}
