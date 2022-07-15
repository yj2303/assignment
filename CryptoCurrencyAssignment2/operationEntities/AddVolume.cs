namespace com.assignment2.operationEntities
{
	using Coin = com.assignment2.entities.Coin;
	using TransactionStatus = com.assignment2.enums.TransactionStatus;
	using CoinNotFoundException = com.assignment2.exceptions.CoinNotFoundException;
	using Transaction = com.assignment2.transactions.Transaction;
	using NotNull = org.jetbrains.annotations.NotNull;
	using JSONObject = org.json.simple.JSONObject;

	/// <summary>
	/// Act as a container for AddVolume transaction i.e. it holds all the properties that a addVolume Transaction have.
	/// </summary>
	public class AddVolume
	{
		private long volume;
		private Coin coin;
		private TransactionStatus status;

		/// <param name="obj"> Require a transaction JSONObject to parse and set all the data of the AddVolume like Coin and quantity. </param>
		/// <exception cref="CoinNotFoundException"> When coin is not present on which addVolume transaction will be done. </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public AddVolume(@NotNull JSONObject obj) throws com.assignment2.exceptions.CoinNotFoundException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public AddVolume(JSONObject obj)
		{
			this.volume = ((long?) obj.get("volume")).Value;
			if (Transaction.symbolWiseCoinMap.ContainsKey((string) obj.get("coin")))
			{
				this.coin = Transaction.symbolWiseCoinMap[(string) obj.get("coin")];
			}
			else
			{
				throw new CoinNotFoundException("Coin not Found for the given Symbol: " + obj.get("coin"));
			}
			status = TransactionStatus.IN_PROGRESS;

		}

		/// <returns> Return the Status of the addVolume transaction </returns>
		public virtual TransactionStatus Status
		{
			get
			{
				return status;
			}
			set
			{
				this.status = value;
			}
		}


		/// <returns> Return long Value i.e. the volume need to be added in the coin. </returns>
		public virtual long Volume
		{
			get
			{
				return volume;
			}
			set
			{
				this.volume = value;
			}
		}


		/// <returns> Returns Coin object on which transaction will be done. </returns>
		public virtual Coin Coin
		{
			get
			{
				return coin;
			}
			set
			{
				this.coin = value;
			}
		}


		/// <returns> Returns a String having all the Details of the current AddVolume Transaction. </returns>
		public override string ToString()
		{
			return "AddVolume{" + "volume=" + volume + ", coin=" + coin + ", status='" + status + '\'' + '}';
		}
	}

}