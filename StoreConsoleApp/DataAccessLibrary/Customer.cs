using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLibrary
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? FavoriteStore { get; set; }

        public virtual Location FavoriteStoreNavigation { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
