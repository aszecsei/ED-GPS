using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_GPS
{
    class EDDBStation
    {
        public int id { get; set; }
        public string name { get; set; }
        public int system_id { get; set; }
        public string max_landing_pad_size { get; set; }
        public string distance_to_star { get; set; }
        public string faction { get; set; }
        public string government { get; set; }
        public string allegiance { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public string has_blackmarket { get; set; }
        public string has_commodities { get; set; }
        public string has_refuel { get; set; }
        public List<EDDBListing> listings { get; set; }
    }
}
