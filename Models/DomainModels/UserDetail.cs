using Cares.Models.IdentityModels;

namespace Cares.Models.DomainModels
{
    public class UserDetail
    {
        public int UserDetailId { get; set; }
        public string CompanyName { get; set; }
        public string CountryName { get; set; }
        public string Address { get; set; }
        public string AccountType { get; set; }
        public string UserId { get; set; }
        public virtual User AspNetUser { get; set; }
    }
}
