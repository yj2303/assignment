using System;
using System.Collections.Generic;

namespace com.assignment2.menufunctionlities
{
	using com.assignment2.comparators;
	using com.assignment2.entities;
	using CoinNotFoundException = com.assignment2.exceptions.CoinNotFoundException;
	using NotInRangeException = com.assignment2.exceptions.NotInRangeException;
	using TraderNotFoundException = com.assignment2.exceptions.TraderNotFoundException;
	using Transaction = com.assignment2.transactions.Transaction;



	/// <summary>
	/// Contains the 5 menu function implementation.
	/// </summary>
	public class MenuFunctions
	{

		/// <summary>
		/// Search and print the coin details on the basis of the Name or Symbol. </summary>
		/// <exception cref="CoinNotFoundException"> when coin is not present in the symbolWiseCoinMap or allCoinList. </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String searchCoin() throws com.assignment2.exceptions.CoinNotFoundException
		public static string searchCoin()
		{

			Scanner sc = new Scanner(System.in);
			Console.WriteLine("Want to proceed with Symbol(Y/N): ");
			string val = sc.nextLine();
			if (val.ToUpper().Equals("Y"))
			{
				Console.WriteLine("Enter the Symbol: ");
				string coinSymbol = sc.nextLine();
				if (!Transaction.symbolWiseCoinMap.ContainsKey(coinSymbol.ToUpper()))
				{
					throw new CoinNotFoundException("Coin not found with the given Symbol: " + coinSymbol);
				}
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
				throw new CoinNotFoundException("Coin not found with given Name: " + coinName);
			}
		}

		/// <param name="n"> Require int value to print Top N coins on the basis of Price. </param>
		/// <exception cref="NotInRangeException"> When required input is greater than the total number of coin. </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void displayTopNCoins(int n) throws com.assignment2.exceptions.NotInRangeException
		public static void displayTopNCoins(int n)
		{
			if (n > Transaction.symbolWiseCoinMap.Count)
			{
				throw new NotInRangeException("Number of coin are less than the number of expected Result!");
			}
//JAVA TO C# CONVERTER TODO TASK: Method reference constructor syntax is not converted by Java to C# Converter:
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

		/// <param name="name"> Require String value to print the portfolio of the required Trader. </param>
		/// <exception cref="TraderNotFoundException"> When the Required Trader is not present in the data. </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void displayPortfolio(String name) throws com.assignment2.exceptions.TraderNotFoundException
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
			throw new TraderNotFoundException("Trader not found!");
		}

		/// <param name="name"> Require String value to print the profit/loss of the required Trader. </param>
		/// <exception cref="TraderNotFoundException"> When the Required Trader is not present in the data. </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void displayProfitLossOfTrader(String name) throws com.assignment2.exceptions.TraderNotFoundException
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
			throw new TraderNotFoundException("Trader not found!");
		}

		/// <param name="n"> Require int value to display top and bottom N trader. </param>
		/// <exception cref="NotInRangeException"> When required input is greater than total number of traders. </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void topNTrader(int n) throws com.assignment2.exceptions.NotInRangeException
		public static void topNTrader(int n)
		{
			if (n > Transaction.allTraderList.Count)
			{
				throw new NotInRangeException("Number of Traders are less than the number of expected Result!");
			}
			else
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

}