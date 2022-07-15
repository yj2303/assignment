using System;
using System.Threading;

namespace com.assignment2.transactions
{
	using HashFun = com.assignment2.callingClasses.HashFun;
	using Trader = com.assignment2.entities.Trader;
	using CoinStatus = com.assignment2.enums.CoinStatus;
	using TransactionStatus = com.assignment2.enums.TransactionStatus;
	using Sell = com.assignment2.operationEntities.Sell;


	/// <summary>
	/// Having all the functionalities of sellCoin Transaction thread.
	/// </summary>
	public class SellCoinTransaction : Transaction
	{

		private readonly Sell sell;

		/// <param name="sell"> Require Sell object to get the information of the sell Transaction. </param>
		public SellCoinTransaction(Sell sell)
		{
			this.sell = sell;
		}

		/// <summary>
		/// Implemented the run function for sell Transaction.
		/// it's first check that trader has the coin or not,
		/// or if the quantity they want to sell is more than the quantity they own-> then decline the Transaction .
		/// If the trader has sufficient quantity to sell then it will check that the coin is AVAILABLE or not
		/// i.e. is it occupied by some other thread or not.
		/// if occupied then current thread goes to wait state.
		/// if the coin is available then the current thread make the coin status not available so that no other thread
		/// can access the coin will current thread is working
		/// then it performs the sell operation
		/// after that it notify all the other thread and then make the coin status available.
		/// </summary>
		public override void run()
		{

			Trader currentTrader = traderMap[this.sell.WalletAddress];
			string currentCoinSymbol = this.sell.Coin.Symbol;
			if (!currentTrader.coinOwnByTheTrader.ContainsKey(currentCoinSymbol) || currentTrader.coinOwnByTheTrader[currentCoinSymbol].getVolume() < this.sell.Quantity)
			{
				this.sell.Status = TransactionStatus.DECLINED;
				return;
			}
			lock (this.sell.Coin)
			{
				while (this.sell.Coin.Status == CoinStatus.NOT_AVAILABLE)
				{
					try
					{
						Monitor.Wait(this.sell.Coin);
					}
					catch (InterruptedException e)
					{
						Console.WriteLine(e.ToString());
						Console.Write(e.StackTrace);
					}
				}
				this.sell.Coin.Status = CoinStatus.NOT_AVAILABLE;
				TransactionId = HashFun.BlockHash;

				double? releasedRevenue = this.sell.Coin.Price * this.sell.Quantity + currentTrader.ReleasedRevenue.Value;
				currentTrader.ReleasedRevenue = releasedRevenue;
				long? quantity = currentTrader.coinOwnByTheTrader[currentCoinSymbol].getVolume();
				currentTrader.coinOwnByTheTrader[currentCoinSymbol].setVolume(quantity.Value - this.sell.Quantity);
				this.sell.Coin.Volume = sell.Coin.Volume + sell.Quantity;
				Monitor.PulseAll(this.sell.Coin);
				this.sell.Coin.Status = CoinStatus.AVAILABLE;
				this.sell.Status = TransactionStatus.COMPLETED;
			}
		}
	}


}