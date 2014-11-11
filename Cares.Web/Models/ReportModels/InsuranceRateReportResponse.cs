
namespace Cares.Web.Models.ReportModels
{
    /// <summary>
    /// Insurance Rate Report Response web Model
    /// </summary>
    public class InsuranceRateReportResponse
    {
        public string InsuranceTypeCode { get; set; }
        public string OperationCode { get; set; }
        public string TarrifTypeCode { get; set; }
        public string HireGroupCode { get; set; }
        public string VehicleMakeCode { get; set; }
        public string VehicleModelCode { get; set; }
        public string VehicelCategoryCode { get; set; }
        public short ModelYear { get; set; }
        public double RevisionNumber { get; set; }
        public double InsuranceRate { get; set; }
        public string StartDate { get; set; }

    }
}
