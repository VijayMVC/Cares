using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// web model
    /// </summary>
    public class CreditLimit
    {

        /// <summary>
        /// Credit Limit ID
        /// </summary>
        public long CreditLimitId { get; set; }

        /// <summary>
        ///Credit Limit Code
        /// </summary>
        public bool IsIndividual { get; set; }

        /// <summary>
        ///Credit Limit description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Credit Limit credit limit
        /// </summary>
        public double StandardCreditLimit { get; set; }

        /// <summary>
        /// Bp Rating Type Id
        /// </summary>
        public Int16 BpRatingTypeId { get; set; }

        /// <summary>
        /// Bp Rating Type Name
        /// </summary>
        public string BpRatingTypeName { get; set; }

        /// <summary>
        /// Bp Sub Type Id
        /// </summary>
        public Int16 BpSubTypeId { get; set; }

        /// <summary>
        /// Bp Sub Type Name
        /// </summary>
        public string BpSubTypeName { get; set; }

           
    }
}