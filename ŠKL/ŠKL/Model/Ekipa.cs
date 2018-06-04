using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ŠKL.Model
{
    public class Ekipa
    {
        public string ImeEkipe { get; private set; }
        public List<Igralec> Igralci{ get; set; }

        public Ekipa(string i, IEnumerable<Igralec> ig)
        {
            ImeEkipe = i;
            Igralci = new List<Igralec>();
            Igralci.AddRange(ig);
        }
    }
}
