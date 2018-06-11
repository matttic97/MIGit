using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinPsi
{
    class Klic
    {
        public static async Task PopulatePsi(ObservableCollection<Slika> poti)
        {
            string url = "https://dog.ceo/api/breed/bullterrier/staffordshire/images";
            Odgovor p = new Odgovor();
            using (var klient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage sp = await klient.GetAsync(url);
                    if (sp.IsSuccessStatusCode)
                    {
                        var x = await sp.Content.ReadAsStringAsync();
                        p = JsonConvert.DeserializeObject<Odgovor>(x);
                    }
                    else
                        p.message = new string[] { "Napaka" };
                }
                catch(Exception z)
                {
                    p.message = new string[] { z.Message };
                }
                
            }
            foreach (string x in p.message)
            {
                Slika s = new Slika();
                s.Pot = x;
                poti.Add(s);
            }
        }
    }
}
