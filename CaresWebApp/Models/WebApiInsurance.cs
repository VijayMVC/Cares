namespace Cares.WebApp.Models
{
    /// <summary>
    /// Web Api Insurance 
    /// </summary>
    public class WebApiInsurance
    {
        /// <summary>
        /// Insurance Id
        /// </summary>
        public long InsuranceId { get; set; }

        /// <summary>
        /// Insurance Type
        /// </summary>
        public string InsuranceType { get; set; }

        /// <summary>
        /// Tariff Type
        /// </summary>
        public string TariffTypeType { get; set; }

        /// <summary>
        /// Insurance Rate
        /// </summary>
        public float InsuranceRate { get; set; }

        /// <summary>
        /// Insurance Charge
        /// </summary>
        public float InsuranceCharge { get; set; }
    }
}