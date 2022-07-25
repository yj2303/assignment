using Assignment_2.Models;
using System.Text.Json;
using System.Threading;

namespace Assignment_2
{
    internal class Program
    {
        static List<Coins> coinsList;
        static List<Transaction> transactionList;
        static List<Traders> traderList;
        static List<Traders> traderPortfolioList = new List<Traders>();



        static void Main(string[] args)
        {

            try
            {
                coinsList = File.ReadAllLines("C:\\Users\\Admin\\Desktop\\KDU-Dotnet-Backend\\Assignment-2\\Files\\coins.csv")
                                        .Skip(1)
                                        .Select(v => Coins.GetCoinsData(v))
                                        .ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine("Unable to get the data from csv files");
            }
            try
            {
                traderList = File.ReadAllLines("C:\\Users\\Admin\\Desktop\\KDU-Dotnet-Backend\\Assignment-2\\Files\\traders.csv")
                                       .Skip(1)
                                       .Select(v => Traders.GetTradersData(v))
                                       .ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine("Inable to get the data from csv file");

            }


            try
            {

                string filename = @"C:\Users\Admin\Desktop\KDU-Dotnet-Backend\Assignment-2\Files\  t.json";
                string jsonString = File.ReadAllText(filename);
                transactionList = JsonSerializer.Deserialize<List<Transaction>>(jsonString);

            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to get the data from json files");
            }






            foreach (var i in transactionList)
            {
                switch (i.type)
                {
                    case "BUY":
                        {
                            Thread buy = new Thread(() => BuyTransaction(i, traderList));
                            buy.Start();
                            break;
                        }
                    case "SELL":
                        {
                            Thread sell = new Thread(() => SellTransaction(i, traderList));
                            sell.Start();
                            break;
                        }
                        case "UPDATE_PRICE":
                        {
                            Thread updatePrice = new Thread(() => UpdatePriceTransaction(i));
                            updatePrice.Start();
                            break;
                        }
                    case "ADD_VOLUME":
                        {
                            Thread addVolume = new Thread(() => AddVolumeTransaction(i));
                            addVolume.Start();
                            break;
                        }
                }
                
             }

            Console.WriteLine("1. Given the name or code of a coin, retrieve all its details");
            Console.WriteLine("2. Display top 50 coins in the market based on price.");
            Console.WriteLine("3. For a given trader, show his portfolio.");
            Console.WriteLine("4. For a given trader, display the total profit or loss they have made trading in the crypto market.");
            Console.WriteLine("5. Show top 5 Trader based on their profit.");

            Console.WriteLine("Select a choice from above menu");
            int choice = Convert.ToInt32(Console.ReadLine());

            while (choice != 6)
            {


                switch (choice)
                {


                    case 1:
                        SearchCoin();
                        break;

                    case 2:
                        Top50Coins();
                        break;

                    case 3:
                        TraderPortfolio();
                        break;
                    case 4:
                        TotalProfitLossOfGivenTrader();
                        break;
                    case 5:
                        Top5Trader();
                        break;
                    case 6:
                        break;

                   

                }

                Console.WriteLine("1. Given the name or code of a coin, retrieve all its details");
                Console.WriteLine("2. Display top 50 coins in the market based on price.");
                Console.WriteLine("3. For a given trader, show his portfolio.");
                Console.WriteLine("4. For a given trader, display the total profit or loss they have made trading in the crypto market.");
                Console.WriteLine("5. Show top 5 Trader based on their profit.");
             

                Console.Write("Enter a choice from above menu. \n");
                choice = Convert.ToInt32(Console.ReadLine());

            }








        }



        public static void BuyTransaction(Transaction transaction, List<Traders> traders)
        {


            double MarketPrice = 0;
            foreach (var coin in coinsList.Where(c => c.Symbol == transaction.data.coin))
            {
                coin.CirculatingSupply -= transaction.data.quantity;
                MarketPrice = coin.Price;
            }

            foreach (var tranasctionTrader in traders.Where(t => t.Wallet_Address == transaction.data.wallet_address))
            {
                if (!(tranasctionTrader.tradersCoins is null))
                {

                    if (tranasctionTrader.tradersCoins.Any(c => c.CoinSymbol == transaction.data.coin))
                    {
                        foreach (var coin in tranasctionTrader.tradersCoins.Where(c => c.CoinSymbol == transaction.data.coin))
                        {
                            int quantity = transaction.data.quantity;
                            coin.Quantity += quantity;
                            coin.CostPrice = MarketPrice;
                            coin.SellingPrice = MarketPrice;


                        }
                    }
                    else
                    {
                        tranasctionTrader.tradersCoins.Add(new TradersCoins
                        {
                            CoinSymbol = transaction.data.coin,
                            Quantity = transaction.data.quantity,
                            CostPrice = MarketPrice,
                            WalletAddress = transaction.data.wallet_address,

                        });
                        traderPortfolioList.Add(tranasctionTrader);

                    }

                }


            }
            




        }



