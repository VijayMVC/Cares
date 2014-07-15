using System;

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
            public string DepartmentCode { get; set; }
            /// <summary>
            /// Department Code
            /// </summary>
            public string DepartmentName { get; set; }
        #endregion
    }
}