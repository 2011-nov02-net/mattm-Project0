using System;
using System.ComponentModel;
using System.Globalization;
using Store.Library;




namespace Store.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Writer writer = new Writer();
            Company acme = new Company("Acme Co.");
            StoreLocation acmeHQ = new StoreLocation("Philadelphia", "PA");
            acme.addStore(acmeHQ);            
            Product productA = new Product("TBD3000", 500, 26.50);
            Product productB = new Product("Acme Anvil", 2, 10000.00);
            Product productC = new Product("Rocket Skates", 100, 50.00);
            acmeHQ.addProducts(productA, productB, productC);
            foreach (StoreLocation store in acme.getStoreList())
            {
                writer.writeStatement(store.getLocation());
            }
            writer.writeTitle($"{acme.getCompanyName().ToUpper()}");
            writer.writeStatement("Welcome to Acme's digital storefront!");
            writer.writeStatement("Who are you? \n [1] customer \n [2] employee?");
            string userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                writer.writeStatement("Our digital storefront is currently under construction. Please check back soon!");
                writer.writeStatement("Our first product!");
                writer.listProducts(productA);
            }
            else if (userChoice == "2")
            {
                writer.writeStatement("Still under construction, get back to work.");
            }

            else
            {
                writer.writeStatement("You probably shouldn't be here then.");
            }

          


        }
    }
}
