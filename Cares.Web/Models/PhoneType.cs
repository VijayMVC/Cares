using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    /// <summary>
    /// Phone Type Web Model
    /// </summary>
    public class PhoneType
    {
        /// <summary>
        /// Phone Type ID
        /// </summary>
        public int PhoneTypeId { get; set; }
        /// <summary>
        /// Phone Type Custom ID
        /// </summary>
        public string PhoneTypeCustomId { get; set; }
        /// <summary>
        /// PhoneType Name
        /// </summary>
        [StringLength(255)]
        public string PhoneTypeName { get; set; }
      
    }
}