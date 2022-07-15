using System;
using System.Text;

namespace com.assignment2.callingClasses
{
	using NotNull = org.jetbrains.annotations.NotNull;

	/// <summary>
	/// Introducing delay mimicking complex
	/// calculation being performed.
	/// </summary>
	public class HashFun
	{
		/// <returns> Mimicking the delay due to transaction. </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NotNull String getBlockHash()
		public static string BlockHash
		{
			get
			{
				string SALTCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
				StringBuilder transactionHash = new StringBuilder();
				Random rnd = new Random();
				for (double i = 0;i < 199999999; i++)
				{
					i = i;
				}
				while (transactionHash.Length < 128)
				{
					int index = (int)(rnd.nextFloat() * SALTCHARS.Length);
					transactionHash.Append(SALTCHARS[index]);
				}
				string hashCode = transactionHash.ToString();
				return "0x" + hashCode.ToLower();
			}
		}

	}

}