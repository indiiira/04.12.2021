using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class Account
    {

	
			public enum Type
			{
				Current,
				Saving
			}

			private int index;
			private Type accountType;
			private int balance;
			private string cardHolder;

			static int indexer = 0;

			public int Index { get => index; }
			public Type AccountType { get => accountType; }
			public int Balance { get => balance; }
			public string CardHolder { get => cardHolder; set => cardHolder = value; }

			private BankTransaction[] bankTransactions;
			static private int transIndex = 0;

			public BankTransaction this[int index]
			{
				get
				{
					return bankTransactions[index];
				}
				set
				{
					bankTransactions[index] = value;
				}
			}

			public bool Withdraw(int sum)
			{
				if (sum <= balance)
				{
					balance -= sum;
					bankTransactions[transIndex++] = new BankTransaction(-sum);
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
					bankTransactions[transIndex++] = new BankTransaction(sum);
					return true;
				}
				else
				{
					return false;
				}
			}
			public bool MakeTransfer(Account accPaymentReceiver, int sum)
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

			public Account()
			{
				index = indexer++;
				bankTransactions = new BankTransaction[20];
			}

			public Account(int balance)
			{
				index = indexer++;
				this.balance = balance;
				bankTransactions = new BankTransaction[20];
			}

			public Account(Type accountType)
			{
				index = indexer++;
				this.accountType = accountType;
				bankTransactions = new BankTransaction[20];
			}

			public Account(Type accountType, int balance) : this(accountType)
			{
				this.balance = balance;
			}

			public static bool operator ==(Account bankAccount1, Account bankAccount2)
			{
				return bankAccount1.AccountType == bankAccount2.AccountType
					&& bankAccount1.Balance == bankAccount2.Balance;
			}

			public static bool operator !=(Account bankAccount1, Account bankAccount2)
			{
				return !(bankAccount1.AccountType == bankAccount2.AccountType
					&& bankAccount1.Balance == bankAccount2.Balance);
			}

			public override bool Equals(object obj)
			{
				if (obj is Account)
				{
					return this == (obj as Account);
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
				return $"{Index}. Тип: {AccountType}, баланс: {Balance}";
			}
		}
	}


