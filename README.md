# TodoistNet
Todoist API v6 implemented in C#.
This project **is not** production ready and will have large architectural changes until most of the features are done.
Most of the features are implemented as I need them for another hobby project.

This API is supported on following platforms:

 - .NET 4.6
 - ASP.NET Core 5.0
 - UWP

Currently supports:

 - Add/update/delete for items, projects, labels and notes
 - Get all resources
 - Execute multiple commands at once

Missing features:

 - Login to get access token
 - Completing items
 - Reorder items, projects, etc.
 - File attachments for notes
 - Search (search by filters or query)
 - Features regarding Karma
 - Collaboration features (sharing, ownership, etc.)
 - Reminders
 - Live notification
 - Proper error handling
 - Testing

Get all resources with automatic data mapping (projects, items, notes and labels are automatically mapped between each other):
``` C#
TodoistClient client = new TodoistClient("<INSERT TOKEN>");

var resources = await client.GetAllResourcesAsync();

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

/* Sample output:
# Inbox
    - My main task
        - My sub task

# Work
    - * Repetative tasks
        - * Daily Scrum
            - Daily standup
            - Send daily Scrum
        - * Weekly tasks
            - Send weekly report
            - Write invoice
            - Clean up inbox
        - Log work in https://ssw.sswtimepro.com/Timesheet

    # Induction-Day
        - * Induction Day Training
            - Difficulties With Clients [Admin & Dev] 1
            - Difficulties With Clients [Admin & Dev] 2
            - Handling Client Arrivals At SSW [Admin & Dev]

    # Done-workflow
        - Send done email
*/
```

Sample how to create one task in inbox with a sub task which has a note (premium feature of Todoist):
``` C#
TodoistClient client = new TodoistClient("<INSERT TOKEN>");

var addMainTaskCmd = new TodoistCommand(TodoistCommands.ItemAdd, new ItemCommandArgument("My main task"));
var addSubTaskCmd = new TodoistCommand(TodoistCommands.ItemAdd, new ItemCommandArgument("My sub task") { Indent = 2 });
var addNoteCmd = new TodoistCommand(TodoistCommands.NoteAdd, NoteCommandArgument.AddNote(addSubTaskCmd.TempId, "Test note"));

await client.ExecuteCommands(addMainTaskCmd, addSubTaskCmd, addNoteCmd);
```