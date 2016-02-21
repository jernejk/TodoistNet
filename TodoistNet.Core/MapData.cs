using System.Collections.Generic;
using System.Linq;
using TodoistNet.Core.Data;

namespace TodoistNet.Core
{
    public class MapData
    {
        public static void Map(TodoistResources res)
        {
            var projects = res.Projects.OrderBy(p => p.ItemOrder);
            var lastProject = projects.First();
            int lastIndent = lastProject.Indent;
            int lastOrder = lastProject.ItemOrder;

            LinkedList<Project> projectParentage = new LinkedList<Project>();

            foreach (var project in projects)
            {
                if (project.Indent > lastProject.Indent)
                {
                    projectParentage.AddLast(lastProject);
                }
                else if (project.Indent < lastProject.Indent)
                {
                    int indent = project.Indent;
                    while (++indent <= lastProject.Indent)
                    {
                        projectParentage.RemoveLast();
                    }
                }

                var parent = projectParentage.Last?.Value;
                if (parent != null)
                {
                    UpdateProjectHierarchy(parent, project);
                }

                UpdateProjectItemsHierarchy(project, res);

                lastProject = project;
            }
        }

        private static void UpdateProjectItemsHierarchy(Project project, TodoistResources res)
        {
            project.Items = res.Items.Where(i => project.Id == i.ProjectId).ToList();

            foreach (Item item in project.Items)
            {
                item.Project = project;
                item.Notes = res.Notes.Where(n => n.ItemId == item.Id).ToList();

                foreach (var note in item.Notes)
                {
                    note.Item = item;
                }

                item.Labels = new List<Label>(0);
                if (item.LabelIds != null)
                {
                    item.Labels.Capacity = item.LabelIds.Length;
                    foreach (var labelId in item.LabelIds)
                    {
                        Label label = res.Labels.FirstOrDefault(l => l.Id == labelId);

                        if (label != null)
                        {
                            UpdateItemLabelRelation(item, label);
                        }
                    }
                }
            }
        }

        private static void UpdateProjectHierarchy(Project parent, Project child)
        {
            child.Parent = parent;

            if (parent.Childs == null)
            {
                parent.Childs = new List<Project>();
            }

            parent.Childs.Add(child);
        }

        private static void UpdateItemLabelRelation(Item item, Label label)
        {
            if (label != null)
            {
                item.Labels.Add(label);
                
                if (label.Items == null)
                {
                    label.Items = new List<Item>();
                }

                label.Items.Add(item);
            }
        }
    }
}
