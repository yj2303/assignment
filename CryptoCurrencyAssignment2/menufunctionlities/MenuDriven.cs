using System;
using System.Threading;

namespace com.assignment2.menufunctionlities
{
	using CoinNotFoundException = com.assignment2.exceptions.CoinNotFoundException;
	using NotInRangeException = com.assignment2.exceptions.NotInRangeException;
	using TraderNotFoundException = com.assignment2.exceptions.TraderNotFoundException;

	/// <summary>
	/// Contains the Menu Part of the Program i.e. the 5 functionalities required.
	/// </summary>
	public class MenuDriven : Thread
	{
		/// <summary>
		/// Print the Menu along with the choice option.
		/// </summary>
		public static void menu()
		{
			Console.WriteLine("Enter the Choice among the following: ");
			Console.WriteLine("1. Give the name or code of a coin, retrieve all its details." + "\n2. Display top 50 coins in the market based on price." + "\n3. Show portfolio of a Trader" + "\n4. Show the total profit or loss they have made trading in the crypto market" + "\n5. Show top 5 and bottom 5 traders based on their profit/loss." + "\n6. Exit!");
		}

		/// <summary>
		/// Perform the user input functionalities on the basis of user's choice.
		/// </summary>
		public static void choice()
		{
			Scanner sc = new Scanner(System.in);
			string name = "";
			bool status = true;
			while (status)
			{
				menu();
				Console.Write("Enter the Choice: ");
				string choice = sc.nextLine();
				switch (choice)
				{
					case "1":
						try
						{
							Console.WriteLine(MenuFunctions.searchCoin());
						}
						catch (CoinNotFoundException e)
						{
							Console.WriteLine(e.Message);
						}
						break;

					case "2":
						try
						{
							Console.Write("Top 50 Coins! ");
							MenuFunctions.displayTopNCoins(50);
						}
						catch (NotInRangeException e)
						{
							Console.WriteLine(e.Message);
						}
						break;

					case "3":
						try
						{
							Console.WriteLine("Enter the Full Name of Trader:");
							name = sc.nextLine();
							MenuFunctions.displayPortfolio(name.ToUpper());
						}
						catch (TraderNotFoundException e)
						{
							Console.WriteLine(e.Message);
						}
						break;

					case "4":
						try
						{
							Console.WriteLine("Enter the Full Name of Trader:");
							name = sc.nextLine();
							MenuFunctions.displayProfitLossOfTrader(name.ToUpper());
						}
						catch (TraderNotFoundException e)
						{
							Console.WriteLine(e.Message);
						}

						break;

					case "5":
						try
						{
							MenuFunctions.topNTrader(5);
						}
						catch (NotInRangeException e)
						{
							Console.WriteLine(e.Message);
						}
						break;

					case "6":
						status = false;
						break;

					default:
						Console.WriteLine("Wrong input try again! ");
						break;
				}

			}
			Console.Write("Program Ended!!");
		}

		/// <summary>
		/// Helps to implement the menu functionalities run on the thread.
		/// </summary>
		public override void run()
		{
			choice();
		}

	}

}