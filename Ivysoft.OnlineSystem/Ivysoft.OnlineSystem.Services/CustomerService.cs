using System.Linq;
using Ivysoft.OnlineSystem.Data.Models;
using Ivysoft.OnlineSystem.Data;
using EntityFramework.DynamicFilters;

namespace Ivysoft.OnlineSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IOnlineSystemDbContext dbContext;

        public CustomerService(IOnlineSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Customer> GetAll()
        {
            return dbContext.All<Customer>();
        }

        public void Update(Customer customer)
        {
            dbContext.Update(customer);
            dbContext.SaveChanges();
        }
    }
}
