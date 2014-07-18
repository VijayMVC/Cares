using System.Collections.Generic;
using System.Linq;
using Cares.Web.Models;
using DomainResponseModels=Models.ResponseModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// TarrifType Detail Response Mapper
    /// </summary>
    public static class TarrifTypeDetailResponseMapper
    {
        #region Public

        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static TariffTypeDetailResponse CreateFrom(this DomainResponseModels.TariffTypeDetailResponse source)
        {
            return new TariffTypeDetailResponse
            {
                TarrifType = source.TarrifType.CreateFromDetail(),
                TarrifTypeRevisions = source.TarrifTypeRevisions != null?source.TarrifTypeRevisions.Select(m => m.CreateFromDetail()):null,
               
            };
        }

        #endregion
    }
}