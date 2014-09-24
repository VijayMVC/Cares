using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// RaVehicle Check List Domain Model
    /// </summary>
    public class RaVehicleCheckList
    {
        #region Persisted Properties

        /// <summary>
        ///Vehicle Check List Id
        /// </summary>
        public long RaVehicleCheckListId { get; set; }
        
        /// <summary>
        /// Vehicle Check List Description
        /// </summary>
        public string RaVehicleCheckListDescription { get; set; }
        
        /// <summary>
        /// Status
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Ra Hire Group id
        /// </summary>
        public long RaHireGroupId { get; set; }

        /// <summary>
        /// Vehicle Check List Id
        /// </summary>
        public short VehicleCheckListId { get; set; }

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
        /// Vehicle Checklist
        /// </summary>
        public virtual VehicleCheckList VehicleCheckList { get; set; }

        /// <summary>
        /// Ra Hire Group
        /// </summary>
        public virtual RaHireGroup RaHireGroup { get; set; } 

        #endregion
    }
}
