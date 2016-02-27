using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using TodoistNet.Core.Commands;

namespace TodoistNet.Core.Helpers
{
    public class PortableDataContractJsonSerializer : IJsonSerializer
    {
        public T Deserialize<T>(string json) where T : class, new()
        {
            T result;

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                result = serializer.ReadObject(ms) as T;
            }

            return result;
        }

        public string Serialize<T>(T obj)
        {
            string json;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TodoistCommand[]),
                new[] { typeof(ProjectCommandArgument), typeof(ItemCommandArgument), typeof(LabelCommandArgument),
                        typeof(NoteCommandArgument) });
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);

                json = Encoding.UTF8.GetString(ms.ToArray());
            }

            return json;
        }
    }
}
