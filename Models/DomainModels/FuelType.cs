using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Fuel Type Domain Model  
    /// </summary>
    public class FuelType
    {
        #region Persisted Properties
        
        /// <summary>
        /// FuelType ld
        /// </summary>
        public short FuelTypeId { get; set; }
        
        /// <summary>
        /// Fuel Type Code
        /// </summary>
        [StringLength(100), Required]
        public string FuelTypeCode { get; set; }
        
        /// <summary>
        /// FuelType Name
        /// </summary>
        [StringLength(255)]
        public string FuelTypeName { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }
        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicles having this Fuel Type
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        #endregion

    }
}
