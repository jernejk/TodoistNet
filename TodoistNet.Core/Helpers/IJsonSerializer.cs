namespace TodoistNet.Core.Helpers
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T obj);

        T Deserialize<T>(string json) where T : class, new();
    }
}
