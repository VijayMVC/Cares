using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    /// <summary>
    /// Address Type Web Model
    /// </summary>
    public class AddressType
    {
        /// <summary>
        /// Address Type ID
        /// </summary>
        public int AddressTypeId { get; set; }
        /// <summary>
        /// Address Type Custom ID
        /// </summary>
        public string AddressTypeCustomId { get; set; }
        /// <summary>
        /// AddressType Name
        /// </summary>
        [StringLength(255)]
        public string AddressTypeName { get; set; }
      
    }
}