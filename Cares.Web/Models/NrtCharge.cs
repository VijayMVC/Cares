namespace Cares.Web.Models
{
    /// <summary>
    /// Nrt Charge Web Model
    /// </summary>
    public sealed class NrtCharge
    {
        /// <summary>
        /// NrtCharge ID
        /// </summary>
        public long NrtChargeId { get; set; }

        /// <summary>
        /// Total NRT Charge Rate
        /// </summary>
        public double TotalNrtChargeRate { get; set; }

        /// <summary>
        /// AdditionalCharge Type ID
        /// </summary>
        public short AdditionalChargeTypeId { get; set; }

        /// <summary>
        /// Contact Person
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// NRT Charge Rate
        /// </summary>
        public double NrtChargeRate { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public short Quantity { get; set; }
        
    }
}