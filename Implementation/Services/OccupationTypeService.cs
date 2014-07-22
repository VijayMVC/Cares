using System.Collections.Generic;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;

namespace Implementation.Services
{
    /// <summary>
    /// Occupation Type Service
    /// </summary>
    public class OccupationTypeService : IOccupationTypeService
    {
        #region Private
        private readonly IOccupationTypeRepository occupationTypeRepository;
        #endregion
        #region Constructor
        public OccupationTypeService(IOccupationTypeRepository occupationTypeRepository)
        {
            this.occupationTypeRepository = occupationTypeRepository;
        }
        #endregion
        #region Public
        public IEnumerable<OccupationType> LoadAll()
        {
            return occupationTypeRepository.GetAll();
        }
        #endregion
    }
}
