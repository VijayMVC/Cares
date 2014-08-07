using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class HireGroupMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static HireGroup CreateFrom(this Cares.Models.DomainModels.HireGroup source)
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