using System;

namespace com.assignment2.exceptions
{
	/// <summary>
	/// Contains the Coin not Found Exception.
	/// </summary>
	public class CoinNotFoundException : Exception
	{
		/// <param name="str"> Require String value i.e. Message to throw when CoinNotFoundException Exception occur. </param>
		public CoinNotFoundException(string str) : base(str)
		{
		}
	}
}