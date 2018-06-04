using ŠKL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ŠKL.ViewModel
{
    class LigaViewModel
    {
        public EkipaViewModel EkipaJimmy { get; set; }
        public EkipaViewModel EkipaJanez { get; set; }
        public LigaViewModel()
        {
            Ekipa janez = new Ekipa("Bomberji", DobiBomberje());
            EkipaJanez = new EkipaViewModel(janez);
            Ekipa jimmy = new Ekipa("Fantastični", DobiFantastične());
            EkipaJimmy = new EkipaViewModel(jimmy);
        }

        private IEnumerable<Igralec> DobiFantastične()
        {
            List<Igralec> x = new List<Igralec>()
            {
                new Igralec("Brian", 31, true),
                new Igralec("Šperko", 26, true),
                new Igralec("CroMane", 7, true),
                new Igralec("TomažVlakec", 18, true),
                new Igralec("JohnSeena", 77, true),
                new Igralec("Weed", 12, false),
                new Igralec("Gorane", 55, false)
            };
            return x;
        }

        private IEnumerable<Igralec> DobiBomberje()
        {
            List<Igralec> x = new List<Igralec>()
            {
                new Igralec("Adrian", 11, true),
                new Igralec("Zeki", 9, true),
                new Igralec("Pero", 41, true),
                new Igralec("Milane", 4, true),
                new Igralec("Katajajaja", 23, true),
                new Igralec("Šljivović", 19, false),
                new Igralec("Bakala", 1, false)
            };
            return x;
        }
    }
}
