using Štoparica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Štoparica.ViewModel
{
    class StoparicaViewModel : INotifyPropertyChanged
    {
        //za obveščanje viewva o spremembah
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string imeL)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(imeL));
        }

        //spremenjlivke
        ModelStoparice _stModel = new ModelStoparice();
        public int Ure
        {
            get
            {
                return _stModel.PretečeniČas.HasValue ?
                    _stModel.PretečeniČas.Value.Hours : 0;
            }
        }
        public int Minute
        {
            get
            {
                return _stModel.PretečeniČas.HasValue ?
                    _stModel.PretečeniČas.Value.Minutes : 0;
            }
        }
        public decimal Sekunde
        {
            get
            {
                if (_stModel.PretečeniČas.HasValue)
                    return (decimal)_stModel.PretečeniČas.Value.Seconds + _stModel.PretečeniČas.Value.Milliseconds * 0.001M;
                else
                    return 0.00M;
            }
        }
        private DispatcherTimer _timer = new DispatcherTimer();
        public StoparicaViewModel()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        public bool Teče { get { return _stModel.Teče; } }
        int _zadnjaUra;
        int _zadnjaMinuta;
        decimal _zadnjaSekunda;
        bool _zadnjičTeče;

        private void _timer_Tick(object sender, object e)
        {
            if (_zadnjičTeče != Teče)
            {
                _zadnjičTeče = Teče;
                OnPropertyChanged("Teče");
            }
            if(_zadnjaUra != Ure)
            {
                _zadnjaUra = Ure;
                OnPropertyChanged("Ure");
            }
            
            if (_zadnjaMinuta != Minute)
            {
                _zadnjaMinuta = Minute;
                OnPropertyChanged("Minute");
            }
            if (_zadnjaSekunda != Sekunde)
            {
                _zadnjaSekunda = Sekunde;
                OnPropertyChanged("Sekunde");
            }
        }
        public void Start()
        {
            _stModel.Start();
        }
        public void Stop()
        {
            _stModel.Stop();
        }
        public void Reset()
        {
            bool teče = Teče;
            _stModel.Reset();
            if (teče)
                _stModel.Start();
        }
    }
}
