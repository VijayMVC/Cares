using System.Data.Entity;
using System.Web.Mvc;
using Interfaces.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Models.IdentityModels;
using Repository.BaseRepository;
using Repository.Repositories;

namespace Repository
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IMenuRightRepository, MenuRightRepository>();
            unityContainer.RegisterType<IProductRepository, ProductRepository>();
            unityContainer.RegisterType<ICategoryRepository, CategoryRepository>();
            unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();
            unityContainer.RegisterType<IDepartmentRepository, DepartmentRepository>();
            unityContainer.RegisterType<DbContext, BaseDbContext>(new HierarchicalLifetimeManager());

            //unityContainer.RegisterType<IUser, ApplicationUser>();
        }
    }
}
