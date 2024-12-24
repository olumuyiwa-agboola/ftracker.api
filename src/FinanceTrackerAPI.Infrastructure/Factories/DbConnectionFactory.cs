using System.Data;
using Microsoft.Data.Sqlite;
using FinanceTrackerAPI.Core.Utilities.Configuration;
using FinanceTrackerAPI.Core.Abstractions.IFactories;

namespace FinanceTrackerAPI.Infrastructure.Factories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateTransactionsDbConnection()
        {
            return new SqliteConnection(AppSettings.ConnectionStrings!.TransactionsDb);
        }
    }
}