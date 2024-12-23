using System.Data;
using Microsoft.Data.SqlClient;
using FinanceTrackerAPI.Core.Abstractions.IConnectionFactories;
using FinanceTrackerAPI.Core.Utilities.Configuration;

namespace FinanceTrackerAPI.Infrastructure.ConnectionFactories
{
    internal class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateTransactionsDbConnection()
        {
            return new SqlConnection(AppSettings.ConnectionStrings!.TransactionsDb);
        }
    }
}