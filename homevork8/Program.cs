using System;

namespace homevork8
{
    public class BankAccount
    {
        private decimal _balance;
        private string _accountType;
        private static int _counter = 0; 
        public string AccountNumber { get; private set; }
        public BankAccount()
        {
            _counter++;
            AccountNumber = $"ACC{_counter:D3}"; /
            _balance = 0;
            _accountType = "Стандартный";
        }
        public BankAccount(decimal balance) : this() 
        {
            _balance = balance;
        }
        public BankAccount(string accountType, decimal balance) : this(balance)
        {
            _accountType = accountType;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Счет: {AccountNumber}, Тип: {_accountType}, Баланс: {_balance}");
        }
    }
    class Program
    {
        static void Main()
        {
            BankAccount acc1 = new BankAccount(); 
            BankAccount acc2 = new BankAccount(1000); 
            BankAccount acc3 = new BankAccount("Кредитный", 5000); 
            acc1.PrintInfo();
            acc2.PrintInfo();
            acc3.PrintInfo();
        }
    }
}