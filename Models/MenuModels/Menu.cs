﻿using System.Collections.Generic;
using Cares.Models.MenuModels;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// MainMenu class for dynamic menu population from database
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Menu Id
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// Menu Key
        /// </summary>
        public int MenuKey { get; set; }
        /// <summary>
        /// Menu Title
        /// </summary>
        public string MenuTitle { get; set; }
        /// <summary>
        /// Sort Order
        /// </summary>
        public int SortOrder { get; set; }
        /// <summary>
        /// Menu Target Url
        /// </summary>
        public string MenuTargetController { get; set; }
        /// <summary>
        /// Menu Image Path
        /// </summary>
        public string MenuImagePath { get; set; }
        /// <summary>
        /// Menu Function
        /// </summary>
        public string MenuFunction { get; set; }
        /// <summary>
        /// Permission Key
        /// </summary>
        public string PermissionKey { get; set; }
        /// <summary>
        /// Menu Root Item Check
        /// </summary>
        public bool IsRootItem { get; set; }
        /// <summary>
        /// Parent Menu Id
        /// </summary>
        public int? ParentMenuId { get; set; }
        /// <summary>
        /// Menu Parent Item
        /// </summary>
        public virtual Menu ParentItem { get; set; }

        /// <summary>
        /// Menu Rights
        /// </summary>
        public virtual ICollection<MenuRight> MenuRights { get; set; } 
    }
}
