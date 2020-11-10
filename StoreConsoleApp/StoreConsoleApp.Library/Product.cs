using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Library
{
    public class Product : IStock
    {
    private string name;
    private string productId;
    private int currentStock;
    private double price;
    private int idSeed = 00001;

    public Product(string _name, int stock, double _price)
    {
        name = _name;
        currentStock = stock;
        price = _price;
        productId = idSeed.ToString();
        idSeed++;
    }
    public string getProductName()
        {
            return name;
        }
        public string getProductId()
        {
            return productId;
        }
        public int getProductStock()
        {
            return currentStock;
        }
        public double getProductPrice()
        {
            return price;
        }

        public void AddStock(int quantity)
        {
            currentStock += quantity;
        }

    }


}
