using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Cares.Repository.Repositories
{
    public class BookingInsuranceRepository : BaseRepository<BookingIsurance>, IBookingInsuranceRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BookingInsuranceRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BookingIsurance> DbSet
        {
            get
            {
                return db.BookingIsurances;
            }
        }
        #endregion
    }
}
