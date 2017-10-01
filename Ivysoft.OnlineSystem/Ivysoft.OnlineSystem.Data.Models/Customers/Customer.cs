﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ivysoft.OnlineSystem.Data.Models.Abstracts;

namespace Ivysoft.OnlineSystem.Data.Models
{
    public partial class Customer : DataModel
    {
        public Customer()
        {
            CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
            Orders = new HashSet<Order>();
        }

        //[Key]
        [Column("CustomerID")]
        [MaxLength(5)]
        public string CustomerId { get; set; }

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

        [InverseProperty("Customer")]
        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Order> Orders { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
