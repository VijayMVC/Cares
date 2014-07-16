namespace Models.RequestModels
{
    /// <summary>
    /// FleetPool Search Request
    /// </summary>
    public class FleetPoolSearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Fleet Pool Code
        /// </summary>
        public string FleetPoolCode { get; set; }
        /// <summary>
        /// Fleet Pool Name
        /// </summary>
        public string FleetPoolName { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Region
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Department
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// Operation
        /// </summary>
        public string Operation { get; set; }

    }
}
