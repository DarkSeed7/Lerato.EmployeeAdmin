using System.Text.RegularExpressions;

namespace Lerato.EmployeeAdmin.Extensions
{
    public static class RegexExtentions
    {
        public static string ReplaceStringWithEnter(this string stringValue)
        {
            return Regex.Replace(stringValue, @"\s+", "\n");
        }
    }
}
