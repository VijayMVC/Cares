

using System.Collections.Generic;

namespace Cares.Models.ReportModels
{
   
    public class RentalAgreementDetailResponse
    {
     
        public IEnumerable<RentalAgreementInfo> RentalAgreementInfos { get; set; }
        public IEnumerable<RaCustomerInfo> RaCustomerInfo { get; set; }


    }
}
