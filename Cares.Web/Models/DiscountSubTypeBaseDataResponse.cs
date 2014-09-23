using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Discount Sub Type Base Data Response WEb model
    /// </summary>
    public class DiscountSubTypeBaseDataResponse
    {
        #region Public
        //Lists of Discount Type
        public IEnumerable<DiscountTypeDropDown> DiscountTypeDropDown { get; set; }
        #endregion
    }
}