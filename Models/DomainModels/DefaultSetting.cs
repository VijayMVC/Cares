namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Default Setting Domain Model
    /// </summary>
    public class DefaultSetting
    {
        #region Persisted Properties
        
        /// <summary>
        /// Default Setting ID
        /// </summary>
        public long DefaultSettingId { get; set; }
        
        /// <summary>
        /// Employee Id
        /// </summary>
        public long EmployeeId { get; set; }
        
        /// <summary>
        /// Default Operation Id
        /// </summary>
        public long? DefaultOperationId { get; set; }

        /// <summary>
        /// Default OperationWorkplaceId
        /// </summary>
        public long? DefaultOperationWorkplaceId { get; set; }

        /// <summary>
        /// Default PaymentTerm Id
        /// </summary>
        public long? DefaultPaymentTermId { get; set; }

        #endregion
    }
}
