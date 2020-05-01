// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-01-2020
//
// Last Modified By : Rku
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="InitializeModule.cs" company="StartupProjectManager.Ui">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace StartupProjectManager.Ui
{
    using System;
    using System.IO;
    using Autofac;
    using Caliburn.Micro;
    using Microsoft.Extensions.Configuration;
    using Serilog;
    using Serilog.Extensions.Autofac.DependencyInjection;
    using Services;

    /// <summary>
    /// Class InitializeModule.
    /// Implements the <see cref="Autofac.Module" />
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class InitializeModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                   .AssignableTo<Screen>()
                   .AsSelf();

            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                                .AddJsonFile("appsettings.json", false)
                                .Build();

            builder.Register(ctx => configuration).As<IConfiguration>();

            var loggerConfiguration = new LoggerConfiguration()
                                          .ReadFrom.Configuration(configuration);

            builder.RegisterSerilog(loggerConfiguration);

            builder.RegisterModule<ServicesModule>();

            builder.Register<IWindowManager>(c => new WindowManager()).InstancePerLifetimeScope();

            builder.Register<IEventAggregator>(c => new EventAggregator()).InstancePerLifetimeScope();


            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(configuration["SyncfusionLicense"]);
        }
    }
}
