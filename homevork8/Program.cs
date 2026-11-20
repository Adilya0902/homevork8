using System;
using System.Collections.Generic;

namespace homevork8
{
    public class BankTransaction
    {
        public readonly DateTime TransactionDate;
        public readonly decimal Amount;
        public BankTransaction(decimal amount)
        {
            TransactionDate = DateTime.Now; 
            Amount = amount;
        }
    }
    public class BankAccount
    {
        private decimal _balance;
        private string _accountType;
        private static int _counter = 0;
        public string AccountNumber { get; private set; }
        private Queue<BankTransaction> _transactions = new Queue<BankTransaction>();
        public BankAccount(decimal balance = 0, string accountType = "Стандартный")
        {
            _counter++;
            AccountNumber = $"ACC{_counter:D3}";
            _balance = balance;
            _accountType = accountType;
        }
        public void Withdraw(decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                _transactions.Enqueue(new BankTransaction(-amount));
                Console.WriteLine($"Снято {amount}. Остаток: {_balance}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств!");
            }
        }
        public void Deposit(decimal amount)
        {
            _balance += amount;
            _transactions.Enqueue(new BankTransaction(amount));
            Console.WriteLine($"Пополнено {amount}. Баланс: {_balance}");
        }
        public void ShowTransactions()
        {
            Console.WriteLine("История операций:");
            foreach (var trans in _transactions)
            {
                Console.WriteLine($"{trans.TransactionDate} | {trans.Amount}");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount(100);
            account.Deposit(50);   
            account.Withdraw(30);
            account.ShowTransactions();
        }
    }
}