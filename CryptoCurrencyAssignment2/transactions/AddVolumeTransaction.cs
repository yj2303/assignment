using System;
using System.Threading;

namespace com.assignment2.transactions
{
	using HashFun = com.assignment2.callingClasses.HashFun;
	using CoinStatus = com.assignment2.enums.CoinStatus;
	using TransactionStatus = com.assignment2.enums.TransactionStatus;
	using AddVolume = com.assignment2.operationEntities.AddVolume;

	/// <summary>
	/// Having all the functionalities of Add volume Transaction thread.
	/// </summary>
	public class AddVolumeTransaction : Transaction
	{
		private readonly AddVolume addVolume;


		/// <param name="addVolume"> Require AddVolume object to get the information of the Add Volume Transaction. </param>
		public AddVolumeTransaction(AddVolume addVolume)
		{
			this.addVolume = addVolume;
		}

		/// <summary>
		/// Implemented the run function for AddVolume Transaction.
		/// first it checks that the coin is AVAILABLE or not
		/// i.e. is it occupied by some other thread or not.
		/// if occupied then current thread goes to wait state.
		/// if the coin is available then the current thread make the coin status not available so that no other thread
		/// can access the coin will it is working
		/// after that it perform the AddVolume operation
		/// after that it notify all the other thread and then make the coin status available.
		/// </summary>
		public override void run()
		{
			lock (this.addVolume.Coin)
			{
				while (this.addVolume.Coin.Status == CoinStatus.NOT_AVAILABLE)
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
				this.addVolume.Coin.Status = CoinStatus.NOT_AVAILABLE;
				TransactionId = HashFun.BlockHash;
				this.addVolume.Coin.Volume = addVolume.Coin.Volume + addVolume.Volume;
				Monitor.PulseAll(this.addVolume.Coin);
				this.addVolume.Coin.Status = CoinStatus.AVAILABLE;
				this.addVolume.Status = TransactionStatus.COMPLETED;
			}

		}
	}

}