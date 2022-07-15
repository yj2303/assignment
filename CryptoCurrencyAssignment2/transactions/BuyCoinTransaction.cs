using System;
using System.Threading;

namespace com.assignment2.transactions
{
	using HashFun = com.assignment2.callingClasses.HashFun;
	using Coin = com.assignment2.entities.Coin;
	using Trader = com.assignment2.entities.Trader;
	using CoinStatus = com.assignment2.enums.CoinStatus;
	using TransactionStatus = com.assignment2.enums.TransactionStatus;
	using Buy = com.assignment2.operationEntities.Buy;

	/// <summary>
	/// Having all the functionalities of buyCoin Transaction thread.
	/// </summary>
	public class BuyCoinTransaction : Transaction
	{
		private readonly Buy buy;

		/// <param name="buy"> Require buy object to get the information of the buy Transaction. </param>
		public BuyCoinTransaction(Buy buy)
		{
			this.buy = buy;
		}

		/// <summary>
		/// Implemented the run function for buy Transaction.
		/// first it checks that the coin is AVAILABLE or not
		/// i.e. is it occupied by some other thread or not.
		/// if occupied then current thread goes to wait state.
		/// if the coin is available then the current thread make the coin status not available so that no other thread
		/// can access the coin will it is working
		/// next it checks that the trader owns the coin or not if own it update the vale of the coin own buy them
		/// else it creates a new coin object and assign the values of the buy transaction and add it in the hashmap of
		/// coinOwnByTrader
		/// after that it perform the buy operation
		/// after that it notify all the other thread and then make the coin status available.
		/// </summary>
		public override void run()
		{

			lock (this.buy.Coin)
			{
				while (this.buy.Coin.Status == CoinStatus.NOT_AVAILABLE || this.buy.Coin.Volume < this.buy.Quantity)
				{
					try
					{
						Monitor.Wait(this.buy.Coin);
					}
					catch (InterruptedException e)
					{
						Console.WriteLine(e.ToString());
						Console.Write(e.StackTrace);
					}
				}
				this.buy.Coin.Status = CoinStatus.NOT_AVAILABLE;
				TransactionId = HashFun.BlockHash;

				Trader currentTrader = traderMap[this.buy.WalletAddress];
				string currentCoinSymbol = this.buy.Coin.Symbol;

				if (currentTrader.coinOwnByTheTrader.ContainsKey(currentCoinSymbol))
				{

					long vol = currentTrader.coinOwnByTheTrader[currentCoinSymbol].getVolume() + this.buy.Quantity;

					currentTrader.coinOwnByTheTrader[currentCoinSymbol].setVolume(vol);

					double? expense = currentTrader.Expense.Value + this.buy.Quantity * this.buy.Coin.Price;
					currentTrader.Expense = expense;
				}
				else
				{
					Coin coin = new Coin();
					coin.Name = this.buy.Coin.Name;
					coin.Symbol = currentCoinSymbol;
					coin.Volume = this.buy.Quantity;
					coin.Price = this.buy.Coin.Price;
					coin.Rank = this.buy.Coin.Rank;
					coin.Status = CoinStatus.AVAILABLE;

					currentTrader.coinOwnByTheTrader[coin.Symbol] = coin;
					double? expense = this.buy.Quantity * this.buy.Coin.Price;
					currentTrader.Expense = expense;
				}
				this.buy.Coin.Volume = buy.Coin.Volume - buy.Quantity;
				Monitor.PulseAll(this.buy.Coin);
				this.buy.Coin.Status = CoinStatus.AVAILABLE;
				this.buy.Status = TransactionStatus.COMPLETED;
			}

		}


	}

}