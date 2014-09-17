using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Phone Domain Model
    /// </summary>
    public class Phone
    {
        #region Persisted Properties
        /// <summary>
        /// Phone Id
        /// </summary>
        public long PhoneId { get; set; }
        /// <summary>
        /// Is Default
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }
        /// <summary>
        /// Phone Type ID
        /// </summary>
        public short PhoneTypeId { get; set; }
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

        /// <summary>
        /// Employee
        /// </summary>
        public long? EmployeeId { get; set; }

        /// <summary>
        /// work Location Id
        /// </summary>
        public long? WorkLocationId { get; set; }


        #endregion

        #region Reference properties
        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }
        /// <summary>
        /// Phone Type
        /// </summary>
        public virtual PhoneType PhoneType { get; set; }

        /// <summary>
        /// Work Location
        /// </summary>
        public virtual WorkLocation WorkLocation { get; set; }

        /// <summary>
        /// Employee
        /// </summary>
        public virtual Employee Employee { get; set; }

        #endregion
    }
}
