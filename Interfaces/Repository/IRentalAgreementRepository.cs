﻿using System.Collections.Generic;
using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Rental Agreement Repository Interface
    /// </summary>
    public interface IRentalAgreementRepository : IBaseRepository<RaMain, long>
    {
        /// <summary>
        /// Load Dependencies
        /// </summary>
        void LoadDependencies(RaMain raMain);
        
        /// <summary>
        /// Get all Ra Main
        /// </summary>
        RaMainForRaQueueSearchResponse GetRaMainsForRaQueue(RaQueueSearchRequest request);

        /// <summary>
        /// Daily Action Detail Report
        /// </summary>        
        IQueryable<RaHireGroup> GetDailyActionReport();

        /// <summary>
        /// GetGrossSalesReport Data
        /// </summary>
        IEnumerable<GrossSalesReportResponse> GetGrossSalesReport();

        /// <summary>
        /// Get total number of rental agreements with domain key
        /// </summary>
        int GetCountOfRAswithDomainKey();
        // get for reports
        RaMain FindRentalAgreement(long rAMainId);
    }
}
