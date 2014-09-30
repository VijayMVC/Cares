using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Document Base Data Response web model [dropdown]
    /// </summary>
    public class DocumentBaseDataResponse
    {
       #region Public
        /// <summary>
        /// Document Groups
        /// </summary>
        public IEnumerable<DocumentGroupDropDown> DocumentGroupDropDown { get; set; }
       #endregion
    }
}