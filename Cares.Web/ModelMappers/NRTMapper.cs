using System.Linq;
using DomainModel = Cares.Models.DomainModels;
using DomainResponseModel = Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Non revenue Ticket Mapper
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class NRTMapper
    {
        #region  Base Data Response

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.NRTBaseResponse CreateFrom(this DomainResponseModel.NRTBaseResponse source)
        {
            return new ApiModel.NRTBaseResponse
            {
                Operations = source.Operations.Select(c => c.CreateFrom()).ToList(),
                Locations = source.Locations.Select(c => c.CreateFromDropDown()).ToList(),
                NRTTypes = source.NRTTypes.Select(c => c.CreateFrom()).ToList(),
                VehicleStatuses = source.VehicleStatuses.Select(c => c.CreateFrom()).ToList(),
            };
        }
        #endregion
    }
}