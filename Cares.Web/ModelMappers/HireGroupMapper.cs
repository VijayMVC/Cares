using Cares.Web.Models;
using DomainModels = Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    public static class HireGroupMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static HireGroup CreateFrom(this DomainModels.HireGroup source)
        {
            return new HireGroup
            {
                HireGroupId = source.HireGroupId,
                HireGroupName = source.HireGroupCode + "-" + source.HireGroupName,
            };
        }
        #endregion
    }
}