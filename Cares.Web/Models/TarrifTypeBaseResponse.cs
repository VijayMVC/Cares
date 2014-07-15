
using System.Collections.Generic;

namespace Cares.Web.Models
{
    public class TarrifTypeBaseResponse
    {
        #region Private
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeBaseResponse()
        {
            ResponseCompanies = new List<Company>();
            ResponseMeasurementUnits = new List<MeasurementUnit>();
            ResponseDepartments = new List<Department>();
            ResponseOperations = new List<Operation>();
            ResponseTarrifTypes = new List<TarrifType>();
        }
        #endregion
        #region Protected
        #endregion
        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Company> ResponseCompanies { get; set; }
        /// <summary>
        /// Measurement Unit 
        /// </summary>
        public IEnumerable<MeasurementUnit> ResponseMeasurementUnits { get; set; }
        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<Department> ResponseDepartments { get; set; }
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<Operation> ResponseOperations { get; set; }
        /// <summary>
        /// List of Tarriff Types
        /// </summary>
        public IEnumerable<TarrifType> ResponseTarrifTypes { get; set; }
        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}