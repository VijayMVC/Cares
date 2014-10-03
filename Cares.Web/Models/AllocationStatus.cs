namespace Cares.Web.Models
{
    /// <summary>
    /// Allocation Status Web Model
    /// </summary>
    public class AllocationStatus
    {
        #region Public Properties
        
        /// <summary>
        /// Allocation Status ID
        /// </summary>
        public short AllocationStatusId { get; set; }

        /// <summary>
        /// Allocation Status Code
        /// </summary>
        public string AllocationStatusCode { get; set; }

        /// <summary>
        /// Allocation Status Name
        /// </summary>
        public string AllocationStatusName { get; set; }

        /// <summary>
        /// Allocation Status Code Name
        /// </summary>
        public string AllocationStatusCodeName { get; set; }

        /// <summary>
        /// Allocation Status Key
        /// </summary>
        public short? AllocationStatusKey { get; set; }

        #endregion
    }
}