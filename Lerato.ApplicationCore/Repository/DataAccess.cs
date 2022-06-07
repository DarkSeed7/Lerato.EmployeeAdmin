using Lerato.ApplicationCore.Domain.Database;
using Lerato.ApplicationCore.Services;
using SQLite;
using System.Collections.Generic;

namespace Lerato.ApplicationCore.Repository
{
    internal class DataAccess
    {
        private readonly ISQLDataService dataService;

        private readonly SQLiteConnection connection;

        public DataAccess(ISQLDataService dataService)
        {
            this.dataService = dataService;

            connection = dataService
                .GetConnection();
        }

        public List<Employee> GetEmployees()
        {
            return connection
                .Table<Employee>()
                .ToList();
        }

        public void AddEmployee(Employee employee)
        {
            connection.
                Insert(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            connection.
                Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            connection.
                Delete(employee);
        }

    }
}
