﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Standard Rate Domain Model
    /// </summary>
    public class StandardRate
    {
        #region Perssisted Properties
        
        /// <summary>
        /// Standard Rate ID
        /// </summary>
        [Key]
        public long StandardRtId { get; set; }
        
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        
        /// <summary>
        /// Standard Rate Main ID
        /// </summary>
        [ForeignKey("StandardRateMain")]
        public long StandardRtMainId { get; set; }
        /// <summary>
        /// Allowed Mileage
        /// </summary>
        public int AllowedMileage { get; set; }
        /// <summary>
        /// Excess Mileage Charge
        /// </summary>
        public float ExcessMileageChrg { get; set; }
        /// <summary>
        /// Standard Rate
        /// </summary>
        public float StandardRt { get; set; }
        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }
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
        /// Is ReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Hire Group Detail ID
        /// </summary>
        [ForeignKey("HireGroupDetail")]
        public long HireGroupDetailId { get; set; }
        /// <summary>
        /// Standard Rate End Date
        /// </summary>
        public DateTime StandardRtEndDt { get; set; }
        /// <summary>
        /// Standard Rate Start Date
        /// </summary>
        public DateTime StandardRtStartDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Child Standard Rate ID
        /// </summary>
        [ForeignKey("ChildStandardRate")]
        public long? ChildStandardRtId { get; set; }

        #endregion
        
        #region Reference Properties
        
        /// <summary>
        /// Hire Group Detail
        /// </summary>
        public virtual HireGroupDetail HireGroupDetail { get; set; }

        /// <summary>
        /// Standard Rate Main
        /// </summary>
        public virtual StandardRateMain StandardRateMain { get; set; }

        /// <summary>
        /// Child Standard Rate
        /// </summary>
        public virtual StandardRate ChildStandardRate { get; set; }

        #endregion
    }
}
