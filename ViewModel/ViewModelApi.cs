using System;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    public abstract class ViewModelApi // : INotifyPropertyChanged
    {
        public static ViewModelApi CreateLayer(ModelApi Mapi = default(ModelApi))
        {
            return new ViewModel(Mapi == null ? ModelApi.CreateLayer() : Mapi);
        }






        // implementacja Api
        private class ViewModel : ViewModelApi 
        {
            private readonly ModelApi model;

            public ViewModel(ModelApi MApi)
            {
                model = MApi;
            }


        }
    }
}
