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
            Company acme = new Company("Acme Co.");           
            Customer activeUser;           
            writer.writeTitle($"{acme.getCompanyName().ToUpper()}");
            writer.writeStatement("Welcome to Acme's digital storefront!");
            writer.writeStatement("Who are you? \n [1] customer \n [2] employee?");
            string userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                writer.writeStatement("Our digital storefront is currently under construction. Please check back soon!");
                writer.writeStatement("Our current offerings!");
                writer.writeStatement("Are you a returning customer? [y]es, [n]o, or E[x]it");
                string newOrExisting = "tbd";
                while (newOrExisting != "y" || newOrExisting != "n")
                {
                    newOrExisting = Console.ReadLine().Trim().ToLower(); ;
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
                        writer.writeStatement("Which of our excellent products catches your eyes ? (Please select the product by ID)");


                    }
                    else if (newOrExisting == "x");
                    else
                    {
                        writer.writeStatement("Please enter 'y'n 'n' or 'x'.");
                    }
                    writer.writeStatement("Have a nice day!");
                    return;
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

           
           

          


        }
    }
}
