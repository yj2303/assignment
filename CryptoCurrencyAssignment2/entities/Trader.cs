using System.Collections.Generic;

namespace CryptoCurrencyAssignment2.entities
{
	using Transaction = CryptoCurrencyAssignment2.transactions.Transaction;



	public class Trader
	{
		private string firstName;
		private string lastName;
		private string phone;
		private string walletAddress;
		private string fullName = "";
		
		private double? expense = 0.0;
		private double? releasedRevenue = 0.0;
		private double? profit = 0.0;
		private double? unReleasedRevenue = 0.0;
		public Dictionary<string, Coin> coinOwnByTheTrader = new Dictionary<string, Coin>();
		public virtual string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				this.firstName = value;
			}
		}


		public virtual string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				this.lastName = value;
			}
		}


		public virtual string Phone
		{
			get
			{
				return phone;
			}
			set
			{
				this.phone = value;
			}
		}


		public virtual string WalletAddress
		{
			get
			{
				return walletAddress;
			}
			set
			{
				this.walletAddress = value;
			}
		}


		public virtual string FullName
		{
			get
			{
				return firstName + " " + lastName;
			}
			set
			{
				this.fullName = value;
			}
		}

	public virtual double? Expense
		{
			get
			{
				return expense;
			}
			set
			{
				this.expense = value;
			}
		}

	public virtual double? ReleasedRevenue
		{
			get
			{
				return releasedRevenue;
			}
			set
			{
				this.releasedRevenue = value;
			}
		}

	public virtual double? Profit
		{
			get
			{
				return ReleasedRevenue.Value + UnReleasedRevenue.Value - Expense.Value;
			}
		}
	public virtual void setProfit()
		{
			this.profit = ReleasedRevenue.Value + UnReleasedRevenue.Value - Expense.Value;
		}
	public virtual double? UnReleasedRevenue
		{
			get
			{
				double val = 0.0;
				foreach (string coinSymbol in coinOwnByTheTrader.Keys)
				{
					val += Transaction.symbolWiseCoinMap[coinSymbol].getPrice() * coinOwnByTheTrader[coinSymbol].Volume;
				}
				this.unReleasedRevenue = val;
				return unReleasedRevenue;
			}
		}
	public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (!(o is Trader))
			{
				return false;
			}
			Trader trader = (Trader) o;
			return firstName.Equals(trader.firstName) && lastName.Equals(trader.lastName) && phone.Equals(trader.phone) && walletAddress.Equals(trader.walletAddress);
		}
	    public override int GetHashCode()
		{
			return Objects.hash(firstName, lastName, phone, walletAddress);
		}
	    public override string ToString()
		{
			return "Trader{" + "firstName='" + firstName + '\'' + ", lastName='" + lastName + '\'' + ", phone='" + phone + '\'' + ", walletAddress='" + walletAddress + '\'' + ", fullName='" + FullName + '\'' + ", expense=" + expense + ", releasedRevenue=" + ReleasedRevenue + ", profit=" + Profit + ", unReleasedRevenue=" + UnReleasedRevenue + ", coinOwnByTheTrader=" + coinOwnByTheTrader + '}';
		}
	}

}