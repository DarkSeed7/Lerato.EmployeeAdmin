using Lerato.ApplicationCore.Domain.Database;
using System.Collections.Generic;

namespace Lerato.ApplicationCore.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();

        void AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
    }
}
