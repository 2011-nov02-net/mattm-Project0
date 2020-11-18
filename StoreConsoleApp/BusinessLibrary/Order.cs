using System;
using System.Collections.Generic;
using System.Text;



namespace Store.Library
{
    class Order
    {
        private int orderIdSeed = 000001;
        private string orderId;
        private int productId;
        private int quantity;


        public void createOrder(string productId, int productQuantity)
        {
            orderId = orderIdSeed.ToString();
            orderIdSeed++;
            // customerOrder.Add(productId, productQuantity);

        }
        /// <summary>
        /// checks if order quantity is reasonable
        /// </summary>
        /// <param name="order"></param>
        /// <returns> true if quantity is in the correct range</returns>
        public bool validOrder(int quantity)
        {
            if(quantity < 0 || quantity > 100)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
