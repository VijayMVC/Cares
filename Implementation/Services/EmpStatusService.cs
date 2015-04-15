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
    /// Employee Status Service
    /// </summary>
    public class EmpStatusService : IEmpStatusService
    {
        #region Private
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmpStatusRepository employeeStatusRepository;

        /// <summary>
        /// Set newly created Employee Status object Properties in case of adding
        /// </summary>
        private void SetEmployeeStatusProperties(EmpStatus empStatus, EmpStatus dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = employeeStatusRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.EmpStatusCode = empStatus.EmpStatusCode;
            dbVersion.EmpStatusName = empStatus.EmpStatusName;
            dbVersion.EmpStatusDescription = empStatus.EmpStatusDescription;
            dbVersion.EmpStatusFlag = empStatus.EmpStatusFlag;
            dbVersion.UserDomainKey = employeeStatusRepository.UserDomainKey;
        }

        /// <summary>
        /// update  Employee Status object Properties in case of updation
        /// </summary>
        protected void UpdateEmployeeStatusPropertie(EmpStatus empStatus, EmpStatus dbVersion)
        {
            dbVersion.RecLastUpdatedBy = employeeStatusRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.EmpStatusCode = empStatus.EmpStatusCode;
            dbVersion.EmpStatusName = empStatus.EmpStatusName;
            dbVersion.EmpStatusDescription = empStatus.EmpStatusDescription;
            dbVersion.EmpStatusFlag = empStatus.EmpStatusFlag;
        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long empStatusId)
        {
            // Assocoation with city Employee 
            if (employeeRepository.IsEmployeeAssociatedWithEmployeeStatus(empStatusId))
                throw new CaresException(Resources.EmployeeManagement.EmpStatus.EmpStatusIsAssociatedWithEmployee); 
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EmpStatusService(IEmployeeRepository employeeRepository, IEmpStatusRepository employeeStatusRepository)
        {
            this.employeeStatusRepository = employeeStatusRepository;
            this.employeeRepository = employeeRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Employee Status
        /// </summary>
        public IEnumerable<EmpStatus> LoadAll()
        {
            return employeeStatusRepository.GetAll();
        }

        /// <summary>
        /// Search Employee Status
        /// </summary>
        public EmpSearchRequestResponse SearchEmployeeStatus(EmpSearchRequest request)
        {
            int rowCount;
            return new EmpSearchRequestResponse
            {
                EmployeeStatuses = employeeStatusRepository.SearchEmpStatus(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Employee Status by id
        /// </summary>
        public void DeleteEmployeeStatus(long empStatusId)
        {
            EmpStatus dbversion = employeeStatusRepository.Find((int)empStatusId);
            ValidateBeforeDeletion(empStatusId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.EmployeeManagement.EmpStatus.EmployeeStatusNotFound));
            }
            employeeStatusRepository.Delete(dbversion);
            employeeStatusRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update Employee Status
        /// </summary>
        public EmpStatus SaveEmpStatus(EmpStatus empStatus)
        {
            EmpStatus dbVersion = employeeStatusRepository.Find(empStatus.EmpStatusId);
            //Code Duplication Check
            if (employeeStatusRepository.DoesEmpStatusCodeExist(empStatus))
                throw new CaresException(Resources.EmployeeManagement.EmpStatus.EmpStatusCodeAlreadyExistsError); 

            if (dbVersion != null)
            {
                UpdateEmployeeStatusPropertie(empStatus, dbVersion);
                employeeStatusRepository.Update(dbVersion);
            }
            else
            {
                dbVersion=new EmpStatus();
                SetEmployeeStatusProperties(empStatus, dbVersion);
                employeeStatusRepository.Add(dbVersion);
            }
            employeeStatusRepository.SaveChanges();
            // To Load the proprties
            return employeeStatusRepository.Find(dbVersion.EmpStatusId);
        }
        #endregion
    }
}