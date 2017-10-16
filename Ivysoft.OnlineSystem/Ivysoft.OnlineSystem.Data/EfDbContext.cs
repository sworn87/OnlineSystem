using Ivysoft.OnlineSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivysoft.OnlineSystem.Data
{
    public class EfDbContext
    {
        private readonly OnlineSystemDbContext dbContext;

        public EfDbContext(OnlineSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Customer> Customers
        {
            get
            {
                return this.dbContext.Set<Customer>();
            }
        }
    }
}
