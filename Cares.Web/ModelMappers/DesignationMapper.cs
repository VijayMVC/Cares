
using Cares.Web.Models;
using System.Linq;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Designation MApper
    /// </summary>
    public static class DesignationMapper
    {
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DesignationDropDown CreateFrom(this DomainModels.Designation source)
        {
            return new DesignationDropDown
            {
                DesignationId = source.DesignationId,
                DesignationCodeName = source.DesignationCode + " - " + source.DesignationName
            };
        }

        /// <summary>
        /// Create From Response model to web search response
        /// </summary>
        public static DesignationSearchRequestResponse CreateFrom(this Cares.Models.RequestModels.DesignationSearchRequestResponse source)
        {
            return new Models.DesignationSearchRequestResponse
            {
                Designations = source.Designations.Select(designation => designation.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        ///  Create from domain model to web model
        /// </summary>
        public static Designation CreateFromm(this DomainModels.Designation source)
        {
            return new Designation
            {
                DesignationId = source.DesignationId,
                DesignationCode = source.DesignationCode,
                DesignationName = source.DesignationName,
                DesignationDescription = source.DesignationDescription
            };
        }


        /// <summary>
        ///  Create from web model 
        /// </summary>
        public static DomainModels.Designation CreateFrom(this Designation source)
        {
            return new DomainModels.Designation
            {
                DesignationId = source.DesignationId,
                DesignationCode = source.DesignationCode,
                DesignationName = source.DesignationName,
                DesignationDescription = source.DesignationDescription
            };
        }
    }
}