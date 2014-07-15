using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    /// <summary>
    /// Department Model
    /// </summary>
    public class Department
    {
        #region Persisted Properties
            /// <summary>
            /// Department ID
            /// </summary>
            public int DepartmentId { get; set; }
            /// <summary>
            /// Department Code
            /// </summary>
        [StringLength(100)]
            public string DepartmentCode { get; set; }
            /// <summary>
            /// Department Code
            /// </summary>
        [StringLength(255)]
            public string DepartmentName { get; set; }
        [StringLength(500)]
        [StringLength(100)]
        [StringLength(100)]

        #endregion
    }
}