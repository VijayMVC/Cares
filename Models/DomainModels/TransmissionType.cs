using System.ComponentModel.DataAnnotations;
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
        [StringLength(100), Required]
        public string TransmissionTypeCode { get; set; }
        
        /// <summary>
        /// Transmission Type Name
        /// </summary>
        [StringLength(255)]
        public string TransmissionTypeName { get; set; }

        #endregion
    }
}
