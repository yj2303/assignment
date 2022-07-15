using System;
using System.Collections.Generic;
using System.IO;

namespace com.assignment2.csvReader
{
	using com.assignment2.entities;
	using CSVReader = com.opencsv.CSVReader;


	/// <summary>
	/// Class containing function to read data of Trader from the CSV.
	/// </summary>
	public class ReadTraderCSV
	{
		/// <param name="path">       Path of the file where it is located. </param>
		/// <param name="tradersMap"> ConcurrentHashMap to store the Trader data on the basis of wallet address from CSV. </param>
		/// <param name="allTrader">  List to store all the Trader from CSV. </param>
		public static void readTraderDataFromCSV(string path, IDictionary<string, Trader> tradersMap, IList<Trader> allTrader)
		{
			string line = "";
			int lineNumber = 0;
			try
			{
					using (StreamReader filereader = new StreamReader(path))
					{
					CSVReader csvReader = new CSVReader(filereader);
					string[] nextRecord;
					while ((nextRecord = csvReader.readNext()) != null)
					{
						if (lineNumber != 0)
						{
							Trader trader = new Trader();
							trader.FirstName = nextRecord[1];
							trader.LastName = nextRecord[2];
							trader.Phone = nextRecord[3];
							trader.WalletAddress = nextRecord[4];
							tradersMap[trader.WalletAddress] = trader;
							allTrader.Add(trader);
						}
						lineNumber++;
					}
					}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}

}