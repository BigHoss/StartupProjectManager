namespace StartupProjectManager.Database.Model
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;

    public partial class ProjectItem : IEntity
    {
        public string Name { get; set; }

        public ProjectItemType ItemType { get; set; }

        [ForeignKey("ParentProjectItemId")]
        public ProjectItem ParentProjectItem { get; set; }

        [InverseProperty("ParentProjectItem")]
        public ObservableCollection<ProjectItem> ChildProjectItems { get; set; }
    }
}
