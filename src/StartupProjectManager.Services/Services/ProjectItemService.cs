// ***********************************************************************
// Assembly         : StartupProjectManager.Services
// Author           : Rku
// Created          : 05-01-2020
// ***********************************************************************

namespace StartupProjectManager.Services.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Database.Data;
    using Database.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Properties;

    /// <summary>
    /// Class ProjectItemService.
    /// Implements the <see cref="StartupProjectManager.Services.Services.IProjectItemService" />
    /// </summary>
    /// <seealso cref="StartupProjectManager.Services.Services.IProjectItemService" />
    public class ProjectItemService : IProjectItemService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger _logger;
        /// <summary>
        /// The context
        /// </summary>
        private StartupProjectManagerContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectItemService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        public ProjectItemService(ILogger<ProjectItemService> logger,
                                  StartupProjectManagerContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Logs the debug method start.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">The parameters.</param>
        void LogDebugMethodStart(string methodName,
                            List<(string, string)> parameters = null)
            => _logger.LogDebug(Resources.Debug_StartMethod,
            nameof(ProjectItemService), methodName, parameters);

        /// <summary>
        /// Gets all project items.
        /// </summary>
        /// <returns>List&lt;ProjectItem&gt;.</returns>
        public List<ProjectItem> GetAllProjectItems()
        {
            LogDebugMethodStart(nameof(GetAllProjectItems));

            return _context.Set<ProjectItem>()
                    .Include(x => x.ItemType)
                    .ToList();
        }
    }
}
