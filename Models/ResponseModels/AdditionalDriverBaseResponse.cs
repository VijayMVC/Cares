using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Additional Driver Domin Base Response
    /// </summary>
    public sealed class AdditionalDriverBaseResponse
    {

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalDriverBaseResponse()
        {
            Companies = new List<Company>();

        }
        #endregion

        #region Public

        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }

        /// <summary>
        /// Departments
        /// </summary>
        public IEnumerable<Department> Departments { get; set; }

        /// <summary>
        /// Operations
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// TariffTypes
        /// </summary>
        public IEnumerable<TariffType> TariffTypes { get; set; }

        #endregion
    }
}
