using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    public sealed class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository empRepository)
        {
            employeeRepository = empRepository;
        }

        public EmployeeResponse LoadAll(EmployeeSearchRequest searchRequest)
        {
            return employeeRepository.GetAllEmployees(searchRequest);
        }

        public Employee Find(int id)
        {
            return employeeRepository.Find(id);
        }

        public void Delete(Employee product)
        {
            employeeRepository.Delete(product);
            employeeRepository.SaveChanges();
        }

        public bool Add(Employee product)
        {
            if(Validate(product))
            {
                employeeRepository.Add(product);
                employeeRepository.SaveChanges();
                return true;
            }
            return false;
        }

        private bool Validate(Employee x)
        {
            Employee productDbVersion = employeeRepository.GetEmployeeByName(x.Name, x.Id);
            return productDbVersion == null;
        }

        public bool Update(Employee product)
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

            if (Validate(product))
            {
                employeeRepository.Update(product);
                employeeRepository.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Employee> FindByDepartment(int depId)
        {
            return employeeRepository.GetEmployeesByDepartment(depId);
        }
    }
}
