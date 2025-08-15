using System;
using System.Collections.Generic;
using System.Transactions;

namespace Assignment3.Question1_Finance
{
    public class FinanceApp
    {
        private List<Transaction> _transactions = new();

        public void Run()
        {
            Console.WriteLine("=== Question 1: Finance Management System ===\n");

            // Create account
            SavingsAccount account = new SavingsAccount("ACC001", 1000m);

            // Normal transactions
            ProcessTransaction(account, new MobileMoneyProcessor(), new Transaction(1, DateTime.Now, 150m, "Groceries"));
            ProcessTransaction(account, new BankTransferProcessor(), new Transaction(2, DateTime.Now, 200m, "Utilities"));
            ProcessTransaction(account, new CryptoWalletProcessor(), new Transaction(3, DateTime.Now, 50m, "Entertainment"));

            // Edge case transaction (amount exceeds balance)
            ProcessTransaction(account, new BankTransferProcessor(), new Transaction(4, DateTime.Now, 5000m, "Luxury Purchase"));

            Console.WriteLine("\n=== All Transactions Recorded Successfully ===");
        }

        private void ProcessTransaction(SavingsAccount account, ITransactionProcessor processor, Transaction transaction)
        {
            processor.Process(transaction);
            account.ApplyTransaction(transaction);
            _transactions.Add(transaction);
        }
    }
}
