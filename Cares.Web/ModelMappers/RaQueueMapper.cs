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
        ///  Ra Queue Base Response Mapper
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

        #region Public

        /// <summary>
        ///  Ra Queue Search Response Mapper
        /// </summary>
        public static ApiModels.RaMainForRaQueueSearchResponse CreateFrom(this DomainResponseModel.RaMainForRaQueueSearchResponse source)
        {
            return new ApiModels.RaMainForRaQueueSearchResponse
            {
                RaMains = source.RaMains.Select(raMain => raMain.CreateFromForRaQueue()).ToList(),
                TotalCount = source.TotalCount,
            };
        }

        /// <summary>
        ///  Ra Queue Search Response Mapper
        /// </summary>
        public static ApiModels.RaMainForRaQueue CreateFromForRaQueue(this DomainModels.RaMain source)
        {
            return new ApiModels.RaMainForRaQueue
            {
                RaMainId = source.RaMainId,
                CloseLocation = source.OperationsWorkPlaceClose.LocationCode,
                OpenLocation = source.OperationsWorkPlaceOpen.LocationCode,
                StartDtTime = source.StartDtTime,
                EndDtTime = source.EndDtTime,
                OperationCode = source.Operation.OperationCode,
                RaStatusCode = source.RaStatus.RaStatusCode,
            };
        }
        #endregion
    }
}