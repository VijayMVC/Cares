using System;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Additional Driver Charge Search Content Domain Content
    /// </summary>
    public sealed class AdditionalDriverChargeSearchContent
    {
        /// <summary>
        /// Additional Driver Charge Id
        /// </summary>
        public long AdditionalDriverChargeId { get; set; }

        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCodeName { get; set; }

        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCode { get; set; }

        /// <summary>
        /// Additional Driver Charge Rate
        /// </summary>
        public float AdditionalDriverChargeRate { get; set; }

        /// <summary>
        /// Company Code Name
        /// </summary>
        public string CompanyCodeName { get; set; }

        /// <summary>
        ///  Operation Code Name
        /// </summary>
        public string OperationCodeName { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }

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
        /// Tariff Type Id
        /// </summary>
        public long TariffTypeId { get; set; }
    }
}
