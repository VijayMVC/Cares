using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Ocupation Type Domain Model
    /// </summary>
    public class OccupationType
    {
        #region Persisted Properties
        /// <summary>
        /// Occupation Type Id
        /// </summary>
        public short OccupationTypeId { get; set; }
        /// <summary>
        /// Occupation Type Code
        /// </summary>
        public string OccupationTypeCode { get; set; }
        /// <summary>
        /// Occupation Type Name
        /// </summary>
        public string OccupationTypeName { get; set; }
        /// <summary>
        /// Occupation Type Description
        /// </summary>
        public string OccupationTypeDescription { get; set; }
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
        /// BpIndividuals that has this Occupation Type
        /// </summary>
        public virtual ICollection<BusinessPartnerIndividual> BusinessPartnerIndividuals { get; set; }
        
        #endregion
    }
}
