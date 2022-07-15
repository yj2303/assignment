using System.Collections.Generic;

namespace CryptoCurrencyAssignment2
{
	using Coin = CryptoCurrencyAssignment2.entities.Coin;
	

	
	public class SortByPrice : IComparer<Coin>
	{

	public virtual int Compare(Coin coin1, Coin coin2)
		{
			return coin1.getPrice().CompareTo(coin2.getPrice());

		}
	}

}