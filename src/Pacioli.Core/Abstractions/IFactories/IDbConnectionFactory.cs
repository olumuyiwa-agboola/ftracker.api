using System.Data;

namespace Pacioli.Core.Abstractions.IFactories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateTransactionsDbConnection();
    }
}
