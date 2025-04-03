namespace Senator.As400.Cloud.Sync.Infrastructure.Abstractions.Persistence;

public class DbContext(IDbConnectionFactory connectionFactory) : IDbContext {
    private IDbConnection? connection;
    private IDbTransaction? transaction;

    public IDbConnection Connection {
        get {
            if (connection != null) return connection;
            connection = connectionFactory.CreateConnection();
            connection.Open();
            State = DbContextState.Open;
            return connection;
        }
    }

    public IDbTransaction Transaction => transaction!;

    //public ISqlQueryBuilder SqlQueryBuilder { get; } = sqlQueryBuilder; 

    public DbContextState State { get; private set; } = DbContextState.Closed;

    public void BeginTransaction() {
        transaction = Connection.BeginTransaction();
    }

    public void Commit() {
        try {
            transaction?.Commit();
            State = DbContextState.Comitted;
        }
        catch {
            Rollback();
            throw;
        }
        finally {
            transaction?.Dispose();
            transaction = null;
        }
    }

    public void Rollback() {
        try {
            transaction?.Rollback();
            State = DbContextState.RolledBack;
        }
        finally {
            transaction?.Dispose();
            transaction = null;
        }
    }

    public void Dispose() {
        if (transaction != null) {
            transaction.Dispose();
            transaction = null;
        }

        if (connection != null) {
            if (connection.State != ConnectionState.Closed) {
                connection.Close();
            }
            connection.Dispose();
            connection = null;
        }
    
        State = DbContextState.Closed;
        GC.SuppressFinalize(this);
    }
}

public interface IDbConnectionFactory {
    IDbConnection CreateConnection();
}

public class DbConnectionFactory(Func<IDbConnection> connectionFactory) : IDbConnectionFactory {
    private readonly Func<IDbConnection> connectionFactoryFunc =
        connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));

    public IDbConnection CreateConnection() => connectionFactoryFunc();
}