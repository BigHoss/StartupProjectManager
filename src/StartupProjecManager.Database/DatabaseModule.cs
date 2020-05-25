// ***********************************************************************
// Assembly         : StartupProjectManager.Database
// Author           : Rku
// Created          : 05-01-2020
// ***********************************************************************
namespace StartupProjectManager.Database
{
    using Autofac;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Class DatabaseModule.
    /// Implements the <see cref="Autofac.Module" />
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class DatabaseModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder builder) => builder.Register(c =>
            {
                var configuration = c.Resolve<IConfiguration>();

                
                var contextOptionsBuilder = new DbContextOptionsBuilder<StartupProjectManagerContext>()
                    .UseSqlite(configuration["ConnectionStrings:Default"]);

                return new StartupProjectManagerContext(contextOptionsBuilder.Options);
            }
        ).InstancePerDependency();

    }
}
