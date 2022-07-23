using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    

    public class Root
    {
        public string type { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        [Name("coin")]
        public string coin { get; set; }
        [Name("quantity")]
        public int quantity { get; set; }
        [Name("wallet_address")]
        public string wallet_address { get; set; }
        [Name("price")]
        public double price { get; set; }
        [Name("volume")]
        public int volume { get; set; }
    }


}
