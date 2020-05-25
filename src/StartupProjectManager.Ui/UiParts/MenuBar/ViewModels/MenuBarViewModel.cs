// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-04-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.UiParts.MenuBar.ViewModels
{
    using Caliburn.Micro;
    using Microsoft.Extensions.Logging;
    using ProjectTree.Messages;
    using Properties;

    /// <summary>
    /// Class MenuBarViewModel.
    /// Implements the <see cref="Caliburn.Micro.Screen" />
    /// </summary>
    /// <seealso cref="Caliburn.Micro.Screen" />
    public class MenuBarViewModel : Screen
    {
        private readonly IEventAggregator _aggregator;
        private readonly ILogger<MenuBarViewModel> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuBarViewModel"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="aggregator">The aggregator.</param>
        public MenuBarViewModel(ILogger<MenuBarViewModel> logger,
                                IEventAggregator aggregator)
        {
            _aggregator = aggregator;
            _logger = logger;
        }

        /// <summary>
        /// Called when an attached view's Loaded event fires.
        /// </summary>
        /// <param name="view">The view.</param>
        protected override void OnViewLoaded(object view)
        {
            _logger.LogDebug(Resources.Info_ViewLoaded, nameof(MenuBarViewModel));
            _aggregator.Subscribe(this);
        }

        /// <summary>
        /// Gets a value indicating whether this instance can file menu new.
        /// </summary>
        /// <value><c>true</c> if this instance can file menu new; otherwise, <c>false</c>.</value>
        // ReSharper disable once UnusedMember.Global
        public bool CanFileMenuNew => true;

        /// <summary>
        /// Files the menu new.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public void FileMenuNew() => _aggregator.PublishOnUIThreadAsync(new AddProjectItemMessage());
    }
}
