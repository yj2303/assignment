using System;
using System.Threading;

namespace CryptoCurrencyAssignment2
{
	using MenuDriven = CryptoCurrencyAssignment2.menufunctionlities.MenuDriven;
	using CryptoCurrencyAssignment2.operationEntities;
	using CryptoCurrencyAssignment2.transactions;


	public class TransactionPerforming
	{

		public static void Main(string[] args)
		{

			try
			{
				Transaction.readData();
				Thread menuDriven = new MenuDriven();
				menuDriven.Start();
				JSONArray transaction = JSONTransactionFileReader.JSONFileReader("../data/small_transaction.json");
				foreach (object obj in transaction)
				{
					JSONObject temp = (JSONObject) obj;
					if (JSONTransactionFileReader.parseTransactionObjectType(temp) == "SELL")
					{
						
							Sell sell = new Sell(JSONTransactionFileReader.parseTransactionObjectDetails(temp));
							Thread sellCoinTransaction = new SellCoinTransaction(sell);
							sellCoinTransaction.Start();
						
					}
					else if (JSONTransactionFileReader.parseTransactionObjectType(temp) =="UPDATE_PRICE")
					{
						
							UpdatePrice updatePrice = new UpdatePrice(JSONTransactionFileReader.parseTransactionObjectDetails(temp));
							Thread updatePriceTransaction = new UpdatePriceTransaction(updatePrice);
							updatePriceTransaction.Start();
						

					}
					else if (JSONTransactionFileReader.parseTransactionObjectType(temp) == "ADD_VOLUME")
					{
						
							AddVolume addVolume = new AddVolume(JSONTransactionFileReader.parseTransactionObjectDetails(temp));
							Thread addVolumeTransaction = new AddVolumeTransaction(addVolume);
							addVolumeTransaction.Start();
						
					}
					else if (JSONTransactionFileReader.parseTransactionObjectType(temp) == "BUY")
					{
						
							Buy buy = new Buy(JSONTransactionFileReader.parseTransactionObjectDetails(temp));
							Thread buyCoinTransaction = new BuyCoinTransaction(buy);
							buyCoinTransaction.Start();
						

					}
				}
			}
			
		}
	}

}