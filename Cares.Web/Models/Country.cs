using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Country Model
    /// </summary>
    public class Country
    {
        #region Persisted Properties
            /// <summary>
            /// Country ID
            /// </summary>
            public int CountryId { get; set; }
            /// <summary>
            /// Country Code
            /// </summary>
            public string CountryCode { get; set; }
            /// <summary>
            /// Country Name
            /// </summary>
            public string CountryName { get; set; }
        #endregion
    }
}