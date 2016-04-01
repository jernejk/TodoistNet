using System;
using System.Threading.Tasks;
using TodoistNet.Core;
using TodoistNet.Core.Commands;
using TodoistNet.Core.Data;
using TodoistNet.Core.Helpers;

namespace TodoistNet.RichClient
{
    public class TodoistClient
    {
        public TodoistWebClient Client { get; }

        public TodoistClient(string token)
        {
            Client = new TodoistWebClient(token);
        }

        public TodoistClient(string token, IHttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            Client = new TodoistWebClient(token, httpClient, jsonSerializer);
        }

        public async Task<CompletedItemsResponse> GetAllCompletedTasks(int offset = 0, int limit = 30, int? projectId = null)
        {
            return await Client.GetAllCompletedTasks(offset, limit, projectId);
        }

        public async Task<TodoistWebResources> GetAllResourcesAsync(bool mapData = true)
        {
            var result = await Client.GetAllResourcesAsync();

            if (result != null && mapData)
            {
                MapData.Map(result);
            }

            return result;
        }

        public async Task<string> ExecuteCommands(params TodoistCommand[] commands)
        {
            return await Client.ExecuteCommands(commands);
        }
    }
}
