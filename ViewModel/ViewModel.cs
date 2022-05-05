using System;
using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Logic;

namespace ViewModel
{
    //public abstract class ViewModelApi // : INotifyPropertyChanged
    //{
    //    public static ViewModelApi CreateLayer(ModelApi Mapi = default(ModelApi))
    //    {
    //        return new ViewModel(Mapi == null ? ModelApi.CreateLayer() : Mapi);
    //    }

    //    // implementacja Api
    //    private class ViewModel : ViewModelApi
    //    {
    //        private readonly ModelApi model;

    //        public ViewModel(ModelApi MApi)
    //        {
    //            model = MApi;
    //        }
    //    }
    //}
    public class MainViewModel : ViewModelBase
    {
        //public ICommand ExiStopButtonClick { get; set; }
        public ICommand StartButtonClick { get; set; }
        public MainViewModel() : this(ModelApi.CreateLayer()) { }
        public MainViewModel(ModelApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            StartButtonClick = new RelayCommand(() => ClickHandler());
            Balls = new ObservableCollection<Ball>();
        }

        //liczba kulek
        public string InputNum
        {  
            set
            {
                number = value;
                RaisePropertyChanged(nameof(number));
            }
            get => number;
        }

        public int InputBox()
        {
            int count;
            if (Int32.TryParse(InputNum, out count))
            {
                count = Int32.Parse(InputNum);
                return count;
            }
            return 0;
        }


        private void ClickHandler()
        {
            //doing something usefull
            ModelLayer.addBalls(InputBox());
            ModelLayer.StartMoving();
            //dodac zmiane pozycji

        }
        private ModelApi ModelLayer;
        private string number;
        public ObservableCollection<Ball> Balls;

    }




}
