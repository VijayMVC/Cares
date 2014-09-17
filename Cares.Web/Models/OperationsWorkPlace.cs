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

        /// <summary>
        /// Operation Name
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// FleetPool Id
        /// </summary>
        public long? FleetPoolId { get; set; }
        /// <summary>
        /// FleetPool Name
        /// </summary>
        public string FleetPoolName { get; set; }

        /// <summary>
        /// CostCenter
        /// </summary>
        public string CostCenter { get; set; }
        
        #endregion
    }
}
