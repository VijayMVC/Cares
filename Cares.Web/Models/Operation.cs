namespace Cares.Web.Models
{
    /// <summary>
    /// Operation Web Model
    /// </summary>
    public class Operation
    {
        #region Public Properties
        /// <summary>
        /// Operation ID
        /// </summary>
        public int OperationId { get; set; }
        /// <summary>
        /// Operation Code
        /// </summary>
        public string OperationCode { get; set; }
        /// <summary>
        /// Operation Name
        /// </summary>        
        public string OperationName { get; set; }
        #endregion
    }
}