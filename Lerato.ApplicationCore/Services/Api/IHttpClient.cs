using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lerato.ApplicationCore.Services.Api
{
    public interface IHttpClient
    {
        Task<string> GetAsync(string uri);

        Task<string> PostAsync<T>(string uri, T data);

        Task<string> PutAsync<T>(string uri, T data);

        Task<string> DeleteAsync(string uri);
    }
}
