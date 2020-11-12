using Banking;
using System;

namespace Banks
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank fnb = new Bank("First National Bank", 4324, "Kenilworth");
            Customer myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");
            fnb.AddCustomer(myNewCustomer);

            var account = myNewCustomer.ApplyForBankAccount();
            account.DepositMoney(1500, DateTime.Now, "Stipend");

            try
            {
                account.WithdrawMoney(500, DateTime.Now, "Buy Lobster");
                account.WithdrawMoney(500, DateTime.Now, "Buy Schnitzel");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message + " go speak to Wouter.");
            }

            Console.WriteLine("Your Balance is:" + account.Balance);

            var history = account.GetTransactionHistory();

            Console.WriteLine(history);
        }
    }
}
