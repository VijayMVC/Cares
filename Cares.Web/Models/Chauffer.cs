using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Chauffer Model
    /// </summary>
    public sealed class Chauffer
    {
        /// <summary>
        /// Id
        /// </summary>
        public long ChaufferId { get; set; }
        
        /// <summary>
        /// Code
        /// </summary>
        public string ChaufferCode { get; set; }

        /// <summary>
        /// Chauffer Name
        /// </summary>
        public string ChaufferName { get; set; }

        /// <summary>
        /// License Number
        /// </summary>
        public string LicenseNo { get; set; }

        /// <summary>
        /// License Expiry Date
        /// </summary>
        public DateTime? LicenseExpDt { get; set; }

        /// <summary>
        /// Desig Grade Code Name
        /// </summary>
        public string DesigGradeCodeName { get; set; }

        /// <summary>
        /// Desig Grade Id
        /// </summary>
        public long DesigGradeId { get; set; }
    }
}