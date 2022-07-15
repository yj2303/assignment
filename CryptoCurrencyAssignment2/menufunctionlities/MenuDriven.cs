using System;
using System.Threading;

namespace CryptoCurrencyAssignment2.menufunctionlities
{

	public class MenuDriven : Thread
	{
		

		public static void option()
		{
			Scanner sc = new Scanner(System.in);
			string name = "";
			bool status = true;
			while (status)
			{
				menu();
				Console.Write("Enter the Feature: ");
				string feature = sc.nextLine();
				switch (feature)
				{
					case "1":
						
							Console.WriteLine(MenuFunctions.searchCoin());
						
						break;

					case "2":
					
							Console.Write("Top 50 Coins! ");
							MenuFunctions.displayTopNCoins(50);
						
						break;

					case "3":
							Console.WriteLine("Enter the Full Name of Trader:");
							name = sc.nextLine();
							MenuFunctions.displayPortfolio(name.ToUpper());
						
						break;

					case "4":
						
							Console.WriteLine("Enter the Full Name of Trader:");
							name = sc.nextLine();
							MenuFunctions.displayProfitLossOfTrader(name.ToUpper());
						

						break;

					case "5":
						
							MenuFunctions.topNTrader(5);
						
						break;

					case "6":
						status = false;
						break;

					default:
						Console.WriteLine("Invalid Input! ");
						break;
				}

			}
			
		}

		public override void run()
		{
			option();
		}

	}

}