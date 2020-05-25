namespace StartupProjectManager.Database.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Model;

    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var now = DateTime.UtcNow;
            var userName = Environment.UserName;
            var rootItemType = new ProjectItemType
            {
                Id = 1,
                Name = ProjectItemTypeEnum.Root,
                CreatedBy = userName,
                CreatedOn = now,
                ModifiedBy = userName,
                ModifiedOn = now
            };

            modelBuilder.Entity<ProjectItemType>().HasData(
                new ProjectItemType { Id = 2, Name = ProjectItemTypeEnum.Application, CreatedBy = userName, CreatedOn = now, ModifiedBy = userName, ModifiedOn = now },
                new ProjectItemType { Id = 3, Name = ProjectItemTypeEnum.Document, CreatedBy = userName, CreatedOn = now, ModifiedBy = userName, ModifiedOn = now },
                new ProjectItemType { Id = 4, Name = ProjectItemTypeEnum.New, CreatedBy = userName, CreatedOn = now, ModifiedBy = userName, ModifiedOn = now},
                new ProjectItemType { Id = 5, Name = ProjectItemTypeEnum.Project, CreatedBy = userName, CreatedOn = now, ModifiedOn = now, ModifiedBy = userName},
                rootItemType
            );
            modelBuilder.Entity<ProjectItem>().HasData(
                new ProjectItem
                {
                    Id = 1,
                    Name = "Root",
                    ItemTypeId = rootItemType.Id,
                    CreatedBy = userName,
                    CreatedOn = now,
                    ModifiedBy = userName,
                    ModifiedOn = now
                }
            );
        }
    }
}
