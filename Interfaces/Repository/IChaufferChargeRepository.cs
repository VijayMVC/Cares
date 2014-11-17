using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Chauffer Charge Repository Interface
    /// </summary>
    public interface IChaufferChargeRepository : IBaseRepository<ChaufferCharge, long>
    {
        /// <summary>
        /// Get Chauffer Charges By Chauffer Charge Main Id
        /// </summary>
        /// <param name="chaufferChargeMainId"></param>
        /// <returns></returns>
        IEnumerable<ChaufferCharge> GetChaufferChargesByChaufferChargeMainId(long chaufferChargeMainId);
        
        /// <summary>
        /// Get Chauffer Charge For Ra Billing
        /// </summary>
        IEnumerable<ChaufferCharge> GetForRaBilling(string tariffTypeCode, long desigGradeId, DateTime raRecCreatedDt);

        IEnumerable<WebApiAvailableChauffer> GetAvailableChauffeurForWebApi(string tarrifTypeCode,
            DateTime startDt,DateTime endDateTime, long userDomainKey);

    }
}
