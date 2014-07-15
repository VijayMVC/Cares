using System;
using Cares.Web.Models;

namespace Cares.Web.Models
{/// <summary>
    /// Operation Model
    /// </summary>
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
            public string OperationName { get; set; }
        #endregion
    }
}