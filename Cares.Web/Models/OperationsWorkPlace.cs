namespace Cares.Web.Models
{
    /// <summary>
    /// Operations Work Place Web Model
    /// </summary>
    public class OperationsWorkPlace
    {

        #region Public Properties
        
        /// <summary>
        /// Operations Work Place Id
        /// </summary>
        public long OperationsWorkPlaceId { get; set; }

        /// <summary>
        /// Location Code
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// Work Place Id
        /// </summary>
        public long WorkPlaceId { get; set; }

        /// <summary>
        /// Operation Id
        /// </summary>
        public long OperationId { get; set; }
        
        #endregion
    }
}
