using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries
{
    class Item
    {
        private string name;
        private string productID;
        private int currentStock;
        private Decimal price;
        private int idSeed = 00001;

        public Item (string _name, int stock, Decimal _price)
        {
            name = _name;
            currentStock = stock;
            price = _price;
            productID = idSeed.ToString();
            idSeed++;
        }

        public void restock(int quantity)
        {
            this.currentStock += quantity;
        }
    }
}
