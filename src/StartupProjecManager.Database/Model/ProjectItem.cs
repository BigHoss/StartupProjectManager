namespace StartupProjectManager.Database.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;

    public partial class ProjectItem : IEntity
    {
        public string Name { get; set; }

        public int ItemTypeId { get; set; }
        public ProjectItemType ItemType { get; set; } 

        public int? ParentProjectItemId { get; set; }
        public ProjectItem ParentProjectItem { get; set; }

        [InverseProperty("ParentProjectItem")]
        public List<ProjectItem> ChildProjectItems { get; set; }

        public string NewProperty { get; set; }
    }
}
