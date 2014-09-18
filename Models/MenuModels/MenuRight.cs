
namespace Cares.Models.DomainModels
{
    /// <summary>
    /// MenuRights class for menu assoication with role
    /// </summary>
    public class MenuRight
    {
        /// <summary>
        /// Menu Right Id
        /// </summary>
        public int MenuRightId { get; set; }

        /// <summary>
        /// Menu Id
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// Role Id
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Menu
        /// </summary>
        public virtual Menu Menu { get; set; }
    }
}