using Implementation.Identity;
using Implementation.Services;
using Interfaces.IServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Models.IdentityModels;
using Repository.Repositories;

namespace Implementation
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            UnityConfig.UnityContainer = unityContainer;
            Repository.TypeRegistrations.RegisterType(unityContainer);
            unityContainer.RegisterType<IMenuRightsService, MenuRightsService>();
            unityContainer.RegisterType<IProductService, ProductService>();
            unityContainer.RegisterType<ICategoryService, CategoryService>();
            unityContainer.RegisterType<ILogger, LoggerService>();
            unityContainer.RegisterType<IEmployeeService, EmployeeService>();
            unityContainer.RegisterType<IDepartmentService, DepartmentService>();
            unityContainer.RegisterType<ITarrifTypeService, TarrifTypeService>();
            unityContainer.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
 	    

        }
    }
}
