namespace com.assignment2.entities
{
	using CoinStatus = com.assignment2.enums.CoinStatus;
	using NotNull = org.jetbrains.annotations.NotNull;

	/// <summary>
	/// Contains the all the details of a coin including rank, symbol, name, price and the volume.
	/// </summary>
	public class Coin
	{

		private int rank;
		private string name;
		private string symbol;
		private double price;
		private long volume;
		private CoinStatus status;

		/// <returns> Gives the Status of the coin. </returns>
		public virtual CoinStatus Status
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


		/// <returns> return integer i.e. rank of the coin in the Market. </returns>
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


		/// <returns> Return String i.e. name of the coin. </returns>
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


		/// <returns> Return String value i.e. current Coin's symbol. </returns>
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


		/// <returns> Return double value i.e. price of the current coin. </returns>
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


		/// <returns> Return long value i.e. volume of the current coin. </returns>
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


		/// <param name="o"> Coin object which we want to compare current coin with. </param>
		/// <returns> Return boolean value true if the coins have all the properties(like name,price etc.) similar.
		/// else return false. </returns>
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

		/// <returns> Returns the integer value that will be calculated on the basis of price and volume. </returns>
		public override int GetHashCode()
		{
			return (int)(price / volume);
		}

		/// <param name="coin"> Coin object which we want to compare current coin with. </param>
		/// <returns> if the hashcode of both the coins are equal then it will return 0 if current
		/// coin have greater has code than other return 1 else return -1; </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public int compare(@NotNull Coin coin)
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

		/// <returns> Return String which will have all the details of the current coin. </returns>
		public override string ToString()
		{
			return "Coin{" + "rank=" + rank + ", name='" + name + '\'' + ", symbol='" + symbol + '\'' + ", price=" + price + ", volume=" + volume + '}';
		}
	}

}