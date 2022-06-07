using Lerato.ApplicationCore.Repository;
using Lerato.ApplicationCore.Services;
using Lerato.CompositionRoot.Extensions;
using Xamarin.Forms;

namespace Lerato.EmployeeAdmin.Facades
{
    public sealed class DatabaseFacade
    {
        private static DatabaseFacade instance;

        private static LeratoRepository database;

        static DatabaseFacade()
        {
        }

        private DatabaseFacade()
        {
        }

        public static DatabaseFacade Instance
        {
            get
            {
                if (instance.IsNull())
                {
                    instance = new();
                }

                return instance;
            }
        }

        public LeratoRepository Database
        {
            get
            {
                if (database.IsNull())
                {
                    var sqlDataService = DependencyService.Get<ISQLDataService>();

                    database = new(sqlDataService);
                }

                return database;
            }
        }
    }
}
