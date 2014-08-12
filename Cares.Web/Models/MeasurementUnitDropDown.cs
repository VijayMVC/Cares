using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    public class MeasurementUnitDropDown
    {
       
        /// <summary>
        /// Measurement Unit ID
        /// </summary>
        public int MeasurementUnitId { get; set; }
        /// <summary>
        /// Measurement Unit Code
        /// </summary>
       
        public string MeasurementUnitCodeName { get; set; }
      
    }
}