// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-04-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.UiParts.ProjectTree.ViewModels
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Documents;
    using Caliburn.Micro;
    using Database.Model;
    using Messages;
    using Microsoft.Extensions.Logging;
    using Properties;
    using Services.Services;
    using Ui.Detail.Messages;
    using Views;

    /// <summary>
    /// Class ProjectTreeViewModel.
    /// Implements the <see cref="Screen" />
    /// </summary>
    /// <seealso cref="Caliburn.Micro.Screen" />
    public class ProjectTreeViewModel : Screen, IHandle<AddProjectItemMessage>
    {

        private readonly IProjectItemService _projectItemService;
        private readonly IEventAggregator _eventAggregator;
        private readonly ILogger<ProjectTreeViewModel> _logger;

        private BindableCollection<ProjectItem> projectItems;
        private ProjectItem selectedProjectItem;



        /// <summary>
        /// Gets or sets the project items.
        /// </summary>
        /// <value>The project items.</value>
        public BindableCollection<ProjectItem> ProjectItems
        {
            get => projectItems;
            set
            {
                projectItems = value;
                NotifyOfPropertyChange(() => ProjectItems);
            }
        }


        /// <summary>
        /// Gets or sets the selected project item.
        /// </summary>
        /// <value>The selected project item.</value>
        public ProjectItem SelectedProjectItem
        {
            get => selectedProjectItem;
            set
            {
                selectedProjectItem = value;
                NotifyOfPropertyChange(() => SelectedProjectItem);
                _eventAggregator.PublishOnUIThreadAsync(new OpenProjectItemMessage(value));
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectTreeViewModel" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="projectItemService">The project item service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ProjectTreeViewModel(ILogger<ProjectTreeViewModel> logger,
                                    IProjectItemService projectItemService,
                                    IEventAggregator eventAggregator)
        {
            _logger = logger;
            _projectItemService = projectItemService;
            _eventAggregator = eventAggregator;
        }

        /// <summary>
        /// Called when an attached view's Loaded event fires.
        /// </summary>
        /// <param name="view">The view.</param>
        protected override void OnViewLoaded(object view)
        {
            _logger.LogDebug(Resources.Info_ViewLoaded, nameof(ProjectTreeView));
            ProjectItems = new BindableCollection<ProjectItem>(_projectItemService.GetAllProjectItems());
        }

        private bool myVar;

        public bool MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        /// <summary>
        /// Adds the project item.
        /// </summary>
        /// <returns>Task.</returns>
        public Task AddProjectItem()
        {
            throw new NotImplementedException();
        }



        public Task AddSubProjectItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task that represents the asynchronous coroutine.</returns>
        public Task HandleAsync(AddProjectItemMessage message,
                                CancellationToken cancellationToken) =>
            AddProjectItem();
    }
}
