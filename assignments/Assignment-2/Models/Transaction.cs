using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class Transaction
    {
        public string Type { get; set; }
        public Data data { get; set; }

       
    }

    public class Data
    {
        public string coin { get; set; }
        public int quantity { get; set; }
        public string wallet_address { get; set; }
        public double? price { get; set; }
        public int? volume { get; set; }
    }


}
