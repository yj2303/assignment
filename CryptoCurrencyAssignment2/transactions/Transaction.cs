using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace com.assignment2.transactions
{
	using ReadCoinCSV = com.assignment2.csvReader.ReadCoinCSV;
	using ReadTraderCSV = com.assignment2.csvReader.ReadTraderCSV;
	using com.assignment2.entities;


	/// <summary>
	/// Parent class for all kind of transaction.
	/// </summary>
	public class Transaction : Thread
	{
		private string transactionId;
		/// <summary>
		/// ConcurrentHashMap that contains all the coin on the basis of coin Symbol.
		/// </summary>
		public static ConcurrentDictionary<string, Coin> symbolWiseCoinMap = new ConcurrentDictionary<string, Coin>();
		/// <summary>
		/// ArrayList that contains all the coin.
		/// </summary>
		public static IList<Coin> allCoinList = new List<Coin>();
		/// <summary>
		///  ConcurrentHashMap that contains all the Trader on the basis of wallet Address.
		/// </summary>
		public static ConcurrentDictionary<string, Trader> traderMap = new ConcurrentDictionary<string, Trader>();
		/// <summary>
		/// ArrayList that contains all the Trader.
		/// </summary>
		public static IList<Trader> allTraderList = new List<Trader>();

		/// <returns> Return String value i.e. id of the Transaction. </returns>
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



		/// <summary>
		/// Read all the data from the CSV using the CSVReader classes and store the value in the
		/// symbolWiseCoinMap, allCoinList, traderMap, and allTraderList
		/// </summary>
		public static void readData()
		{
			ReadCoinCSV.readCoinDataFromCSV("src/main/java/com/assignment2/data/coins.csv",symbolWiseCoinMap,allCoinList);
			ReadTraderCSV.readTraderDataFromCSV("src/main/java/com/assignment2/data/traders.csv",traderMap,allTraderList);

		}
	}

}