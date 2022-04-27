using System;
using Logic;

namespace Model
{
    public  abstract class ModelApi
    {

        public static ModelApi CreateLayer(Logic.LogicApi Lapi = default(LogicApi))
        {
            return new Model(Lapi == null ? LogicApi.CreateLayer() : Lapi);
        }



        // implementacja Api
        private class Model : ModelApi
        {
            private readonly LogicApi logapi;
            public Model(LogicApi logika)
            {
                logapi = logika;
            }



        }
    }
}
