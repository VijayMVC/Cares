using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Employee Status Mapper
    /// </summary>
    public static class EmpStatusMapper
    {
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static EmpStatusDropDown CreateFrom(this DomainModels.EmpStatus source)
        {
            return new EmpStatusDropDown
            {
                EmpStatusId = source.EmpStatusId,
                EmpStatusCodeName = source.EmpStatusCode + " - " + source.EmpStatusName
            };
        }
    }
}