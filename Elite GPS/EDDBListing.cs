using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_GPS
{
    class EDDBListing
    {
        public int id { get; set; }
        public int station_id { get; set; }
        public int commodity_id { get; set; }
        public string supply { get; set; }
        public string buy_price { get; set; }
        public string sell_price { get; set; }
        public string demand { get; set; }
    }
}