namespace Cares.Web.Models
{
    /// <summary>
    /// FleetPool Model
    /// </summary>
    public class FleetPool
    {
        /// <summary>
        /// Approximate Vehicles for a fleetpool
        /// </summary>
        public int ApproximateVehiclesAsgnd { get; set; }

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
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Operation id
        /// </summary>
        public int OperationId { get; set; }
        /// <summary>
        /// Operation Name
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Region id
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// Region Name
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// country id
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// country name
        /// </summary>
        public string CountryName { get; set; }
    }
}