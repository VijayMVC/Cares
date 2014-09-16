using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Vehicle Base Data Domain Response
    /// </summary>
    public sealed class VehicleBaseDataResponse
    {
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// Fleet Pools 
        /// </summary>
        public IEnumerable<FleetPool> FleetPools { get; set; }

        /// <summary>
        /// Companies 
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }

        /// <summary>
        /// Regions 
        /// </summary>
        public IEnumerable<Region> Regions { get; set; }

        /// <summary>
        /// FuelTypes 
        /// </summary>
        public IEnumerable<FuelType> FuelTypes { get; set; }

        /// <summary>
        /// Vehicle Models 
        /// </summary>
        public IEnumerable<VehicleModel> VehicleModels { get; set; }

        /// <summary>
        /// Vehicle Statuses 
        /// </summary>
        public IEnumerable<VehicleStatus> VehicleStatuses { get; set; }

        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<Department> Departments { get; set; }

        /// <summary>
        /// Vehicle Categories 
        /// </summary>
        public IEnumerable<VehicleCategory> VehicleCategories { get; set; }

        /// <summary>
        /// Transmission Types 
        /// </summary>
        public IEnumerable<TransmissionType> TransmissionTypes { get; set; }

        /// <summary>
        /// Vehicle Makes 
        /// </summary>
        public IEnumerable<VehicleMake> VehicleMakes { get; set; }

        /// <summary>
        /// Business Partners 
        /// </summary>
        public IEnumerable<BusinessPartner> BusinessPartners { get; set; }

        /// <summary>
        /// Insurance Types 
        /// </summary>
        public IEnumerable<InsuranceType> InsuranceType { get; set; }

        /// <summary>
        /// Maintenance Types 
        /// </summary>
        public IEnumerable<MaintenanceType> MaintenanceTypes { get; set; }

        /// <summary>
        /// Vehicle Check List 
        /// </summary>
        public IEnumerable<VehicleCheckList> VehicleCheckList { get; set; }

        /// <summary>
        /// Vehicle Check List 
        /// </summary>
        public IEnumerable<OperationsWorkPlace> Locations { get; set; }
    }
}
