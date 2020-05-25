// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-04-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.Detail.Messages
{
    using Database.Model;

    /// <summary>
    /// Class OpenProjectItemMessage. This class cannot be inherited.
    /// </summary>
    public sealed class OpenProjectItemMessage 
    {
        /// <summary>
        /// Gets or sets the project item.
        /// </summary>
        /// <value>The project item.</value>
        public ProjectItem ProjectItem { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenProjectItemMessage"/> class.
        /// </summary>
        /// <param name="projectItem">The project item.</param>
        public OpenProjectItemMessage(ProjectItem projectItem) => ProjectItem = projectItem;
    }
}
