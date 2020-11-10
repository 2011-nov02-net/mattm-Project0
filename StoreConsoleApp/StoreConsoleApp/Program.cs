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
            writer.writeTitle("Store Name TBD");
            writer.writeStatement("Welcome to TBD's digital storefront!");
            writer.writeStatement("Who are you? \n [1] customer \n [2] employee?");
            string userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                writer.writeStatement("Our digital storefront is currently under construction. Please check back soon!");
            }
            else if (userChoice == "2")
            {
                writer.writeStatement("Still under construction, get back to work.");
            }

            else
            {
                writer.writeStatement("You probably shouldn't be here then.");
            }

            Product productA = new Product("TBD3000", 500, 26.50);

        }
    }
}
