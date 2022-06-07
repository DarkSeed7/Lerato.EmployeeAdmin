namespace Lerato.EmployeeAdmin.Services
{
    public interface IDatabaseService
    {
        string SetupDatabase();

        void DeleteDatabase();
    }
}
