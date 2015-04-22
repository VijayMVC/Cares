using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Rental Agreement Repository
    /// </summary>
    public sealed class RentalAgreementRepository : BaseRepository<RaMain>, IRentalAgreementRepository
    {
        #region Private
        private readonly Dictionary<RaQueueByColumn, Func<RaMain, object>> raMainClause =
             new Dictionary<RaQueueByColumn, Func<RaMain, object>>
                    {
                        { RaQueueByColumn.RaMainId, c => c.RaMainId },
                        { RaQueueByColumn.StartDate, c => c.StartDtTime },
                        { RaQueueByColumn.EndDate, c => c.EndDtTime },
                        { RaQueueByColumn.OpenLocation, c => c.OpenLocation },
                        { RaQueueByColumn.CloseLocation, c => c.CloseLocation },
                        { RaQueueByColumn.Status, c => c.RaStatusId },
                        { RaQueueByColumn.Operation, c => c.Operation.OperationId },
                    };
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<RaMain> DbSet
        {
            get
            {
                return db.RaMains;
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Load Dependencies
        /// </summary>
        public void LoadDependencies(RaMain raMain)
        {
            LoadProperty(raMain, () => raMain.RaHireGroups, true);
            LoadProperty(raMain, () => raMain.RaServiceItems, true);
            LoadProperty(raMain, () => raMain.RaAdditionalCharges, true);
            LoadProperty(raMain, () => raMain.RaDrivers, true);
            LoadProperty(raMain, () => raMain.RaPayments, true);
            LoadProperty(raMain, () => raMain.RaCustomerDocuments, true);
            LoadProperty(raMain, () => raMain.BusinessPartner);
        }
        
        /// <summary>
        /// Get all Ra Main
        /// </summary>
        public RaMainForRaQueueSearchResponse GetRaMainsForRaQueue(RaQueueSearchRequest request)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<RaMain, bool>> query =
                s => (!request.RaNumber.HasValue || s.RaMainId == request.RaNumber) && (!request.CloseLocationId.HasValue || s.CloseLocation == request.CloseLocationId)
                     && (!request.OpenLocationId.HasValue || s.OpenLocation == request.OpenLocationId) && (!request.StartDate.HasValue || s.StartDtTime == request.StartDate)
                     && (!request.EndDate.HasValue || s.EndDtTime == request.EndDate) && (!request.RaStatusId.HasValue || s.RaStatusId == request.RaStatusId)
                     && (!request.PaymentTermId.HasValue || s.PaymentTermId == request.PaymentTermId) && s.UserDomainKey == UserDomainKey;

            IEnumerable<RaMain> raMains = request.IsAsc ? DbSet.Where(query)
                                            .OrderBy(raMainClause[request.RaQueueOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(raMainClause[request.RaQueueOrderBy]).Skip(fromRow).Take(toRow).ToList();


            return new RaMainForRaQueueSearchResponse { RaMains = raMains, TotalCount = DbSet.Count(query) };
        }


        /// <summary>
        /// Daily Action Detail Report
        /// </summary>        
        public IQueryable<RaHireGroup> GetDailyActionReport()
        {
            return db.RaHireGroups.Select(raHireGroup => raHireGroup).Where(rahiregroup => rahiregroup.UserDomainKey == UserDomainKey);
        }

        /// <summary>
        /// GetGrossSalesReport Data
        /// </summary>
        public IEnumerable<GrossSalesReportResponse> GetGrossSalesReport()
        {            
            var query =
                from raMain in
                    DbSet.Where(ramain => ramain.StartDtTime.Month.Equals(10) && ramain.RaStatus.RaStatusId == 2 && ramain.UserDomainKey == UserDomainKey)
                select new GrossSalesReportResponse
                {
                    CompanyCode = raMain.BusinessPartner.Company.CompanyCode + "-"+raMain.BusinessPartner.Company.CompanyName,
                    DepartmentCode = raMain.Operation.Department.DepartmentCode,
                    OperationCode = raMain.Operation.OperationCode,
                    MonthName = raMain.StartDtTime.Month,
                    Year = raMain.StartDtTime.Year,
                    TotalSales = raMain.NetBillAfterDiscount,
                    CollectedAmount = raMain.AmountPaid,
                    UnCollectedAmount = raMain.NetBillAfterDiscount - raMain.AmountPaid
                };
            return query.OrderBy(ramain => ramain.CollectedAmount).ToList();
        }

        /// <summary>
        /// Get total number of rental agreements with domain key
        /// </summary>
        public int GetCountOfRAswithDomainKey()
        {
            return DbSet.Count(ra => ra.UserDomainKey == UserDomainKey);
        }

        public RaMain FindRentalAgreement(long rAMainId)
        {
            return DbSet.Include(ra => ra.BusinessPartner.BusinessPartnerCompany).Include(ra => ra.BusinessPartner.BusinessPartnerIndividual).FirstOrDefault(ra => ra.RaMainId == rAMainId);
        }
        #endregion
    }
}
