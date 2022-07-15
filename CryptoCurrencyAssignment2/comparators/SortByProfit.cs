using System.Collections.Generic;

namespace CryptoCurrencyAssignment2
{
	using Trader = CryptoCurrencyAssignment2.entities.Trader;


	
	public class SortByProfit : IComparer<Trader>
	{
	public virtual int Compare(Trader trader1, Trader trader2)
		{
			return trader1.getProfit().CompareTo(trader2.getProfit());

		}
	}
}