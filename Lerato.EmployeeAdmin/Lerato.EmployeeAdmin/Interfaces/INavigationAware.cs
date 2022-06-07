using Xamarin.Forms;

namespace Lerato.EmployeeAdmin.Interfaces
{
    public interface INavigationAware
    {
        INavigation NavigationHandler { get; set; }
    }
}
