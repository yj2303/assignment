using System;
using System.Collections.Generic;
using System.IO;

namespace com.assignment2.csvReader
{
	using Coin = com.assignment2.entities.Coin;
	using CoinStatus = com.assignment2.enums.CoinStatus;
	using CSVReader = com.opencsv.CSVReader;


	/// <summary>
	/// Class containing function to read data of coin from the CSV.
	/// </summary>
	public class ReadCoinCSV
	{
		/// <param name="path">               Path of the file where it is located. </param>
		/// <param name="symbolWiseCoinsMap"> ConcurrentHashMap to store the Coin data on the basis of coin Symbol from CSV. </param>
		/// <param name="allCoinList">        List to store all the coin from CSV. </param>
		public static void readCoinDataFromCSV(string path, IDictionary<string, Coin> symbolWiseCoinsMap, IList<Coin> allCoinList)
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
							Coin coin = new Coin();
							coin.Rank = int.Parse(nextRecord[1]);
							coin.Name = nextRecord[2];
							coin.Symbol = nextRecord[3];
							coin.Price = double.Parse(nextRecord[4]);
							coin.Volume = long.Parse(nextRecord[5]);
							coin.Status = CoinStatus.AVAILABLE;
							symbolWiseCoinsMap[coin.Symbol] = coin;
							allCoinList.Add(coin);
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