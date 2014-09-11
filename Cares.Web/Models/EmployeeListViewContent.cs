namespace Cares.Web.Models
{
    /// <summary>
    /// Employee List View Content
    /// </summary>
    public sealed class EmployeeListViewContent
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Employee Status
        /// </summary>
        public string EmpStatus { get; set; }

        /// <summary>
        /// Company Code Name
        /// </summary>
        public string CompanyCodeName { get; set; }

        /// <summary>
        /// Nationality 
        /// </summary>
        public string Nationality { get; set; }


    }
}