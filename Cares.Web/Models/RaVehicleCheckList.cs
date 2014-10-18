namespace Cares.Web.Models
{
    /// <summary>
    /// RaVehicle Check List Model
    /// </summary>
    public class RaVehicleCheckList
    {
        #region Persisted Properties

        /// <summary>
        ///Vehicle Check List Id
        /// </summary>
        public long RaVehicleCheckListId { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Ra Hire Group id
        /// </summary>
        public long RaHireGroupId { get; set; }

        /// <summary>
        /// Vehicle Check List Id
        /// </summary>
        public short VehicleCheckListId { get; set; }

        /// <summary>
        /// Is Interior
        /// </summary>
        public bool IsInterior { get; set; }

        /// <summary>
        /// Vehicle Check List Key
        /// </summary>
        public short? VehicleCheckListKey { get; set; }

        /// <summary>
        /// Vehicle Check List Code Name
        /// </summary>
        public string VehicleCheckListCodeName { get; set; }
        
        #endregion

    }
}