

using System.Collections.Generic;

namespace Cares.Models.ReportModels
{
   
    public class RentalAgreementDetailResponse
    {
     
        public IEnumerable<RaVehicleInfo> RaVehicleInfo { get; set; }
        public IEnumerable<RaCustomerInfo> RaCustomerInfo { get; set; }


    }
}
