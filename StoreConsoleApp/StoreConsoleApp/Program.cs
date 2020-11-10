using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Store.Library;
using System.Collections.Generic;




namespace Store.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Writer writer = new Writer();
            List<Customer> customerList = new List<Customer>();
            Company acme = new Company("Acme Co.");
            StoreLocation acmeHQ = new StoreLocation("Philadelphia", "PA");
            Customer bob = new Customer("Bob", "Vance");
            Customer mike = new Customer("Michael", "Scott");
            Customer jim = new Customer("Jim", "Halpert");
            Customer pam = new Customer("Pam", "Beasley");
            Customer dwight = new Customer("Dwight", "Schrute");
            Customer phyllis = new Customer("Phyllis", "Lapin");
            Customer creed = new Customer("Creed", "Bratton");
            Customer activeUser;
            acme.addCustomer(bob);
            acme.addCustomer(mike);
            acme.addCustomer(jim);
            acme.addCustomer(pam);
            acme.addCustomer(dwight);
            acme.addCustomer(phyllis);
            acme.addCustomer(creed);
            acme.addStore(acmeHQ);            
            Product productA = new Product("TBD3000", 500, 26.50);
            Product productB = new Product("Acme Anvil", 2, 10000.00);
            Product productC = new Product("Rocket Skates", 100, 50.00);
            acmeHQ.addProducts(productA, productB, productC);
            writer.writeTitle($"{acme.getCompanyName().ToUpper()}");
            writer.writeStatement("Welcome to Acme's digital storefront!");
            writer.writeStatement("Who are you? \n [1] customer \n [2] employee?");
            string userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                writer.writeStatement("Our digital storefront is currently under construction. Please check back soon!");
                writer.writeStatement("Our current offerings!");
                writer.listProducts(acmeHQ);
                writer.writeStatement("Are you a returning customer? y/n");
                string newOrExisting = "tbd";
                while (newOrExisting != "y" || newOrExisting != "n")
                {
                    newOrExisting = Console.ReadLine();
                    if (newOrExisting == "y")
                    {
                        writer.writeStatement("Who are you?");
                        writer.listCustomers(acme);
                        string customerSelection = Console.ReadLine();
                        int customerNumber = Int32.Parse(customerSelection) - 1;
                        activeUser = acme.getCustomerList().ElementAt(customerNumber);
                        writer.writeStatement($"Welcome back {activeUser.getName()}!");

                    }
                    else if (newOrExisting == "n")
                    {
                        writer.writeStatement("Great! Welcome to Acme! Let's get you signed up. What is your first name?");
                        string newFirstName = Console.ReadLine();
                        writer.writeStatement("What is your last name?");
                        string newLastName = Console.ReadLine();
                        Customer newCustomer = new Customer(newFirstName, newLastName);
                        acme.addCustomer(newCustomer);
                        writer.writeStatement("Great, lets get to some shopping!");
                        writer.listProducts(acmeHQ);
                        writer.writeStatement("Which of our excellent products catches your eyes ? (Please select the product by ID)");


                    }
                    else
                    {
                        writer.writeStatement("Please enter 'y' or 'n'.");
                    }
                }
            }
            else if (userChoice == "2")
            {
                writer.writeStatement("Still under construction, get back to work.");
            }

            else
            {
                writer.writeStatement("You probably shouldn't be here then.");
            }

            writer.writeStatement("Have a nice day!");
            return;

          


        }
    }
}
