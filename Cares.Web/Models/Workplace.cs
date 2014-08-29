using Cares.Models.DomainModels;
using System;
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// workplace web model
    /// </summary>
   
        public class WorkPlace
        {
            #region Persisted Properties

            /// <summary>
            /// Work Place Id
            /// </summary>
            public long WorkPlaceId { get; set; }

            /// <summary>
            /// Work Location Id
            /// </summary>
            public long WorkLocationId { get; set; }

            /// <summary>
            /// Work Place Code
            /// </summary>
            public string WorkPlaceCode { get; set; }

            /// <summary>
            /// Work Place Name
            /// </summary>
            public string WorkPlaceName { get; set; }

            /// <summary>
            /// Work Place Description
            /// </summary>
            public string WorkPlaceDescription { get; set; }

            /// <summary>
            /// Parent Work Place Id
            /// </summary>
            public long? ParentWorkPlaceId { get; set; }

            /// <summary>
            /// Work Place Type Id
            /// </summary>
            public short WorkPlaceTypeId { get; set; }

            /// <summary>
            /// Company Id
            /// </summary>
            public long CompanyId { get; set; }

            /// <summary>
            /// Parent Work Place Id
            /// </summary>
            public string ParentWorkPlaceName { get; set; }

            /// <summary>
            /// Company Name
            /// </summary>
            public string CompanyName { get; set; }

            /// <summary>
            /// Work Place Type Name
            /// </summary>
            public string WorkPlaceTypeName { get; set; }

            /// <summary>
            /// Work Location Name
            /// </summary>
            public string WorkLocationName { get; set; }

            #endregion

        }
}