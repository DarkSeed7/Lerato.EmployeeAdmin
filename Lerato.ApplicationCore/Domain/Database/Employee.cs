using SQLite;

namespace Lerato.ApplicationCore.Domain.Database
{
    [Table("Employee")]
    public sealed class Employee
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Title { get; set; }

        public string BirthDate { get; set; }

        public string EmployeeNum { get; set; }

        public string EmployedDate { get; set; }

        public string Terminated { get; set; }
       
    }
}
