using Lerato.ApplicationCore.Domain.Database;
using Lerato.EmployeeAdmin.ViewModels;

namespace Lerato.EmployeeAdmin.Views
{
    public partial class AddEmployeePage
    {
        public AddEmployeePage()
        {
            InitializeComponent();

            this.BindingContext = new AddEmployeeViewModel(this.Navigation, null);
        }

        public AddEmployeePage(Employee employee)
        {
            InitializeComponent();

            this.BindingContext = new AddEmployeeViewModel(this.Navigation, employee);
        }
    }
}