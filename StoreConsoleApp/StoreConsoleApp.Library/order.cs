﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Library
{
    class order
    {
        private int orderIdSeed = 000001;
        private string orderId;
        private Dictionary<string, int> customerOrder = new Dictionary<string,  int>();


        public void createOrder(string productId, int productQuantity, string customerId)
        {
            orderId = orderIdSeed.ToString();
            orderIdSeed++;
            customerOrder.Add(productId, productQuantity);

        }
    }
}
