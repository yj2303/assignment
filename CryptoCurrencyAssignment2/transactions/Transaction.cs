using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace CryptoCurrencyAssignment2.transactions
{
	using ReadCoinCSV = CryptoCurrencyAssignment2.csvReader.ReadCoinCSV;
	using ReadTraderCSV = CryptoCurrencyAssignment2.csvReader.ReadTraderCSV;
	using CryptoCurrencyAssignment2.entities;


	public class Transaction : Thread
	{
		private string transactionId;
	
		public static ConcurrentDictionary<string, Coin> symbolWiseCoinMap = new ConcurrentDictionary<string, Coin>();
	
		public static IList<Coin> allCoinList = new List<Coin>();
	
		public static ConcurrentDictionary<string, Trader> traderMap = new ConcurrentDictionary<string, Trader>();
		
		public static IList<Trader> allTraderList = new List<Trader>();

			public virtual string TransactionId
		{
			get
			{
				return transactionId;
			}
			set
			{
				this.transactionId = value;
			}
		}



		public static void readData()
		{
			ReadCoinCSV.readCoinDataFromCSV("../data/coins.csv",symbolWiseCoinMap,allCoinList);
			ReadTraderCSV.readTraderDataFromCSV("../data/traders.csv",traderMap,allTraderList);

		}
	}

}