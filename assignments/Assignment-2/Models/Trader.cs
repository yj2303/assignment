using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{   
    internal class Trader
    {

        List<traderData> traderDetails;
        [Name("first_name")]
        public string first_name { get; set; }
        [Name("last_name")]
        public string last_name { get; set; }
        [Name("phone")]
        public string phone { get; set; }
        [Name("Wallet_Address")]
        public string Wallet_Address { get; set; }
       // [Name("selling_price")]
        //public double selling_price { get; set; }
        //[Name("profit")]
        //public double profit { get; set; }
        //[Name("loss")]
        //public double loss { get; set; }


        public static Trader GetTradersData(string csvLine)
        {
            string[] values = csvLine.Split(',');
            var tradersData = new Trader();

            tradersData.first_name = values[1];
            tradersData.last_name = values[2];
            tradersData.phone = values[3];
            tradersData.Wallet_Address = values[4];

            return tradersData;
        }
    }
}
