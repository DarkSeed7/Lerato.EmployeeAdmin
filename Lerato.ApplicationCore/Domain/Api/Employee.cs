using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lerato.ApplicationCore.Domain.Api
{
    public sealed class Employee
    {
        public int EmployeeId { get; set; }

        public int PersonId { get; set; }

        public string EmployeeNum { get; set; }

        public string Terminated { get; set; }
    }
}
