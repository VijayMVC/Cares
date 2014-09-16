using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Work Location service 
    /// </summary>
    public class PhoneService : IPhoneService
    {
        #region Private
        private readonly IPhoneRepository phoneRepository;

        #endregion
        #region Constructor
        public PhoneService(IPhoneRepository phoneRepository)
        {
            this.phoneRepository = phoneRepository;
        }

        #endregion
        #region Public 

        /// <summary>
        /// Get Phones By Worklocation ID
        /// </summary>
        public PhonesSearchByWorkLocationIdResponse GetPhonesByWorklocationId(long workLocationId)
        {
            return new PhonesSearchByWorkLocationIdResponse
            {
                PhonesAssociatedWithWorkLocation = phoneRepository.GetPhonesByWorkLocationId(workLocationId)
            };
        }
        #endregion
    }
}
