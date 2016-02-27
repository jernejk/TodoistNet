using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoistNet.Core.Helpers
{
    public interface IHttpClient
    {
        Task<string> ExecuteRequest(Uri requestUri, string method, Dictionary<string, string> requestMessage);
    }
}
