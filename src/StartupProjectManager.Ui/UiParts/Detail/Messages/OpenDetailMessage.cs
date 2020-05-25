// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-07-2020
// ***********************************************************************

namespace StartupProjectManager.Ui.UiParts.Detail.Messages
{
    using Database.Model;

    /// <summary>
    /// Class OpenDetailMessage.
    /// </summary>
    public class OpenDetailMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenDetailMessage"/> class.
        /// </summary>
        /// <param name="projectItem">The project item.</param>
        public OpenDetailMessage(ProjectItem projectItem) => ProjectItem = projectItem;

        /// <summary>
        /// Gets or sets the project item.
        /// </summary>
        /// <value>The project item.</value>
        public ProjectItem ProjectItem { get; set; }
    }
}
