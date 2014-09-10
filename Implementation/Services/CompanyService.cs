using System;
using System.Globalization;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System.Collections.Generic;
namespace Cares.Implementation.Services
{
    /// <summary>
    /// Company Service
    /// </summary>
    public class CompanyService : ICompanyService
    {   
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IOrganizationGroupRepository organizationGroupRepository;
        private readonly IBusinessSegmentRepository businessSegmentRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IDepartmentRepository departmentRepository;
        #endregion
        #region Constructor
        /// <summary>
        ///  Company Constructor
        /// </summary>
        public CompanyService(ICompanyRepository companyRepository,
            IBusinessSegmentRepository businessSegmentRepository, IOrganizationGroupRepository organizationGroupRepository, IDepartmentRepository departmentRepository)
        {
            this.companyRepository = companyRepository;
            this.businessSegmentRepository = businessSegmentRepository;
            this.organizationGroupRepository = organizationGroupRepository;
            this.departmentRepository = departmentRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Add/Update Company
        /// </summary>
        public Company AddUpdateCompany(Company companyRequest)
        {
            Company dbVersion = companyRepository.Find(companyRequest.CompanyId);
            if (!companyRepository.IsCompanyCodeExists(companyRequest))
            {
                if (dbVersion != null)
                {
                    companyRequest.RecLastUpdatedBy = organizationGroupRepository.LoggedInUserIdentity;
                    companyRequest.RecLastUpdatedDt = DateTime.Now;
                    companyRequest.RowVersion = dbVersion.RowVersion + 1;
                    companyRequest.RecCreatedBy = dbVersion.RecCreatedBy;
                    companyRequest.RecCreatedDt = dbVersion.RecCreatedDt;
                    companyRequest.UserDomainKey = dbVersion.UserDomainKey;
                }
                else
                {
                    companyRequest.RecCreatedBy =
                        companyRequest.RecLastUpdatedBy = organizationGroupRepository.LoggedInUserIdentity;
                    companyRequest.RecCreatedDt = companyRequest.RecLastUpdatedDt = DateTime.Now;
                    companyRequest.RowVersion = 0;
                    companyRequest.UserDomainKey = 1;
                }
                companyRepository.Update(companyRequest);
                companyRepository.SaveChanges();
                // To Load the proprties
                return companyRepository.GetCompanyWithDetails(companyRequest.CompanyId);
            }
            throw new CaresException(Resources.Organization.Company.CompanyWithSameCodeAlreadyExistsError);
        }
        /// <summary>
        /// Load company Base data
        /// </summary>
        public CompanyBaseDataResponse LoadCompanyBaseData()
        {
            return new CompanyBaseDataResponse
            {
                ParrentCompanies = companyRepository.GetAll(),
                OrgGroups = organizationGroupRepository.GetAll(),
                BusinessSegments = businessSegmentRepository.GetAll()
            };
        }
        /// <summary>
        /// Delete Company 
        /// </summary>
        public void DeleteCompany(long companyId)
        {
            Company dbversion = companyRepository.Find(companyId);
            
            // company-department association checking
            if (departmentRepository.IsCompanyContainDepartment(companyId))
                throw new CaresException(Resources.Organization.Company.CompanyIsAssociatedWithDepartmentError);
            //if company is parent of other companies
            if (companyRepository.IsComapnyParent(companyId)) 
                throw new CaresException(Resources.Organization.Company.CompanyIsParentOfOtherCompanyError);

            
                if (dbversion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "Company with Id {0} not found!", companyId));
                }
                companyRepository.Delete(dbversion);
                companyRepository.SaveChanges();                
        }
        /// <summary>
        /// Search Company
        /// </summary>
        public CompanySearchRequestResponse SearchCompany(CompanySearchRequest request)
        {
            int rowCount;
            return new CompanySearchRequestResponse
            {
                Companies = companyRepository.SearchCompany(request, out rowCount),
                TotalCount = rowCount
            };
        }
        /// <summary>
        /// Load All Companies
        /// </summary>
        public IEnumerable<Company> LoadAll()
        {
            return companyRepository.GetAll();
        }
        #endregion
    }
}
