using System;

namespace com.assignment2.exceptions
{
	/// <summary>
	/// Contains TransactionTypeNotFoundException Exception
	/// </summary>
	public class TransactionTypeNotFoundException : Exception
	{

		/// <param name="str"> Require String value i.e. Message to throw when TransactionTypeNotFoundException Exception occur. </param>
		public TransactionTypeNotFoundException(string str) : base(str)
		{
		}
	}

}