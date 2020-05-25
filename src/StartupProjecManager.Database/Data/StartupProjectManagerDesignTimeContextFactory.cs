// ***********************************************************************
// Assembly         : StartupProjectManager.Database
// Author           : Rku
// Created          : 05-01-2020
// ***********************************************************************
namespace StartupProjectManager.Database.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// Class StartupProjectManagerDesignTimeContextFactory.
    /// Implements the <see cref="StartupProjectManagerContext" />
    /// </summary>
    /// <seealso cref="StartupProjectManagerContext" />
    public class StartupProjectManagerDesignTimeContextFactory : IDesignTimeDbContextFactory<StartupProjectManagerContext>
    {
        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>An instance of <typeparamref name="TContext" />.</returns>
        public StartupProjectManagerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StartupProjectManagerContext>()
                .UseSqlite("Data Source=startupProjectManager.db")
                .EnableSensitiveDataLogging();

            return new StartupProjectManagerContext(optionsBuilder.Options);
        }
    }
}
