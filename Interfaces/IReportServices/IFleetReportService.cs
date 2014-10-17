using System.Collections.Generic;
using Cares.Models.ReportModels;

namespace Cares.Interfaces.IReportServices
{
    /// <summary>
    /// Vehicle Report Service Interface
    /// </summary>
    public interface IFleetReportService
    {

        IList<RptFleetHireGroupDetail> LoadFleetHireGroupDetail();
    }
}
