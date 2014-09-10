using Cares.Web.Models;
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
        public static DesigGradeDropDown CreateFrom(this DomainModels.DesigGrade source)
        {
            return new DesigGradeDropDown
            {
                DesigGradeId = source.DesigGradeId,
                DesigGradeCodeName = source.DesigGradeCode + " - " + source.DesigGradeName
            };
        }
    }
}