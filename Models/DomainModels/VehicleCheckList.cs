using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Check List Domain Model
    /// </summary>
    public class VehicleCheckList
    {
        #region Persisted Properties

        /// <summary>
        ///Vehicle Check List Id
        /// </summary>
        public short VehicleCheckListId { get; set; }

        /// <summary>
        /// Vehicle Check List Code
        /// </summary>
        public string VehicleCheckListCode { get; set; }

        /// <summary>
        /// Vehicle Check List Name
        /// </summary>
        public string VehicleCheckListName { get; set; }

        /// <summary>
        /// Vehicle Check List Description
        /// </summary>
        public string VehicleCheckListDescription { get; set; }

        /// <summary>
        /// Is Interior
        /// </summary>
        public bool IsInterior { get; set; }

        /// <summary>
        /// Vehicle Check List Key
        /// </summary>
        public short? VehicleCheckListKey { get; set; }

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
        /// Vehicle Checklist Items
        /// </summary>
        public virtual ICollection<VehicleCheckListItem> VehicleCheckListItems { get; set; }

        /// <summary>
        /// RaVehicle Checklists
        /// </summary>
        public virtual ICollection<RaVehicleCheckList> RaVehicleCheckLists { get; set; } 

        #endregion
    }
}
