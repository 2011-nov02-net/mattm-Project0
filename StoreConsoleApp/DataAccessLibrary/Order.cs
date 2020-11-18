using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLibrary
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }

        public virtual Location Location { get; set; }
        public virtual CustomerOrder OrderNavigation { get; set; }
        public virtual Product Product { get; set; }
    }
}
