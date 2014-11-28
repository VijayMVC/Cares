
namespace Cares.WebApi.Models
{
    /// <summary>
    /// Booking Main Request 
    /// </summary>
    public class WebApiSetBookingRequest
    {
        /// <summary>
        /// Selected Insurance Type ids indexes
        /// </summary>
        public int[] InsurancesTypeIndex { get; set; }
        /// <summary>
        /// Selected Chauffers IDs
        /// </summary>
        public int[] ChauffersIndexInts { get; set; }
        /// <summary>
        /// Additional Driver info
        /// </summary>
        public AdditionalDriverInfo AdditionalDriver { get; set; }
        /// <summary>
        /// Booking Main info 
        /// </summary>
        public WebApiBookingMainInfo BookingMainInfo { get; set; }

    }
}