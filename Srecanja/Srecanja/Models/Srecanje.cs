using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Srecanja.Models
{
    public class Srecanje
    {
        public int Id { get; set; }
        public string Lokacija { get; set; }
        public string Tema { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan Trajanje { get; set; }
        public List<Clan> Prisotni { get; set; }
        public Image Slika { get; set; }
    }
}