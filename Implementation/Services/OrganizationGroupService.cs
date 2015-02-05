using System.Globalization;
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
        /// <summary>
        /// Set newly added org group properties
        /// </summary>
        private void SetOrgGroupProperties(OrgGroup requestOrgGroup)
        {
            requestOrgGroup.RecCreatedBy =
                requestOrgGroup.RecLastUpdatedBy = organizationGroupRepository.LoggedInUserIdentity;
            requestOrgGroup.RecCreatedDt = requestOrgGroup.RecLastUpdatedDt = DateTime.Now;
            requestOrgGroup.UserDomainKey = organizationGroupRepository.UserDomainKey;
            requestOrgGroup.RowVersion = 0;
            organizationGroupRepository.Add(requestOrgGroup);
        }
        /// <summary>
        /// set to be updated Org Group Properties
        /// </summary>
        private void UpdateOrgGroupProperties(OrgGroup requestOrgGroup, OrgGroup dbVersion)
        {
            dbVersion.OrgGroupCode = requestOrgGroup.OrgGroupCode;
            dbVersion.OrgGroupName = requestOrgGroup.OrgGroupName;
            dbVersion.OrgGroupDescription = requestOrgGroup.OrgGroupDescription;
            dbVersion.RecLastUpdatedBy = organizationGroupRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            organizationGroupRepository.Update(dbVersion);
        }
        #endregion

        #region Constructors

        /// <summary>
        /// constuctor
        /// </summary>
        public OrganizationGroupService(IOrganizationGroupRepository organizationGroupRepository,
            ICompanyRepository companyRepository)
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
        public void DeleteOrgGroup(long orgGroupId)
        {
            OrgGroup dbVersion = organizationGroupRepository.Find(orgGroupId);
            if (!companyRepository.IsOrgGroupContainCompany(orgGroupId))
            {
                if (dbVersion != null)
                {
                    organizationGroupRepository.Delete(dbVersion);
                    organizationGroupRepository.SaveChanges();
                }
                else
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "OrgGroup with Id {0} not found!", orgGroupId));
            }
            else
                throw new CaresException(
                    Resources.Organization.OrganizationGroup.OrganizationGroupIsAssociatedWithCompanyError);
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
                    UpdateOrgGroupProperties(requestOrgGroup, dbVersion);
                }
                else
                {
                    SetOrgGroupProperties(requestOrgGroup);
                }                
                organizationGroupRepository.SaveChanges();
                return organizationGroupRepository.Find(requestOrgGroup.OrgGroupId);
            }
            throw new CaresException(Resources.Organization.OrganizationGroup.OrganizationGroupWithSameCodeAlreadyExists);
        }
        #endregion
    }
}
