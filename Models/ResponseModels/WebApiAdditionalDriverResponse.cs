
namespace Cares.Models.ResponseModels
{

    /// <summary>
    /// Additional Driver 
    /// </summary>
    public class WebApiAdditionalDriverResponse
    {
        /// <summary>
        /// Tariff type code
        /// </summary>
        public string TariffTypeCode { get; set; }

        /// <summary>
        /// Additional driver rate
        /// </summary>
        public double Rate { get; set; }
    }
}
