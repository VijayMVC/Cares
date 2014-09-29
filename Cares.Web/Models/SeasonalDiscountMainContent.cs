using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Seasonal Discount Main Content Web Model
    /// </summary>
    public class SeasonalDiscountMainContent
    {
        /// <summary>
        /// Seasonal Discount Main ID
        /// </summary>
        public long SeasonalDiscountMainId { get; set; }

        /// <summary>
        /// Seasonal Discount Main Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Seasonal Discount Main Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Seasonal Discount Main Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Company Code Name
        /// </summary>
        public string CompanyCodeName { get; set; }

        /// <summary>
        /// Company Id
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Department Id
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// Operation Id
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// Operation Code Name
        /// </summary>
        public string OperationCodeName { get; set; }

        /// <summary>
        /// Tariff Type Id
        /// </summary>
        public long TariffTypeId { get; set; }

        /// <summary>
        /// Tariff Type Code Name
        /// </summary>
        public string TariffTypeCodeName { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDt { get; set; }
    }
}