using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Operations Work Place Domain Model
    /// </summary>
    public class OperationsWorkPlace
    {
        #region Persisted Properties
        
        /// <summary>
        /// Operations Work Place Id
        /// </summary>
        public long OperationsWorkPlaceId { get; set; }

        /// <summary>
        /// Location Code
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// Work Place Id
        /// </summary>
        public long WorkPlaceId { get; set; }

        /// <summary>
        /// Operation Id
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// Fleet Pool Id
        /// </summary>
        public long? FleetPoolId { get; set; }
        
        /// <summary>
        /// CostCenter
        /// </summary>
        public string CostCenter { get; set; }

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
        /// Work Place
        /// </summary>
        public virtual WorkPlace WorkPlace { get; set; }

        /// <summary>
        /// Fleet Pool
        /// </summary>
        public virtual FleetPool FleetPool { get; set; }

        /// <summary>
        /// Operation
        /// </summary>
        public virtual Operation Operation { get; set; }

        /// <summary>
        /// Vehicles Associated with this OperationsWorkPlace
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// EmpAutOperationsWorkplaces
        /// </summary>
        public virtual ICollection<EmpAuthOperationsWorkplace> EmpAuthOperationsWorkplaces { get; set; } 

        #endregion
    }
}
