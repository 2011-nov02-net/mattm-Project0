using System;
using Figgle;
using System.Collections.Generic;
using System.Text;
using Store.Library;

namespace Store.ConsoleApp
{
    class Writer
    {

        public void writeStatement(string message)
        {
            Console.WriteLine(message);
        }

        public void writeTitle(string title)
        {
            Console.WriteLine(FiggleFonts.Standard.Render(title));
        }

        public void listProducts(StoreLocation store)
        {
            foreach (Product prod in store.getProductList())
            {
                Console.WriteLine($"Product:{prod.getProductName()}  ID:{prod.getProductId()} Stock:{prod.getProductStock()} Price:{prod.getProductPrice()} \n");
            }
            
        }

        //public void listCustomers(Company company) 
        //{
        //    int i = 1;
        //    foreach (Customer customer in company.getCustomerList())
        //    {
        //        Console.WriteLine($"{i}. {customer.getName()}");
        //        i++;
        //    }
        //}
    }
}
