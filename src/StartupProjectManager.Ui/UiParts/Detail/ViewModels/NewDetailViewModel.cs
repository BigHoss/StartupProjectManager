// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-07-2020
// ***********************************************************************

namespace StartupProjectManager.Ui.UiParts.Detail.ViewModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using Database.Model;
    using Messages;
    using Microsoft.Extensions.Logging;
    using StartupProjectManager.Ui.UiParts.ProjectTree.Messages;
    using Properties;
    using StartupProjectManager.Ui.Detail.Messages;
    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    /// Class NewDetailViewModel.
    /// Implements the <see cref="Screen" />
    /// Implements the <see cref="IDetailViewModel" />
    /// Implements the <see cref="OpenDetailMessage" />
    /// </summary>
    /// <seealso cref="Screen" />
    /// <seealso cref="IDetailViewModel" />
    /// <seealso cref="OpenDetailMessage" />
    // ReSharper disable once ClassNeverInstantiated.Global
    public class NewDetailViewModel : Screen,
                                      IDetailViewModel,
                                      IHandle<OpenDetailMessage>
    {
        private readonly ILogger<NewDetailViewModel> _logger;
        private readonly IEventAggregator _eventAggregator;
        private ProjectItem projectItem = null!;
        private ProjectItem originalProjectItem = null!;

        /// <summary>
        /// Gets or sets the project item.
        /// </summary>
        /// <value>The project item.</value>
        public ProjectItem ProjectItem
        {
            get => projectItem;
            set => Set(ref projectItem, value, nameof(ProjectItem));
        }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>The type of the item.</value>
        public ProjectItemTypeEnum ItemType
        {
            get => ProjectItem?.ItemType.Name ?? ProjectItemTypeEnum.New;
            set
            {
                ProjectItem.ItemType.Name = value;
                NotifyOfPropertyChange(() => ItemType);
                NotifyOfPropertyChange(() => ProjectItem);
            }
        }


        /// <summary>
        /// Gets all project types.
        /// </summary>
        /// <value>All project types.</value>
        public IEnumerable<ProjectItemTypeEnum> AllProjectTypes => new [] {ProjectItemTypeEnum.Application, ProjectItemTypeEnum.Document, ProjectItemTypeEnum.Project};


        /// <summary>
        /// Initializes a new instance of the <see cref="NewDetailViewModel" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public NewDetailViewModel(ILogger<NewDetailViewModel> logger,
                                  IEventAggregator eventAggregator)
        {
            _logger = logger;
            _eventAggregator = eventAggregator;
        }

        /// <summary>
        /// Called when an attached view's Loaded event fires.
        /// </summary>
        /// <param name="view">The view.</param>
        protected override void OnViewLoaded(object view)
        {
            _logger.LogDebug(Resources.Info_ViewLoaded, nameof(NewDetailViewModel));
            _eventAggregator.Subscribe(this);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save() => _eventAggregator.PublishOnUIThread(new UpdateProjectItemMessage(ProjectItem));

        /// <summary>
        /// Cancels this instance.
        /// </summary>
        public void Cancel() => _eventAggregator.PublishOnUIThread(new OpenProjectItemMessage(originalProjectItem));


        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(OpenDetailMessage message)
        {
            ProjectItem = message.ProjectItem;
            originalProjectItem = ProjectItem;
        }
    }
}
