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
    using Microsoft.Extensions.Logging;
    using Ui.Detail.Messages;

    /// <summary>
    /// Class DetailConductorViewModel.
    /// Implements the <see cref="Conductor{T}.Collection.OneActive" />
    /// Implements the <see cref="OpenProjectItemMessage" />
    /// </summary>
    /// <seealso cref="Conductor{T}.Collection.OneActive" />
    /// <seealso cref="OpenProjectItemMessage" />
    public class DetailConductorViewModel : Conductor<Screen>.Collection.OneActive, IHandle<OpenProjectItemMessage>
    {
        private readonly ILogger<DetailConductorViewModel> _logger;
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailConductorViewModel" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public DetailConductorViewModel(ILogger<DetailConductorViewModel> logger,
                                        IEventAggregator eventAggregator)
        {
            _logger = logger;
            _eventAggregator = eventAggregator;
        }
        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task that represents the asynchronous coroutine.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task HandleAsync(OpenProjectItemMessage message,
                                CancellationToken cancellationToken) =>
            throw new System.NotImplementedException();
    }
}
