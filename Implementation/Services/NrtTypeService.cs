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
    public class NrtTypeService : INrtTypeService
    {   
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IOrganizationGroupRepository organizationGroupRepository;
        private readonly IBusinessSegmentRepository businessSegmentRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IDepartmentRepository departmentRepository;

        /// <summary>
        /// Set Company Properties while adding new instance
        /// </summary>
        private void SetCompanyProperties(Company companyRequest, Company dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = organizationGroupRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = 1;
            dbVersion.CompanyCode = companyRequest.CompanyCode;
            dbVersion.CompanyName = companyRequest.CompanyName;
            dbVersion.CompanyDescription = companyRequest.CompanyDescription;
            dbVersion.OrgGroupId = companyRequest.OrgGroupId;
            dbVersion.BusinessSegmentId = companyRequest.BusinessSegmentId;
            dbVersion.ParentCompanyId = companyRequest.ParentCompanyId;
            dbVersion.Ntn = companyRequest.Ntn;
            dbVersion.Uan = companyRequest.Uan;
            dbVersion.CompanyLegalName = companyRequest.CompanyLegalName;
            dbVersion.PaidUpCapital = companyRequest.PaidUpCapital;
            dbVersion.CrNumber = companyRequest.CrNumber;
        }

        /// <summary>
        /// Update Company Properties while updating the instance
        /// </summary>
        private void UpdateCompanyProperties(Company companyRequest, Company dbVersion)
        {
            dbVersion.RecLastUpdatedBy = organizationGroupRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.CompanyCode = companyRequest.CompanyCode;
            dbVersion.CompanyName = companyRequest.CompanyName;
            dbVersion.CompanyDescription = companyRequest.CompanyDescription;
            dbVersion.OrgGroupId = companyRequest.OrgGroupId;
            dbVersion.BusinessSegmentId = companyRequest.BusinessSegmentId;
            dbVersion.ParentCompanyId = companyRequest.ParentCompanyId;
            dbVersion.Ntn = companyRequest.Ntn;
            dbVersion.Uan = companyRequest.Uan;
            dbVersion.CompanyLegalName = companyRequest.CompanyLegalName;
            dbVersion.PaidUpCapital = companyRequest.PaidUpCapital;
            dbVersion.CrNumber = companyRequest.CrNumber;
        }

        /// <summary>
        /// Check company association with other entites before deletion
        /// </summary>
        private void CheckCompanyAssociations(long companyId)
        {
            // company-department association checking
            if (departmentRepository.IsCompanyContainDepartment(companyId))
                throw new CaresException(Resources.Organization.Company.CompanyIsAssociatedWithDepartmentError);
            //if company is parent of other companies
            if (companyRepository.IsComapnyParent(companyId))
                throw new CaresException(Resources.Organization.Company.CompanyIsParentOfOtherCompanyError);
        }


        #endregion
        #region Constructor
        /// <summary>
        ///  Company Constructor
        /// </summary>
        public NrtTypeService(ICompanyRepository companyRepository,
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
            CheckCompanyAssociations(companyId);
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
        /// Add/Update Company
        /// </summary>
        public Company AddUpdateCompany(Company companyRequest)
        {
            Company dbVersion = companyRepository.Find(companyRequest.CompanyId);
            if (!companyRepository.IsCompanyCodeExists(companyRequest))
            {
                if (dbVersion != null)
                {
                    UpdateCompanyProperties(companyRequest, dbVersion);
                    companyRepository.Update(dbVersion);
                }
                else
                {
                    dbVersion= new Company();
                    SetCompanyProperties(companyRequest, dbVersion);
                    companyRepository.Add(dbVersion);
                }
  
                companyRepository.SaveChanges();
                // To Load the proprties
                return companyRepository.GetCompanyWithDetails(dbVersion.CompanyId);
            }
            throw new CaresException(Resources.Organization.Company.CompanyWithSameCodeAlreadyExistsError);
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
