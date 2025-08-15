using System;
using System.Transactions;

namespace Assignment3.Question1_Finance
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Crypto Wallet] Processed GHS{transaction.Amount:F2} for {transaction.Category}");
        }
    }
}
