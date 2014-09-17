using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using Cares.Models.DomainModels;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Category Repository
    /// </summary>
    public sealed class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CategoryRepository(IUnityContainer container)
            : base(container)
        {
        }

        #endregion
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Category> DbSet
        {
            get
            {
                return  null;
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return DbSet.ToList();
        }
    }
}
