using Lerato.ApplicationCore.Domain.Database;
using Lerato.ApplicationCore.Services;
using System.Collections.Generic;
using System.Linq;

namespace Lerato.DomainServices.Services
{
    public sealed class EmployeeDatabaseService
    {
        private readonly IEmployeeService repository;

        public EmployeeDatabaseService(IEmployeeService repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return repository.GetEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            return repository
                .GetEmployees()
                .FirstOrDefault(x => x.EmployeeId.Equals(id));
        }

        public void AddEmployee(Employee emp)
        {
            repository.AddEmployee(emp);
        }

        public void UpdateEmployee(Employee emp)
        {
            repository.UpdateEmployee(emp);
        }

        public void DeleteEmployee(Employee emp)
        {
            repository.DeleteEmployee(emp);
        }
    }
}
