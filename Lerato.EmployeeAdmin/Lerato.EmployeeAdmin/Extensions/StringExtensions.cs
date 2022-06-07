using System;
using System.Collections.Generic;
using System.Text;

namespace Lerato.EmployeeAdmin.Extensions
{
    public static class StringExtensions
    {
        public static string GetFirstLetter(this string stringValue)
        {
            return !string.IsNullOrEmpty(stringValue) ? stringValue.Substring(0, 1) : " ";
        }
    }
}
