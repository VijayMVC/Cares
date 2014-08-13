namespace Cares.Web.Models
{
    /// <summary>
    /// Operation Web Model
    /// </summary>
    public class OperationDropDown
    {
        #region Public Properties
        /// <summary>
        /// Operation ID
        /// </summary>
        public long OperationId { get; set; }
        /// <summary>
        /// Operation Code
        /// </summary>
        public string OperationCodeName { get; set; }

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