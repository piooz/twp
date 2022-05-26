using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logic;

namespace Model
{
    public abstract class ModelApi
    {
        private logic Logic;
        public static ModelApi CreateLayer(Logic.logic Lapi = default(logic))
        {
            return new Model(Lapi == null ? logic.CreateLayer() : Lapi);
        }

        public abstract void GenerateBallsRepresentative(int height, int width, int numberOfBalls, int radiusOfBalls);
        public abstract void StartSimulation();
        public abstract void StopSimulation();

        public ObservableCollection<ElipseModel> Ellipses
        {
            get => ellipses;
            set => ellipses = value;
        }

        private ObservableCollection<ElipseModel> ellipses = new ObservableCollection<ElipseModel>();

        // implementacja Api
        private class Model : ModelApi
        {
            public Model(logic logika)
            {
                Logic = logika;
            }

            private ObservableCollection<ElipseModel> Elipses = new ObservableCollection<ElipseModel>();


            public override void GenerateBallsRepresentative(int height, int width, int numberOfBalls, int radiusOfBalls)
            {
                Logic.DestroyThreads();
                Logic.CreateBoard(height, width, numberOfBalls, radiusOfBalls);

                ellipses.Clear();

                foreach (BallConnector bc in Logic.GetBalls())
                {
                    ellipses.Add(new ElipseModel(bc));
                }

                StartSimulation();
            }
            public override void StartSimulation()
            {
                Logic.StartMovingBalls();
            }

            public override void StopSimulation()
            {
                Logic.DestroyThreads();
            }

        }
    }
}
