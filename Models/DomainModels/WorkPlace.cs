using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Work Place Domain Model
    /// </summary>
    public class WorkPlace
    {
        #region Persisted Properties
        
        /// <summary>
        /// Work Place Id
        /// </summary>
        public long WorkPlaceId { get; set; }

        /// <summary>
        /// Work Location Id
        /// </summary>
        public long WorkLocationId { get; set; }

        /// <summary>
        /// Work Place Code
        /// </summary>
        public string WorkPlaceCode { get; set; }

        /// <summary>
        /// Work Place Name
        /// </summary>
        public string WorkPlaceName { get; set; }

        /// <summary>
        /// Work Place Description
        /// </summary>
        public string WorkPlaceDescription { get; set; }

        /// <summary>
        /// Parent Work Place Id
        /// </summary>
        public long? ParentWorkPlaceId { get; set; }

        /// <summary>
        /// Work Place Type Id
        /// </summary>
        public short WorkPlaceTypeId { get; set; }

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
        public virtual WorkPlace ParentWorkPlace { get; set; }

        /// <summary>
        /// Work Place Type
        /// </summary>
        public virtual WorkPlaceType WorkPlaceType { get; set; }

        /// <summary>
        /// Work Location
        /// </summary>
        public virtual WorkLocation WorkLocation { get; set; }

        /// <summary>
        /// Operations Workplaces that use this workspace
        /// </summary>
        public virtual ICollection<OperationsWorkPlace> OperationsWorkPlaces { get; set; }

        /// <summary>
        /// EmpJobInfos
        /// </summary>
        public virtual ICollection<EmpJobInfo> EmpJobInfos { get; set; }

        /// <summary>
        /// EmpJobProgs
        /// </summary>
        public virtual ICollection<EmpJobProg> EmpJobProgs { get; set; } 

        

        #endregion
    }
}
