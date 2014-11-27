using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
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
                        !cChrg.IsDeleted && cChrg.StartDt <= raRecCreatedDt).OrderByDescending(adc => adc.RowVersion).ToList();
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

        public IEnumerable<WebApiAvailableChauffer> GetAvailableChauffeurForWebApi(string tarrifTypeCode, DateTime startDt,DateTime endDateTime, long userDomainKey)
        {
                var query =
                    db.Employees.Where(
                        emp => emp.EmpJobProgs.Any(jobprog => jobprog.DesignationId == (int) DesignationEnum.Chauffer))
                        .Select(employee => employee);
                List<Employee> availableEmpos = query.OrderBy(emp => emp.EmpFName).ToList();

                var final = from chauffer in (availableEmpos.Select(chauffer => chauffer).
                    Where(chauffer => chauffer.ChaufferReservations.OrderBy(date=>date.StartDtTime)
                        .Any(reservationRec =>!( startDt <= reservationRec.EndDtTime && endDateTime >= reservationRec. StartDtTime))).ToList())
                    join
                        chuffferCharge in db.ChaufferCharges
                        on new {chauffer.EmpJobInfo.DesigGradeId} equals new {chuffferCharge.DesigGradeId}
                    where (chuffferCharge.ChaufferChargeMain.TariffTypeCode.Equals(tarrifTypeCode))
                    select new WebApiAvailableChauffer
                    {
                        ChaufferId = chauffer.EmployeeId,
                        DesignationGrade = chauffer.EmpJobInfo.DesigGrade.DesigGradeCode,
                        TariffTypeCode = chuffferCharge.ChaufferChargeMain.TariffTypeCode,
                        ChaufferChargeRate =  chuffferCharge.ChaufferChargeMain.ChaufferCharges.
                        Where(rate=> rate.StartDt<=startDt).OrderBy(abc=>abc.RevisionNumber).FirstOrDefault()!=null ? chuffferCharge.ChaufferChargeMain.ChaufferCharges.
                        Where(rate=> rate.StartDt<=startDt).OrderBy(abc=>abc.RevisionNumber).FirstOrDefault().ChaufferChargeRate:0,

                         RevisionNumber =  chuffferCharge.ChaufferChargeMain.ChaufferCharges.
                         Where(rate => rate.StartDt <= startDt).OrderBy(abc => abc.RevisionNumber).FirstOrDefault()!=null ?
                         chuffferCharge.ChaufferChargeMain.ChaufferCharges.
                         Where(rate => rate.StartDt <= startDt).OrderBy(abc => abc.RevisionNumber).FirstOrDefault().RevisionNumber:0
                    };
                return final.OrderBy(abc => abc.TariffTypeCode).ToList();
         }
        #endregion
    }
}
// look at it showoing some erros 