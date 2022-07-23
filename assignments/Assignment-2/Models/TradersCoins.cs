using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class TradersCoins
    {
        public string CoinSymbol { get; set; }

        public long  Quantity { get; set; }

        public double Price { get; set; }

        public double CostPrice { get; set; }

        public double SellingPrice { get; set; }

        public string WalletAddress { get; set; }
    }
}
