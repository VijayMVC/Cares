using Cares.Models.ReportModels;
using System.Collections.Generic;

namespace Cares.Interfaces.IReportServices
{
    public interface IMissingHireGroupService
    {
        IList<MissingHireGroupResponse> LoadMissingHireGroups();
    }
}
