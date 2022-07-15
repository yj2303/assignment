using System;
using System.Collections.Generic;

namespace CryptoCurrencyAssignment2.menufunctionlities
{
	using CryptoCurrencyAssignment2.comparators;
	using CryptoCurrencyAssignment2.entities;
	using Transaction = CryptoCurrencyAssignment2.transactions.Transaction;



	
	public class MenuFunctions
	{

		public static string searchCoin()
		{

			Scanner sc = new Scanner(System.in);
			Console.WriteLine("Enter (Y/N): ");
			string val = sc.nextLine();
			if (val.ToUpper().Equals("Y"))
			{
				Console.WriteLine("Enter the Symbol: ");
				string coinSymbol = sc.nextLine();
				
				return Transaction.symbolWiseCoinMap[coinSymbol.ToUpper()].ToString();
			}
			else
			{
				Console.WriteLine("Enter the Name: ");
				string coinName = sc.nextLine();
				foreach (Coin coin in Transaction.allCoinList)
				{
					if (coin.Name.Equals(coinName, StringComparison.OrdinalIgnoreCase))
					{
						return coin.ToString();
					}
				}
				
			}
		}	
		public static void displayTopNCoins(int n)
		{
			
			Dictionary<string, Coin> temp = Transaction.symbolWiseCoinMap.SetOfKeyValuePairs().OrderBy(Collections.reverseOrder(Map.Entry.comparingByValue(new SortByPrice()))).ToDictionary(Map.Entry.getKey, Map.Entry.getValue, (e1, e2) => e2, LinkedHashMap::new);
			int curr = 1;
			Console.WriteLine("Top " + n + " Coins based on the Price: ");
			foreach (string symbol in temp.Keys)
			{
				if (curr == 51)
				{
					break;
				}
				Console.WriteLine("Coin " + curr + " :" + temp[symbol].ToString());
				curr++;
			}
		}
		public static void displayPortfolio(string name)
		{
			int numberOfTrader = Transaction.allTraderList.Count;
			for (int i = 0;i < numberOfTrader;i++)
			{
				if (name.Equals(Transaction.allTraderList[i].FullName, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine(Transaction.allTraderList[i].ToString());
					return;
				}
			}
			
		}

			public static void displayProfitLossOfTrader(string name)
		{
			int numberOfTrader = Transaction.allTraderList.Count;
			for (int i = 0;i < numberOfTrader;i++)
			{
				if (name.Equals(Transaction.allTraderList[i].FullName, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Trader have made a profit of: " + Transaction.allTraderList[i].Profit);
					return;
				}
			}
			
		}

			public static void topNTrader(int n)
		{
			
				IList<Trader> topTrader = Transaction.allTraderList.OrderBy(Collections.reverseOrder(new SortByProfit())).Take(n).ToList();
				IList<Trader> bottomTrader = Transaction.allTraderList.OrderBy(new SortByProfit()).Take(n).ToList();
				Console.WriteLine("Top " + n + " Traders!");
				foreach (Trader trader in topTrader)
				{
					Console.WriteLine(trader.ToString());
				}
				Console.WriteLine("Bottom " + n + " Traders!");
				foreach (Trader trader in bottomTrader)
				{
					Console.WriteLine(trader.ToString());
				}
			

		}
	}

}