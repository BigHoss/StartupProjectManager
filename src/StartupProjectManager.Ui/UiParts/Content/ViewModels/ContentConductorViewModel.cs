// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-04-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.UiParts.Content.ViewModels
{
    using System.Threading;
    using Caliburn.Micro;
    using Detail.ViewModels;
    using MenuBar.ViewModels;
    using Microsoft.Extensions.Logging;
    using ProjectTree.ViewModels;
    using Properties;

    /// <summary>
    /// Class ContentConductorViewModel.
    /// Implements the <see cref="Conductor{Screen}.Collection.AllActive" />
    /// </summary>
    /// <seealso cref="Conductor{Screen}.Collection.AllActive" />
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ContentConductorViewModel : Conductor<Screen>.Collection.AllActive
    {
        private readonly ILogger<ContentConductorViewModel> _logger;
        
        private MenuBarViewModel menuBarViewModel = null!;
        private ProjectTreeViewModel projectTreeViewModel = null!;
        private DetailConductorViewModel detailConductorConductorViewModel = null!;

        /// <summary>
        /// Gets or sets the menu bar.
        /// </summary>
        /// <value>The menu bar.</value>
        public MenuBarViewModel MenuBarViewModel
        {
            get => menuBarViewModel;
            set
            {
                menuBarViewModel = value;
                NotifyOfPropertyChange(() => MenuBarViewModel);
            }
        }

        /// <summary>
        /// Gets or sets the project tree.
        /// </summary>
        /// <value>The project tree.</value>
        public ProjectTreeViewModel ProjectTreeViewModel
        {
            get => projectTreeViewModel;
            set
            {
                projectTreeViewModel = value;
                NotifyOfPropertyChange(() => ProjectTreeViewModel);
            }
        }

        /// <summary>
        /// Gets or sets the detail conductor view model.
        /// </summary>
        /// <value>The detail conductor view model.</value>
        public DetailConductorViewModel DetailConductorViewModel
        {
            get => detailConductorConductorViewModel;
            set
            {
                detailConductorConductorViewModel = value;
                NotifyOfPropertyChange(() => DetailConductorViewModel);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentConductorViewModel" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="menuBarViewModel">The menu bar view model.</param>
        /// <param name="projectTreeViewModel">The project TreeView model.</param>
        /// <param name="detailConductorViewModel">The detail conductor view model.</param>
        public ContentConductorViewModel(ILogger<ContentConductorViewModel> logger,
                                         MenuBarViewModel menuBarViewModel,
                                         ProjectTreeViewModel projectTreeViewModel,
                                         DetailConductorViewModel detailConductorViewModel)
        {
            _logger = logger;
            
            MenuBarViewModel = menuBarViewModel;
            ProjectTreeViewModel = projectTreeViewModel;
            DetailConductorViewModel = detailConductorViewModel;
        }

        /// <summary>
        /// Called when an attached view's Loaded event fires.
        /// </summary>
        /// <param name="view">The view.</param>
        protected override void OnViewLoaded(object view)
        {
            _logger.LogDebug(Resources.Info_ViewLoaded, nameof(ContentConductorViewModel));

            ActivateItem(MenuBarViewModel);
            ActivateItem(ProjectTreeViewModel);
            ActivateItem(DetailConductorViewModel);
        }

        
    }
}
