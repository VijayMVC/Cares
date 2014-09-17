using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Work Location Domain Model
    /// </summary>
    public class WorkLocation
    {
        #region Persisted Properties
        
        /// <summary>
        /// Work Location Id
        /// </summary>
        public long WorkLocationId { get; set; }

        /// <summary>
        /// Company Id
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Work Location Code
        /// </summary>
        public string WorkLocationCode { get; set; }

        /// <summary>
        /// Work Location Name
        /// </summary>
        public string WorkLocationName { get; set; }

        /// <summary>
        /// Work Location Description
        /// </summary>
        public string WorkLocationDescription { get; set; }

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
        /// AddressId
        /// </summary>
        public long? AddressId { get; set; }

        #endregion

        #region Reference Properties


        /// <summary>
        /// Address
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Company
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// Phones this Work Location Has
        /// </summary>
        public virtual ICollection<Phone> Phones { get; set; }

        /// <summary>
        /// Work Places this Work Location Has
        /// </summary>
        public virtual ICollection<WorkPlace> Workplaces { get; set; }

        #endregion
    }
}
