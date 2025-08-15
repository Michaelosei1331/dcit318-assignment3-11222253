using System;
using System.Transactions;

namespace Assignment3.Question1_Finance
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Mobile Money] Processed GHS{transaction.Amount:F2} for {transaction.Category}");
        }
    }
}
