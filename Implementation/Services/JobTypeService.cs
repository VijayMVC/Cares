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
    /// Job Type Service
    /// </summary>
    public class JobTypeService : IJobTypeService
    {
        #region Private
        private readonly IJobTypeRepository jobTypeRepository;
        private readonly IEmpJobInfoRepository empJobInfoRepository;

        /// <summary>
        /// Set newly created Job Type object Properties in case of adding
        /// </summary>
        private void SetJobTypeProperties(JobType jobType, JobType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = jobTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.JobTypeCode = jobType.JobTypeCode;
            dbVersion.JobTypeName = jobType.JobTypeName;
            dbVersion.JobTypeDescription = jobType.JobTypeDescription;
            dbVersion.UserDomainKey = jobTypeRepository.UserDomainKey;
        }

        /// <summary>
        /// update Job Type object Properties in case of updation
        /// </summary>
        protected void UpdateJobTypePropertie(JobType jobType, JobType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = jobTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.JobTypeCode = jobType.JobTypeCode;
            dbVersion.JobTypeName = jobType.JobTypeName;
            dbVersion.JobTypeDescription = jobType.JobTypeDescription;
        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long jobTypeId)
        {
            // Assocoation with Job Info check 
            if (empJobInfoRepository.IsEmpJobInfoAssociatedWithJobType(jobTypeId))
                throw new CaresException(Resources.EmployeeManagement.JobType.JobTypeIsAssociatedWithEmployeeJobInfoError); 
        }

        #endregion
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public JobTypeService(IJobTypeRepository jobTypeRepository, IEmpJobInfoRepository empJobInfoRepository)
        {
            this.jobTypeRepository = jobTypeRepository;
            this.empJobInfoRepository = empJobInfoRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Load all Job Types
        /// </summary>
        public IEnumerable<JobType> LoadAll()
        {
            return jobTypeRepository.GetAll();
        }

        /// <summary>
        /// Search Job Type
        /// </summary>
        public JobTypeSearchRequestResponse SearchJobType(JobTypeSearchRequest request)
        {
            int rowCount;
            return new JobTypeSearchRequestResponse
            {
                JobTypes = jobTypeRepository.SearchJobType(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Job Type by id
        /// </summary>
        public void DeleteJobType(long jobTypeId)
        {
            JobType dbversion = jobTypeRepository.Find((int)jobTypeId);
            ValidateBeforeDeletion(jobTypeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Job Type with Id {0} not found!", jobTypeId));
            }
            jobTypeRepository.Delete(dbversion);
            jobTypeRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update JobType
        /// </summary>
        public JobType SaveJobType(JobType jobType)
        {
            JobType dbVersion = jobTypeRepository.Find(jobType.JobTypeId);

            //Code Duplication Check
            if (jobTypeRepository.DoesJobTypeCodeExists(jobType))
                throw new CaresException(Resources.EmployeeManagement.JobType.JobTypeCodeDuplicationError);  

            if (dbVersion != null)
            {
                UpdateJobTypePropertie(jobType, dbVersion);
                jobTypeRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new JobType();
                SetJobTypeProperties(jobType, dbVersion);
                jobTypeRepository.Add(dbVersion);
            }
            jobTypeRepository.SaveChanges();
            // To Load the proprties
            return jobTypeRepository.Find(dbVersion.JobTypeId);
        }
        #endregion
    }
}