using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
    public class BankAccount : IDisposable 
    {
        private decimal _balance;
        public string AccountNumber { get; private set; }
        private Queue<BankTransaction> _transactions = new Queue<BankTransaction>();
        private static int _counter = 0;

        public BankAccount(decimal balance = 0)
        {
            _counter++;
            AccountNumber = $"ACC{_counter:D3}";
            _balance = balance;
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
            _transactions.Enqueue(new BankTransaction(amount));
        }
        public void Dispose()
        {
            using (StreamWriter writer = new StreamWriter("bank_transactions.txt", false, Encoding.UTF8))
            {
                writer.WriteLine($"Отчет по счету: {AccountNumber}");
                foreach (var trans in _transactions)
                {
                    writer.WriteLine($"{trans.TransactionDate} : {trans.Amount}");
                }
            }
            GC.SuppressFinalize(this);
            Console.WriteLine("Данные записаны в файл, ресурсы освобождены.");
        }
    }

    class Program
    {
        static void Main()
        {
            using (BankAccount acc = new BankAccount(1000))
            {
                acc.Deposit(500);
                acc.Deposit(200);
            }
            
            Console.WriteLine("Проверь файл bank_transactions.txt в папке с проектом.");
        }
    }
}