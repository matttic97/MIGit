using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZaKonzolo.Models;

namespace ZaKonzolo.Controllers
{
    public class ProduktController : ApiController
    {
        Produkt[] produkti = new Produkt[]
        {
            new Produkt{Id=1, Ime="Paradižnikova juha", Kategorija="Jedi", Cena=0.89m},
            new Produkt{Id=2, Ime="Bong", Kategorija="Prosti čas", Cena=13.55m},
            new Produkt{Id=3, Ime="deeW", Kategorija="zelenjava", Cena=5}
        };

        public IEnumerable<Produkt> GetProdukt()
        {
            return produkti;
        }

        public Produkt GetProdukt(int id)
        {
            return produkti.Where(a => a.Id == id).FirstOrDefault();
        }

    }
}
