using Assignment_2.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Assignment_2
{
    internal class Program
    {
        static List<Assignment_2.Models.Coin> coins;
        private static Stream jsonArray;


        static void Main(string[] args)
        {

       
            List<Coin> coins = new List<Coin>();
            List<Trader> traders = new List<Trader>();
            var reader = new StreamReader(@" C: \Users\Admin\Source\Repos\KDU - Dotnet - Backend\Assignment - 2\Files\coins.csv");
            var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            coins = csv.GetRecords<Coin>()
                       .ToList();

            var reader1 = new StreamReader(@" C: \Users\Admin\Source\Repos\KDU - Dotnet - Backend\Assignment - 2\Files\coins.csv");
            var csv1 = new CsvHelper.CsvReader(reader1, CultureInfo.InvariantCulture);
            traders = csv1.GetRecords<Trader>()
                          .ToList();

        

         

            
            Console.WriteLine("1. Given the name or code of a coin, retrieve all its details");
            Console.WriteLine("2. Display top 50 coins in the market based on price.");
            Console.WriteLine("3. For a given trader, show his portfolio.");
            Console.WriteLine("4. For a given trader, display the total profit or loss they have made trading in the crypto market.");
            Console.WriteLine("Show top 5 and bottom 5 traders based on their profit/loss.");
                
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {


                case 1:
                    SearchCoins();
                    break;

                case 2:
                    DisplayTop50();
                    break;

                case 3:
                    DisplayPortfolio();
                    break;
               
                case 4:
                    DisplayProfitLoss();
                    break;
                case 4:
                    DisplayTopN();
                    break;

                default:
                    Console.WriteLine("Invalid Input");
                    break;

            }
        }

        

        static void RetriveCoinsDetails()
        {
            Console.WriteLine("Enter Name of Coin");
            string coinName = Console.ReadLine();

            foreach(var coin in coinsList)
            {
                if (coin.Name == coinName)
                {
                    Console.WriteLine(coin.Name + " " + coin.Symbol + " " + coin.Price + " " + coin.CirculatingSupply);
                }
            }
        }

        static void Top50Coins()
        {
            var top50CoinsList = coinsList.OrderByDescending(c => c.Price).Take(50);

            foreach (var coin in top50CoinsList)
            {
                Console.WriteLine(coin.Name + " "+ coin.Price);
            }
        }

        static void TraderPortfolio()
        {
            Console.WriteLine("Enter Name of Coin");
            string traderName = Console.ReadLine();

            Console.WriteLine(traderName);


            Dictionary<string, List<string>> traderPortfolio = new Dictionary<string, List<string>>();




        }

    }
}