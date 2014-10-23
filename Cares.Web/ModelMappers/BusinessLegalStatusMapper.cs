
using System.Linq;
using DomainModels = Cares.Models.DomainModels;
using Cares.Web.Models;
using CompanySearchRequestResponse = Cares.Models.ResponseModels.CompanySearchRequestResponse;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Legal Status Mapper
    /// </summary>
    public static class BusinessLegalStatusMapper
    {
        /// <summary>
        ///  Create web model from entity [DropDown]
        /// </summary>
        public static BusinessLegalStatusDropDown CreateFrom(this DomainModels.BusinessLegalStatus source)
        {
            return new BusinessLegalStatusDropDown
            {
                BusinessLegalStatusId = source.BusinessLegalStatusId,
                BusinessLegalStatusCodeName = source.BusinessLegalStatusCode + " - " + source.BusinessLegalStatusName
            };
        }
        /// <summary>
        ///  Create entity from web model [DropDown]
        /// </summary>
        public static DomainModels.BusinessLegalStatus CreateFrom(this BusinessLegalStatusDropDown source)
        {
            if (source != null)
            {
                return new DomainModels.BusinessLegalStatus
                {
                    BusinessLegalStatusId = source.BusinessLegalStatusId,
                    BusinessLegalStatusName = source.BusinessLegalStatusCodeName
                };
            }
            return new DomainModels.BusinessLegalStatus();
        }

        /// <summary>
        /// Crete From Search Response domain model
        /// </summary>
        public static BusinessLegalStatusSearchRequestRespose CreateFrom(this Cares.Models.ResponseModels.BusinessLegalStatusSearchRequestRespose source)
        {
            return new BusinessLegalStatusSearchRequestRespose
            {
                BusinessLegalStatuses = source.BusinessLegalStatuses.Select(company => company.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Crete From Domain model
        /// </summary>
        public static BusinessLegalStatus CreateFromm(this DomainModels.BusinessLegalStatus source)
        {
            return new BusinessLegalStatus
            {
               BusinessLegalStatusId = source.BusinessLegalStatusId,
               BusinessLegalStatusCode = source.BusinessLegalStatusCode,
               BusinessLegalStatusName = source.BusinessLegalStatusName,
               BusinessLegalStatusDescription = source.BusinessLegalStatusDescription
            };
        }

        /// <summary>
        /// Crete From Web model
        /// </summary>
        public static DomainModels.BusinessLegalStatus CreateFromm(this BusinessLegalStatus source)
        {
            return new DomainModels.BusinessLegalStatus
            {
                BusinessLegalStatusId = source.BusinessLegalStatusId,
                BusinessLegalStatusCode = source.BusinessLegalStatusCode.Trim(),
                BusinessLegalStatusName = source.BusinessLegalStatusName,
                BusinessLegalStatusDescription = source.BusinessLegalStatusDescription
            };
        }
    }
}