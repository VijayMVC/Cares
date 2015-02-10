using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;


namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Country Mapper
    /// </summary>
    public static class CountryMapper
    {
        /// <summary>
        ///  Create  dropdown web model from entity
        /// </summary>
        public static ApiModel.CountryDropDown CreateFrom(this Country source)
        {
            return new ApiModel.CountryDropDown
            {
                CountryId = source.CountryId,
                CountryCodeName = source.CountryName + " - (" + source.CountryCode + ")",
            };
        }
    }
}