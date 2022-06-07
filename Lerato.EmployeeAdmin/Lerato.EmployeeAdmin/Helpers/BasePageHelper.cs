using Lerato.EmployeeAdmin.Enums;

namespace Lerato.EmployeeAdmin.Helpers
{
    public sealed class BasePageHelper
    {
        private static readonly BasePageHelper instance = new BasePageHelper();

        public static Sections activeSection;

        public BasePageHelper()
        {
        }

        static BasePageHelper()
        {
        }


        public static BasePageHelper Instance
        {
            get
            {
                return instance;
            }
        }

        public void SetActiveSection(Sections section)
        {
            activeSection = section;
        }

        public Sections GetActiveActiveSection()
        {
            return activeSection;
        }
    }
}
