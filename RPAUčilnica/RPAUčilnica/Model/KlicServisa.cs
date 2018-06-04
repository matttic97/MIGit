using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RPAUčilnica.Model
{
    class KlicServisa
    {
        private const string začetekPoti = "https://eucilnica.scng.si/webservice/rest/server.php?wstoken=10ee27a3802957bcb49252cfda803d81&wsfunction=";
        private const string konecPoti = "&courseid=133&moodlewsrestformat=json";
        private const string funkcija = "core_course_get_contents";

        public static async Task PopulatePoglavja(ObservableCollection<Poglavja> poglavja)
        {
            string url = začetekPoti + funkcija + konecPoti;
            List<Poglavja> vsa = new List<Poglavja>();
            using(var klient = new HttpClient())
            {
                HttpResponseMessage sp = await klient.GetAsync(url);
                vsa = await sp.Content.ReadAsAsync<List<Poglavja>>();
            }
            foreach(var x in vsa)
            {
                poglavja.Add(x);
            }
        }
    }
}
