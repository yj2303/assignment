
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    internal class Traders
    {
      
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone { get; set; }
        public string Wallet_Address { get; set; }

        public List<TradersCoins>? tradersCoins { get; set; }





     

        public static Traders GetTradersData(string csvLine)
        {
            string[] values = csvLine.Split(',');
            var tradersData = new Traders();

            tradersData.first_name = values[1];
            tradersData.last_name = values[2];
            tradersData.phone = values[3];
            tradersData.Wallet_Address = values[4];
            tradersData.tradersCoins = new List<TradersCoins>();

            return tradersData;
        }
    }
}
