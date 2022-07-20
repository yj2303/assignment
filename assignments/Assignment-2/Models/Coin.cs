using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class Coin
    {
           [Name("Rank")]
        public int Rank { get; set; }
        [Name("Name")]
        public string Name { get; set; }
        [Name("Symbol")]
        public string Symbol { get; set; }
        [Name("Price")]
        public double Price { get; set; }
        [Name("CirculatingSupply")]
        public long CirculatingSupply { get; set; }



         public static Coin GetCoinsData(string csvLine)
         {
             string[] values = csvLine.Split(',');
             Coin coinsData = new Coin();

             coinsData.Rank = Convert.ToInt32(values[1]);
             coinsData.Name = values[2];
             coinsData.Symbol = values[3];
             coinsData.Price = Convert.ToDouble(values[4]);
             coinsData.CirculatingSupply = Convert.ToInt64(values[5]);

             return coinsData;
         }

     
    }
}
