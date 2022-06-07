using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lerato.CompositionRoot.Utils
{
    public static class UriUtils
    {
        public static string BuildUri(string uri, string path)
        {
            var builder = new UriBuilder(uri) { Path = path };

            return builder.ToString();
        }
    }
}
