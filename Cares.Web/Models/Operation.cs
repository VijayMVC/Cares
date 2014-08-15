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
        public long OperationId { get; set; }
        /// <summary>
        /// Operation Code
        /// </summary>
        public string OperationCode { get; set; }

        /// <summary>
        /// Operation Name
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Operation Code Name
        /// </summary>
        public string OperationCodeName
        {
            get
            {
                return string.Format("{0}-{1}", OperationCode, OperationName);
            }
        }
        #endregion
       
    }
}