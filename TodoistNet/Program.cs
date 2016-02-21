using System.Collections.Generic;
using System.Linq;
using TodoistNet.Core;
using TodoistNet.Core.Data.Commands;
using TodoistNet.Core.Helpers;

namespace TodoistNet
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoistClient client = new TodoistClient("3e760c167933189705335d1e6077279a998b57c3");

            var cmd = new TodoistCommand("project_add", new ProjectCommandArgument("Test project"));
            var cmd2 = new TodoistCommand("project_add", new ProjectCommandArgument("Test project 123") { Color = 11, ItemOrder = 5, Indent = 2 });

            //System.Console.WriteLine(client.ExecuteCommands(cmd, cmd2).Result);

            var res = client.GetAllResourcesAsync().Result;

            var cmd3 = new TodoistCommand(TodoistCommand.ItemAdd, new ItemCommandArgument("Task test"));
            var cmd4 = new TodoistCommand(TodoistCommand.ItemAdd, new ItemCommandArgument("Sub-task test") { Indent = 2 });

            //var task = client.CreateNewItem(new ItemCommandArgument("Task test")).Result;

            System.Console.WriteLine(client.ExecuteCommands(cmd3, cmd4).Result);

            res = client.GetAllResourcesAsync().Result;
            var inbox = res.Projects.First(p => p.ItemOrder == 0);

            int a = 0;
            List<TodoistCommand> cmds = new List<TodoistCommand>();
            foreach (var it in inbox.Items.OrderByDescending(i => i.ItemOrder).Take(2))
            {
                var c = new TodoistCommand(TodoistCommand.ItemUpdate, new ItemCommandArgument(it.Id) { ItemOrder = ++a + 1, Indent = 2 });
                cmds.Add(c);
            }

            System.Console.WriteLine(client.ExecuteCommands(cmds.ToArray()).Result);

            System.Console.WriteLine("Done...");
        }
    }
}
