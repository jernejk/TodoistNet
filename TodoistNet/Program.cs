using System;
using System.Collections.Generic;
using System.Linq;
using TodoistNet.Core;
using TodoistNet.Core.Commands;
using TodoistNet.Core.Helpers;

namespace TodoistNet
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoistClient client = new TodoistClient("<INSERT TOKEN>");

            int page = 0;
            while (true)
            {
                var result = client.GetAllCompletedTasks(page * 30).Result;
                page++;

                if (result == null || result.Items == null || result.Items.Length == 0)
                {
                    break;
                }

                Console.WriteLine(result.Items.Length);
            }

            var cmd = new TodoistCommand(TodoistCommands.ProjectAdd, new ProjectCommandArgument("Test project"));
            var cmd2 = new TodoistCommand(TodoistCommands.ProjectAdd, new ProjectCommandArgument("Test project 123") { Color = 11, ItemOrder = 5, Indent = 2 });

            //System.Console.WriteLine(client.ExecuteCommands(cmd, cmd2).Result);

            var resources = client.GetAllResourcesAsync().Result;

            foreach (var project in resources.Projects.OrderBy(p => p.ItemOrder))
            {
                string projectIndent = new string('\t', project.Indent - 1);
                Console.WriteLine($"{projectIndent}# {project.Name}");

                foreach (var item in project.Items.OrderBy(i => i.ItemOrder))
                {
                    string itemIndent = projectIndent + new string('\t', item.Indent);
                    Console.WriteLine($"{itemIndent}- {item.Content}");
                }

                Console.WriteLine();
            }

            var addMainTaskCmd = new TodoistCommand(TodoistCommands.ItemAdd, new ItemCommandArgument("My main task @pbi @needSendDonePBI"));
            var addSubTaskCmd = new TodoistCommand(TodoistCommands.ItemAdd, new ItemCommandArgument("My sub task") { Indent = 2 });
            var addNoteCmd = new TodoistCommand(TodoistCommands.NoteAdd, NoteCommandArgument.AddNote(addSubTaskCmd.TempId, "Test note"));

            //var task = client.CreateNewItem(new ItemCommandArgument("Task test")).Result;

            System.Console.WriteLine(client.ExecuteCommands(addMainTaskCmd, addSubTaskCmd, addNoteCmd).Result);

            resources = client.GetAllResourcesAsync().Result;
            var inbox = resources.Projects.First(p => p.ItemOrder == 0);

            int a = 0;
            List<TodoistCommand> cmds = new List<TodoistCommand>();
            //foreach (var it in inbox.Items.OrderByDescending(i => i.ItemOrder).Take(2))
            //{
            //    var c = new TodoistCommand(TodoistCommand.ItemUpdate, new ItemCommandArgument(it.Id) { ItemOrder = ++a + 1, Indent = 2 });
            //    cmds.Add(c);
            //}

            //var noteCommand = new TodoistCommand(TodoistCommands.NoteAdd, NoteCommandArgument.AddProjectNote(res.Projects[0].Id, "Test note"));
            //cmds.Add(noteCommand);

            System.Console.WriteLine(client.ExecuteCommands(cmds.ToArray()).Result);

            System.Console.WriteLine("Done...");
        }
    }
}
