﻿using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Tarrif Type Response Web Models
    /// </summary>
    public class TarrifTypeSearchResponse
    { 
        
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeSearchResponse()
        {
            ServerTarrifTypes = new List<TarrifType>();
        }
        #endregion
        
        #region Public
        /// <summary>
        /// Tarrif Types
        /// </summary>
        public IEnumerable<TarrifType> ServerTarrifTypes { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}