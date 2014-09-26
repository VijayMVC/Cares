using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;


namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Standard Rate Repository
    /// </summary>
    public sealed class StandardRateRepository : BaseRepository<StandardRate>, IStandardRateRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public StandardRateRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<StandardRate> DbSet
        {
            get
            {
                return db.StandardRates;
            }
        }

        #endregion
        
        #region Public
        
        /// <summary>
        /// Get All Standard Rates for User Domain Key
        /// </summary>
        public override IEnumerable<StandardRate> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get Standard Rate For Tariff Rate
        /// </summary>
        /// <param name="standardRtMainId"></param>
        /// <returns></returns>
        public IEnumerable<StandardRate> GetStandardRateForTariffRate(long standardRtMainId)
        {
            return DbSet.Where(s => s.UserDomainKey == UserDomainKey && s.StandardRtMainId == standardRtMainId && s.ChildStandardRtId == null).ToList();

        }
        
        /// <summary>
        /// Find by hire group and standard rate main id
        /// </summary>
        /// <param name="standardRtMainId"></param>
        /// <param name="hireGroupDetailId"></param>
        /// <returns></returns>
        public IEnumerable<StandardRate> FindByHireGroupId(long standardRtMainId, long hireGroupDetailId)
        {
            return DbSet.Where(s => s.UserDomainKey == UserDomainKey && s.StandardRtMainId == standardRtMainId && s.ChildStandardRtId == null && s.HireGroupDetailId == hireGroupDetailId);

        }

        /// <summary>
        /// Get For Ra Billing
        /// </summary>
        public IEnumerable<StandardRate> GetForRaBilling(string tariffTypeCode, long hireGroupDetailId, DateTime raRecCreatedDate)
        {
            return
                DbSet.Include(s => s.StandardRtMain).Where(
                    s =>
                        s.UserDomainKey == UserDomainKey && s.HireGroupDetailId == hireGroupDetailId &&
                        s.StandardRtStartDt <= raRecCreatedDate && s.StandardRtMain.TariffTypeCode == tariffTypeCode &&
                        !s.IsDeleted).OrderByDescending(s => s.StandardRtStartDt).ToList();
        }

        #endregion
    }
}
