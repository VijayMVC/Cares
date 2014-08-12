using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    /// <summary>
    /// Address Type Dropdown Web Model
    /// </summary>
    public class AddressTypeDropDown
    {
        /// <summary>
        /// Address Type ID
        /// </summary>
        public int AddressTypeId { get; set; }
        /// <summary>
        /// AddressType Code and Name
        /// </summary>
        [StringLength(255)]
        public string AddressTypeCodeName { get; set; }
      
    }
}