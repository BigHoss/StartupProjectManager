// ***********************************************************************
// Assembly         : StartupProjectManager.Services
// Author           : Rku
// Created          : 05-01-2020
// ***********************************************************************
namespace StartupProjectManager.Services.Services.ProjectItem
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Base;
    using Database.Model;

    /// <summary>
    /// Interface IProjectItemService
    /// Implements the <see cref="StartupProjectManager.Services.Services.Base.IService" />
    /// </summary>
    /// <seealso cref="StartupProjectManager.Services.Services.Base.IService" />
    public interface IProjectItemService : IService
    {
        /// <summary>
        /// Gets all project items.
        /// </summary>
        /// <returns>List&lt;ProjectItem&gt;.</returns>
        List<ProjectItem> GetAll();

        /// <summary>
        /// Adds the specified root item identifier.
        /// </summary>
        /// <param name="parentItemId">The parent item identifier.</param>
        /// <returns>ProjectItemType.</returns>
        ProjectItem Add(int? parentItemId = null);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>ProjectItem.</returns>
        ProjectItem Update(ProjectItem item);
    }
}
