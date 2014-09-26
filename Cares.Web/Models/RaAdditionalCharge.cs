namespace Cares.Web.Models
{
    /// <summary>
    /// RAAdditional Charge Model
    /// </summary>
    public class RaAdditionalCharge
    {
        #region Persisted Properties

        /// <summary>
        /// RaAdditionalCharge ID
        /// </summary>
        public long RaAdditionalChargeId { get; set; }

        /// <summary>
        /// RA Main Id
        /// </summary>
        public long RaMainId { get; set; }

        /// <summary>
        /// AdditionalCharge Type ID
        /// </summary>
        public short AdditionalChargeTypeId { get; set; }

        /// <summary>
        /// Additional Charge Type Code
        /// </summary>
        public string AdditionalChargeTypeCode { get; set; }

        /// <summary>
        /// Additional Charge Type Name
        /// </summary>
        public string AdditionalChargeTypeName { get; set; }

        /// <summary>
        /// Hire Group Detail ID
        /// </summary>
        public long? HireGroupDetailId { get; set; }

        /// <summary>
        /// Hire Group Code
        /// </summary>
        public string HireGroupCodeName { get; set; }

        /// <summary>
        /// Additional Charge Rate
        /// </summary>
        public double AdditionalChargeRate { get; set; }

        /// <summary>
        /// Plate Number
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public short Quantity { get; set; }

        #endregion

    }
}