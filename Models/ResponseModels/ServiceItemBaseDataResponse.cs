using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Service Item Base Data Response Domain Model
    /// </summary>
    public class ServiceItemBaseDataResponse
    {
        #region Public
        /// <summary>
        /// List of Service Type
        /// </summary>
        public IEnumerable<ServiceType> ServiceTypes { get; set; }
        #endregion 
    }
}
