namespace CryptoCurrencyAssignment2.operationEntities
{
	using Coin = CryptoCurrencyAssignment2.entities.Coin;
	using Transaction = CryptoCurrencyAssignment2.transactions.Transaction;
	using NotNull = org.jetbrains.annotations.NotNull;
	using JSONObject = org.json.simple.JSONObject;

		public class AddVolume
	{
		private long volume;
		

			public AddVolume(JSONObject obj)
		{
			this.volume = ((long?) obj.get("volume")).Value;
			if (Transaction.symbolWiseCoinMap.ContainsKey((string) obj.get("coin")))
			{
				this.coin = Transaction.symbolWiseCoinMap[(string) obj.get("coin")];
			}
			
			status = "IN_PROGRESS";

		}

			

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

			public override string ToString()
		{
			return "AddVolume{" + "volume=" + volume + ", coin=" + coin + ", status='" + status + '\'' + '}';
		}
	}

}