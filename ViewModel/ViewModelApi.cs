using System;
using Model;

namespace ViewModel
{
    public abstract class ViewModelApi
    {
        public static ViewModelApi CreateLayer(ModelApi Mapi = default(ModelApi))
        {
            return new ViewModel(Mapi == null ? ModelApi.CreateLayer() : Mapi);
        }

        // implementacja Api
        private class ViewModel : ViewModelApi
        {
            private readonly ModelApi _model;

            public ViewModel(ModelApi MApi)
            {
                _model = MApi;
            }
        }
    }
}
