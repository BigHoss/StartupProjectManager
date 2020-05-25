// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-04-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.UiParts.ProjectTree.ViewModels
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using Database.Model;
    using Messages;
    using Microsoft.Extensions.Logging;
    using Properties;
    using StartupProjectManager.Services.Services;
    using StartupProjectManager.Services.Services.ProjectItem;
    using Ui.Detail.Messages;
    using Views;

    /// <summary>
    /// Class ProjectTreeViewModel.
    /// Implements the <see cref="Screen" />
    /// </summary>
    /// <seealso cref="Caliburn.Micro.Screen" />
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ProjectTreeViewModel : Screen,
                                        IHandle<AddProjectItemMessage>,
                                        IHandle<AddSubProjectItemMessage>,
                                        IHandle<UpdateProjectItemMessage>
    {

        private readonly IProjectItemService _projectItemService;
        private readonly IEventAggregator _eventAggregator;
        private readonly ILogger<ProjectTreeViewModel> _logger;

        private BindableCollection<ProjectItem> projectItems = new BindableCollection<ProjectItem>();
        private ProjectItem selectedProjectItem = new ProjectItem();



        /// <summary>
        /// Gets or sets the project items.
        /// </summary>
        /// <value>The project items.</value>
        public BindableCollection<ProjectItem> ProjectItems
        {
            get => projectItems;
            set => Set(ref projectItems, value, nameof(ProjectItems));
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
                Set(ref selectedProjectItem, value, nameof(SelectedProjectItem));
                _eventAggregator.PublishOnUIThread(new OpenProjectItemMessage(value));
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
            _eventAggregator.Subscribe(this);

            ProjectItems = new BindableCollection<ProjectItem>(_projectItemService.GetAll());
        }

        /// <summary>
        /// Adds the project item.
        /// </summary>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public void AddProjectItem()
        {
            var newItem = _projectItemService.Add();

            ProjectItems.Add(newItem);

            SelectedProjectItem = newItem;
        }


        /// <summary>
        /// Adds the sub project item.
        /// </summary>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public void AddSubProjectItem()
        {
            var newItem = _projectItemService.Add(SelectedProjectItem?.Id);

            ProjectItems.Add(newItem);

            SelectedProjectItem = newItem;
        }


        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(AddSubProjectItemMessage message) => AddSubProjectItem();

        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(UpdateProjectItemMessage message)
        {
            ProjectItems = new BindableCollection<ProjectItem>(ProjectItems.Where(x => x.Id == message.ProjectItem.Id)
                                                                              .Select(y => { return message.ProjectItem; })
                                                                              .ToList());

            _projectItemService.Update(message.ProjectItem);
        } 

        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(AddProjectItemMessage message) => AddProjectItem();


    }
}
