using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Address Type Domain Model
    /// </summary>
    public class AddressType
    {
        #region Persisted Properties
        /// <summary>
        /// Address Type Key
        /// </summary>
        public short AddressTypeKey
        { get; set; }

        /// <summary>
        /// Address Type ID
        /// </summary>
        public short AddressTypeId { get; set; }
        /// <summary>
        /// Address Type Code
        /// </summary>
        public string AddressTypeCode { get; set; }
        /// <summary>
        /// Address Type Name
        /// </summary>
        public string AddressTypeName { get; set; }
        /// <summary>
        /// Address Type Description
        /// </summary>
        public string AddressTypeDescription { get; set; }
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
        /// Addresses
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        #endregion
    }
}
