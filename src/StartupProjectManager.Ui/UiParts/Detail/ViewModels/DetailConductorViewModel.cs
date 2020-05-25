// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-04-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.UiParts.Detail.ViewModels
{
    using System.Threading;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using Database.Model;
    using Messages;
    using Microsoft.Extensions.Logging;
    using Properties;
    using StartupProjectManager.Ui.Detail.Messages;
    
    /// <summary>
    /// Class DetailConductorViewModel.
    /// Implements the <see cref="Conductor{T}.Collection.OneActive" />
    /// Implements the <see cref="OpenProjectItemMessage" />
    /// </summary>
    /// <seealso cref="Conductor{T}.Collection.OneActive" />
    /// <seealso cref="OpenProjectItemMessage" />
    public class DetailConductorViewModel : Conductor<Screen>.Collection.OneActive,
                                            IHandle<OpenProjectItemMessage>
    {
        private readonly ILogger<DetailConductorViewModel> _logger;
        private readonly IEventAggregator _eventAggregator;
        private readonly ApplicationDetailViewModel _applicationDetailViewModel;
        private readonly NewDetailViewModel _newDetailViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailConductorViewModel" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="applicationDetailViewModel">The application detail view model.</param>
        /// <param name="newDetailViewModel">The new detail view model.</param>
        public DetailConductorViewModel(ILogger<DetailConductorViewModel> logger,
                                        IEventAggregator eventAggregator,
                                        ApplicationDetailViewModel applicationDetailViewModel,
                                        NewDetailViewModel newDetailViewModel)
        {
            _logger = logger;
            _eventAggregator = eventAggregator;
            _applicationDetailViewModel = applicationDetailViewModel;
            _newDetailViewModel = newDetailViewModel;
        }

        /// <summary>
        /// Called when an attached view's Loaded event fires.
        /// </summary>
        /// <param name="view">The view.</param>
        protected override void OnViewLoaded(object view)
        {
            _logger.LogDebug(Resources.Info_ViewLoaded, nameof(DetailConductorViewModel));
            _eventAggregator.Subscribe(this);
        }


        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Handle(OpenProjectItemMessage message)
        {
            var projectItem = message.ProjectItem;

            switch (projectItem.ItemType.Name)
            {
                case ProjectItemTypeEnum.Root:
                    break;
                case ProjectItemTypeEnum.Application:
                    ActivateItem(_applicationDetailViewModel);
                    break;
                case ProjectItemTypeEnum.Document:
                    break;
                case ProjectItemTypeEnum.New:
                    ActivateItem(_newDetailViewModel);
                    break;
            }
            _eventAggregator.PublishOnUIThread(new OpenDetailMessage(projectItem));
        }

    }
}
