namespace StartupProjectManager.Database.Model
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;

    public partial class ProjectItemType : IEntity
    {
        public ProjectItemTypeEnum Name { get; set; }

        public byte[] Icon { get; set; }

        }
}
