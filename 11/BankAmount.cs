using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
namespace lab
{
     class BankAmount

    {
        public enum BankAccountType
        {
            Save = 1,
            Current
        }
        public void GetOnBalance(decimal money)
        {
            bool flag = this._bankType == BankAccountType.Save;
            if (flag)
            {
                bool flag2 = money > 0m;
                if (flag2)
                {
                    bankTransactions.Enqueue(new BankTransaction(money, BankTransaction.TypeTransaction.Replenishment));
                    this._balanceSave += money;
                }
                else
                {
                    Console.WriteLine("Вы не можете положить отрицательное значение денег");
                }
                Console.WriteLine("Текущий баланс " + this._balanceSave.ToString());
            }
            else
            {
                bool flag3 = money > 0m;
                if (flag3)
                {
                    this._balanceCurrent += money;
                    bankTransactions.Enqueue(new BankTransaction(money, BankTransaction.TypeTransaction.Replenishment));
                }
                else
                {
                    Console.WriteLine("Вы не можете положить отрицательное значение денег");
                }
                Console.WriteLine("Текущий баланс " + this._balanceCurrent.ToString());
            }
        }
        public void GetFromBalance(decimal money)
        {
            bool flag = this._bankType == BankAccountType.Save;
            if (flag)
            {
                bool flag2 = money <= this._balanceSave && money > 0m;
                if (flag2)
                {
                    this._balanceSave -= money;
                    bankTransactions.Enqueue(new BankTransaction(money, BankTransaction.TypeTransaction.Withdrawal));
                }
                else
                {
                    Console.WriteLine("Вы не можете снять отрицательное значение денег/недостаточный баланс");
                }
                Console.WriteLine("Текущий баланс " + this._balanceSave.ToString());
            }
            else
            {
                bool flag3 = money <= this._balanceCurrent && money > 0m;
                if (flag3)
                {
                    bankTransactions.Enqueue(new BankTransaction(money, BankTransaction.TypeTransaction.Withdrawal));
                    this._balanceCurrent -= money;
                }
                else
                {
                    Console.WriteLine("Вы не можете снять отрицательное значение денег/недостаточный баланс");
                }
                Console.WriteLine("Текущий баланс " + this._balanceCurrent.ToString());
            }
        }
        public void SwapBankTypes()
        {
            bool flag = this._bankType == BankAccountType.Save;
            if (flag)
            {
                this._bankType = BankAccountType.Current;
            }
            else
            {
                this._bankType = BankAccountType.Save;
            }
            Console.WriteLine("Текущий счет - " + this._bankType.ToString());
        }

        public void SetTypeBank(string type)
        {
            bool flag = type.ToLower().Equals("сберегательный");
            if (flag)
            {
                this._bankType = BankAccountType.Save;
            }
            else
            {
                this._bankType = BankAccountType.Current;
            }
        }
        public void CheckBalance()
        {
            bool flag = this._bankType == BankAccountType.Save;
            if (flag)
            {
                Console.WriteLine("Текущий баланс " + this._balanceSave.ToString());
            }
            else
            {
                Console.WriteLine("Текущий баланс " + this._balanceCurrent.ToString());
            }
        }
        public void Transaction(decimal summ)
        {
            if (this._bankType == BankAccountType.Current)
            {
                if (_balanceCurrent - summ >= 0 && summ > 0)
                {
                    _balanceCurrent -= summ;
                    _balanceSave += summ;
                    bankTransactions.Enqueue(new BankTransaction(summ, BankTransaction.TypeTransaction.Transfer));
                }
                else
                {
                    Console.WriteLine("Операция невозможна");
                }

            }
            else
            {
                if (_balanceSave - summ >= 0 && summ > 0)
                {
                    _balanceCurrent += summ;
                    _balanceSave -= summ;
                    bankTransactions.Enqueue(new BankTransaction(summ, BankTransaction.TypeTransaction.Transfer));
                }
                else
                {
                    Console.WriteLine("Операция невозможна");
                }
            }
        }

        public static void Dispose(BankAmount bankAmount)
        {
            for (int i = 0; i < bankAmount.bankTransactions.Count; i++)
            {
                string info = GetInfoAboutTransaction(bankAmount.bankTransactions.Dequeue());

                File.AppendAllText("transaction.txt", info + "\n");

            }
            GC.SuppressFinalize(bankAmount);
            Console.WriteLine("Информация о всех транзакциях записана в файл transaction.txt");
        }
        public void CheckType()
        {
            Console.WriteLine("Текущий тип банковского счета " + this._bankType.ToString());
        }
        public static string GetInfoAboutTransaction(BankTransaction bankTrans)
        {
            return $" Время выполнения операции {bankTrans.dateTime}; сумма перевода {bankTrans.summ} ; тип операции {bankTrans.typeTransaction}";
        }
        internal BankAmount()
        {
            _guid = Guid.NewGuid();
            _balanceCurrent = 0;
            _balanceSave = 0;
            HashCode = SHA256.Create();

        }


        public Guid id
        {
            get { return _guid; }
        }
        public SHA256 HashCode { get; private set; }
        private Guid _guid;
        private decimal _balanceCurrent;
        private decimal _balanceSave;
        private BankAccountType _bankType;
        private Queue<BankTransaction> bankTransactions = new Queue<BankTransaction>();


    }
}

