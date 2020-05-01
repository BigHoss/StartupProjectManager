namespace StartupProjectManager.Database.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class StartupProjectManagerContextFactory : IDesignTimeDbContextFactory<StartupProjectManagerContext>
    {
        public StartupProjectManagerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StartupProjectManagerContext>()
                .UseSqlite("Data Source=startupProjectManager.db");

            return new StartupProjectManagerContext(optionsBuilder.Options);
        }
    }
}
