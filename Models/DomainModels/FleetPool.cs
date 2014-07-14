using System;

namespace Models.DomainModels
{
    /// <summary>
    /// FleetPool Domail Model
    /// </summary>
    public class FleetPool
    {
        public long FleetPoolId { get; set; }
        public int ApproximateVehiclesAsgnd { get; set; }
        public string FleetPoolCode { get; set; }
        public string FleetPoolName { get; set; }
        public string FleetPoolDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsDeleted { get; set; }
        public long OperationId { get; set; }
        public short RegionId { get; set; }
        public DateTime RecCreatedDt { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecLastUpdatedDt { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public long RowVersion { get; set; }
        public long UserDomainKey { get; set; }
    }
}
