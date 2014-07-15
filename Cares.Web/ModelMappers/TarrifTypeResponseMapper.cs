using System.Linq;
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class TarrifTypeResponseMapper
    {   
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static TarrifTypeResponse CreateFrom(this global::Models.ResponseModels.TarrifTypeResponse source)
        {
            return new TarrifTypeResponse
            {
                TotalCount = source.TotalCount,
                ServerTarrifTypes = source.TarrifTypes.Select(p => p.CreateFrom())
            };
           
        }

        #endregion

    }
}