using System;

namespace com.assignment2.exceptions
{
	/// <summary>
	/// Contains the Not in Range Exception.
	/// </summary>
	public class NotInRangeException : Exception
	{

		/// <param name="str"> Require String value i.e. Message to throw when NotInRangeException Exception occur. </param>
		public NotInRangeException(string str) : base(str)
		{
		}
	}

}