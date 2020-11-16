using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLibrary
{
    public partial class CustomerOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
