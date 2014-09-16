using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Area Base Data Response Web Model
    /// </summary>
    public class AreaBaseDataResponse
    {
        #region Public
        /// <summary>
        /// List of Cities
        /// </summary>
        public IEnumerable<CityDropDown> Cities { get; set; }
        #endregion
    }
}