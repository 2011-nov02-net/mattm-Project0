using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLibrary
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
