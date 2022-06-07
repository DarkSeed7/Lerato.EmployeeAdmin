using Lerato.ApplicationCore.Facade;
using Lerato.ApplicationCore.Services;
using Lerato.EmployeeAdmin.Droid.Services;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDataServiceImpl))]
namespace Lerato.EmployeeAdmin.Droid.Services
{
    public sealed class SQLiteDataServiceImpl : ISQLDataService
    {
        public SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(DatabaseSettingsFacade.GetDBPath(),true);

            return connection;
        }
    }
}