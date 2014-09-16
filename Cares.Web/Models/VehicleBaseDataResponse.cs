using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Base Data Web Response
    /// </summary>
    public sealed class VehicleBaseDataResponse
    {
        /// <summary>
        /// Operations Drop Down
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }

        /// <summary>
        /// Fleet Pools Drop Down
        /// </summary>
        public IEnumerable<FleetPoolDropDown> FleetPools { get; set; }

        /// <summary>
        /// Companies Drop Down
        /// </summary>
        public IEnumerable<CompanyDropDown> Companies { get; set; }

        /// <summary>
        /// Regions Drop Down
        /// </summary>
        public IEnumerable<RegionDropDown> Regions { get; set; }

        /// <summary>
        /// Fuel Type Drop Down
        /// </summary>
        public IEnumerable<FuelTypeDropDown> FuelTypes { get; set; }

        /// <summary>
        /// Vehicle Models Drop Down
        /// </summary>
        public IEnumerable<VehicleModelDropDown> VehicleModels { get; set; }

        /// <summary>
        /// Vehicle Statuses Drop Down
        /// </summary>
        public IEnumerable<VehicleStatusDropDown> VehicleStatuses { get; set; }

        /// <summary>
        /// Departments Drop Down
        /// </summary>
        public IEnumerable<DepartmentDropDown> Departments { get; set; }

        /// <summary>
        /// Vehicle Categories Drop Down
        /// </summary>
        public IEnumerable<VehicleCategoryDropDown> VehicleCategories { get; set; }

        /// <summary>
        /// Transmission Types Drop Down
        /// </summary>
        public IEnumerable<TransmissionTypeDropDown> TransmissionTypes { get; set; }

        /// <summary>
        /// Vehicle Makes Drop Down
        /// </summary>
        public IEnumerable<VehicleMakeDropDown> VehicleMakes { get; set; }

        /// <summary>
        /// Business Partners Drop Down
        /// </summary>
        public IEnumerable<BusinessPartnerDropDown> BusinessPartners { get; set; }

        /// <summary>
        /// Insurance Types Drop Down
        /// </summary>
        public IEnumerable<InsuranceTypeDropDown> InsuranceType { get; set; }

        /// <summary>
        /// Maintenance Types Drop Down
        /// </summary>
        public IEnumerable<MaintenanceTypeDropDown> MaintenanceTypes { get; set; }

        /// <summary>
        /// Vehicle Check List Drop Down
        /// </summary>
        public IEnumerable<VehicleCheckListDropDown> VehicleCheckList { get; set; }

        /// <summary>
        /// Vehicle Check List 
        /// </summary>
        public IEnumerable<OperationsWorkPlace> Locations { get; set; }
    }
}