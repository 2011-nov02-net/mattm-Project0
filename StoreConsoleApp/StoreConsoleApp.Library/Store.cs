using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Library
{
    public class StoreLocation
    {
        private int storeNumSeed = 00001;
        private string storeNum;
        private string storeCity;
        private string storeState;
        private List<Product> storeProductList;


        public StoreLocation(string city, string state)
        {
            storeNum = storeNumSeed.ToString();
            storeNumSeed++;
            storeProductList = new List<Product>();
        }
        public void addProducts(params Product[] newProducts)
        {
            foreach(Product prod in newProducts)
            {
                storeProductList.Add(prod);
            }
        }

        public string getLocation()
        {
            return storeCity + storeState;
        }


    }
}
