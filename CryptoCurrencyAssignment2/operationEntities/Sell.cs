namespace com.assignment2.operationEntities
{
	using Coin = com.assignment2.entities.Coin;
	using TransactionStatus = com.assignment2.enums.TransactionStatus;
	using CoinNotFoundException = com.assignment2.exceptions.CoinNotFoundException;
	using Transaction = com.assignment2.transactions.Transaction;
	using NotNull = org.jetbrains.annotations.NotNull;
	using JSONObject = org.json.simple.JSONObject;

	/// <summary>
	/// Act as a container for sell transaction i.e. it holds all the properties that a sell Transaction have.
	/// </summary>
	public class Sell
	{
		private Coin coin;
		private long quantity;
		private string walletAddress;
		private TransactionStatus status;

		/// <param name="obj"> Require a transaction JSONObject to parse and
		///            set all the data of sell like Coin, quantity and walletAddress. </param>
		/// <exception cref="CoinNotFoundException"> When coin is not present on which sell transaction will be done. </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public Sell(@NotNull JSONObject obj) throws com.assignment2.exceptions.CoinNotFoundException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public Sell(JSONObject obj)
		{
			if (Transaction.symbolWiseCoinMap.ContainsKey((string) obj.get("coin")))
			{
				this.coin = Transaction.symbolWiseCoinMap[(string) obj.get("coin")];
			}
			else
			{
				throw new CoinNotFoundException("Coin not Found for the given Symbol: " + obj.get("coin"));
			}
			this.walletAddress = (string) obj.get("wallet_address");
			this.quantity = ((long?) obj.get("quantity")).Value;
			this.status = TransactionStatus.IN_PROGRESS;
		}

		/// <returns> Return the Status of the sell transaction </returns>
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


		/// <returns> Returns Coin object on which sell transaction will be done. </returns>
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


		/// <returns> Return long Value i.e. the volume of coin that will sell. </returns>
		public virtual long Quantity
		{
			get
			{
				return quantity;
			}
			set
			{
				this.quantity = value;
			}
		}


		/// <returns> Return String value i.e. the walletAddress of the trader performing sell operation. </returns>
		public virtual string WalletAddress
		{
			get
			{
				return walletAddress;
			}
			set
			{
				this.walletAddress = value;
			}
		}


		/// <returns> Return String that contains all the Details of the current sell Transaction. </returns>
		public override string ToString()
		{
			return "Sell{" + "coin=" + coin + ", quantity=" + quantity + ", walletAddress='" + walletAddress + '\'' + ", status=" + status + '}';
		}
	}

}