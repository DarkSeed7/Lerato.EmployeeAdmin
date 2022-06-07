using Lerato.ApplicationCore.Facade;
using SQLite;
using Lerato.ApplicationCore.Services;
using Lerato.EmployeeAdmin.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDataServiceImpl))]
namespace Lerato.EmployeeAdmin.iOS.Services
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