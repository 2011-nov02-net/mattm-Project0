using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLibrary
{
    public partial class Location
    {
        public Location()
        {
            Customers = new HashSet<Customer>();
            LocationStocks = new HashSet<LocationStock>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<LocationStock> LocationStocks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
