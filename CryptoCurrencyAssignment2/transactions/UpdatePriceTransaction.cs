using System;
using System.Threading;

namespace com.assignment2.transactions
{
	using HashFun = com.assignment2.callingClasses.HashFun;
	using CoinStatus = com.assignment2.enums.CoinStatus;
	using TransactionStatus = com.assignment2.enums.TransactionStatus;
	using UpdatePrice = com.assignment2.operationEntities.UpdatePrice;

	/// <summary>
	/// Having all the functionalities of updatePrice Transaction thread.
	/// </summary>
	public class UpdatePriceTransaction : Transaction
	{

		private readonly UpdatePrice updatePrice;


		/// <param name="updatePrice"> Require UpdatePrice object to get the information of the UpdatePrice Transaction. </param>
		public UpdatePriceTransaction(UpdatePrice updatePrice)
		{
			this.updatePrice = updatePrice;
		}

		/// <summary>
		/// Implemented the run function for Update Price Transaction.
		/// first it checks that the coin is AVAILABLE or not
		/// i.e. is it occupied by some other thread or not.
		/// if occupied then current thread goes to wait state.
		/// if the coin is available then the current thread make the coin status not available so that no other thread
		/// can access the coin will it is working
		/// after that it perform the Update Price operation
		/// after that it notify all the other thread and then make the coin status available.
		/// </summary>
		public override void run()
		{
			lock (this.updatePrice.Coin)
			{
				while (this.updatePrice.Coin.Status == CoinStatus.NOT_AVAILABLE)
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
				this.updatePrice.Coin.Status = CoinStatus.NOT_AVAILABLE;
				TransactionId = HashFun.BlockHash;
				this.updatePrice.Coin.Price = updatePrice.Price;
				Monitor.PulseAll(this.updatePrice.Coin);
				this.updatePrice.Coin.Status = CoinStatus.AVAILABLE;
				this.updatePrice.Status = TransactionStatus.COMPLETED;
			}

		}
	}

}