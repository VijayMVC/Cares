using System.Linq;
using DomainModels = Cares.Models.DomainModels;
using ApiModels = Cares.Web.Models;
using DomainResponseModel = Cares.Models.ResponseModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Ra Queue Mapper
    /// </summary>
    public static class RaQueueMapper
    {
        #region Base Data Mapper

        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static ApiModels.RaQueueBaseResponse CreateFrom(this DomainResponseModel.RaQueueBaseResponse source)
        {
            return new ApiModels.RaQueueBaseResponse
            {
                Operations = source.Operations.Select(c => c.CreateFrom()),
                OperationWorkPlaces = source.OperationWorkPlaces.Select(m => m.CreateFromDropDown()),
                RaStatuses = source.RaStatuses.Select(s => s.CreateFrom()),
                PaymentTerms = source.PaymentTerms.Select(pt => pt.CreateFrom()),
            };
        }

        #endregion
    }
}