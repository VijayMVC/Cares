using System.Collections.Generic;
namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Transmission Type Domain Model  
    /// </summary>
    public class TransmissionType
    {
        #region Persisted Properties
        
        /// <summary>
        /// Transmission Type ld
        /// </summary>
        public short TransmissionTypeId { get; set; }
        
        /// <summary>
        /// Transmission Type Code
        /// </summary>
        public string TransmissionTypeCode { get; set; }
        
        /// <summary>
        /// Transmission Type Name
        /// </summary>
        public string TransmissionTypeName { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicles having this Transmission Type
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        #endregion
    }
}
