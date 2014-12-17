using Cares.Models.IdentityModels;

namespace Cares.Models.DomainModels
{
    using System.Collections.Generic;
    
    /// <summary>
    /// User Role
    /// </summary>
    public partial class UserRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
        
        public virtual ICollection<MenuRight> MenuRights { get; set; }
    }
}
