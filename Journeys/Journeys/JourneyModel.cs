using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Journeys
{

    //public class Rootobject
    //{
    //    public JourneyModel[] Property1 { get; set; }
    //}

    public class JourneyModel
    {
        public int id { get; set; }
        public VehicleModel vehicle { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public DateTime departure { get; set; }
        public int? capacity { get; set; }
        public string pictureUrl { get; set; }

        public JourneyModel(int id, VehicleModel vehicle, string country, string description, DateTime departure, int? capacity, string pictureUrl)
        {
            this.id = id;
            this.vehicle = vehicle;
            this.country = country;
            this.description = description;
            this.departure = departure;
            this.capacity = capacity;
            this.pictureUrl = pictureUrl;
        }

        public static List<JourneyModel>? LoadFromJson(string fileName)
        {
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string jsonString = sr.ReadToEnd();
                List<JourneyModel>? journeys = JsonSerializer.Deserialize<List<JourneyModel>>(jsonString);
                return journeys;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"A fájlt betöltése sikertelen!\n{ex}");
            }
            return null;
        }

    }

    

}
