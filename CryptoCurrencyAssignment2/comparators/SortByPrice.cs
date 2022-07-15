using System.Collections.Generic;

namespace com.assignment2.comparators
{
	using Coin = com.assignment2.entities.Coin;
	using NotNull = org.jetbrains.annotations.NotNull;

	/// <summary>
	/// Comparator to compare the coin on the basis of price.
	/// </summary>
	public class SortByPrice : IComparer<Coin>
	{


		/// <param name="coin1"> first coin </param>
		/// <param name="coin2"> Second coin </param>
		/// <returns> return 1 if coin1 price is greater than coin2 price else return 0. </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public int compare(@NotNull Coin coin1, @NotNull Coin coin2)
		public virtual int Compare(Coin coin1, Coin coin2)
		{
			return coin1.getPrice().CompareTo(coin2.getPrice());

		}
	}

}