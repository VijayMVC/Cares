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
    /// Chauffer Charge Repository
    /// </summary>
    public class ChaufferChargeRepository : BaseRepository<ChaufferCharge>, IChaufferChargeRepository
    {
        #region Private
        
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ChaufferChargeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ChaufferCharge> DbSet
        {
            get
            {
                return db.ChaufferCharges;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Chauffer Charge for User Domain Key
        /// </summary>
        public override IEnumerable<ChaufferCharge> GetAll()
        {
            return DbSet.Where(addDriverChrg => addDriverChrg.UserDomainKey == UserDomainKey).ToList();
        }
        
        /// <summary>
        /// Get For Ra Billing
        /// </summary>
        public IEnumerable<ChaufferCharge> GetForRaBilling(string tariffTypeCode, long desigGradeId, DateTime raRecCreatedDt)
        {
            return
                DbSet.Include(cc => cc.ChaufferChargeMain).Where(
                    cChrg =>
                        cChrg.UserDomainKey == UserDomainKey && cChrg.DesigGradeId == desigGradeId && cChrg.ChaufferChargeMain.TariffTypeCode == tariffTypeCode &&
                        !cChrg.IsDeleted && cChrg.StartDt <= raRecCreatedDt).OrderByDescending(adc => adc.StartDt).ToList();
        }
        
        /// <summary>
        /// Get Chauffer Charges By Chauffer Charge Main Id
        /// </summary>
        /// <param name="chaufferChargeMainId"></param>
        /// <returns></returns>
        public IEnumerable<ChaufferCharge> GetChaufferChargesByChaufferChargeMainId(long chaufferChargeMainId)
        {
            return
                DbSet.Where(
                    addChrg =>
                        addChrg.ChildChaufferChargeId == null &&
                        addChrg.ChaufferChargeMainId == chaufferChargeMainId).ToList();
        }


        #endregion
    }
}
