// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-01-2020
//
// Last Modified By : Rku
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="AppBootstrapper.cs" company="StartupProjectManager.Ui">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace StartupProjectManager.Ui
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    using Autofac;
    using Caliburn.Micro;
    using Serilog;
    using ViewModels;

    /// <summary>
    /// Class AppBootstrapper.
    /// Implements the <see cref="Caliburn.Micro.BootstrapperBase" />
    /// </summary>
    /// <seealso cref="Caliburn.Micro.BootstrapperBase" />
    public class AppBootstrapper : BootstrapperBase
    {
        /// <summary>
        /// The container
        /// </summary>
        private IContainer container = null!;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AppBootstrapper"/> class.
        /// </summary>
        public AppBootstrapper()
        {
            Initialize();
            
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Application.Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }

        /// <summary>
        /// Override this to add custom behavior to execute after the application starts.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The args.</param>
        protected override void OnStartup(object sender,
                                          StartupEventArgs e) =>
            DisplayRootViewFor<ShellViewModel>();

        /// <summary>
        /// Override to configure the framework and setup your IoC container.
        /// </summary>
        protected override void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<InitializeModule>();
            
            container = builder.Build();
        }

        /// <summary>
        /// Override this to provide an IoC specific implementation.
        /// </summary>
        /// <param name="service">The service to locate.</param>
        /// <param name="key">The key to locate.</param>
        /// <returns>The located service.</returns>
        protected override object GetInstance(Type service,
                                              string key) => key == null ? container.Resolve(service) : container.ResolveNamed(key, service);

        /// <summary>
        /// Override this to provide an IoC specific implementation
        /// </summary>
        /// <param name="service">The service to locate.</param>
        /// <returns>The located services.</returns>
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            var type = typeof(IEnumerable<>).MakeGenericType(service);

#pragma warning disable CS8603 // Possible null reference return.
            return container.Resolve(type) as IEnumerable<object>;
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Override this to provide an IoC specific implementation.
        /// </summary>
        /// <param name="instance">The instance to perform injection on.</param>
        protected override void BuildUp(object instance) => container.InjectProperties(instance);

        /// <summary>
        /// Tasks the scheduler on unobserved task exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnobservedTaskExceptionEventArgs"/> instance containing the event data.</param>
        private void TaskSchedulerOnUnobservedTaskException(object? sender,
                                                            UnobservedTaskExceptionEventArgs e)
        {
            Log.Information(Ui.Properties.Resources.Info_UnhandledTaskException);
            e.SetObserved();

            HandleException(e.Exception!);
        }

        /// <summary>
        /// Currents the on dispatcher unhandled exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DispatcherUnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private void CurrentOnDispatcherUnhandledException(object sender,
                                                           DispatcherUnhandledExceptionEventArgs e)
        {
            Log.Information(Ui.Properties.Resources.Info_UnhandledDispatcherThreadException);
            e.Handled = true;
            HandleException(e.Exception);
        }

        /// <summary>
        /// Currents the domain on unhandled exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private void CurrentDomainOnUnhandledException(object sender,
                                                       UnhandledExceptionEventArgs e)
        {
            Log.Information(Ui.Properties.Resources.Info_UnhandledAppDomainException);
            HandleException((e.ExceptionObject as Exception)!);
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        private void HandleException(Exception exception) => Log.Error(Ui.Properties.Resources.Error_Exception, exception);


    }
}
