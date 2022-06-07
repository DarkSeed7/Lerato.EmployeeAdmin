using SQLite;

namespace Lerato.ApplicationCore.Services
{
    public interface ISQLDataService
    {
        SQLiteConnection GetConnection();
    }
}
