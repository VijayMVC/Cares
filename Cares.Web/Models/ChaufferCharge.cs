using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Chauffer Charge Web Model
    /// </summary>
    public class ChaufferCharge
    {
        /// <summary>
        /// Chauffer Charge ID
        /// </summary>
        public long ChaufferChargeId { get; set; }

        /// <summary>
        /// Desig Grade ID
        /// </summary>
        public long DesigGradeId { get; set; }

        /// <summary>
        /// Desig Grade Code Name
        /// </summary>
        public string DesigGradeCodeName { get; set; }

        /// <summary>
        /// Chauffer Charge Rate
        /// </summary>
        public double ChaufferChargeRate { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }

    }
}