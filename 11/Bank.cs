using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace lab
{
    class Bank
    {

		public enum Type
		{
			Current,
			Saving
		}

		private int index;
		private Type accountType;
		private int balance;

		static int indexer = 0;

		public Bank()
		{
			index = indexer++;
		}

		public Bank(int balance)
		{
			index = indexer++;
			this.balance = balance;
		}

		public Bank(Type accountType)
		{
			index = indexer++;
			this.accountType = accountType;
		}

		public Bank(Type accountType, int balance) : this(accountType)
		{
			this.balance = balance;
		}

		public bool Withdraw(int sum)
		{
			if (sum <= balance)
			{
				balance -= sum;
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool PutInBalance(int sum)
		{
			if (sum > 0)
			{
				balance += sum;
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool MakeTransfer(Bank accPaymentReceiver, int sum)
		{
			if (Withdraw(sum))
			{
				accPaymentReceiver.PutInBalance(sum);
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool operator ==(Bank bankAccount1, Bank bankAccount2)
		{
			return bankAccount1.accountType == bankAccount2.accountType
				&& bankAccount1.balance == bankAccount2.balance;
		}

		public static bool operator !=(Bank bankAccount1, Bank bankAccount2)
		{
			return !(bankAccount1.accountType == bankAccount2.accountType
				&& bankAccount1.balance == bankAccount2.balance);
		}

		public override bool Equals(object obj)
		{
			if (obj is Bank)
			{
				return this == (obj as Bank);
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public override string ToString()
		{
			return $"{index}. Тип: {accountType}, баланс: {balance}";
		}
	}

}

