using System.Data;

namespace FinanceTrackerAPI.Core.Abstractions.IFactories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateTransactionsDbConnection();
    }
}
