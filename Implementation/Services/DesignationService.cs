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
    /// Designation Service 
    /// </summary>
    public class DesignationService : IDesignationService
    {
        #region Private
        private readonly IEmpJobInfoRepository empJobInfoRepository;
        private readonly IEmpJobProgRepository empJobProgRepository;
        private readonly IDesignationRepository designationRepository;
        /// <summary>
        /// Set newly created Designation object Properties in case of adding
        /// </summary>
        private void SetDesignationProperties(Designation designation, Designation dbVersion)
        {
            dbVersion.RecLastUpdatedBy = dbVersion.RecCreatedBy = designationRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.UserDomainKey = designationRepository.UserDomainKey;
            dbVersion.DesignationCode = designation.DesignationCode;
            dbVersion.DesignationName = designation.DesignationName;
            dbVersion.DesignationDescription = designation.DesignationDescription;
        }

        /// <summary>
        /// update  Designation object Properties in case of updation
        /// </summary>
        protected void UpdateDesignationPropertie(Designation designation, Designation dbVersion)
        {
            dbVersion.RecLastUpdatedBy = designationRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.DesignationCode = designation.DesignationCode;
            dbVersion.DesignationName = designation.DesignationName;
            dbVersion.DesignationDescription = designation.DesignationDescription;
        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long designationId)
        {
            // Assocoation with Employee Job Info check 
            if (empJobInfoRepository.IsEmpJobInfoAssociatedWithDesignation(designationId))
                throw new CaresException(Resources.EmployeeManagement.Designation.DesignationIsAssociatedWithEmpJobInfoError);

            // Assocoation with sub Emp Job progress check 
            if (empJobProgRepository.IsEmpJobProgressAssociatedWithDesignation(designationId))
                throw new CaresException(Resources.EmployeeManagement.Designation.DesignationIsAssociatedWithEmpJobProgError); 
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DesignationService(IEmpJobInfoRepository empJobInfoRepository, IEmpJobProgRepository empJobProgRepository, IDesignationRepository designationRepository)
        {
            this.empJobInfoRepository = empJobInfoRepository;
            this.empJobProgRepository = empJobProgRepository;
            this.designationRepository = designationRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Designations
        /// </summary>
        public IEnumerable<Designation> LoadAll()
        {
            return designationRepository.GetAll();
        }

        /// <summary>
        /// Search Designation
        /// </summary>
        public DesignationSearchRequestResponse SearchDesignation(DesignationSearchRequest request)
        {
            int rowCount;
            return new DesignationSearchRequestResponse
            {
                Designations = designationRepository.SearchDesignation(request, out rowCount),
                TotalCount = rowCount
            };
        }
        /// <summary>
        /// Delete Designation by id
        /// </summary>
        public void DeleteDesignation(long designationId)
        {
            Designation dbversion = designationRepository.Find((int)designationId);
            ValidateBeforeDeletion(designationId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.EmployeeManagement.Designation.DesignationNotFound));
            }
            designationRepository.Delete(dbversion);
            designationRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update Designation
        /// </summary>
        public Designation SaveDesignation(Designation designation)
        {
            Designation dbVersion = designationRepository.Find(designation.DesignationId);
            //Code Duplication Check
            if (designationRepository.DoesDesignationCodeExist(designation))
                throw new CaresException(Resources.EmployeeManagement.Designation.DesignationCodeDuplicationCheck); 

            if (dbVersion != null)
            {
                UpdateDesignationPropertie(designation, dbVersion);
                designationRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new Designation();
                SetDesignationProperties(designation, dbVersion);
                designationRepository.Add(dbVersion);
            }
            designationRepository.SaveChanges();
            // To Load the proprties
            return designationRepository.Find(dbVersion.DesignationId);
        }
      
        #endregion
    }
}