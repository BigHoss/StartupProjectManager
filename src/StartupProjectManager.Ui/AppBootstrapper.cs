// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-01-2020
// ***********************************************************************
namespace StartupProjectManager.Ui
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    using Autofac;
    using Caliburn.Micro.Autofac;
    using Serilog;

    /// <summary>
    /// Class AppBootstrapper.
    /// Implements the <see cref="Caliburn.Micro.BootstrapperBase" />
    /// </summary>
    /// <seealso cref="Caliburn.Micro.BootstrapperBase" />
    public class AppBootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppBootstrapper" /> class.
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
        /// Configures the container.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void ConfigureContainer(ContainerBuilder builder) => builder.RegisterModule<UiModule>();

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
