
namespace Cares.Web.Models.ReportModels
{
    /// <summary>
    /// Gross Sales Report Response Web model
    /// </summary>
    public class GrossSalesReportResponse
    {
        public string CompanyCode { get; set; }
        public string DepartmentCode { get; set; }
        public string OperationCode { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public double TotalSales { get; set; }
        public double CollectedAmount { get; set; }
        public double UnCollectedAmount { get; set; }
    }
}