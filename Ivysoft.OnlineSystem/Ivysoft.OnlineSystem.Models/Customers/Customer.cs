using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ivysoft.OnlineSystem.Models
{
    public partial class Customer  : IdentityUser
    {
        public Customer()
        {
            //CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
            Orders = new HashSet<Order>();
        }

        //[Column("CustomerID")]
        //[MaxLength(5)]
        //public string CustomerId { get; set; }

        [MaxLength(60)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string City { get; set; }

        //[Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }

        [MaxLength(30)]
        public string ContactName { get; set; }

        [MaxLength(30)]
        public string ContactTitle { get; set; }

        [MaxLength(15)]
        public string Country { get; set; }

        [MaxLength(24)]
        public string Fax { get; set; }

        [MaxLength(24)]
        public string Phone { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(15)]
        public string Region { get; set; }

        //[InverseProperty("Customer")]
        //public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Order> Orders { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Customer> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
