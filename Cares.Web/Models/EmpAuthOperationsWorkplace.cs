namespace Cares.Web.Models
{
    /// <summary>
    /// Employee Authorized Operations Workplace Web Model
    /// </summary>
    public sealed class EmpAuthOperationsWorkplace
    {
        /// <summary>
        /// Employee Authorized Operations Workplace ID
        /// </summary>
        public long EmpAuthLocationId { get; set; }

        /// <summary>
        /// Employee ID 
        /// </summary>
         public long EmployeeId { get; set; }

        /// <summary>
        /// Designation Id
        /// </summary>
        public long OperationsWorkplaceId { get; set; }

        /// <summary>
        ///Is Default
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Is Operation Default
        /// </summary>
        public bool IsOperationDefault { get; set; }

        /// <summary>
        /// Operation Code Name
        /// </summary>
        public string OperationCodeName { get; set; }

        /// <summary>
        /// Operation workPalce Name
        /// </summary>
        public string OperationworkPalceCode { get; set; }


    }
}