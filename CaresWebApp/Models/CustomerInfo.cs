using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.WebApp.Models
{
    /// <summary>
    /// Customer Info
    /// </summary>
    public class CustomerInfo
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LName { get; set; }

        /// <summary>
        /// NIC Nymber
        /// </summary>
        public string NICNo { get; set; }

        /// <summary>
        /// NIC Expiry Date
        /// </summary>
        public DateTime NICExpDt { get; set; }

        /// <summary>
        /// Passport Number
        /// </summary>
        public string PassportNo { get; set; }

        /// <summary>
        /// Passport Expiry Date
        /// </summary>
        public DateTime PassportExpDt { get; set; }

        /// <summary>
        /// License Number
        /// </summary>
        public string LicenseNo { get; set; }

        /// <summary>
        /// License Expiry Date
        /// </summary>
        public DateTime LicenseExpDt { get; set; }

        /// <summary>
        /// DOB
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        /// Sponser
        /// </summary>
        public string Sponser { get; set; }

        /// <summary>
        /// Phone Numer
        /// </summary>
        public string PhoneNumer { get; set; }

        /// <summary>
        /// Mobile Numer
        /// </summary>
        public string MobileNumer { get; set; }

        /// <summary>
        /// Email 
        /// </summary>
        [EmailAddress(ErrorMessage = "Bad email")]
        public string Email { get; set; }

    }
}