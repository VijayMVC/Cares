using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// User Model being used to edit user 
    /// </summary>
    public class UserModelForEditUser
    {
        public string id { get; set; }
        public string UserEmail { get; set; }
        public string SelectedRole { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<UserRole> Roles { get; set; } 
    }
}