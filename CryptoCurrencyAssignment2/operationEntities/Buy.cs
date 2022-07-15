namespace CryptoCurrencyAssignment2.operationEntities
{
	using Coin = CryptoCurrencyAssignment2.entities.Coin;
	using Transaction = CryptoCurrencyAssignment2.transactions.Transaction;
	using JSONObject = org.json.simple.JSONObject;

	
	public class Buy
	{
		private Coin coin;
		private long quantity;
		private string walletAddress;

		public Buy(JSONObject obj)
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
			this.status = "IN_PROGRESS";
		}
	




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

	public override string ToString()
		{
			return "Buy{" + "coin=" + coin + ", quantity=" + quantity + ", walletAddress='" + walletAddress + '\'' + ", status=" + status + '}';
		}
	}

}