
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cares.Models.DomainModels;

namespace Cares.Web.Models
{
    /// <summary>
    /// User mgmt model in user mangement section
    /// </summary>
    public class UserManagement
    {
        [Display(Name = "User Email")]
        public string UserEmail { get; set; }

        [Display(Name = "User Role")]
        public string UserRole { get; set; }

        public long DomainKey { get; set; }
        public string Id { get; set; }

       [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}