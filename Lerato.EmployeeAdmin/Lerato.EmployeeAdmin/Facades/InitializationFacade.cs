using Lerato.ApplicationCore.Facade;
using Lerato.ApplicationCore.Services;
using Lerato.EmployeeAdmin.Services;
using Xamarin.Forms;

namespace Lerato.EmployeeAdmin.Facades
{
    public static class InitializationFacade
    {
        public static void InitializeApplication()
        {
            InitializeDatabase();

            InitializeDIServices();
        }

        private static void InitializeDatabase()
        {
            var dbPath = DependencyService
                .Get<IDatabaseService>()
                .SetupDatabase();

            DatabaseSettingsFacade.SetDBPath(dbPath);
        }

        private static void InitializeDIServices()
        {
            DependencyService.Register<ISQLDataService>();

            SettingsFacade.RegisterIOCServices();
        }

    }
}
