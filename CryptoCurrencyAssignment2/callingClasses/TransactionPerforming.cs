using System;
using System.Threading;

namespace com.assignment2.callingClasses
{
	using TransactionType = com.assignment2.enums.TransactionType;
	using com.assignment2.exceptions;
	using JSONTransactionFileReader = com.assignment2.jsonReader.JSONTransactionFileReader;
	using MenuDriven = com.assignment2.menufunctionlities.MenuDriven;
	using com.assignment2.operationEntities;
	using com.assignment2.transactions;
	using JSONArray = org.json.simple.JSONArray;
	using JSONObject = org.json.simple.JSONObject;

	public class TransactionPerforming
	{

		public static void Main(string[] args)
		{

			try
			{
				Transaction.readData();
				Thread menuDriven = new MenuDriven();
				menuDriven.Start();
				JSONArray transaction = JSONTransactionFileReader.JSONFileReader("src/main/java/com/assignment2/data/small_transaction.json");
				foreach (object obj in transaction)
				{
					JSONObject temp = (JSONObject) obj;
					if (JSONTransactionFileReader.parseTransactionObjectType(temp) == TransactionType.SELL)
					{
						try
						{
							Sell sell = new Sell(JSONTransactionFileReader.parseTransactionObjectDetails(temp));
							Thread sellCoinTransaction = new SellCoinTransaction(sell);
							sellCoinTransaction.Start();
						}
						catch (CoinNotFoundException e)
						{
							Console.WriteLine(e.Message);
						}
					}
					else if (JSONTransactionFileReader.parseTransactionObjectType(temp) == TransactionType.UPDATE_PRICE)
					{
						try
						{
							UpdatePrice updatePrice = new UpdatePrice(JSONTransactionFileReader.parseTransactionObjectDetails(temp));
							Thread updatePriceTransaction = new UpdatePriceTransaction(updatePrice);
							updatePriceTransaction.Start();
						}
						catch (CoinNotFoundException e)
						{
							Console.WriteLine(e.Message);
						}

					}
					else if (JSONTransactionFileReader.parseTransactionObjectType(temp) == TransactionType.ADD_VOLUME)
					{
						try
						{
							AddVolume addVolume = new AddVolume(JSONTransactionFileReader.parseTransactionObjectDetails(temp));
							Thread addVolumeTransaction = new AddVolumeTransaction(addVolume);
							addVolumeTransaction.Start();
						}
						catch (CoinNotFoundException e)
						{
							Console.WriteLine(e.Message);
						}
					}
					else if (JSONTransactionFileReader.parseTransactionObjectType(temp) == TransactionType.BUY)
					{
						try
						{
							Buy buy = new Buy(JSONTransactionFileReader.parseTransactionObjectDetails(temp));
							Thread buyCoinTransaction = new BuyCoinTransaction(buy);
							buyCoinTransaction.Start();
						}
						catch (CoinNotFoundException e)
						{
							Console.WriteLine(e.Message);
						}

					}
				}
			}
			catch (TransactionTypeNotFoundException e)
			{
				Console.WriteLine(e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}

}