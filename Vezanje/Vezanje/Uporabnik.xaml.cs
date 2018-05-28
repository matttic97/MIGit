using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Vezanje.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Vezanje
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Uporabnik : Page
    {
        List<Icon> Icons;
        private ObservableCollection<Contact> Contacts = new ObservableCollection<Contact>();

        public Uporabnik()
        {
            this.InitializeComponent();
            Icons = new List<Icon>();
            Icons.Add(new Icon { IconPath = "Assets/male-01.png" });
            Icons.Add(new Icon { IconPath = "Assets/male-02.png" });
            Icons.Add(new Icon { IconPath = "Assets/male-03.png" });
            Icons.Add(new Icon { IconPath = "Assets/female-01.png" });
            Icons.Add(new Icon { IconPath = "Assets/female-02.png" });
            Icons.Add(new Icon { IconPath = "Assets/female-03.png" });
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Contacts.Add(new Contact
            {
                Ime = Ime.Text,
                Priimek = Priimek.Text,
                AvatarPot = ((Icon)Avatar.SelectedValue).IconPath
            });
            Ime.Text = "";
            Priimek.Text = "";
            Avatar.SelectedIndex = -1;
            Ime.Focus(FocusState.Programmatic);
        }
    }
}
