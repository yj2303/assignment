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






            Console.WriteLine("1. given the name or code of a coin, retrieve all its details");
            Console.WriteLine("2. display top 50 coins in the market based on price.");
            Console.WriteLine("3. for a given trader, show his portfolio.");
            Console.WriteLine("4. for a given trader, display the total profit or loss they have made trading in the crypto market.");
            Console.WriteLine("show top 5 and bottom 5 traders based on their profit/loss.");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {


                case 1:
                    string input = Console.ReadLine();

                    searchcoins(input);
                    break;

                case 2:
                    displaytop50();
                    break;

                case 3:
                    string tradername = Console.ReadLine();
                    displayportfolio(tradername);
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



        static void searchcoins(string coinname)
        {

            foreach (var coin in coins)
            {
                if (coin.Name == coinname)
                {
                    Console.WriteLine(coin.Name + " " + coin.Symbol + " " + coin.Price + " " + coin.CirculatingSupply);
                }
            }
        }

        static void displaytop50()
        {
            var top50coinslist = coins.OrderByDescending(c => c.Price).Take(50);

            foreach (var coin in top50coinslist)
            {
                Console.WriteLine(coin.Name + " " + coin.Price);
            }
        }

        static void displayportfolio(string tradername)
        {


            foreach (var trader in traders)
            {
                if (trader.first_name == tradername)
                {
                    Console.WriteLine(trader.first_name + " " + trader.last_name + " " + trader.phone + " " + trader.Wallet_Address);
                }
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
