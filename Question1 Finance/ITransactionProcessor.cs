using System.Transactions;

namespace Assignment3.Question1_Finance
{
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
}
