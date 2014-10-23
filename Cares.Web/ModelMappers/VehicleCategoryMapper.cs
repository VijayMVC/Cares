using System.Linq;
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Vehicle Category Mapper
    /// </summary>
    public static class VehicleCategoryMapper
    {
        #region Public
        
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleCategoryDropDown CreateFrom(this Cares.Models.DomainModels.VehicleCategory source)
        {
            return new VehicleCategoryDropDown
            {
                VehicleCategoryId = source.VehicleCategoryId,
                VehicleCategoryCodeName = source.VehicleCategoryCode + "-" + source.VehicleCategoryName
            };
        }
        

         /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleCategory CreateFromm(this Cares.Models.DomainModels.VehicleCategory source)
         {
             return new VehicleCategory
             {
                 VehicleCategoryId = source.VehicleCategoryId,
                 VehicleCategoryCode = source.VehicleCategoryCode,
                 VehicleCategoryName = source.VehicleCategoryName,
                 VehicleCategoryDescription = source.VehicleCategoryDescription
             };
         }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static Cares.Models.DomainModels.VehicleCategory CreateFromm(this VehicleCategory source)
        {
            return new Cares.Models.DomainModels.VehicleCategory
            {
                VehicleCategoryId = source.VehicleCategoryId,
                VehicleCategoryCode = source.VehicleCategoryCode,
                VehicleCategoryName = source.VehicleCategoryName,
                VehicleCategoryDescription = source.VehicleCategoryDescription
            };
        }

        /// <summary>
        /// Create From Domain Search Request Response
        /// </summary>

        public static VehicleCategorySearchRequestResponse CreateFrom(this Cares.Models.ResponseModels.VehicleCategorySearchRequestResponse source)
        {
            return new VehicleCategorySearchRequestResponse
            {
                VehicleCategories = source.VehicleCategories.Select(vehiclecategory => vehiclecategory.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        #endregion
    }
}