using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLibrary
{
    public partial class Product
    {
        public Product()
        {
            LocationStocks = new HashSet<LocationStock>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<LocationStock> LocationStocks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
