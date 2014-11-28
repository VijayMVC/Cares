
namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Available chauufers 
    /// </summary>
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
        
        /// <summary>
        /// Chauffer designation grade
        /// </summary>
        public string  DesignationGrade { get; set; }
    }
}
