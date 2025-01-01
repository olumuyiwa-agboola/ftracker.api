using System.Data;
using Microsoft.Data.Sqlite;
using Pacioli.Core.Utilities.Configuration;
using Pacioli.Core.Abstractions.IFactories;

namespace Pacioli.Infrastructure.Factories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateTransactionsDbConnection()
        {
            return new SqliteConnection(AppSettings.ConnectionStrings!.TransactionsDb);
        }
    }
}