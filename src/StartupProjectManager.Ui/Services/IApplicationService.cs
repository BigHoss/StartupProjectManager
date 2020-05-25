// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-05-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.Services
{
    using StartupProjectManager.Services.Services.Base;

    /// <summary>
    /// Interface IApplicationService
    /// Implements the <see cref="StartupProjectManager.Services.Services.Base.IService" />
    /// </summary>
    /// <seealso cref="StartupProjectManager.Services.Services.Base.IService" />
    public interface IApplicationService :IService
    {
        /// <summary>
        /// Gets the log folder.
        /// </summary>
        /// <value>The log folder.</value>
        string LogFolder { get; }

        /// <summary>
        /// Copies to clipboard.
        /// </summary>
        /// <param name="text">The text.</param>
        void CopyToClipboard(string text);
        /// <summary>
        /// Exits this instance.
        /// </summary>
        void Exit();
        /// <summary>
        /// Restarts this instance.
        /// </summary>
        void Restart();
        /// <summary>
        /// Opens the folder.
        /// </summary>
        /// <param name="folder">The folder.</param>
        void OpenFolder(string folder);
    }
}
