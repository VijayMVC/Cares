namespace Cares.Web.Models
{
    /// <summary>
    /// FleetPool Model
    /// </summary>
    public class FleetPool
    {
        #region FleetPool Persisted Properties
            /// <summary>
            /// FleetPool ID
            /// </summary>
            public long FleetPoolId { get; set; }
            /// <summary>
            /// FleetPool Code
            /// </summary>
            public string FleetPoolCode { get; set; }
            /// <summary>
            /// FleetPool Name
            /// </summary>
            public string FleetPoolName { get; set; }
            /// <summary>
            /// Operation
            /// </summary>
            public Operation Operation { get; set; }
            /// <summary>
            /// Region
            /// </summary>
            public Region Region { get; set; }
        #endregion
    }
}