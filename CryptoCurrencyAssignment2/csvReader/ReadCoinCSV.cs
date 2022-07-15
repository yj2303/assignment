using System;
using System.Collections.Generic;
using System.IO;

namespace CryptoCurrencyAssignment2.csvReader
{
	using Coin = CryptoCurrencyAssignment2.entities.Coin;
	


	public class ReadCoinCSV
	{
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
							coin.Status = "AVAILABLE";
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