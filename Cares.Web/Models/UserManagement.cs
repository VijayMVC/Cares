
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Web.Models
{
    /// <summary>
    /// User mgmt model in user mangement section
    /// </summary>
    public class UserManagement
    {
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public long DomainKey { get; set; }
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}