using Lerato.CompositionRoot.Containers;
using Lerato.DomainServices.Services;
using Lerato.EmployeeAdmin.Facades;
using Unity.Resolution;

namespace Lerato.EmployeeAdmin.Helpers
{
    public sealed class DatabaseServiceHelper
    {
        private static readonly DatabaseServiceHelper instance = new DatabaseServiceHelper();

        public DatabaseServiceHelper()
        {
        }

        public static DatabaseServiceHelper Instance
        {
            get
            {
                return instance;
            }
        }

        public EmployeeDatabaseService GetDatabaseService()
        {
            return UnityServiceContainer.Instance.Resolve<EmployeeDatabaseService>(
                   new ResolverOverride[]
                   {
                        new ParameterOverride("repository", DatabaseFacade.Instance.Database),
                   });
        }

    }
}
