using System.Collections.Generic;
using SQLite.Net;
using TestingSQLite.Core.DependencyService;
using TestingSQLite.Core.Models;

namespace TestingSQLite.Core
{
    public class DatabaseManager
    {
        private readonly SQLiteConnection databaseConnection;

        public DatabaseManager()
        {
            this.databaseConnection = Xamarin.Forms.DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<Employee> GetAllEmployees()
        {
            return this.databaseConnection.Query<Employee>("Select * From [Employee]");
        }

        public int SaveEmployee(Employee aEmployee)
        {
            return this.databaseConnection.Insert(aEmployee);
        }
    }
}
