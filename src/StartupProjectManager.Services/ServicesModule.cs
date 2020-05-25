// ***********************************************************************
// Assembly         : StartupProjectManager.Services
// Author           : Rku
// Created          : 04-28-2020
// ***********************************************************************
namespace StartupProjectManager.Services
{
    using Autofac;
    using Database;
    using Services.Base;

    /// <summary>
    /// Class ServicesModule.
    /// Implements the <see cref="Autofac.Module" />
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class ServicesModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DatabaseModule>();

            //builder.RegisterAssemblyTypes(ThisAssembly)
            //       .Where(x => x.Name.EndsWith("Service"))
            //       .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                   .Where(t => typeof(IService).IsAssignableFrom(t))
                   .AsImplementedInterfaces();
        }
    }
}
