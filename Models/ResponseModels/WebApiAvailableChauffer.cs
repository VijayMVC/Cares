
namespace Cares.Models.ResponseModels
{
    public class WebApiAvailableChauffer
    {
        /// <summary>
        /// Employee ID 
        /// </summary>
        public long ChaufferId { get; set; }

        /// <summary>
        ///Tariff Type Name
        /// </summary>
        public string TariffTypeCode { get; set; }

        /// <summary>
        /// Insurance Type ID
        /// </summary>
        public long RevisionNumber { get; set; }

        /// <summary>
        /// Insurance Rate
        /// </summary>
        public double ChaufferChargeRate { get; set; }
        
        public string  DesignationGrade { get; set; }
    }
}
