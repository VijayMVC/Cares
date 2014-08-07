using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using Models.DomainModels;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Product Repository
    /// </summary>
    public sealed class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        #region Private
        /// <summary>
        /// Order by Column Names Dictionary statements - for Product
        /// </summary>
        private readonly Dictionary<ProductByColumn, Func<Product, object>> productClause =
              new Dictionary<ProductByColumn, Func<Product, object>>
                    {
                        { ProductByColumn.Name, c => c.Name },
                        { ProductByColumn.Description, c => c.Description },
                        { ProductByColumn.Price, c => c.Price },
                         { ProductByColumn.CategoryName, c => c.Category.Name }
                    };
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Product> DbSet
        {
            get
            {
                return db.Products;
            }
        }
        #endregion
        public ProductResponse GetAllProducts(ProductSearchRequest productSearchRequest)
        {
            int fromRow = (productSearchRequest.PageNo - 1) * productSearchRequest.PageSize;
            int toRow = productSearchRequest.PageSize;

            //Expression<Func<Product, bool>> query = 
            //    s => (!productSearchRequest.CategoryId.HasValue || s.CategoryId == productSearchRequest.CategoryId) &&
            //         (string.IsNullOrEmpty(productSearchRequest.SearchString) ||s.Name.Contains(productSearchRequest.SearchString));

            //IEnumerable<Product> products = productSearchRequest.IsAsc ? DbSet.Where(query).Include("Category")
            //                                .OrderBy(productClause[productSearchRequest.ProductOrderBy]).Skip(fromRow).Take(toRow).ToList()
            //                                : DbSet.Where(query).Include("Category")
            //                                    .OrderByDescending(productClause[productSearchRequest.ProductOrderBy]).Skip(fromRow).Take(toRow).ToList();

            //return new ProductResponse { Products = products, TotalCount = DbSet.Count(query) };
            return new ProductResponse { Products = null, TotalCount =10};
        }

        public Product GetProductByName(string name, int id)
        {
            return DbSet.FirstOrDefault(product => product.Name == name && product.Id != id);
        }

        public IQueryable<Product> GetProductsByCategory(int catId)
        {
            return DbSet.Where(x => x.CategoryId == catId).AsQueryable();
        }
    }
}
