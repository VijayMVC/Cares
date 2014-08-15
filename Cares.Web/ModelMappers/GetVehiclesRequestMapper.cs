using System.Linq;
using Cares.Web.Models;
using ResponseModel = Cares.Models.ResponseModels;
namespace Cares.Web.ModelMappers
{
    public static class GetVehiclesRequestMapper
    {
        #region Public

        /// <summary>
        /// Create Vehicle Search Response from domain Vehicle Search Response
        /// </summary>
        public static GetVehicleResponse CreateFrom(this ResponseModel.GetVehicleResponse source)
        {
            return new GetVehicleResponse
            {
                Vehicles = source.Vehicles.Select(hg => hg.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }

        #endregion

    }
}