using System;
using System.IO;

namespace com.assignment2.jsonReader
{
	using TransactionType = com.assignment2.enums.TransactionType;
	using TransactionTypeNotFoundException = com.assignment2.exceptions.TransactionTypeNotFoundException;
	using NotNull = org.jetbrains.annotations.NotNull;
	using Nullable = org.jetbrains.annotations.Nullable;
	using JSONArray = org.json.simple.JSONArray;
	using JSONObject = org.json.simple.JSONObject;
	using JSONParser = org.json.simple.parser.JSONParser;
	using ParseException = org.json.simple.parser.ParseException;

	/// <summary>
	/// Contains all the Functionalities of the JSON Object Reader.
	/// </summary>
	public class JSONTransactionFileReader
	{

		/// <param name="path"> Path where file is located. </param>
		/// <returns> JSONArray have all the transactions in the file. </returns>
		public static JSONArray JSONFileReader(string path)
		{
			JSONParser jsonParser = new JSONParser();
			JSONArray transaction = new JSONArray();
			try
			{
					using (StreamReader reader = new StreamReader(path))
					{
					object obj = jsonParser.parse(reader);
					transaction = (JSONArray) obj;
					}
			}
			catch (Exception e) when (e is IOException || e is ParseException)
			{
				Console.WriteLine(e.getMessage());
			}
			return transaction;
		}

		/// <param name="transaction"> Require JSONObject to parse it. </param>
		/// <returns> Type of the Transaction in the JSONObject. </returns>
		/// <exception cref="TransactionTypeNotFoundException"> when type is not among the 4 transaction type
		/// i.e. BUY , SELL, UPDATE_PRICE, ADD_VOLUME. </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @Nullable TransactionType parseTransactionObjectType(@NotNull JSONObject transaction) throws com.assignment2.exceptions.TransactionTypeNotFoundException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public static TransactionType parseTransactionObjectType(JSONObject transaction)
		{
			string type = (string) transaction.get("type");
			if (type.Equals("SELL"))
			{
				return TransactionType.SELL;
			}
			else if (type.Equals("BUY"))
			{
				return TransactionType.BUY;
			}
			else if (type.Equals("UPDATE_PRICE"))
			{
				return TransactionType.UPDATE_PRICE;
			}
			else if (type.Equals("ADD_VOLUME"))
			{
				return TransactionType.ADD_VOLUME;
			}
			else
			{
				throw new TransactionTypeNotFoundException("Invalid Transaction Type!");
			}
		}

		/// <param name="transaction"> Require a JSONObject of Transaction having both type and Data. </param>
		/// <returns> JSONObject having the data part of the Transaction JSONObject. </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static org.json.simple.JSONObject parseTransactionObjectDetails(@NotNull JSONObject transaction)
		public static JSONObject parseTransactionObjectDetails(JSONObject transaction)
		{
			return (JSONObject) transaction.get("data");
		}

	}

}