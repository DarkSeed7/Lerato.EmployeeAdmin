using Lerato.EmployeeAdmin.ViewModels;
using Xamarin.Forms;

namespace Lerato.EmployeeAdmin.Views
{
    public partial class EmployeeListPage
    {
        public EmployeeListPage()
        {
            InitializeComponent();

            this.BindingContext = new EmployeeListViewModel(this.Navigation);

            NavigationPage.SetHasBackButton(this, false);
        }
    }
}