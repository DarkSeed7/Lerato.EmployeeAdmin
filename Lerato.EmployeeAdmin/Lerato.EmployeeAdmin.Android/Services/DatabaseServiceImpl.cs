using System.IO;
using Lerato.EmployeeAdmin.Droid.Services;
using Lerato.EmployeeAdmin.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseServiceImpl))]
namespace Lerato.EmployeeAdmin.Droid.Services
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
            using (BinaryReader br = new BinaryReader(Android.App.Application.Context.Assets.Open(DATABASE_NAME)))
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                {
                    byte[] buffer = new byte[2048];

                    int len = 0;

                    while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bw.Write(buffer, 0, len);
                    }
                }
            }
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