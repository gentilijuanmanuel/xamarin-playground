using SQLite.Net;

namespace TestingSQLite.Core.DependencyService
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
