using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using System.Linq;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Credit Limit Mapper
    /// </summary>
    public static class CreditLimitMapper
    {
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.CreditLimit CreateFrom(this CreditLimit source)
        {
            return new Models.CreditLimit
            {
               CreditLimitId = source.CreditLimitId,
               BpSubTypeId = source.BpSubTypeId,
               BpSubTypeName = source.BpSubType.BusinessPartnerSubTypeName,
               BpRatingTypeId = source.BpRatingTypeId,
               BpRatingTypeName = source.BpRatingType.BpRatingTypeName,
               IsIndividual = source.IsIndividual,
               StandardCreditLimit = source.StandardCreditLimit,
               Description = source.Description

            };
        }

        /// <summary>
        /// create Base Data Response web model from doain model
        /// </summary>
        public static Models.CreditLimitBaseDataResponse CreateFrom(this CreditLimitBaseDataResponse source)
        {
            return new Models.CreditLimitBaseDataResponse
            {
                BusinessPartnerSubTypes = source.BusinessPartnerSubTypes.Select(bpsubtype => bpsubtype.CreateFrom()),
                BpRatingTypes = source.BpRatingTypes.Select(ratingType => ratingType.CreateFrom())
            };
        }

        /// <summary>
        /// Create from search response domain model
        /// </summary>
        public static Models.CreditLimitSearchRequestResponse CreateFrom(this CreditLimitSearchRequestResponse source)
        {
            return new Models.CreditLimitSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                CreditLimits = source.CreditLimits.Select(creditLimit => creditLimit.CreateFrom())
            };
        }

        /// <summary>
        ///  Create domain model from web model
        /// </summary>
        public static CreditLimit CreateFrom(this Models.CreditLimit source)
        {
            return new CreditLimit
            {
                CreditLimitId = source.CreditLimitId,
                BpSubTypeId = source.BpSubTypeId,
                BpRatingTypeId = source.BpRatingTypeId,
                IsIndividual = source.IsIndividual,
                StandardCreditLimit = source.StandardCreditLimit,
                Description = source.Description
            };
        }
    }
}