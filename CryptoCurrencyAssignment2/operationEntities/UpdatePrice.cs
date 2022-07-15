namespace CryptoCurrencyAssignment2.operationEntities
{
	using Coin = CryptoCurrencyAssignment2.entities.Coin;
	using Transaction = CryptoCurrencyAssignment2.transactions.Transaction;
	using JSONObject = org.json.simple.JSONObject;


	public class UpdatePrice
	{
		private double price;
	

	public UpdatePrice(JSONObject obj)
		{
			if (Transaction.symbolWiseCoinMap.ContainsKey((string) obj.get("coin")))
			{
				this.coin = Transaction.symbolWiseCoinMap[(string) obj.get("coin")];
			}
			this.price = ((double?) obj.get("price")).Value;
			this.status = "IN_PROGRESS";
		}


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
	

	public override string ToString()
		{
			return "UpdatePrice{" + "price=" + price + ", coin=" + coin + '}';
		}
	}

}