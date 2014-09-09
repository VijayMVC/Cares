using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Work Place web model
    /// </summary>
    public class WorkLocation
    {
        #region Public
        /// <summary>
        /// Work Location Id
        /// </summary>
        public long WorkLocationId { get; set; }

        /// <summary>
        /// Company Id
        /// </summary>
        public long CompanyId { get; set; }


        /// <summary>
        /// Company name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Work Location Code
        /// </summary>
        public string WorkLocationCode { get; set; }

        /// <summary>
        /// Work Location Name
        /// </summary>
        public string WorkLocationName { get; set; }

        /// <summary>
        /// Work Location Description
        /// </summary>
        public string WorkLocationDescription { get; set; }

        #endregion
        #region Reference Properties

        /// <summary>
        /// Phones this Work Location Has
        /// </summary>
        public virtual List<Phone> Phones { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public virtual Address Address { get; set; }
        #endregion
    }
}