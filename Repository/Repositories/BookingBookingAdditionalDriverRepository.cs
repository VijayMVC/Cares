using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Cares.Repository.Repositories
{
    public class BookingBookingAdditionalDriverRepository : BaseRepository<BookingAdditionalDriver>, IBookingBookingAdditionalDriverRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BookingBookingAdditionalDriverRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BookingAdditionalDriver> DbSet
        {
            get
            {
                return db.BookingAdditionalDrivers;
            }
        }
        #endregion
    }
}
