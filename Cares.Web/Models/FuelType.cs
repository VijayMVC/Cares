
namespace Cares.Web.Models
{
    /// <summary>
    /// Fuel Type Api Model
    /// </summary>
    public class FuelType
    {
        #region Public Properties

        /// <summary>
        /// FuelType ID
        /// </summary>
        public short FuelTypeId { get; set; }

        /// <summary>
        /// FuelType Code
        /// </summary>
        public string FuelTypeCode { get; set; }

        /// <summary>
        /// FuelType Name
        /// </summary>
        public string FuelTypeName { get; set; }

        /// <summary>
        /// FuelType Code Name
        /// </summary>
        public string FuelTypeCodeName {
            get
            {
                return string.Format("{0}-{1}", FuelTypeCode, FuelTypeName);
            } 
        }

        #endregion
    }
}
