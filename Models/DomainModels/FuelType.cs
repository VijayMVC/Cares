using System.Collections.Generic;
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
        public string FuelTypeCode { get; set; }
        
        /// <summary>
        /// FuelType Name
        /// </summary>
        public string FuelTypeName { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
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
