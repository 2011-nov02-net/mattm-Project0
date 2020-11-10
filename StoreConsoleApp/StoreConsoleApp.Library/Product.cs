using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Library
{
    public class Product
    {
    private string name;
    private string productID;
    private int currentStock;
    private double price;
    private int idSeed = 00001;

    public Product(string _name, int stock, double _price)
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
