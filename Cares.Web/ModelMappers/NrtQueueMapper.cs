using System.Linq;
using DomainModels = Cares.Models.DomainModels;
using ApiModels = Cares.Web.Models;
using DomainResponseModel = Cares.Models.ResponseModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// NRT Queue Mapper
    /// </summary>
    public static class NrtQueueMapper
    {

        #region Base Data Mapper

        /// <summary>
        ///  NRT Queue Base Response Mapper
        /// </summary>
        public static ApiModels.NrtQueueBaseResponse CreateFrom(this DomainResponseModel.NrtQueueBaseResponse source)
        {
            return new ApiModels.NrtQueueBaseResponse
            {
                OperationWorkPlaces = source.OperationWorkPlaces.Select(m => m.CreateFromDropDown()),
                RaStatuses = source.RaStatuses.Select(s => s.CreateFrom()),
                NrtTypes = source.NrtTypes.Select(pt => pt.CreateFrom()),
            };
        }

        #endregion

        #region Public

        /// <summary>
        ///  NRT Queue Search Response Mapper
        /// </summary>
        public static ApiModels.NrtQueueSearchResponse CreateFrom(this DomainResponseModel.NrtQueueSearchResponse source)
        {
            return new ApiModels.NrtQueueSearchResponse
            {
                NrtMains = source.NrtMains.Select(raMain => raMain.CreateFromForNrtQueue()).ToList(),
                TotalCount = source.TotalCount,
            };
        }

        /// <summary>
        ///  NRT Main For NRT Queuue SearchMapper
        /// </summary>
        public static ApiModels.NrtMainForNrtQueue CreateFromForNrtQueue(this DomainModels.NrtMain source)
        {
            return new ApiModels.NrtMainForNrtQueue
            {
                NrtMainId = source.NrtMainId,
                CloseLocation = source.CloseLocation.LocationCode,
                OpenLocation = source.OpenLocation.LocationCode,
                StartDtTime = source.StartDtTime,
                EndDtTime = source.EndDtTime,
                NrtTypeCode = source.NrtType.NrtTypeCode + "-" + source.NrtType.NrtTypeName,
                NrtStatusCode = source.NrtStatus.RaStatusCode + "-" + source.NrtStatus.RaStatusName,
            };
        }
        #endregion
    }
}