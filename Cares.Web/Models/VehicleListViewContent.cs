namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle List View content
    /// </summary>
    public sealed class VehicleListViewContent
    {

        /// <summary>
        /// Vehicle Id
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Plate Number
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// Vehicle Name
        /// </summary>
        public string VehicleName { get; set; }

        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }

        /// <summary>
        /// Fuel Level
        /// </summary>
        public short? FuelLevel { get; set; }

        /// <summary>
        /// Current Odometer
        /// </summary>
        public int CurrentOdometer { get; set; }

        /// <summary>
        /// Vehicle Make Code Name
        /// </summary>
        public string VehicleMakeCodeName { get; set; }

        /// <summary>
        /// Vehicle Statud Code Name
        /// </summary>
        public string VehicleStatusCodeName { get; set; }

        /// <summary>
        /// Fleet Pool Code Name
        /// </summary>
        public string FleetPoolCodeName { get; set; }

        /// <summary>
        /// Operation Code Name
        /// </summary>
        public string OperationCodeName { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public string Location { get; set; }
    }
}