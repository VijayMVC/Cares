namespace Cares.Web.Models
{
    /// <summary>
    /// Occupation Type Web Api Model
    /// </summary>
    public class OccupationType
    {
        #region Public Properties
        /// <summary>
        /// Occupation Type ID
        /// </summary>
        public int OccupationTypeId { get; set; }
        /// <summary>
        /// Occupation Code
        /// </summary>
        public string OccupationTypeCode { get; set; }
        /// <summary>
        /// Occupation Name
        /// </summary>        
        public string OccupationTypeName { get; set; }


        #endregion
    }
}