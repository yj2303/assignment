using System;
using System.Threading;

namespace CryptoCurrencyAssignment2.transactions
{
	using HashFun = CryptoCurrencyAssignment2.callingClasses.HashFun;
	using AddVolume = CryptoCurrencyAssignment2.operationEntities.AddVolume;

	public class AddVolumeTransaction : Transaction
	{
		private readonly AddVolume addVolume;


			public AddVolumeTransaction(AddVolume addVolume)
		{
			this.addVolume = addVolume;
		}
	public override void run()
		{
			lock (this.addVolume.Coin)
			{
				while (this.addVolume.Coin.Status == "NOT_AVAILABLE")
				{
					try
					{
						Monitor.Wait(this.addVolume.Coin);
					}
					catch (InterruptedException e)
					{
						Console.WriteLine(e.ToString());
						Console.Write(e.StackTrace);
					}
				}
				this.addVolume.Coin.Status = "NOT_AVAILABLE";
				TransactionId = HashFun.BlockHash;
				this.addVolume.Coin.Volume = addVolume.Coin.Volume + addVolume.Volume;
				Monitor.PulseAll(this.addVolume.Coin);
				this.addVolume.Coin.Status = "AVAILABLE";
				this.addVolume.Status = "COMPLETED";
			}

		}
	}

}