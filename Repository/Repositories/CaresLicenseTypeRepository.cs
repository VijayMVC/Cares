using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Cares.Repository.Repositories
{
    public class CaresLicenseTypeRepository : BaseRepository<CaresLicenseType>, ICaresLicenseTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CaresLicenseTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<CaresLicenseType> DbSet
        {
            get
            {
                return db.CaresLicenseTypes;
            }
        }
        #endregion
        #region Public
        
        #endregion

    }
}
