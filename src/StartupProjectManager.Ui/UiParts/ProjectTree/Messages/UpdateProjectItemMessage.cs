// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-05-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.UiParts.ProjectTree.Messages
{
    using Database.Model;

    /// <summary>
    /// Class UpdateProjectItemMessage.
    /// </summary>
    public class UpdateProjectItemMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProjectItemMessage"/> class.
        /// </summary>
        /// <param name="projectItem">The project item.</param>
        public UpdateProjectItemMessage(ProjectItem projectItem) => ProjectItem = projectItem;

        /// <summary>
        /// Gets or sets the project item.
        /// </summary>
        /// <value>The project item.</value>
        public ProjectItem ProjectItem { get; private set; }
    }
}
