using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ŠKL.Model
{
    public class Igralec
    {
        public string Ime { get; set; }
        public int Stevilka { get; set; }
        public bool Starter { get; set; }

        public Igralec(string i, int š, bool s)
        {
            Ime = i;
            Stevilka = š;
            Starter = s;
        }
    }
}
