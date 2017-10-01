using Ivysoft.OnlineSystem.Data.Models;
using Ivysoft.OnlineSystem.Data.Models.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace Ivysoft.OnlineSystem.Data
{
    public class OnlineSystemDbContext : IdentityDbContext<Customer>
    {
        public OnlineSystemDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

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

        public static OnlineSystemDbContext Create()
        {
            return new OnlineSystemDbContext();
        }
    }
}
