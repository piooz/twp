using System;
using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private ModelApi MyModel { get; set; }

        private int _numberOfBalls;
        private int _height = 600;
        private int _width = 900;
        private string _startButton;
        private bool _enabled = true;

        public MainViewModel()
        {
            MyModel = ModelApi.CreateLayer();
            Start = new RelayCommand(() => start());
            Stop = new RelayCommand(() => stop());
            _numberOfBalls = 7;
            _startButton = "Start";
        }

        public string StartButton
        {
            get => _startButton;
            set
            {
                _startButton = value;
                RaisePropertyChanged("StartButton");
            }

        }

        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                RaisePropertyChanged("Width");
            }

        }


        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                RaisePropertyChanged("Height");
            }
        }

        public ObservableCollection<ElipseModel> Ellip
        {
            get => MyModel.Ellipses;
            set => MyModel.Ellipses = value;
        }

        public string NumberOfBalls
        {
            get => _numberOfBalls.ToString();
            set
            {
                if (int.TryParse(value, out int n) && n != 0)
                    _numberOfBalls = Math.Abs(n);
                RaisePropertyChanged(nameof(NumberOfBalls));
            }
        }

        public bool StartEnabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                RaisePropertyChanged(nameof(StartEnabled));
            }
        }

        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }

        private void start()
        {
            MyModel.GenerateBallsRepresentative(Height, Width, _numberOfBalls, 30);
            StartButton = "Restart";
            StartEnabled = false;

        }

        private void stop()
        {
            MyModel.StopSimulation();
            StartEnabled = true;
        }



    }

}
