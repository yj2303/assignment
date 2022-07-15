namespace CryptoCurrencyAssignment2.entities
{


	public class Coin
	{

		private int rank;
		private string name;
		private string symbol;
		private double price;
		private long volume;
		public virtual int Rank
		{
			get
			{
				return rank;
			}
			set
			{
				this.rank = value;
			}
		}


		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
			}
		}


		public virtual string Symbol
		{
			get
			{
				return symbol;
			}
			set
			{
				this.symbol = value;
			}
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

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (!(o is Coin))
			{
				return false;
			}
			Coin coin = (Coin) o;
			return rank == coin.rank && coin.price.CompareTo(price) == 0 && volume == coin.volume && Objects.equals(name, coin.name) && Objects.equals(symbol, coin.symbol);
		}
	public override int GetHashCode()
		{
			return (int)(price / volume);
		}
	public virtual int compare(Coin coin)
		{
			if (this.GetHashCode() > coin.GetHashCode())
			{
				return 1;
			}
			else if (this.GetHashCode() < coin.GetHashCode())
			{
				return -1;
			}
			else
			{
				return 1;
			}
		}
	public override string ToString()
		{
			return "Coin{" + "rank=" + rank + ", name='" + name + '\'' + ", symbol='" + symbol + '\'' + ", price=" + price + ", volume=" + volume + '}';
		}
	}

}