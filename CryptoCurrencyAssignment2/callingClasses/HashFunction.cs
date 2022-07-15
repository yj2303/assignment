using System;
using System.Text;

namespace CryptoCurrencyAssignment2
{
	
	public class HashFunction
	{
		
		public static string BlockHash
		{
			get
			{
				string GroupOfChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
				StringBuilder Hash = new StringBuilder();
				Random rnd = new Random();
				for (double i = 0;i < 199999999; i++)
				{
					i = i;
				}
				while (Hash.Length < 128)
				{
					int ind = (int)(rnd.nextFloat() * GroupOfChars.Length);
				    Hash.Append(GroupOfChars[ind]);
				}
				string hashCode = Hash.ToString();
				return "0x" + hashCode.ToLower();
			}
		}

	}

}