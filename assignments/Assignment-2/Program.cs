using Assignment_2.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using BenchmarkDotNet.Exporters.Csv;

namespace Assignment_2
{
    internal class Program
    {
        static List<Coin> coins;
        // private static Stream jsonArray;
        static List<Transaction> jsonlist;
        static List<Trader> traders;
        static List<traderData> tradersdata;

        static void Main(string[] args)
        {


            List<Coin> coins = new List<Coin>();
            List<Trader> traders = new List<Trader>();
            //ch
            var reader = new StreamReader(@"C:\Users\Admin\Source\Repos\KDU-Dotnet-Backend\Assignment-2\Files\coins.csv");
            var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
               coins = csv.GetRecords<Coin>().ToList();

               var reader1 = new StreamReader(@"C:\Users\Admin\source\repos\KDU-Dotnet-Backend\Assignment-2\Files\traders.csv");
               var csv1 = new CsvHelper.CsvReader(reader1, CultureInfo.InvariantCulture);
               traders = csv1.GetRecords<Trader>()
                            .ToList();


            string fileName = @"C:\Users\Admin\source\repos\KDU-Dotnet-Backend\Assignment-2\Files\test_transaction.json";
            string jsonString = File.ReadAllText(fileName);
            jsonlist = JsonSerializer.Deserialize<List<Transaction>>(jsonString);



            Console.WriteLine("1. given the name or code of a coin, retrieve all its details");
            Console.WriteLine("2. display top 50 coins in the market based on price.");
            Console.WriteLine("3. for a given trader, show his portfolio.");
            Console.WriteLine("4. for a given trader, display the total profit or loss they have made trading in the crypto market.");
            Console.WriteLine("5. show top 5 and bottom 5 traders based on their profit/loss.");

            
            int choice = Convert.ToInt32(Console.ReadLine());

            
            
            switch (choice)
            {


                case 1:
                    
                    
                    
                    string input = Console.ReadLine();

                    searchcoins(input, coins);
                    break;

                case 2:
                    displaytop50(coins);
                    break;

                case 3:
                    string tradername = Console.ReadLine();
                    displayportfolio(tradername, traders);
                    break;

                case 4:

                    displayprofitloss();
                    break;
                case 5:
                    int n = Convert.ToInt32(Console.ReadLine());
                    displaytopn(n);
                    break;

                default:
                    Console.WriteLine("invalid input");
                    break;

            }
        }



        static void searchcoins(string coinname, List<Coin>coins)
        {
            //     List<Coin> coins = new List<Coin>();
            var coinslist = coins.Where(x => (x.Name == coinname) || (x.Symbol == coinname));

            foreach (var coin in coinslist)
            {
                
                    Console.WriteLine(coin.Name + " " + coin.Symbol + " " + coin.Price + " " + coin.CirculatingSupply);
                
            }
        }

        static void displaytop50(List<Coin>coins)
        {
            var top50coinslist = coins.OrderByDescending(c => c.Price).Take(50);

            foreach (var coin in top50coinslist)
            {
                Console.WriteLine(coin.Name + " " + coin.Price);
            }
        }

        static void displayportfolio(string tradername,List<Trader>traders)
        {

            var traderslist = traders.Where(x => x.first_name == tradername);
            foreach (var trader in traderslist)
            {
              
                    Console.WriteLine(trader.first_name + " " + trader.last_name + " " + trader.phone + " " + trader.Wallet_Address);
                
            }

            //dictionary<string, list<string>> traderportfolio = new dictionary<string, list<string>>();




        }

        static void displayprofitloss()
        {


        }
        static void displaytopn(int n)
        {

            var topnlist = tradersdata.OrderByDescending(c => c.quantity).Take(n);

            foreach (var coin in topnlist)
            {
                Console.WriteLine(coin.name_of_coin + " " + coin.current_price);
            }
        }
    }

    }
