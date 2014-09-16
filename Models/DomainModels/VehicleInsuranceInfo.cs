using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Insurance Info Domain Model
    /// </summary>
    public class VehicleInsuranceInfo
    {
        #region Persisted Properties
        
        /// <summary>
        /// Vehicle Insurance Info Id
        /// </summary>
        public long VehicleInsuranceInfoId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }

        /// <summary>
        /// Insurance Agent
        /// </summary>
        [StringLength(100)]
        public string InsuranceAgent { get; set; }

        /// <summary>
        /// Coverage Limit
        /// </summary>
        public int? CoverageLimit { get; set; }

        /// <summary>
        /// Renewal Date
        /// </summary>
        public DateTime? RenewalDate { get; set; }

        /// <summary>
        /// Insurance Date
        /// </summary>
        public DateTime? InsuranceDate { get; set; }

        /// <summary>
        /// Premium
        /// </summary>
        public float? Premium { get; set; }

        /// <summary>
        /// Insured Value
        /// </summary>
        public decimal? InsuredValue { get; set; }

        /// <summary>
        /// Insured From
        /// </summary>
        [StringLength(200)]
        public string InsuredFrom { get; set; }

        /// <summary>
        /// BP Main ID
        /// </summary>
        [ForeignKey("BusinessPartner")]
        public long? BPMainId { get; set; }

        /// <summary>
        /// Insurance Type ID
        /// </summary>
        [ForeignKey("InsuranceType")]
        public short? InsuranceTypeId { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100)]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
         public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
         public long UserDomainKey { get; set; }


        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        /// <summary>
        /// Insurance Type
        /// </summary>
        public virtual InsuranceType InsuranceType { get; set; }

        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }

        #endregion
    }
}
