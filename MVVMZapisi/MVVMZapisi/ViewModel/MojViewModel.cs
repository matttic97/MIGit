using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace MVVMZapisi
{
    class MojViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string imeLastnosti = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(imeLastnosti));
            }
        }

        public ObservableCollection<MojZapis> Zapis { get; set; }

        private MojZapis trenutni;
        public MojZapis Trenutni
        {
            get { return trenutni; }
            set { trenutni = value;
                OnPropertyChanged();
                NarediZelenoUkaz.RaiseCanExecuteChanged();
            }
        }

        public string Naslov { get; set; }
        public DelegateCommand NarediZelenoUkaz { get; set; }

        public MojViewModel()
        {
            Zapis = new ObservableCollection<MojZapis>();
            for(int i = 1; i <= 10; i++)
            {
                Zapis.Add(new MojZapis { Ime = i.ToString(), Barva = Colors.Orange });
            }
            trenutni = Zapis.First();
            Naslov = "Moji zapisi";
            NarediZelenoUkaz = new DelegateCommand(
                (p) => { Trenutni.Barva = Colors.Green; },
                (p) => { return Trenutni != null; }
                );
        }
    }
}
