// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 04-30-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.ViewModels
{
    using System.Threading;
    using Caliburn.Micro;
    using Microsoft.Extensions.Logging;
    using Properties;
    using UiParts.Content.ViewModels;
    using UiParts.Detail.ViewModels;
    using UiParts.ProjectTree.ViewModels;

    /// <summary>
    /// Class ShellViewModel.
    /// Implements the <see cref="Caliburn.Micro.Screen" />
    /// </summary>
    /// <seealso cref="Caliburn.Micro.Screen" />
    public class ShellViewModel : Conductor<Screen>.Collection.AllActive
    {
        private readonly ILogger<ShellViewModel> _logger;
        private readonly IEventAggregator _aggregator;

        private string _title = "StartupProjectManager";
        private ContentConductorViewModel _contentConductorViewModel;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public ContentConductorViewModel ContentConductorViewModel
        {
            get
            {
                return _contentConductorViewModel;
            }
            set
            {
                _contentConductorViewModel = value;
                NotifyOfPropertyChange(() => ContentConductorViewModel);
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="aggregator">The aggregator.</param>
        public ShellViewModel(ILogger<ShellViewModel> logger,
                              IEventAggregator aggregator,
                              ContentConductorViewModel contentConductorViewModel)
        {
            _logger = logger;
            _aggregator = aggregator;
            this._contentConductorViewModel = contentConductorViewModel;


        }

        /// <summary>
        /// Called when an attached view's Loaded event fires.
        /// </summary>
        /// <param name="view">The view.</param>
        protected override void OnViewLoaded(object view)
        {
            _logger.LogDebug(Resources.Info_ViewLoaded, nameof(ShellViewModel));

            
        }
    }
}
