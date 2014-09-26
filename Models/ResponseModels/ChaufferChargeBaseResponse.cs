using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Chauffer Charge Domain Base Response
    /// </summary>
    public sealed class ChaufferChargeBaseResponse
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ChaufferChargeBaseResponse()
        {
            Companies = new List<Company>();
            Departments = new List<Department>();
            Operations = new List<Operation>();
            TariffTypes = new List<TariffType>();
            DesigGrades = new List<DesignGrade>();
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
        /// Tariff Types
        /// </summary>
        public IEnumerable<TariffType> TariffTypes { get; set; }

        /// <summary>
        /// Design Grade
        /// </summary>
        public IEnumerable<DesignGrade> DesigGrades { get; set; }

        #endregion
    }
}
