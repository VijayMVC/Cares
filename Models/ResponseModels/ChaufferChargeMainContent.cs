using System;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Chauffer Charge Main Content
    /// </summary>
    public class ChaufferChargeMainContent
    {
        /// <summary>
        /// Chauffer Charge Main ID
        /// </summary>
        public long ChaufferChargeMainId { get; set; }

        /// <summary>
        /// Chauffer Charge Main Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Chauffer Charge Main Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Chauffer Charge Main Description
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
        public DateTime StartDate { get; set; }
    }
}
