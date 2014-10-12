using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Nrt Driver Web Model
    /// </summary>
    public class NrtDriver
    {
        /// <summary>
        /// Nrt Driver ID
        /// </summary>
        public long NrtDriverId { get; set; }

        /// <summary>
        /// Chauffer ID
        /// </summary>
        public long? ChaufferId { get; set; }

        /// <summary>
        /// Desig Grade ID
        /// </summary>
        public long? DesigGradeId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDtTime { get; set; }

        /// <summary>
        /// License Exp Date
        /// </summary>
        public DateTime? LicenseExpDt { get; set; }

        /// <summary>
        /// License No
        /// </summary>
        public string LicenseNo { get; set; }
        
        /// <summary>
        ///Code 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        
    }
}