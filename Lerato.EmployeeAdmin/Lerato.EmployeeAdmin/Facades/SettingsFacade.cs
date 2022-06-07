using Lerato.ApplicationCore.Repository;
using Lerato.CompositionRoot.Containers;
using Lerato.DomainServices.Services;

namespace Lerato.EmployeeAdmin.Facades
{
    public static class SettingsFacade
    {
        public static void RegisterIOCServices()
        {
         
            UnityServiceContainer.Instance.Register<EmployeeDatabaseService>();

            UnityServiceContainer.Instance.Register<LeratoRepository>();
        }
    }
}
