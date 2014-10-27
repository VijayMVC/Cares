namespace Cares.Models.DomainModels
{
    /// <summary>
    /// User Claim
    /// </summary>
    public class UserClaim
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    
        public virtual User User { get; set; }
    }
}
