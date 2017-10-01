using Ivysoft.OnlineSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivysoft.OnlineSystem.Data
{
    public class OnlineSystemDbContext : IdentityDbContext<Customer>
    {
        public OnlineSystemDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public static OnlineSystemDbContext Create()
        {
            return new OnlineSystemDbContext();
        }
    }
}
