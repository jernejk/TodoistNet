using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoistNet.Core.Data;
using TodoistNet.Core.Commands;
using TodoistNet.Core.Helpers;

namespace TodoistNet.Core
{
    public class TodoistWebClient
    {
        private int lastSeqNumber = 0;
        private string token;
        private IJsonSerializer jsonSerializer;
        private IHttpClient httpClient;
        
        public TodoistWebClient(string token)
            : this(token, new PortableHttpClient(), new PortableDataContractJsonSerializer()) { }

        public TodoistWebClient(string token, IHttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            this.token = token;
            this.httpClient = httpClient;
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<CompletedItemsResponse> GetAllCompletedTasks(int offset = 0, int limit = 30, int? projectId = null)
        {
            string content = string.Empty;

            var values = new Dictionary<string, string>
            {
                ["token"] = token,
                ["limit"] = limit.ToString(),
                ["offset"] = offset.ToString()
            };

            if (projectId.HasValue)
            {
                values.Add("project_id", projectId.Value.ToString());
            }

            content = await httpClient.ExecuteRequest(new Uri("https://todoist.com/API/v6/get_all_completed_items"), "SYNC", values);

            return jsonSerializer.Deserialize<CompletedItemsResponse>(content);
        }

        public async Task<TodoistWebResources> GetAllResourcesAsync()
        {
            string content = await httpClient.ExecuteRequest(new Uri("https://todoist.com/API/v6/sync"), "SYNC", new Dictionary<string, string>
            {
                ["token"] = token,
                ["seq_no"] = lastSeqNumber.ToString(),
                ["resource_types"] = @"[""all""]"
            });

            try
            {
                var result = jsonSerializer.Deserialize<TodoistWebResources>(content);
                if (result.ContainsErrors)
                    throw TodoistWebException.GenerateFromHttpErrorCode(result.ErrorCode.Value, null);

                return result;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public async Task<string> ExecuteCommands(params TodoistCommand[] commands)
        {
            string json = jsonSerializer.Serialize(commands);

            string content = await SyncAsync(json);

            return content;
        }

        private async Task<string> SyncAsync(string json)
        {
            string content = await httpClient.ExecuteRequest(new Uri("https://todoist.com/API/v6/sync"), "SYNC", new Dictionary<string, string>
            {
                ["token"] = token,
                ["commands"] = json
            });

            return content;
        }
    }
}
