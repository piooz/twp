using System;
using System.Collections.Generic;
using Logic;

namespace Model
{
    public  abstract class ModelApi
    {
        private logic logic;
        public static ModelApi CreateLayer(Logic.logic Lapi = default(logic))
        {
            return new Model(Lapi == null ? logic.CreateLayer() : Lapi);
        }
        
        public abstract void StartMoving();
        public abstract void StopMoving();

        //public abstract void Start();
        public abstract List<Ball> getBalls();
        public abstract int getBoardSize();
        public abstract void addBalls(int count);

        // implementacja Api
        private class Model : ModelApi
        {

            public Model(logic logika)
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
                return logic.BallCollection();
            }
            override public int getBoardSize()
            {
                return logic.BoardSize();
            }

            public override void addBalls(int count)
            {
                logic.AddBalls(count);
                
            }



        }
    }
}
