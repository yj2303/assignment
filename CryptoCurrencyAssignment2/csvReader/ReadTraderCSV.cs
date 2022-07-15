using System;
using System.Collections.Generic;
using System.IO;

namespace CryptoCurrencyAssignment2.csvReader
{
	using CryptoCurrencyAssignment2.entities;
	


	public class ReadTraderCSV
	{
			public static void readTraderDataFromCSV(string path, IDictionary<string, Trader> tradersMap, IList<Trader> allTrader)
		{
			string line = "";
			int lineNumber = 0;
			
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
	}

}