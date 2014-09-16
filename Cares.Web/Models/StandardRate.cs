using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Standard Rate Web Models
    /// </summary>
    public class StandardRate
    {
        /// <summary>
        /// Standard Rate Id
        /// </summary>
        public long StandardRtId { get; set; }
        /// <summary>
        /// Hire Group Detail Id
        /// </summary>
        public long HireGroupDetailId { get; set; }
       
        /// <summary>
        /// Child Standard Rate ID
        /// </summary>
        public long? ChildStandardRtId { get; set; }
        /// <summary>
        /// Hire Group
        /// </summary>
        public string HireGroup { get; set; }
        /// <summary>
        /// Vehicle Make
        /// </summary>
        public string VehicleMake { get; set; }
        /// <summary>
        /// Vehicle Make
        /// </summary>
        public string VehicleModel { get; set; }
        /// <summary>
        /// Vehicle Category
        /// </summary>
        public string VehicleCategory { get; set; }
        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }
        /// <summary>
        /// Allow Mileage
        /// </summary>
        public int AllowMileage { get; set; }
        /// <summary>
        /// Excess Mileage Charge
        /// </summary>
        public float ExcessMileageCharge { get; set; }
        /// <summary>
        /// Standard Rate
        /// </summary>
        public float StandardRt { get; set; }
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDt { get; set; }
        /// <summary>
        /// Standard rate main id
        /// </summary>
        public long StandardRtMainId { get; set; }
        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }
     
    }
}