using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Operation Domain Model
    /// </summary>
    public class Operation
    {
        #region Persisted Properties

        /// <summary>
        /// Operation ID
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// Operation Code
        /// </summary>
        public string OperationCode { get; set; }

        /// <summary>
        /// Operation Name
        /// </summary>
        public string OperationName { get; set; }
        /// <summary>
        /// Operation Description
        /// </summary>
        public string OperationDescription { get; set; }
        
        /// <summary>
        /// Department ID
        /// </summary>
        public long DepartmentId { get; set; }
        
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
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion
        #region Reference Properties
        
        /// <summary>
        /// Department Reference
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// FleetPools performing this operation
        /// </summary>
        public virtual ICollection<FleetPool> FleetPools { get; set; }

        /// <summary>
        /// Operations Workplaces that use this workspace
        /// </summary>
        public virtual ICollection<OperationsWorkPlace> OperationsWorkplaces { get; set; }

        /// <summary>
        /// Tarrif Types
        /// </summary>
        public virtual ICollection<TariffType> TariffTypes { get; set; }

        /// <summary>
        /// Ra Mains
        /// </summary>
        public virtual ICollection<RaMain> RaMains { get; set; }

        /// <summary>
        /// Booking Mains
        /// </summary>
        public virtual ICollection<BookingMain> BookingMains { get; set; }

        #endregion
    }
}
