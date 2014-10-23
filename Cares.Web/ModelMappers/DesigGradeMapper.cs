using Cares.Web.Models;
using System.Linq;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Designation Grade Mapper
    /// </summary>
    public static class DesigGradeMapper
    {
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DesigGradeDropDown CreateFrom(this DomainModels.DesignGrade source)
        {
            return new DesigGradeDropDown
            {
                DesigGradeId = source.DesigGradeId,
                DesigGradeCodeName = source.DesigGradeCode + " - " + source.DesigGradeName
            };
        }


        /// <summary>
        /// Create From Response model to web search response
        /// </summary>
        public static DesignGradeSearchRequestResponse CreateFrom(this Cares.Models.RequestModels.DesignGradeSearchRequestResponse source)
        {
            return new DesignGradeSearchRequestResponse
            {
                DesignGrades = source.DesignGrades.Select(region => region.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        ///  Create from domain model to web model
        /// </summary>
        public static DesignGrade CreateFromm(this DomainModels.DesignGrade source)
        {
            return new DesignGrade
            {
                DesigGradeId = source.DesigGradeId,
                DesigGradeCode = source.DesigGradeCode,
                DesigGradeName = source.DesigGradeName,
                DesigGradeDescription = source.DesigGradeDescription
            };
        }

        /// <summary>
        ///  Create from web model 
        /// </summary>
        public static DomainModels.DesignGrade CreateFrom(this DesignGrade source)
        {
            return new DomainModels.DesignGrade
            {
                DesigGradeId = source.DesigGradeId,
                DesigGradeCode = source.DesigGradeCode,
                DesigGradeName = source.DesigGradeName,
                DesigGradeDescription = source.DesigGradeDescription
            };
        }

    }
}