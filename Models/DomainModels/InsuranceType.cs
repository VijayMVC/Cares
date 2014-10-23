
using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Insurance Type Domain Model
    /// </summary>
    public class InsuranceType
    {
        #region Persisted Properties

        /// <summary>
        ///Insurance Type Id
        /// </summary>
        public short InsuranceTypeId { get; set; }

        /// <summary>
        /// Insurance Type Code
        /// </summary>
        public string InsuranceTypeCode { get; set; }

        /// <summary>
        /// Insurance Type Name
        /// </summary>
        public string InsuranceTypeName { get; set; }

        /// <summary>
        /// Insurance Type Description
        /// </summary>
        public string InsuranceTypeDescription { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Row Vesion
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Insurance Rates
        /// </summary>
        public virtual ICollection<InsuranceRt> InsuranceRates { get; set; }

        /// <summary>
        /// Vehicle Insurance Infos
        /// </summary>
        public virtual ICollection<VehicleInsuranceInfo> VehicleInsuranceInfos { get; set; }

        /// <summary>
        /// Ra Hire Group Insurances
        /// </summary>
        public virtual ICollection<RaHireGroupInsurance> RaHireGroupInsurances { get; set; }

        /// <summary>
        /// Booking Insurances
        /// </summary>
        public virtual ICollection<BookingIsurance> BookingIsurances { get; set; }

        #endregion
    }
}