        static void SellTransaction(Transaction transaction, List<Traders> traders)
        {



            double MarketPrice = 0;

            foreach (var coin in coinsList.Where(c => c.Symbol == transaction.data.coin))
            {
                coin.CirculatingSupply += transaction.data.quantity;
                MarketPrice = coin.Price;

            }



           

            foreach (var tranasctionTrader in traders.Where(t => t.Wallet_Address == transaction.data.wallet_address))
            {

                    if (tranasctionTrader.tradersCoins.Any(c => c.CoinSymbol == transaction.data.coin))
                    {
                        foreach (var coin in tranasctionTrader.tradersCoins.Where(c => c.CoinSymbol == transaction.data.coin))
                        {

                            if (coin.Quantity < transaction.data.quantity)
                            {
                                Console.WriteLine("Invalid Transaction");
                            }
                            else
                            {
                                coin.Quantity -= transaction.data.quantity;
                                coin.CostPrice = MarketPrice/transaction.data.quantity;

                            }

                            
                            

                        }
                     }
                
                
            }


        }
        static void UpdatePriceTransaction(Transaction transaction)
        {

            foreach (var coin in coinsList)
            {

                if (coin.Symbol == transaction.data.coin)
                {
                    coin.Price = transaction.data.price;
                }
            }




       }

        static void AddVolumeTransaction(Transaction transaction)
        {

            foreach (var coin in coinsList)
            {

                if (coin.Symbol == transaction.data.coin)
                {
                    coin.CirculatingSupply += transaction.data.quantity;
                }
            }


        }



        public static void SearchCoin()
        {
            string coinName = Console.ReadLine();

            foreach(var coin in coinsList)
            {
                if (coin.Name==(coinName))
                {
                    Console.WriteLine("Name "+ coin.Name);
                    Console.WriteLine("Symbol " + coin.Symbol);
                    Console.WriteLine("Price " + coin.Price);
                    Console.WriteLine("Circulating Supply " + coin.CirculatingSupply);

                   

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
            string traderFirstName = Console.ReadLine();
            Console.WriteLine();
            string traderLastName = Console.ReadLine();


            foreach (var trader in traderList)
            {
                if (trader.first_name ==traderFirstName && trader.last_name == traderLastName)
                {
                    Console.WriteLine(traderFirstName + " " +traderLastName );
                   


                    var coinPortfolio = trader.tradersCoins;

                    foreach(var portfolio in coinPortfolio)
                    {
                        string coinName = "";
                        foreach(var coin in coinsList)
                        {
                             if (coin.Symbol == portfolio.CoinSymbol)
                             {
                                coinName = coin.Name;
                                break;
                            }
                        }
                        Console.WriteLine( coinName   + "Quantity " + portfolio.Quantity);



                    }
                }
            }


        }



        static void TotalProfitLossOfGivenTrader()
        {
            Console.WriteLine("Enter First Name of Trader");
            string traderFirstName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter Last Name of Trader");
            string traderLastName = Console.ReadLine();

            foreach (var trader in traderList)
            {
                if (trader.first_name == traderFirstName && trader.last_name == traderLastName)
                {


                    var coinPortfolio = trader.tradersCoins;
                    double TotalProfit = 0;
                    double TotalLoss = 0;

                    foreach (var portfolio in coinPortfolio)
                    {

                        if (portfolio.SellingPrice > portfolio.CostPrice)
                            TotalProfit += portfolio.Quantity * (portfolio.SellingPrice - portfolio.CostPrice);
                        else
                            TotalLoss += portfolio.Quantity * (-portfolio.SellingPrice + portfolio.CostPrice);
                    }
                    Console.WriteLine(traderFirstName + " " + traderLastName + " " + "has made " + TotalProfit + " Profits." );
                    Console.WriteLine(traderFirstName + " " + traderLastName + " " + "has made " + TotalLoss + " Loss.");


                }
            }


        }

        static void Top5Trader()
        {


            var list = traderList.ToList().Take(5);

            foreach(var trader in list)
            {
                Console.WriteLine(trader.first_name + " " + trader.last_name);
            }
           
        }







    }
}