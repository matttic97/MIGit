using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAUčilnica.Model
{
    class Podatki
    {
    }

    public class Učilnica
    {
        public List<Poglavja> Poglavje { get; set; }
    }

    public class Poglavja
    {
        public int id { get; set; }
        public string name { get; set; }
        public int visible { get; set; }
        public string summary { get; set; }
        public int summaryformat { get; set; }
        public int section { get; set; }
        public int hiddenbynumsections { get; set; }
        public bool uservisible { get; set; }
        public ObservableCollection<Module> modules { get; set; }
    }

    public class Module
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public int instance { get; set; }
        public int visible { get; set; }
        public bool uservisible { get; set; }
        public int visibleoncoursepage { get; set; }
        public string modicon { get; set; }
        public string modname { get; set; }
        public string modplural { get; set; }
        public int indent { get; set; }
        public Content[] contents { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        public string filename { get; set; }
        public string filepath { get; set; }
        public int filesize { get; set; }
        public string fileurl { get; set; }
        public int? timecreated { get; set; }
        public int timemodified { get; set; }
        public int? sortorder { get; set; }
        public string mimetype { get; set; }
        public bool isexternalfile { get; set; }
        public int? userid { get; set; }
        public object author { get; set; }
        public string license { get; set; }
    }

}
