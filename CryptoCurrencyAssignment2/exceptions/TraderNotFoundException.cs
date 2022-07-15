using System;

namespace com.assignment2.exceptions
{
	/// <summary>
	/// Contains the TraderNotFoundException Exception
	/// </summary>
	public class TraderNotFoundException : Exception
	{
		/// <param name="str"> Require String value i.e. Message to throw when TraderNotFoundException Exception occur. </param>
		public TraderNotFoundException(string str) : base(str)
		{
		}
	}
}