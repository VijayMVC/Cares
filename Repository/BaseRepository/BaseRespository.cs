using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using Interfaces.Repository;
using Microsoft.Practices.Unity;

namespace Repository.BaseRepository
{
    /// <summary>
    /// Base Repository
    /// </summary>
    public abstract class BaseRepository<TDomainClass> : IBaseRepository<TDomainClass, long>
       where TDomainClass : class
    {
        #region Private

// ReSharper disable once InconsistentNaming
        private readonly IUnityContainer container;
        #endregion
        #region Protected

        /// <summary>that specifies the User's domain on the system
        /// User Domain key 
        /// </summary>
        protected long UserDomaingKey { get { return 1; } }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected abstract IDbSet<TDomainClass> DbSet { get; }

        


        #endregion
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseRepository(IUnityContainer container)
        {

            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            db = new BaseDbContext(connectionString, container);

        }

        #endregion
        #region Public
        /// <summary>
        /// base Db Context
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public BaseDbContext db;

        /// <summary>
        /// Create object instance
        /// </summary>
        public virtual TDomainClass Create()
        {
            TDomainClass result = container.Resolve<TDomainClass>();
            return result;
        }
        /// <summary>
        /// Find entry by key
        /// </summary>
        public virtual IQueryable<TDomainClass> Find(TDomainClass instance)
        {
            return DbSet.Find(instance) as IQueryable<TDomainClass>;
        }
        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public virtual TDomainClass Find(long id)
        {
            return DbSet.Find(id);
        }
        /// <summary>
        /// Get All Entites 
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TDomainClass> GetAll()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Save Changes in the entities
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                List<string> errorMessages = new List<string>();
                foreach (DbEntityValidationResult validationResult in ex.EntityValidationErrors)
                {
                    string entityName = validationResult.Entry.Entity.GetType().Name;
                    foreach (DbValidationError error in validationResult.ValidationErrors)
                    {
                        errorMessages.Add(entityName + "." + error.PropertyName + ": " + error.ErrorMessage);
                    }
                }
                int i = 0;
            }
        }
        /// <summary>
        /// Delete an entry
        /// </summary>
        public virtual void Delete(TDomainClass instance)
        {
            DbSet.Remove(instance);

        }
        /// <summary>
        /// Add an entry
        /// </summary>
        public virtual void Add(TDomainClass instance)
        {
            DbSet.Add(instance);
        }
        /// <summary>
        /// Add an entry
        /// </summary>
        public virtual void Update(TDomainClass instance)
        {
            DbSet.AddOrUpdate(instance);
        }
        /// <summary>
        /// Eager Load Property
        /// </summary>
        public void LoadProperty<T>(object entity, string propertyName, bool isCollection = false)
        {
            db.LoadProperty<T>(entity, propertyName, isCollection);
        }
        /// <summary>
        /// Eager load property
        /// </summary>
        public void LoadProperty<T>(object entity, Expression<Func<T>> propertyExpression, bool isCollection = false)
        {
            db.LoadProperty(entity, propertyExpression, isCollection);
        }
        #endregion
    }
}