using Lerato.ApplicationCore.Domain.Database;
using Lerato.ApplicationCore.Services;
using System;
using System.Collections.Generic;

namespace Lerato.ApplicationCore.Repository
{
    public sealed class LeratoRepository : IDisposable, IEmployeeService
    {
        private static DataAccess dataAccess;

        public LeratoRepository(ISQLDataService sqlDataService)
        {
            dataAccess = new DataAccess(sqlDataService);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return dataAccess.GetEmployees();  
        }

        public void AddEmployee(Employee employee)
        {
            dataAccess.AddEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            dataAccess.UpdateEmployee(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            dataAccess.DeleteEmployee(employee);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
