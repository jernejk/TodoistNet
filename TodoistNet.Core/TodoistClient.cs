using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TodoistNet.Core.Data;
using TodoistNet.Core.Data.Commands;

namespace TodoistNet.Core
{
    public class TodoistClient
    {
        private int lastSeqNumber = 0;
        private string token;

        public TodoistClient(string token)
        {
            this.token = token;
        }

        public async Task<string> GetAllCompletedTasks()
        {
            string content = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = new HttpMethod("SYNC");
                Dictionary<string, string> d = new Dictionary<string, string>
                    {
                        ["token"] = token
                };

                message.Content = new FormUrlEncodedContent(d);
                message.RequestUri = new Uri("https://todoist.com/API/v6/get_all_completed_items");
                var tasks = await client.SendAsync(message);

                content = await tasks.Content.ReadAsStringAsync();
            }

            return content;
        }

        public async Task<TodoistResources> GetAllResourcesAsync(bool mapData = true)
        {
            string content = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = new HttpMethod("SYNC");
                Dictionary<string, string> d = new Dictionary<string, string>
                {
                    ["token"] = token,
                    ["seq_no"] = lastSeqNumber.ToString(),
                    ["resource_types"] = @"[""all""]"
                };

                message.Content = new FormUrlEncodedContent(d);
                message.RequestUri = new Uri("https://todoist.com/API/v6/sync");

                try
                {
                    var tasks = await client.SendAsync(message);
                    content = await tasks.Content.ReadAsStringAsync();
                }
                catch (Exception exception)
                {
                }
            }

            try
            {
                var result = Deserialize<TodoistResources>(content);
                if (result != null && mapData)
                {
                    MapData.Map(result);
                }

                return result;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public async Task<string> ExecuteCommands(params TodoistCommand[] commands)
        {
            string json = SearializeCommands(commands);

            string content = await SyncAsync(json);

            return content;
        }

        private async Task<string> SyncAsync(string json)
        {
            string content = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = new HttpMethod("SYNC");
                Dictionary<string, string> d = new Dictionary<string, string>
                {
                    ["token"] = token,
                    ["commands"] = json
                };

                message.Content = new FormUrlEncodedContent(d);
                message.RequestUri = new Uri("https://todoist.com/API/v6/sync");

                try
                {
                    var tasks = await client.SendAsync(message);
                    content = await tasks.Content.ReadAsStringAsync();
                }
                catch (Exception exception)
                {
                }
            }

            return content;
        }

        private static string SearializeCommands(TodoistCommand[] commands)
        {
            string json;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TodoistCommand[]), new[] { typeof(ProjectCommandArgument), typeof(ItemCommandArgument) });
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    serializer.WriteObject(ms, commands);
                }
                catch
                {
                }
                json = Encoding.UTF8.GetString(ms.ToArray());
            }

            return json;
        }

        private static T Deserialize<T>(string json) where T : class
        {
            T result;

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                result = serializer.ReadObject(ms) as T;
            }

            return result;
        }
    }
}
