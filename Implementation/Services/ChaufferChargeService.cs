using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Chauffer Charge Service
    /// </summary>
    public class ChaufferChargeService : IChaufferChargeService
    {
        #region Private

        /// <summary>
        /// Private members
        /// </summary>
        private readonly IChaufferChargeRepository chaufferChargeRepository;
        private readonly IChaufferChargeMainRepository chaufferChargeMainRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IOperationRepository operationRepository;
        private readonly ITariffTypeRepository tariffTypeRepository;
        private readonly IDesignGradeRepository designGradeRepository;


        #endregion

        #region Constructor

        /// <summary>
        ///  Constructor
        /// </summary>
        public ChaufferChargeService(IChaufferChargeRepository chaufferChargeRepository,
            IChaufferChargeMainRepository chaufferChargeMainRepository, ICompanyRepository companyRepository,
            IDepartmentRepository departmentRepository, IOperationRepository operationRepository, ITariffTypeRepository tariffTypeRepository,
            IDesignGradeRepository designGradeRepository)
        {
            this.chaufferChargeRepository = chaufferChargeRepository;
            this.chaufferChargeMainRepository = chaufferChargeMainRepository;
            this.companyRepository = companyRepository;
            this.departmentRepository = departmentRepository;
            this.operationRepository = operationRepository;
            this.operationRepository = operationRepository;
            this.tariffTypeRepository = tariffTypeRepository;
            this.designGradeRepository = designGradeRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Load Chauffer Charge Base data
        /// </summary>
        public ChaufferChargeBaseResponse GetBaseData()
        {
            return new ChaufferChargeBaseResponse
            {
                Companies = companyRepository.GetAll(),
                Departments = departmentRepository.GetAll(),
                Operations = operationRepository.GetAll(),
                TariffTypes = tariffTypeRepository.GetAll(),
                DesigGrades = designGradeRepository.GetAll(),
            };
        }

        /// <summary>
        /// Load Chauffer Charge Main  Based on search criteria
        /// </summary>
        /// <returns></returns>
        public ChaufferChargeSearchResponse LoadAll(ChaufferChargeSearchRequest request)
        {
            return chaufferChargeMainRepository.GetChaufferCharges(request);
        }

        /// <summary>
        /// Save Chauffer Charge
        /// </summary>
        /// <param name="chaufferCharge"></param>
        /// <returns></returns>
        public ChaufferChargeMainContent SaveChaufferCharge(ChaufferChargeMain chaufferCharge)
        {
            return null;

        }

        /// <summary>
        /// Delete Chauffer Charge
        /// </summary>
        /// <param name="chaufferChargeMain"></param>
        public void DeleteAdditionalCharge(ChaufferChargeMain chaufferChargeMain)
        {
            chaufferChargeMainRepository.Delete(chaufferChargeMain);
            chaufferChargeMainRepository.SaveChanges();
        }

        /// <summary>
        /// Find Chauffer Charge By Id
        /// </summary>
        /// <param name="chaufferChargeMainId"></param>
        /// <returns></returns>
        public ChaufferChargeMain FindById(long chaufferChargeMainId)
        {
            return chaufferChargeMainRepository.Find(chaufferChargeMainId);
        }

        /// <summary>
        /// Get Chauffer Charges By Chauffer Charge Main Id
        /// </summary>
        /// <param name="chaufferChargeMainId"></param>
        /// <returns></returns>
        public IEnumerable<ChaufferCharge> GetChaufferChargesByChaufferChargeMainId(long chaufferChargeMainId)
        {
            return chaufferChargeRepository.GetChaufferChargesByChaufferChargeMainId(chaufferChargeMainId);
        }



        #endregion
    }
}
