using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinPsi
{
	public partial class MainPage : ContentPage
	{
        ObservableCollection<Slika> VsiPsi;

        public MainPage()
        {
            this.InitializeComponent();
            VsiPsi = new ObservableCollection<Slika>();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Klic.PopulatePsi(VsiPsi);
            glavniView.ItemsSource = VsiPsi;
        }
    }
}
