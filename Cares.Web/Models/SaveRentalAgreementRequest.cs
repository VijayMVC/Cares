using Cares.Models.Common;

namespace Cares.Web.Models
{
    /// <summary>
    /// Save Ra Request web model
    /// </summary>
    public class SaveRentalAgreementRequest
    {
        #region Public

        /// <summary>
        /// RaMain
        /// </summary>
        public RaMain RaMain { get; set; }

        /// <summary>
        /// Action To Perform e.g. Open / Close Agreement
        /// </summary>
        private short raStatus;

        /// <summary>
        /// ChaufferC harge By Order
        /// </summary>
        public RaStatusEnum Action
        {
            get
            {
                return (RaStatusEnum)raStatus;
            }
            set
            {
                raStatus = (short)value;
            }
        }

        #endregion
    }
}