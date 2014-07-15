using System.Linq;
using Models.ResponseModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Partner Response Mapper
    /// </summary>
    public static class  BusinessPartnertResponseMapper
    {
        #region Public

        /// <summary>
        ///  Create web api model from domain entity
        /// </summary>
        public static Models.BusinessPartnerResponse CreateFrom(this BusinessPartnerResponse source)
        {
            return new Models.BusinessPartnerResponse
            {
                TotalCount = source.TotalCount,
                BusinessPartners = source.BusinessPartners.Select(p => p.CreateFrom())
            };
        }
        #endregion

    }
}
