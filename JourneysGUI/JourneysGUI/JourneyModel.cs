using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JourneysGUI
{

    //public class Rootobject
    //{
    //    public JourneyModel[] Property1 { get; set; }
    //}

    public class JourneyModel
    {
        public int id { get; set; }
        public int vehicleid { get; set; }
        public VehicleModel vehicle { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public DateTime departure { get; set; }
        public int? capacity { get; set; }

    }

    

}
