using System;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    public class Operation
    {
        #region Persisted Properties
            /// <summary>
            /// Operation ID
            /// </summary>
            public int OperationId { get; set; }
            /// <summary>
            /// Operation Code
            /// </summary>
            public string OperationCode { get; set; }
            /// <summary>
            /// Operation Name
            /// </summary>
        [StringLength(255)]
            public string OperationName { get; set; }
        #endregion
    }
}