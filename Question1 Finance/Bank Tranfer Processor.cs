using System;
using System.Transactions;

namespace Assignment3.Question1_Finance
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Bank Transfer] Processed GHS{transaction.Amount:F2} for {transaction.Category}");
        }
    }
}
