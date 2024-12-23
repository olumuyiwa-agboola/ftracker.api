using System.Data;

namespace FinanceTrackerAPI.Core.Abstractions.IConnectionFactories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateTransactionsDbConnection();
    }
}
