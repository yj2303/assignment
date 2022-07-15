using System.Collections.Generic;

namespace com.assignment2.comparators
{
	using Trader = com.assignment2.entities.Trader;
	using NotNull = org.jetbrains.annotations.NotNull;

	/// <summary>
	/// Comparator to compare trader on the basis of profit.
	/// </summary>
	public class SortByProfit : IComparer<Trader>
	{

		/// <param name="trader1"> first Trader </param>
		/// <param name="trader2"> Second Trader </param>
		/// <returns> Return 1.0 if trader1's profit greater than trader2's profit else return 0.0; </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public int compare(@NotNull Trader trader1, @NotNull Trader trader2)
		public virtual int Compare(Trader trader1, Trader trader2)
		{
			return trader1.getProfit().CompareTo(trader2.getProfit());

		}
	}
}