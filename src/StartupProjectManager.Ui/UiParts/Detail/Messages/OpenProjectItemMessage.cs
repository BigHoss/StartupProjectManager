namespace StartupProjectManager.Ui.Detail.Messages
{
    using Database.Model;

    public sealed class OpenProjectItemMessage 
    {
        public ProjectItem ProjectItem { get; set; }

        public OpenProjectItemMessage(ProjectItem projectItem) => ProjectItem = projectItem;
    }
}
