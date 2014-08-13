
namespace Cares.Web.Models
{
    /// <summary>
    /// Transmission Type Api Model
    /// </summary>
    public class TransmissionType
    {
        #region Public Properties

        /// <summary>
        /// TransmissionType ID
        /// </summary>
        public short TransmissionTypeId { get; set; }

        /// <summary>
        /// TransmissionType Code
        /// </summary>
        public string TransmissionTypeCode { get; set; }

        /// <summary>
        /// TransmissionType Name
        /// </summary>
        public string TransmissionTypeName { get; set; }
        
        /// <summary>
        /// TransmissionType Code Name
        /// </summary>
        public string TransmissionTypeCodeName {
            get
            {
                return string.Format("{0}-{1}", TransmissionTypeCode, TransmissionTypeName);
            } 
        }

        #endregion
    }
}
