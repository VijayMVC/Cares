using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Design Grade Service
    /// </summary>
    public class DesignGradeService : IDesignGradeService
    {
        #region Private
        private readonly IEmpJobInfoRepository empJobInfoRepository;
        private readonly IDesignGradeRepository desigGradeRepository;

        /// <summary>
        /// Set newly created Design Grade object Properties in case of adding
        /// </summary>
        private void SetDesignGradeProperties(DesignGrade designGrade, DesignGrade dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = desigGradeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.DesigGradeCode = designGrade.DesigGradeCode;
            dbVersion.DesigGradeName = designGrade.DesigGradeName;
            dbVersion.DesigGradeDescription = designGrade.DesigGradeDescription;
            dbVersion.UserDomainKey = desigGradeRepository.UserDomainKey;
        }

        /// <summary>
        /// update  Region object Properties in case of updation
        /// </summary>
        protected void UpdateDesignGradePropertie(DesignGrade designGrade, DesignGrade dbVersion)
        {
            dbVersion.RecLastUpdatedBy = desigGradeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.DesigGradeCode = designGrade.DesigGradeCode;
            dbVersion.DesigGradeName = designGrade.DesigGradeName;
            dbVersion.DesigGradeDescription = designGrade.DesigGradeDescription;
        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long designGradeId)
        {
            // Assocoation with Emp Job Info check 
            if (empJobInfoRepository.IsEmpJobInfoAssociatedWithDesignGrade(designGradeId))
                throw new CaresException(Resources.EmployeeManagement.DesignationGrade.DesignationGradeIsAssociatedWithEmpJobInfo);
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DesignGradeService(IEmpJobInfoRepository empJobInfoRepository, IDesignGradeRepository desigGradeRepository)
        {
            this.empJobInfoRepository = empJobInfoRepository;
            this.desigGradeRepository = desigGradeRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Design Grades
        /// </summary>
        public IEnumerable<DesignGrade> LoadAll()
        {
            return desigGradeRepository.GetAll();
        }

        /// <summary>
        /// Search Design Grade
        /// </summary>
        public DesignGradeSearchRequestResponse SearchDesignGrade(DesignGradeSearchRequest request)
        {
            int rowCount;
            return new DesignGradeSearchRequestResponse
            {
                DesignGrades = desigGradeRepository.SearchDesigGrade(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Design Grade by id
        /// </summary>
        public void DeleteDesignGrade(long designGradeId)
        {
            DesignGrade dbversion = desigGradeRepository.Find((int)designGradeId);
            ValidateBeforeDeletion(designGradeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.EmployeeManagement.DesignationGrade.DesignGradeNotFound));
            }
            desigGradeRepository.Delete(dbversion);
            desigGradeRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update Design Grade
        /// </summary>
        public DesignGrade SaveDesignGrade(DesignGrade designGrade)
        {
            DesignGrade dbVersion = desigGradeRepository.Find(designGrade.DesigGradeId);
            //Code Duplication Check
            if (desigGradeRepository.DesignGradeCodeDuplicationCheck(designGrade))
                throw new CaresException(Resources.EmployeeManagement.DesignationGrade.DesignationGradeCodeAlreadyExistsError); 

            //UPDATE
            if (dbVersion != null) 
            {
                UpdateDesignGradePropertie(designGrade, dbVersion);
                desigGradeRepository.Update(dbVersion);
            } //ADD
            else
            {
                dbVersion = new DesignGrade();
                SetDesignGradeProperties(designGrade, dbVersion);
                desigGradeRepository.Add(dbVersion);
            }
            desigGradeRepository.SaveChanges();
            return desigGradeRepository.Find(dbVersion.DesigGradeId);
        }
        #endregion
    }
}