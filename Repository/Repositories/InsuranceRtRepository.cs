using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Insurance Rate Repository
    /// </summary>
    public sealed class InsuranceRtRepository : BaseRepository<InsuranceRt>, IInsuranceRtRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceRtRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<InsuranceRt> DbSet
        {
            get
            {
                return db.InsuranceRts;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Insurance Rate for User Domain Key
        /// </summary>
        public override IEnumerable<InsuranceRt> GetAll()
        {
            return DbSet.Where(insuranceRt => insuranceRt.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get Insurance Rate By Insurance Rate MainI d
        /// </summary>
        /// <param name="insuranceRtMainId"></param>
        /// <returns></returns>
        public IEnumerable<InsuranceRt> GetInsuranceRtByInsuranceRtMainId(long insuranceRtMainId)
        {
            return DbSet.Where(insuranceRt => insuranceRt.UserDomainKey == UserDomainKey && insuranceRt.InsuranceRtMainId == insuranceRtMainId).ToList();
        }

        /// <summary>
        /// Get Insurance Rate for Ra Billing
        /// </summary>
        public IEnumerable<InsuranceRt> GetForRaBilling(string tariffTypeCode, long hireGroupDetailId, long insuranceTypeId,
            DateTime raRecCreatedDate)
        {
            return
                DbSet.Include(ir => ir.InsuranceRtMain).Where(ir => ir.UserDomainKey == UserDomainKey && !ir.IsDeleted && ir.HireGroupDetailId == hireGroupDetailId &&
                        ir.StartDt <= raRecCreatedDate && ir.InsuranceTypeId == insuranceTypeId && ir.InsuranceRtMain.TariffTypeCode == tariffTypeCode)
                        .OrderByDescending(ir => ir.StartDt).ToList();
        }

        /// <summary>
        /// Get Insurance Rate for Ra
        /// </summary>
        public IEnumerable<InsuranceRt> GetAllForRa()
        {
            return DbSet.Where(ir => ir.UserDomainKey == UserDomainKey && !ir.IsDeleted && ir.ChildInsuranceRtId == null).ToList();
        }


        /// <summary>
        /// Association check B/W Insurance Type and Insurance RT
        /// </summary>
        public bool IsInsuranceTypeAssociatedWithInsuranceRt(long insuranceTypeId)
        {
            return DbSet.Count(insuranceRt => insuranceRt.InsuranceTypeId == insuranceTypeId && insuranceRt.UserDomainKey == UserDomainKey) > 0;
        }

        /// <summary>
        /// Get Available Insurance Rate ForWebApi
        /// </summary>
        public IEnumerable<WebApiAvailableInsurance> GetAvailableInsuranceRtForWebApi(long hireGroupDetailId, DateTime startDt, long userDomainKey)
        {
            return DbSet.Where(
                ir =>
                    ir.UserDomainKey == userDomainKey && !ir.IsDeleted && ir.ChildInsuranceRtId == null &&
                    ir.HireGroupDetailId == hireGroupDetailId &&
                    ir.StartDt <= startDt).Select(x => new WebApiAvailableInsurance()
                    {
                        InsuranceRtId = x.InsuranceRtId
                    }).ToList();

        }

        #endregion
    }
}
