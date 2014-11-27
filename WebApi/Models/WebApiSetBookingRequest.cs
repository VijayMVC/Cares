
namespace Cares.WebApi.Models
{
    public class WebApiSetBookingRequest
    {
        public int[] InsurancesTypeIndex { get; set; }
        public int[] ChauffersIndexInts { get; set; }
        public AdditionalDriverInfo AdditionalDriver { get; set; }
        public BookingMainInfo BookingMainInfo { get; set; }

    }
}