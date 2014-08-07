using System;
using System.Collections.Generic;
using System.Globalization;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Models.DomainModels;

namespace Cares.Implementation.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;

        }

        public ProductResponse LoadAllProducts(ProductSearchRequest productSearchRequest)
        {

            return productRepository.GetAllProducts(productSearchRequest);
        }

        public Product FindProduct(int id)
        {
            return productRepository.Find(id);
        }

        public void DeleteProduct(Product product)
        {
            Product productDbVersion = FindProduct(product.Id);
            if (productDbVersion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Product with Id {0} not found!", product.Id));
            }

            productRepository.Delete(productDbVersion);
            productRepository.SaveChanges();
        }

        public bool AddProduct(Product product)
        {
            if(ValidateProduct(product))
            {
                productRepository.Add(product);
                productRepository.SaveChanges();
                return true;
            }
            return false;
        }

        private bool ValidateProduct(Product product)
        {
            Product productDbVersion = productRepository.GetProductByName(product.Name, product.Id);
            return productDbVersion == null;
        }

        public bool Update(Product product)
        {

            //Product productDbVersion =  productRepository.Find(product.Id);

            //if (productDbVersion != null)
            //{
            //    //productDbVersion.Category =
            //    //    categoryRepository.GetAllCategories().Where(x => x.Id == product.CategoryId).FirstOrDefault();
            //    using (TransactionScope transaction = new TransactionScope())
            //    {
            //        productDbVersion.Category.Name = "KHurram U" + DateTime.Now.Minute;
            //        productDbVersion.Name = product.Name;

            //        //Thread.Sleep(20*1000);
            //        productRepository.SaveChanges();
            //        throw new Exception();

            //        transaction.Complete();

            //    }
            //}

            if (ValidateProduct(product))
            {
                productRepository.Update(product);
                productRepository.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Product> FindProductsByCategory(int catId)
        {
            return productRepository.GetProductsByCategory(catId);
        }
    }
}
