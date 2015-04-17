using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_GPS
{
    class Location
    {
        public string System = "";
        public string Station = "";
        public bool Buy = false;
        public string BuyCommodityName = "";
        public int BuyCommodityAmount = 0;
        public bool Sell = false;
        public string SellCommodityName = "";
        public int SellCommodityAmount = 0;

        public string Display
        {
            get
            {
                string result = System;
                if(Station != "")
                {
                    result += " (" + Station + ")";
                }

                return result;
            }
        }
    }
}