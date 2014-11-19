using System;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Web Api Available Insurance
    /// </summary>
    public class WebApiAvailableInsurance
    {
        
        /// <summary>
        ///Tariff Type Name
        /// </summary>
        public string TariffTypeName { get; set; }

        /// <summary>
        /// Insurance Type ID
        /// </summary>
        public short InsuranceTypeId { get; set; }

        /// <summary>
        /// Insurance Type Name
        /// </summary>
        public string InsuranceTypeName { get; set; }
        /// <summary>
        /// Insurance Rate
        /// </summary>
        public double InsuranceRate { get; set; }

    }
}
