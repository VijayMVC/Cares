namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Additional Charge For Nrt Domain Model
    /// </summary>
    public class AdditionalChargeForNrt
    {
        /// <summary>
        /// Additional Charge Type Id
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
        /// Additional Charge Rate
        /// </summary>
        public double? AdditionalChargeRate { get; set; }

        /// <summary>
        /// Hire Group Detail
        /// </summary>
        public string HireGroupDetail { get; set; }
    }
}
