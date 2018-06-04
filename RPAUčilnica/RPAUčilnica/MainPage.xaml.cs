using RPAUčilnica.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RPAUčilnica
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Poglavja> VsaPoglavja { get; set; }
        public ObservableCollection<Module> Vsebina { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            VsaPoglavja = new ObservableCollection<Poglavja>();
            Vsebina = new ObservableCollection<Module>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await KlicServisa.PopulatePoglavja(VsaPoglavja);
        }

        private void lv_ItemClick(object sender, ItemClickEventArgs e)
        {
            var izbranoP = e.ClickedItem as Poglavja;
            Vsebina = izbranoP.modules;
            lst.ItemsSource = Vsebina;

        }
    }
}
