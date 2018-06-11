using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pesić
{
    class Klic
    {
        public static async Task PopulatePsi(ObservableCollection<Slika> poti)
        {
            string url = "https://dog.ceo/api/breed/bullterrier/staffordshire/images";
            Odgovor p = new Odgovor();
            using (var klient = new HttpClient())
            {
                HttpResponseMessage sp = await klient.GetAsync(url);
                p = await sp.Content.ReadAsAsync<Odgovor>();
            }
            int k = 0;
            foreach (string x in p.message)
            {
                Slika s = new Slika();
                s.Pot = x;
                poti.Add(s);
            }
        }
    }
}
