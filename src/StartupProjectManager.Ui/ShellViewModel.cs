// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 04-30-2020
// ***********************************************************************
namespace StartupProjectManager.Ui
{
    using Caliburn.Micro;
    using Microsoft.Extensions.Logging;
    using Properties;
    using UiParts.Content.ViewModels;

    /// <summary>
    /// Class ShellViewModel.
    /// Implements the <see cref="Caliburn.Micro.Screen" />
    /// </summary>
    /// <seealso cref="Caliburn.Micro.Screen" />
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive
    {
        private readonly ILogger<ShellViewModel> _logger;
        
        private string title = "StartupProjectManager";
        private ContentConductorViewModel contentConductorViewModel = null!;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        // ReSharper disable once UnusedMember.Global
        public string Title
        {
            get => title;
            set
            {
                title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        /// <summary>
        /// Gets or sets the content conductor view model.
        /// </summary>
        /// <value>The content conductor view model.</value>
        public ContentConductorViewModel ContentConductorViewModel
        {
            get => contentConductorViewModel;
            set
            {
                contentConductorViewModel = value;
                NotifyOfPropertyChange(() => ContentConductorViewModel);
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="contentConductorViewModel">The content conductor view model.</param>
        public ShellViewModel(ILogger<ShellViewModel> logger,
                              ContentConductorViewModel contentConductorViewModel)
        {
            _logger = logger;
            ContentConductorViewModel = contentConductorViewModel;


        }

        /// <summary>
        /// Called when an attached view's Loaded event fires.
        /// </summary>
        /// <param name="view">The view.</param>
        protected override void OnViewLoaded(object view)
        {
            _logger.LogDebug(Resources.Info_ViewLoaded, nameof(ShellViewModel));
            ActivateItem(ContentConductorViewModel);
        }
    }
}
