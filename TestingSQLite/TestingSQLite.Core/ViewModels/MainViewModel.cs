using System.Collections.Generic;
using TestingSQLite.Core.Models;

namespace TestingSQLite.Core.ViewModels
{
    public class MainViewModel
    {
        public static DatabaseManager DatabaseManager { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public MainViewModel()
        {
            DatabaseManager = new DatabaseManager();

            Employees = DatabaseManager.GetAllEmployees();
        }
    }
}
