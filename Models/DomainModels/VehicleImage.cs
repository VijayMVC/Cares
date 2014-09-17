using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Image Domain Model
    /// </summary>
    public class VehicleImage
    {
        #region Persisted Properties
        
        /// <summary>
        /// Vehicle Image ID
        /// </summary>
        public long VehicleImageId { get; set; }
        
        /// <summary>
        /// Vehicle Image Code
        /// </summary>
        public string VehicleImageCode { get; set; }

        /// <summary>
        /// Vehicle Image Name
        /// </summary>
        public string VehicleImageName { get; set; }

        /// <summary>
        /// Vehicle Image Description
        /// </summary>
        public string VehicleImageDescription { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        public byte[] Image { get; set; }
        
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
        /// Vehicle Image Hire Group Details Associated to this Vehicle Image
        /// </summary>
        public virtual ICollection<VehicleImageHireGroupDetail> VehicleImageHireGroupDetails { get; set; } 

        #endregion
    }
}
