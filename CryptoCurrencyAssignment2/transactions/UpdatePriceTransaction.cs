using System;
using System.Threading;

namespace CryptoCurrencyAssignment2.transactions
{
	using HashFun = CryptoCurrencyAssignment2.callingClasses.HashFun;
	using UpdatePrice = CryptoCurrencyAssignment2.operationEntities.UpdatePrice;

		public class UpdatePriceTransaction : Transaction
	{

		private readonly UpdatePrice updatePrice;

	public UpdatePriceTransaction(UpdatePrice updatePrice)
		{
			this.updatePrice = updatePrice;
		}

			public override void run()
		{
			lock (this.updatePrice.Coin)
			{
				while (this.updatePrice.Coin.Status == "NOT_AVAILABLE")
				{
					try
					{
						Monitor.Wait(this.updatePrice.Coin);
					}
					catch (InterruptedException e)
					{
						Console.WriteLine(e.ToString());
						Console.Write(e.StackTrace);
					}
				}
				this.updatePrice.Coin.Status = "NOT_AVAILABLE";
				TransactionId = HashFun.BlockHash;
				this.updatePrice.Coin.Price = updatePrice.Price;
				Monitor.PulseAll(this.updatePrice.Coin);
				this.updatePrice.Coin.Status = "AVAILABLE";
				this.updatePrice.Status = "COMPLETED";
			}

		}
	}

}