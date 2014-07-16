namespace Models.RequestModels
{
    /// <summary>
    /// FleetPool Search Request
    /// </summary>
    public class FleetPoolSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Region
        /// </summary>
        public int? RegionId { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public int? OperationId { get; set; }

    }
}
