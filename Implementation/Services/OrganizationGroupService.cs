using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Organization Group  Service
    /// </summary>
   public sealed class OrganizationGroupService : IOrganizationGroupService
   {
       #region Private       
        private readonly IOrganizationGroupRepository organizationGroupRepository;
        private readonly ICompanyRepository companyRepository;

        #endregion
       #region Constructors
       /// <summary>
       /// constuctor
       /// </summary>
        public OrganizationGroupService(IOrganizationGroupRepository organizationGroupRepository, ICompanyRepository companyRepository)
        {
            this.organizationGroupRepository = organizationGroupRepository;
            this.companyRepository = companyRepository;
        }

        #endregion
       #region Public
        /// <summary>
        /// Search/Get Organization Group
        /// </summary>
        public OrgGroupResponse SerchOrgGroup(OrgGroupSearchRequest request)
        {
            int rowCount;
            return new OrgGroupResponse
            {
                OrgGroups = organizationGroupRepository.SearchOrgGroup(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Organization Group
        /// </summary>
        public void DeleteOrgGroup(OrgGroup request)
        {
            OrgGroup dbVersion = organizationGroupRepository.Find(request.OrgGroupId);
            if (!companyRepository.IsOrgGroupContainCompany(request))
            {
                if (dbVersion != null)
                {
                    organizationGroupRepository.Delete(dbVersion);
                    organizationGroupRepository.SaveChanges();
                }
            }
            else 
                throw new CaresException(Resources.Organization.OrganizationGroup.OrganizationGroupIsAssociatedWithCompanyError);
        }

        /// <summary>
        /// Add/Update Organization Group
        /// </summary>
        public OrgGroup AddUpdateOrgGroup(OrgGroup requestOrgGroup)
        {

            OrgGroup dbVersion = organizationGroupRepository.Find(requestOrgGroup.OrgGroupId);
            if (!organizationGroupRepository.IsOrgGroupCodeExists(requestOrgGroup))
            {
                if (dbVersion != null)
                {
                    requestOrgGroup.RecLastUpdatedBy = organizationGroupRepository.LoggedInUserIdentity;
                    requestOrgGroup.RecLastUpdatedDt = DateTime.Now;
                    requestOrgGroup.RowVersion = dbVersion.RowVersion + 1;
                    requestOrgGroup.RecCreatedBy = dbVersion.RecCreatedBy;
                    requestOrgGroup.RecCreatedDt = dbVersion.RecCreatedDt;
                    requestOrgGroup.UserDomainKey = dbVersion.UserDomainKey;

                }
                else
                {
                    requestOrgGroup.RecCreatedBy =
                    requestOrgGroup.RecLastUpdatedBy = organizationGroupRepository.LoggedInUserIdentity;
                    requestOrgGroup.RecCreatedDt = requestOrgGroup.RecLastUpdatedDt = DateTime.Now;
                    requestOrgGroup.RowVersion = 0;
                    requestOrgGroup.UserDomainKey = 1;

                }
                organizationGroupRepository.Update(requestOrgGroup);
                organizationGroupRepository.SaveChanges();
                return organizationGroupRepository.Find(requestOrgGroup.OrgGroupId);
            }
            throw new CaresException(Resources.Organization.OrganizationGroup.OrganizationGroupWithSameCodeAlreadyExists);
        }
        #endregion
   }
}
