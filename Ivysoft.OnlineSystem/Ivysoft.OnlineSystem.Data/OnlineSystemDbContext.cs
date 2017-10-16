using EntityFramework.DynamicFilters;
using Ivysoft.OnlineSystem.Data.Models;
using Ivysoft.OnlineSystem.Data.Models.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Ivysoft.OnlineSystem.Data
{
    public class OnlineSystemDbContext : IdentityDbContext<User> , IOnlineSystemDbContext
    {
        public OnlineSystemDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Customer> Customers
        {
            get
            {
                return this.Set<Customer>();
            }
        }

        public DbContext DbContext => this;

    //    public new IDbSet<T> Set<T>()
    //where T : class
    //    {
    //        return base.Set<T>();
    //    }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }


        //public IQueryable<T> All<T>() where T : class, IDeletable
        //{
        //    return this.Set<T>().Where(s => !s.IsDeleted);
        //}

        public void Add<T>(T entity) where T : class, IDeletable
        {
            DbEntityEntry entry = this.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.Set<T>().Add(entity);
            }
        }

        public void Delete<T>(T entity) where T : class, IDeletable
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            var entry = this.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Update<T>(T entity) where T : class, IDeletable
        {
            DbEntityEntry entry = this.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public static OnlineSystemDbContext Create()
        {
            return new OnlineSystemDbContext();
        }

        //modelBuilder.Filter("IsDeleted", (ISoftDelete d) => d.IsDeleted, false);

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //        dbContext.DbContext.DisableFilter("IsDeleted");
            modelBuilder.Filter("IsDeleted", (IDeletable d) => d.IsDeleted, false);
        }
            //public static OnlineSystemDbContext Create()
            //{
            //    return new OnlineSystemDbContext();
            //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<CustomerCustomerDemo>().HasKey(entity =>
        //    //{
        //    //    entity.HasKey(e => new { e.CustomerId, e.CustomerTypeId })
        //    //        .HasName("PK_CustomerCustomerDemo");

        //    //    entity.HasIndex(e => e.CustomerTypeId)
        //    //        .HasName("IX_CustomerCustomerDemo_CustomerTypeID");
        //    //});

        //    //modelBuilder.Entity<EmployeeTerritory>(entity =>
        //    //{
        //    //    entity.HasKey(e => new { e.EmployeeId, e.TerritoryId })
        //    //        .HasName("PK_EmployeeTerritories");

        //    //    entity.HasIndex(e => e.TerritoryId)
        //    //        .HasName("IX_EmployeeTerritories_TerritoryID");
        //    //});

        //    //modelBuilder.Entity<Employee>(entity =>
        //    //{
        //    //    entity.HasIndex(e => e.ReportsTo)
        //    //        .HasName("IX_Employees_ReportsTo");
        //    //});

        //    //modelBuilder.Entity<OrderDetail>(entity =>
        //    //{
        //    //    entity.HasKey(e => new { e.OrderId, e.ProductId })
        //    //        .HasName("PK_Order_Details");

        //    //    entity.HasIndex(e => e.ProductId)
        //    //        .HasName("IX_Order Details_ProductID");

        //    //    entity.Property(e => e.Discount).HasDefaultValueSql("0");

        //    //    entity.Property(e => e.Quantity).HasDefaultValueSql("1");

        //    //    entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");
        //    //});

        //    //modelBuilder.Entity<Order>(entity =>
        //    //{
        //    //    entity.HasIndex(e => e.CustomerId)
        //    //        .HasName("IX_Orders_CustomerID");

        //    //    entity.HasIndex(e => e.EmployeeId)
        //    //        .HasName("IX_Orders_EmployeeID");

        //    //    entity.HasIndex(e => e.ShipVia)
        //    //        .HasName("IX_Orders_ShipVia");

        //    //    entity.Property(e => e.Freight).HasDefaultValueSql("0");
        //    //});

        //    //modelBuilder.Entity<Product>(entity =>
        //    //{
        //    //    entity.HasIndex(e => e.CategoryId)
        //    //        .HasName("IX_Products_CategoryID");

        //    //    entity.HasIndex(e => e.SupplierId)
        //    //        .HasName("IX_Products_SupplierID");

        //    //    entity.Property(e => e.Discontinued).HasDefaultValueSql("0");

        //    //    entity.Property(e => e.ReorderLevel).HasDefaultValueSql("0");

        //    //    entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");

        //    //    entity.Property(e => e.UnitsInStock).HasDefaultValueSql("0");

        //    //    entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("0");
        //    //});

        //    //modelBuilder.Entity<Region>(entity =>
        //    //{
        //    //    entity.Property(e => e.RegionId).ValueGeneratedNever();
        //    //});

        //    //modelBuilder.Entity<Territory>(entity =>
        //    //{
        //    //    entity.HasIndex(e => e.RegionId)
        //    //        .HasName("IX_Territories_RegionID");
        //    //});


        //}

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
