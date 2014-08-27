using Cares.Web.Models;
using System.Linq;
using CompanyBaseDataResponse = Cares.Web.Models.CompanyBaseDataResponse;
using CompanySearchRequestResponse = Cares.Models.ResponseModels.CompanySearchRequestResponse;
using DomainModels = Cares.Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Company Mapper
    /// </summary>
    public static class CompanyMapper
    {
        #region Public
        /// <summary>
        /// Crete From web model
        /// </summary>
        public static DomainModels.Company CreateFrom(this Company source)
        {
            return new DomainModels.Company
            {
                CompanyId = source.CompanyId,
                CompanyCode = source.CompanyCode,
                CompanyName = source.CompanyName,
                CompanyLegalName = source.CompanyLegalName ?? string.Empty,
                ParentCompanyId = source.ParentCompanyId,
                CompanyDescription = source.CompanyDescription,
                CrNumber = source.CrNumber,
                PaidUpCapital = source.PaidUpCapital,
                Uan = source.Uan,
                Ntn = source.Ntn,
                OrgGroupId = source.OrgGroupId,
                BusinessSegmentId = source.BusinessSegmentId,
            };
        }
        /// <summary>
        /// Crete From company Responsemodel
        /// </summary>
        public static Models.CompanySearchRequestResponse CreateFrom(this CompanySearchRequestResponse source)
        {
            return new Models.CompanySearchRequestResponse
            {
                Companies = source.Companies.Select(company => company.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }
        /// <summary>
        /// Crete From Domain model
        /// </summary>
        public static Company CreateFromm(this DomainModels.Company source)
        {
            return new Company
            {
                CompanyId = source.CompanyId,
                CompanyCode = source.CompanyCode ,
                CompanyName = source.CompanyName,
                CompanyLegalName = source.CompanyLegalName,
                ParentCompanyId = source.ParentCompanyId,
                ParentCompanyName = source.ParentCompanyId != null ? source.ParentCompany.CompanyName : "",
                CompanyDescription = source.CompanyDescription,
                CrNumber = source.CrNumber,
                PaidUpCapital = source.PaidUpCapital,
                Uan = source.Uan,
                Ntn = source.Ntn,
                OrgGroupId = source.OrgGroupId,
                OrgGroupName = source.OrgGroupId !=null ? source.OrgGroup.OrgGroupName: "[No Org-Group]",
                BusinessSegmentId = source.BusinessSegmentId,
                BusinessSegmentName = source.BusinessSegment.BusinessSegmentName 
            };
        }
        /// <summary>
        /// Crete From domain model to dropdown
        /// </summary>
        public static CompanyDropDown CreateFrom(this DomainModels.Company source)
        {
            return new CompanyDropDown
            {
                CompanyId = source.CompanyId,
                CompanyCodeName = source.CompanyCode+" - " +source.CompanyName,
                ParentCompanyId = source.CompanyId
            };
        }
        /// <summary>
        /// Crete From response model to web base data
        /// </summary>
        public static CompanyBaseDataResponse CreateFrom(this Cares.Models.ResponseModels.CompanyBaseDataResponse source)
        {
            return new CompanyBaseDataResponse
            {
                ParrentCompanies = source.ParrentCompanies.Select(company => company.CreateFrom()),
                OrgGroups = source.OrgGroups.Select(orgGroup => orgGroup.CreateFrom()),
                BusinessSegments = source.BusinessSegments.Select(businessSegmen => businessSegmen.CreateFrom())
            };
        }
        #endregion
    }
}