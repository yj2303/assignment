using System;
using System.Threading;

namespace CryptoCurrencyAssignment2.transactions
{
	using HashFun = CryptoCurrencyAssignment2.callingClasses.HashFun;
	using Coin = CryptoCurrencyAssignment2.entities.Coin;
	using Trader = CryptoCurrencyAssignment2.entities.Trader;
	using Buy = CryptoCurrencyAssignment2.operationEntities.Buy;


	public class BuyCoinTransaction : Transaction
	{
		private readonly Buy buy;

			public BuyCoinTransaction(Buy buy)
		{
			this.buy = buy;
		}
	public override void run()
		{

			lock (this.buy.Coin)
			{
				while (this.buy.Coin.Status =="NOT_AVAILABLE" || this.buy.Coin.Volume < this.buy.Quantity)
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
				this.buy.Coin.Status = "NOT_AVAILABLE";
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
					coin.Status = "AVAILABLE";

					currentTrader.coinOwnByTheTrader[coin.Symbol] = coin;
					double? expense = this.buy.Quantity * this.buy.Coin.Price;
					currentTrader.Expense = expense;
				}
				this.buy.Coin.Volume = buy.Coin.Volume - buy.Quantity;
				Monitor.PulseAll(this.buy.Coin);
				this.buy.Coin.Status = "AVAILABLE";
				this.buy.Status = "COMPLETED";
			}

		}


	}

}