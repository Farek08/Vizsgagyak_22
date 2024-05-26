using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journeys
{
    public static class Solution
    {
        public static List<JourneyModel>? journeys { get; set; }

        public static void LoadJourneys()
        {
            journeys = JourneyModel.LoadFromJson("journeys.json");
        }

        public static string GetJourneysByPlane()
        {
            List<JourneyModel> planes = journeys.Where(x => x.vehicle.type == "repülőgép").OrderBy(x => x.departure).ToList();
            string resultString = "";
            for (int i = 0; i < planes.Count; i++)
            {
                resultString += $"\t{planes[i].country}";
                if (i == 0)
                    resultString += $" - legkorábbi ({planes[0].departure:yyyy.MM.dd})";
                resultString += "\n";
            }
            return resultString;
        }

        public static string GetJourneysByPlaneNoLinq()
        {
            List<JourneyModel> planes = new List<JourneyModel>();
            foreach (var item in journeys)
            {
                if (item.vehicle.type == "repülőgép")
                    planes.Add(item);
            }
            planes.OrderBy(x => x.vehicle.type);
            string resultString = "";
            for (int i = 0; i < planes.Count; i++)
            {
                resultString += $"\t{planes[i].country}";
                if (i == 0)
                    resultString += $" - legkorábbi ({planes[0].departure:yyyy.MM.dd})";
                resultString += "\n";
            }
            return resultString;
        }

        public static string GetJourneysByType()
        {
            string resultString = "";
            Dictionary<string, int> stat = new Dictionary<string, int>();
            foreach (var journey in journeys)
            {
                if (stat.ContainsKey(journey.vehicle.type))
                {
                    stat[journey.vehicle.type]++;
                }
                else
                {
                    stat[journey.vehicle.type] = 1;
                }
            }
            foreach (var item in stat)
            {
                resultString += $"\t{item.Key} : {item.Value} utazás";
                int? capacity = journeys.Where(x => x.vehicle.type == item.Key).Sum(x => x.capacity);
                resultString += capacity == null || capacity == 0 ? ", önálló szervezés" : $", férőhely összesen {capacity} fő\n";
            }
            return resultString;
        }

        public static string GetJourneysByTypeNoLinq()
        {
            string resultString = "";
            Dictionary<string, int> stat = new Dictionary<string, int>();
            foreach (var journey in journeys)
            {
                if (stat.ContainsKey(journey.vehicle.type))
                {
                    stat[journey.vehicle.type]++;
                }
                else
                {
                    stat[journey.vehicle.type] = 1;
                }
            }
            foreach (var item in stat)
            {
                resultString += $"\t{item.Key} : {item.Value} utazás";
                int? capacity = 0;
                foreach (var journey in journeys)
                {
                    if (journey.vehicle.type == item.Key)
                        capacity += journey.capacity;
                }
                resultString += capacity == null || capacity == 0 ? ", önálló szervezés" : $", férőhely összesen {capacity} fő\n";
            }
            return resultString;
        }

    }
}
