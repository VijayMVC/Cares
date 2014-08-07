namespace Cares.Models.RequestModels
{
    /// <summary>
    /// FleetPool Search Request
    /// </summary>
    public class FleetPoolSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// FleetPool Code
        /// </summary>
        public string FleetPoolCode { get; set; }  
        /// <summary>
        /// Region Id
        /// </summary>
        public int? RegionId { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public int? OperationId { get; set; }

    }
}
