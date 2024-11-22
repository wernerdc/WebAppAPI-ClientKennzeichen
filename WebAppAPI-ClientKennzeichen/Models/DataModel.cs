using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppAPI_ClientKennzeichen.Models
{
    class DataModel
    {
    //    public Class1[] Property1 { get; set; }
    //}

    //public class Class1
    //{
        public int id { get; set; }
        public string kennzeichen { get; set; }
        public string ort { get; set; }
        public string kreis { get; set; }
        public string bundesland { get; set; }
        public string wappenLink { get; set; }
    }
}
