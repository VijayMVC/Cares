using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Tariff Type Detail Web Model
    /// </summary>
    public class TariffTypeDetail
    {
        #region Public Properties
        /// <summary>
        /// Tariff Type Id
        /// </summary>
        public long TariffTypeId { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public int OperationId { get; set; }
        /// <summary>
        /// Measurement Unit Id
        /// </summary>
        public int MeasurementUnitId { get; set; }
        /// <summary>
        /// Company Id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Department ID
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCode { get; set; }
        /// <summary>
        /// Tariff Type Name
        /// </summary>
        public string TariffTypeName { get; set; }
        /// <summary>
        /// Tariff Type Description
        /// </summary>
        public string TariffTypeDescription { get; set; }
        /// <summary>
        /// Pricing Strategy Id
        /// </summary>
        public int PricingStrategyId { get; set; }
        /// <summary>
        /// Duration From
        /// </summary>
        public short DurationFrom { get; set; }
        /// <summary>
        /// Duration To
        /// </summary>
        public short DurationTo { get; set; }
        /// <summary>
        /// Grace Period
        /// </summary>
        public float GracePeriod { get; set; }
        /// <summary>
        /// Effective Date
        /// </summary>
        public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }
        /// <summary>
        /// Created By
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Modified By
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Modified Date
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        #endregion
    }
}