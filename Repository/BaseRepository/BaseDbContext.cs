using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Models.IdentityModels;
using Models.LoggerModels;
using Models.MenuModels;

namespace Repository.BaseRepository
{
    /// <summary>
    /// Base Db Context. Implements Identity Db Context over Application User
    /// </summary>
    public sealed class BaseDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Private
        private IUnityContainer container;
        #endregion
        #region Protected
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
        #endregion
        #region Constructor
        public BaseDbContext()
        {            
        }
        #endregion
        #region Public

        public BaseDbContext(string connectionString,IUnityContainer container)
            : base(connectionString)
        {
            this.container = container;
        }
        #region Logger

        /// <summary>
        /// Logs
        /// </summary>
        public DbSet<Log> Logs { get; set; }
        /// <summary>
        /// Log Categories
        /// </summary>
        public DbSet<LogCategory> LogCategories { get; set; }
        /// <summary>
        /// Category Logs
        /// </summary>
        public DbSet<CategoryLog> CategoryLogs { get; set; }
        #endregion
        #region Menu Rights and Security
        /// <summary>
        /// Menu Rights
        /// </summary>
        public DbSet<MenuRight> MenuRights { get; set; }
        /// <summary>
        /// Menu
        /// </summary>
        public DbSet<Menu> Menus { get; set; }
        #endregion
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Department> Departments { get; set; }
        public DbSet<TarrifType> TarrifTypes { get; set; }

        #endregion
    }
}
