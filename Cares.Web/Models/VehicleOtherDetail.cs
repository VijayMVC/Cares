namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Other Detail Web Model
    /// </summary>
    public sealed class VehicleOtherDetail
    {
        /// <summary>
        /// Vehicle Other Detail
        /// </summary>
        public long VehicleOtherDetailId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Number Of Doors
        /// </summary>
        public short? NumberOfDoors { get; set; }

        /// <summary>
        /// Horse Power_CC
        /// </summary>
        public short HorsePower_CC { get; set; }

        /// <summary>
        /// Number Of Cylinders
        /// </summary>
        public short? NumberOfCylinders { get; set; }

        /// <summary>
        /// is Alloy Rim
        /// </summary>
        public bool? IsAlloyRim { get; set; }

        /// <summary>
        /// Chasis Number
        /// </summary>
        public string ChasisNumber { get; set; }

        /// <summary>
        /// Engine Number
        /// </summary>
        public string EngineNumber { get; set; }

        /// <summary>
        /// Key Code
        /// </summary>
        public string KeyCode { get; set; }

        /// <summary>
        /// Radio Code
        /// </summary>

        public string RadioCode { get; set; }

        /// <summary>
        /// Accessories
        /// </summary>

        public string Accessories { get; set; }

        /// <summary>
        /// Top Speed
        /// </summary>
        public short? TopSpeed { get; set; }

        /// <summary>
        /// Interior Description
        /// </summary>
        public string InteriorDescription { get; set; }

        /// <summary>
        /// Front Wheel Size
        /// </summary>
        public double? FrontWheelSize { get; set; }

        /// <summary>
        /// Back Wheel Size
        /// </summary>
        public double? BackWheelSize { get; set; }
    }
}