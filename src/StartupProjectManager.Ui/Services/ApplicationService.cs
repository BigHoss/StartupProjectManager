// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-05-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using Caliburn.Micro;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Class ApplicationService.
    /// Implements the <see cref="StartupProjectManager.Ui.Services.IApplicationService" />
    /// </summary>
    /// <seealso cref="StartupProjectManager.Ui.Services.IApplicationService" />
    public class ApplicationService : IApplicationService
    {
        private string logFolder = string.Empty;

        /// <summary>
        /// Gets the log folder.
        /// </summary>
        /// <value>The log folder.</value>
        public string LogFolder
        {
            get
            {
                if (!string.IsNullOrEmpty(logFolder))
                {
                    return logFolder;
                }

                logFolder = GetLogFolder();
                return logFolder;
            }
        }

        /// <summary>
        /// Copies to clipboard.
        /// </summary>
        /// <param name="text">The text.</param>
        public void CopyToClipboard(string text) => Clipboard.SetText(text);

        /// <summary>
        /// Exits this instance.
        /// </summary>
        public void Exit() => Application.Current.Shutdown();

        /// <summary>
        /// Restarts this instance.
        /// </summary>
        public void Restart()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Opens the folder.
        /// </summary>
        /// <param name="folder">The folder.</param>
        public void OpenFolder(string folder) => System.Diagnostics.Process.Start("explorer.exe", folder);

        private static string GetLogFolder() => Environment.CurrentDirectory;
    }
}
