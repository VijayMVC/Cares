using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Image Hire Group Detail Domain Model
    /// </summary>
    public class VehicleImageHireGroupDetail
    {
        #region Persisted Properties
        
        /// <summary>
        /// VehicleImage HireGroupDetail Id
        /// </summary>
        public long VehicleImageHireGroupDetailId { get; set; }
        
        /// <summary>
        /// Vehicle Image Id
        /// </summary>
        public long VehicleImageId { get; set; }

        /// <summary>
        /// HireGroup Detail Id
        /// </summary>
        public long HireGroupDetailId { get; set; }
        
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
        /// Vehicle Image
        /// </summary>
        public virtual VehicleImage VehicleImage { get; set; }

        /// <summary>
        /// Hire Group Detail
        /// </summary>
        public virtual HireGroupDetail HireGroupDetail { get; set; }

        #endregion
    }
}
