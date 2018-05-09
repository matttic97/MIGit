using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Pozeni().Wait();
            Console.ReadLine();
        }

        private static async Task Pozeni()
        {
            using(HttpClient klient = new HttpClient())
            {
                klient.BaseAddress = new Uri("http://localhost:30714/");
                klient.DefaultRequestHeaders.Accept.Clear();
                klient.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage odgovor = await klient.GetAsync("api/Produkt");
                if (odgovor.IsSuccessStatusCode)
                {
                    List<Produkt> p = await odgovor.Content.ReadAsAsync<List<Produkt>>();
                    foreach(Produkt pr in p)
                    {
                        Console.WriteLine("Produkt " + pr.Id + " " + pr.Ime + " " + pr.Kategorija + " " + pr.Cena);
                    }
                }
            }
        }
    }
}
