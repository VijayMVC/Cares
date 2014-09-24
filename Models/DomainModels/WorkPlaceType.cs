using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Work Place Type Domain Model
    /// </summary>
    public class WorkPlaceType
    {
        #region Persisted Properties
        
        /// <summary>
        /// Work Place Type Id
        /// </summary>
        public short WorkPlaceTypeId { get; set; }
        
        /// <summary>
        /// WorkPlace Type Code
        /// </summary>
        public string WorkPlaceTypeCode { get; set; }

        /// <summary>
        /// WorkPlace Type Name
        /// </summary>
        public string WorkPlaceTypeName { get; set; }

        /// <summary>
        /// WorkPlace Type Description
        /// </summary>
        public string WorkPlaceTypeDescription { get; set; }

        /// <summary>
        /// WorkPlace Nature
        /// </summary>
        public string WorkPlaceNature { get; set; }


        /// <summary>
        /// Work Place Type Cat
        /// </summary>
        public short? WorkPlaceTypeCat { get; set; }

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
        /// WorkPlaces having this Workplace Type
        /// </summary>
        public virtual ICollection<WorkPlace> WorkPlaces { get; set; }

        #endregion

    }
}
