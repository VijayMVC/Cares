using System.Collections;
using System.Collections.Generic;

namespace Cares.WebApp.ViewModel
{
    /// <summary>
    /// Services View Model
    /// </summary>
    public class ServicesViewModel
    {
        /// <summary>
        /// Insurance List
        /// </summary>
        public IEnumerable Insurances { get; set; }

        /// <summary>
        /// Selected Insurance 
        /// </summary>
        public List<long> SubmittedInsurances { get; set; }
    }
}