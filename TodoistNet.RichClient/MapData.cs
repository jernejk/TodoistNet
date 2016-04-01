using System.Collections.Generic;
using System.Linq;
using TodoistNet.Core.Data;

namespace TodoistNet.Core
{
    public class MapData
    {
        public static void Map(TodoistWebResources res)
        {
            var projects = res.Projects.OrderBy(p => p.ItemOrder);
            var lastProject = projects.First();
            int lastIndent = lastProject.Indent;
            int lastOrder = lastProject.ItemOrder;

            LinkedList<WebProject> projectParentage = new LinkedList<WebProject>();

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

        private static void UpdateProjectItemsHierarchy(WebProject project, TodoistWebResources res)
        {
            project.Items = res.Items.Where(i => project.Id == i.ProjectId).ToList();

            foreach (WebItem item in project.Items)
            {
                item.Project = project;
                item.Notes = res.Notes.Where(n => n.ItemId == item.Id).ToList();

                foreach (var note in item.Notes)
                {
                    note.Item = item;
                }

                item.Labels = new List<WebLabel>(0);
                if (item.LabelIds != null)
                {
                    item.Labels.Capacity = item.LabelIds.Length;
                    foreach (var labelId in item.LabelIds)
                    {
                        WebLabel label = res.Labels.FirstOrDefault(l => l.Id == labelId);

                        if (label != null)
                        {
                            UpdateItemLabelRelation(item, label);
                        }
                    }
                }
            }
        }

        private static void UpdateProjectHierarchy(WebProject parent, WebProject child)
        {
            child.Parent = parent;

            if (parent.Childs == null)
            {
                parent.Childs = new List<WebProject>();
            }

            parent.Childs.Add(child);
        }

        private static void UpdateItemLabelRelation(WebItem item, WebLabel label)
        {
            if (label != null)
            {
                item.Labels.Add(label);
                
                if (label.Items == null)
                {
                    label.Items = new List<WebItem>();
                }

                label.Items.Add(item);
            }
        }
    }
}
