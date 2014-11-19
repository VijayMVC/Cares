namespace Cares.WebApp.Models
{
    /// <summary>
    /// Web Api Service Rate
    /// </summary>
    public class WebApiServiceRate
    {
        /// <summary>
        /// Service Rate ID
        /// </summary>
        public long ServiceRateId { get; set; }

        /// <summary>
        /// Item Name
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Tariff Type
        /// </summary>
        public string TariffType { get; set; }

        /// <summary>
        /// Item Rate
        /// </summary>
        public float ItemRate { get; set; }

        /// <summary>
        /// Item Charge
        /// </summary>
        public float ItemCharge { get; set; }
    }
}