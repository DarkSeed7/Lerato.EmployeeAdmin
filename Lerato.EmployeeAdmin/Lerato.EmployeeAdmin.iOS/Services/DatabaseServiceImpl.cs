using System.IO;
using Foundation;
using Lerato.EmployeeAdmin.iOS.Services;
using Lerato.EmployeeAdmin.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseServiceImpl))]
namespace Lerato.EmployeeAdmin.iOS.Services
{
    public sealed class DatabaseServiceImpl : IDatabaseService
    {
        private const string DATABASE_NAME = "LeratoDB.db";

        private const string TEMP_DATABASE_NAME = "LeratoDBtemp.db";

        public string SetupDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), DATABASE_NAME);

            if (!File.Exists(dbPath))
            {
                CreateDatabase(dbPath);
            }
             
            return dbPath;
        }

        private void CreateDatabase(string dbPath)
        {
            var bundleDBPath = Path.Combine(NSBundle.MainBundle.BundlePath, DATABASE_NAME);

            File.Copy(bundleDBPath, dbPath, true);
        }

        public void DeleteDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), DATABASE_NAME);

            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }
        }
    }
}