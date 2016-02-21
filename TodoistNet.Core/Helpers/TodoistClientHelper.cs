using System.Threading.Tasks;
using TodoistNet.Core.Data.Commands;

namespace TodoistNet.Core.Helpers
{
    public static class TodoistClientHelper
    {
        public static async Task<string> CreateNewProject(this TodoistClient client, string name, int? color = null, int? indent = null, int? itemOrder = null)
        {
            return await CreateNewProject(client, new ProjectCommandArgument(name) { Color = color, Indent = indent, ItemOrder = itemOrder });
        }

        public static async Task<string> CreateNewProject(this TodoistClient client, ProjectCommandArgument project)
        {
            return await client.ExecuteCommands(new TodoistCommand(TodoistCommand.ProjectAdd, project));
        }

        public static async Task<string> CreateNewItem(this TodoistClient client, ItemCommandArgument item)
        {
            return await client.ExecuteCommands(new TodoistCommand(TodoistCommand.ItemAdd, item));
        }
    }
}
