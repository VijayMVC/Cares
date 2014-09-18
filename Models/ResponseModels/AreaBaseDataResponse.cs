using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Area Base Data Response Domain Model
    /// </summary>
   public class AreaBaseDataResponse
    {
        #region Public
        /// <summary>
        /// List of Cities
        /// </summary>
       public IEnumerable<City> Cities { get; set; }
        #endregion 
    }
}
