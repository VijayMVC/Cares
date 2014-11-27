
namespace Cares.WebApp.Models
{
    public class WebApiBookingMainRequest
    {
        public int[] InsurancesTypeIndex { get; set; }
        public int[] ChauffersIndexInts { get; set; }
        public AdditionalDriverInfo  AdditionalDriver { get; set; }
        public BookingMainInfo BookingMainInfo { get; set; }
    }
}