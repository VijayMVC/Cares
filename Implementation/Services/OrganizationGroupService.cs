using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System;

namespace Cares.Implementation.Services
{
   public sealed class OrganizationGroupService : IOrganizationGroupService
   {
       #region Public
       /// <summary>
       /// Search/Get org Group 
       /// </summary>
       public  OrgGroupResponse SerchOrgGroup(OrgGroupSearchRequest request)
       {
           int rowCount;
          return new OrgGroupResponse
           {
               OrgGroups = organizationGroupRepository.SearchOrgGroup(request, out rowCount),
               TotalCount = rowCount
           };
       }

       /// <summary>
       /// Delete Org Group
       /// </summary>
       public void DeleteOrgGroup(OrgGroup request)
       {
           OrgGroup dbVersion = organizationGroupRepository.Find(request.OrgGroupId);
           if (dbVersion != null)
           {
               organizationGroupRepository.Delete(dbVersion);
               organizationGroupRepository.SaveChanges();
           }
       }

       /// <summary>
       /// Add/Update Org Group
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
           throw new CaresException("Organization Group with same code already exists!");
       }
       #endregion

       #region Private       
        private readonly IOrganizationGroupRepository organizationGroupRepository;
        #endregion
       #region Constructors
       /// <summary>
       /// constuctor
       /// </summary>
        public OrganizationGroupService(IOrganizationGroupRepository organizationGroupRepository)
        {
            this.organizationGroupRepository = organizationGroupRepository;
        }

        #endregion
   }
}
