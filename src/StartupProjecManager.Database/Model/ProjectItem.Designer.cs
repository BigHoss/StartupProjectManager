namespace StartupProjectManager.Database.Model
{
    using System;

    public partial class ProjectItem
    {
       public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
