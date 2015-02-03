using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Country Domain Model
    /// </summary>
    public class Country
    {
        #region Persisted Properties
        
        /// <summary>
        /// Country ID
        /// </summary>
        public short CountryId { get; set; }
        
        /// <summary>
        /// Country Code
        /// </summary>
        public string CountryCode { get; set; }
        
        /// <summary>
        /// Country Name
        /// </summary>
        public string CountryName { get; set; }
        
        /// <summary>
        /// Country Description
        /// </summary>
        public string CountryDescription { get; set; }
        
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }
        
        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }
        
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        
        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }
        
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }
        
    

        #endregion

        #region Reference Properties

        /// <summary>
        /// Regions in the country
        /// </summary>
        public virtual ICollection<Region> Regions { get; set; }

        /// <summary>
        /// Addresses
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// Business Partner Individuals
        /// </summary>
        public virtual ICollection<BusinessPartnerIndividual> BusinessPartnerIndividuals { get; set; }

        /// <summary>
        /// Cities in the country
        /// </summary>
        public virtual ICollection<City> Cities { get; set; }

        /// <summary>
        /// Employees
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; } 

        #endregion
    }
}
