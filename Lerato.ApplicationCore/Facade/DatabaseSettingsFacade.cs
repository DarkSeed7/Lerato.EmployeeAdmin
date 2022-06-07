using SQLite;
namespace Lerato.ApplicationCore.Facade
{
    public sealed class DatabaseSettingsFacade
    {
        private static string DB_PATH = string.Empty;

        public static void SetDBPath(string dbPath)
        {
            DB_PATH = dbPath;
        }

        public static string GetDBPath()
        {
            return DB_PATH;
        }
    }
}
