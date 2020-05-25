// ***********************************************************************
// Assembly         : StartupProjectManager.Services
// Author           : Rku
// Created          : 05-01-2020
// ***********************************************************************

namespace StartupProjectManager.Services.Services.ProjectItem
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Database.Data;
    using Database.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Properties;

    /// <summary>
    /// Class ProjectItemService.
    /// Implements the <see cref="IProjectItemService" />
    /// </summary>
    /// <seealso cref="IProjectItemService" />
    public class ProjectItemService : IProjectItemService
    {
        private readonly ILogger _logger;
        private readonly StartupProjectManagerContext _context;

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
        private void LogDebugMethodStart(string methodName,
                                         (string, string)[] parameters = null) =>
            _logger.LogDebug(Resources.Debug_StartMethod,
                nameof(ProjectItemService), methodName, parameters
            );

        /// <summary>
        /// Gets all project items.
        /// </summary>
        /// <returns>List&lt;ProjectItem&gt;.</returns>
        public List<ProjectItem> GetAll()
        {
            LogDebugMethodStart(nameof(GetAll));

            return _context.Set<ProjectItem>()
                    .Include(x => x.ItemType)
                    .ToList();
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="parentItemId">The parent item identifier.</param>
        /// <returns>ProjectItemType.</returns>
        public ProjectItem Add(int? parentItemId = null)
        {
            LogDebugMethodStart(nameof(Add), new []{(nameof(parentItemId), parentItemId.ToString())});

            var parent = _context.Set<ProjectItem>().FirstOrDefault(x => x.Id == parentItemId);

            var newType = _context.Set<ProjectItemType>().FirstOrDefault(x => x.Name == ProjectItemTypeEnum.New);

            var item = _context.Set<ProjectItem>()
                                 .Add(new ProjectItem { ParentProjectItem = parent, ItemType = newType});

            _context.SaveChanges();

            return item.Entity;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>ProjectItem.</returns>
        public ProjectItem Update(ProjectItem item)
        {
            LogDebugMethodStart(nameof(Update), new []{(nameof(item), item?.Id.ToString())});

            item = _context.Set<ProjectItem>()
                           .Update(item)
                           .Entity;
            _context.SaveChanges();

            return item;
        }

       
    }
}
