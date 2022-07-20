using Assignment_2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.OperationEntities
{
    internal class UpdatePrice
    {
        private const int V = 0;
        static List<Assignment_2.Models.Coin> coins;
        // private static Stream jsonArray;
        static List<Assignment_2.Models.Trader> traders;

        static List<Assignment_2.Models.Transaction> transactions;

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Admin\Source\Repos\KDU-Dotnet-Backend\Assignment-2\Files\test_transaction.json"))
            {
                string json = r.ReadToEnd();
                List<Transaction> transactions = JsonConvert.DeserializeObject<List<Transaction>>(json);
            }
        }

        public List<traderData> UpdatePortfolio(int current_price, string name, string wallet_address, List<traderData> traderdata)
        {
            foreach (var trader in traderdata)
            {
                if (trader.name_of_coin == name)
                {
                    trader.current_price = current_price;
                }
            }
            return traderdata;
        }
     
    }
}
