using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Rental Agreement Repository
    /// </summary>
    public sealed class RentalAgreementRepository : BaseRepository<RaMain>, IRentalAgreementRepository
    {
        #region Private
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<RaMain> DbSet
        {
            get
            {
                return db.RaMains;
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Load Dependencies
        /// </summary>
        public void LoadDependencies(RaMain raMain)
        {
            LoadProperty(raMain, () => raMain.RaHireGroups, true);
            LoadProperty(raMain, () => raMain.RaServiceItems, true);
            LoadProperty(raMain, () => raMain.RaAdditionalCharges, true);
            LoadProperty(raMain, () => raMain.RaDrivers, true);
            LoadProperty(raMain, () => raMain.RaPayments, true);
            LoadProperty(raMain, () => raMain.RaCustomerDocuments, true);
            LoadProperty(raMain, () => raMain.BusinessPartner);
        }

        #endregion
    }
}
