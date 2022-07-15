namespace com.assignment2.operationEntities
{
	using Coin = com.assignment2.entities.Coin;
	using TransactionStatus = com.assignment2.enums.TransactionStatus;
	using CoinNotFoundException = com.assignment2.exceptions.CoinNotFoundException;
	using Transaction = com.assignment2.transactions.Transaction;
	using NotNull = org.jetbrains.annotations.NotNull;
	using JSONObject = org.json.simple.JSONObject;

	/// <summary>
	/// Act as a container for UpdatePrice transaction i.e. it holds all the properties that a UpdatePrice Transaction have.
	/// </summary>
	public class UpdatePrice
	{
		private double price;
		private Coin coin;
		private TransactionStatus status;

		/// <param name="obj"> Require a transaction JSONObject to parse and
		///            set all the data of UpdatePrice like Coin, Price . </param>
		/// <exception cref="CoinNotFoundException"> When coin is not present on which UpdatePrice transaction will be done. </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public UpdatePrice(@NotNull JSONObject obj) throws com.assignment2.exceptions.CoinNotFoundException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public UpdatePrice(JSONObject obj)
		{
			if (Transaction.symbolWiseCoinMap.ContainsKey((string) obj.get("coin")))
			{
				this.coin = Transaction.symbolWiseCoinMap[(string) obj.get("coin")];
			}
			else
			{
				throw new CoinNotFoundException("Coin not Found for the given Symbol: " + obj.get("coin"));
			}
			this.price = ((double?) obj.get("price")).Value;
			this.status = TransactionStatus.IN_PROGRESS;
		}

		/// <returns> Return the Status of the UpdatePrice transaction. </returns>
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


		/// <returns> Return double value i.e. the price which is need to be updated for the given coin. </returns>
		public virtual double Price
		{
			get
			{
				return price;
			}
			set
			{
				this.price = value;
			}
		}


		/// <returns> Returns Coin object on which UpdatePrice transaction will be done. </returns>
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


		/// <returns> Return String that contains all the Details of the current updatePrice Transaction. </returns>
		public override string ToString()
		{
			return "UpdatePrice{" + "price=" + price + ", coin=" + coin + '}';
		}
	}

}