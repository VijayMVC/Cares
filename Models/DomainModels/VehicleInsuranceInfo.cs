using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Insurance Info Domain Model
    /// </summary>
    public class VehicleInsuranceInfo
    {
        #region Persisted Properties
        
        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Insurance Agent
        /// </summary>
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
        public double? Premium { get; set; }

        /// <summary>
        /// Insured Value
        /// </summary>
        public decimal? InsuredValue { get; set; }

        /// <summary>
        /// Insured From
        /// </summary>
        public string InsuredFrom { get; set; }

        /// <summary>
        /// BP Main ID
        /// </summary>
        public long? BPMainId { get; set; }

        /// <summary>
        /// Insurance Type ID
        /// </summary>
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
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
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
