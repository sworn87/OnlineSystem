using Ivysoft.OnlineSystem.Data.Models;
using Ivysoft.OnlineSystem.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivysoft.OnlineSystem.Data
{
    public interface IOnlineSystemDbContext
    {
        IDbSet<Customer> Customers { get; }

        int SaveChanges();

        void Add<T>(T entity) where T : class, IDeletable;

        void Delete<T>(T entity) where T : class, IDeletable;

        void Update<T>(T entity) where T : class, IDeletable;

        IQueryable<T> All<T>() where T : class, IDeletable;

        DbContext DbContext { get; }

        //IDbSet<T> Set<T>()
        //    where T : class;
    }
}
