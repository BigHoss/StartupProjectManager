// ***********************************************************************
// Assembly         : StartupProjectManager.Services
// Author           : Rku
// Created          : 05-01-2020
// ***********************************************************************
namespace StartupProjectManager.Services.Services
{
    using System.Collections.Generic;
    using Database.Model;
    using Base;

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
        List<ProjectItem> GetAllProjectItems();
    }
}
