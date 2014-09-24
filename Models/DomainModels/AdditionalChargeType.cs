using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Additional Charge Type Model
    /// </summary>
    public class AdditionalChargeType
    {
        #region Persisted Properties
        
        /// <summary>
        /// Additional Charge Type ID
        /// </summary>
        public short AdditionalChargeTypeId { get; set; }

        /// <summary>
        /// Additional Charge Type Code
        /// </summary>
        public string AdditionalChargeTypeCode { get; set; }

        /// <summary>
        /// Additional Charge Type Name
        /// </summary>
        public string AdditionalChargeTypeName { get; set; }

        /// <summary>
        /// Additional Charge Type Description
        /// </summary>
        public string AdditionalChargeTypeDescription { get; set; }

        /// <summary>
        /// Additional Charge Key
        /// </summary>
        public short? AdditionalChargeKey { get; set; }

        /// <summary>
        /// Is Editable
        /// </summary>
        public bool IsEditable { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

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
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Additional Charges
        /// </summary>
        public virtual ICollection<AdditionalCharge> AdditionalCharges { get; set; }

        /// <summary>
        /// Hire Group Detaill
        /// </summary>
        public virtual HireGroupDetail HireGroupDetail { get; set; }

        /// <summary>
        /// Nrt Charges
        /// </summary>
        public virtual ICollection<NrtCharge> NrtCharges { get; set; }

        /// <summary>
        /// Ra Additional Charges
        /// </summary>
        public virtual ICollection<RaAdditionalCharge> RaAdditionalCharges { get; set; }

        #endregion
    }
}
