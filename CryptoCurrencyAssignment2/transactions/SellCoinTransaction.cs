using System;
using System.Threading;

namespace CryptoCurrencyAssignment2.transactions
{
	using HashFun = CryptoCurrencyAssignment2.callingClasses.HashFun;
	using Trader = CryptoCurrencyAssignment2.entities.Trader;
	using Sell = CryptoCurrencyAssignment2.operationEntities.Sell;


	
	public class SellCoinTransaction : Transaction
	{

		private readonly Sell sell;

			public SellCoinTransaction(Sell sell)
		{
			this.sell = sell;
		}
	public override void run()
		{

			Trader currentTrader = traderMap[this.sell.WalletAddress];
			string currentCoinSymbol = this.sell.Coin.Symbol;
			if (!currentTrader.coinOwnByTheTrader.ContainsKey(currentCoinSymbol) || currentTrader.coinOwnByTheTrader[currentCoinSymbol].getVolume() < this.sell.Quantity)
			{
				this.sell.Status = "DECLINED";
				return;
			}
			lock (this.sell.Coin)
			{
				while (this.sell.Coin.Status =="NOT_AVAILABLE")
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
				this.sell.Coin.Status = "NOT_AVAILABLE";
				TransactionId = HashFun.BlockHash;

				double? releasedRevenue = this.sell.Coin.Price * this.sell.Quantity + currentTrader.ReleasedRevenue.Value;
				currentTrader.ReleasedRevenue = releasedRevenue;
				long? quantity = currentTrader.coinOwnByTheTrader[currentCoinSymbol].getVolume();
				currentTrader.coinOwnByTheTrader[currentCoinSymbol].setVolume(quantity.Value - this.sell.Quantity);
				this.sell.Coin.Volume = sell.Coin.Volume + sell.Quantity;
				Monitor.PulseAll(this.sell.Coin);
				this.sell.Coin.Status = "AVAILABLE";
				this.sell.Status = "COMPLETED";
			}
		}
	}


}