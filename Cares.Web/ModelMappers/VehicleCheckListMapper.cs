using System.Linq;
using Cares.Web.Models;
using CompanySearchRequestResponse = Cares.Models.ResponseModels.CompanySearchRequestResponse;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Vehicle Check List Mapper
    /// </summary>
    public static class VehicleCheckListMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity [dropdown]
        /// </summary>
        public static VehicleCheckListDropDown CreateFromDropDown(this Cares.Models.DomainModels.VehicleCheckList source)
        {
            return new VehicleCheckListDropDown
            {
                VehicleCheckListId = source.VehicleCheckListId,
                VehicleCheckListCodeName = source.VehicleCheckListCode + " - " + source.VehicleCheckListName
            };
        }


        /// <summary>
        /// Crete From web model
        /// </summary>
        public static Cares.Models.DomainModels.VehicleCheckList CreateFrom(this VehicleCheckList source)
        {
            return new Cares.Models.DomainModels.VehicleCheckList
            {
                VehicleCheckListId = source.VehicleCheckListId,
                VehicleCheckListCode = source.VehicleCheckListCode,
                VehicleCheckListName = source.VehicleCheckListName,
                VehicleCheckListDescription = source.VehicleCheckListDescription,
                IsInterior = source.IsInterior
            };
        }

        /// <summary>
        /// Crete From  search Response domain model
        /// </summary>
        public static VehicleCheckListSearchRequestResponse CreateFrom(this Cares.Models.ResponseModels.VehicleCheckListSearchRequestResponse source)
        {
            return new VehicleCheckListSearchRequestResponse
            {
                VehicleCheckLists = source.VehicleCheckLists.Select(vehicleCheckList=> vehicleCheckList.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Crete From Domain model
        /// </summary>
        public static VehicleCheckList CreateFromm(this Cares.Models.DomainModels.VehicleCheckList source)
        {
            return new VehicleCheckList
            {
                VehicleCheckListId=source.VehicleCheckListId,
                VehicleCheckListCode = source.VehicleCheckListCode,
                VehicleCheckListName = source.VehicleCheckListName,
                VehicleCheckListKey = source.VehicleCheckListKey,
                VehicleCheckListDescription = source.VehicleCheckListDescription,
                VehicleCheckListCodeName = source.VehicleCheckListCode + " - " + source.VehicleCheckListName,
                IsInterior = source.IsInterior
            };
        }
        #endregion
    }
}