﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DataAccessLibrary;
using DataAccessLibrary.Repository;


namespace Store.ConsoleApp
{
    public class Menu
    {
        private bool loop = true;
        private bool shoppingLoop = true;
        DataAccessLibrary.Customer activeUser = new DataAccessLibrary.Customer();
        Writer menuWriter = new Writer();
        int count = 0;
        /// <summary> Method to display the original menu </summary>
        /// <params> Takes in a repository object</params>
        public bool displayMenu(Repository repo)
        {

            menuWriter.writeTitle($"Acme Co.".ToUpper());
            menuWriter.writeStatement("Welcome to Acme's online ordering system!");
            //loops until user chooses to exit or takes a path
            while (loop)
            {
                             
                menuWriter.writeStatement("Are you a returning customer? [y]es, [n]o, or E[x]it. [z] to access system administration");
                string input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "y":
                        returningCustomer(repo);
                        loop = false;
                        break;
                    case "n":
                        newCustomer(repo);
                        loop = false;
                        break;
                    case "x":
                        loop = false;
                        break;
                    case "z":
                        manageStore(repo);
                        loop = false;
                        break;
                    default:
                        break;
                }


            }
            return false;

        }
        /// <summary> Method to display shopping related menus </summary>
        /// <params> Takes in a repository object</params>
        public void shoppingMenu(Repository repo)
        {
            //loops until user chooses not to make an order
            while (shoppingLoop)
            {
                menuWriter.writeStatement("Would you like to place an order? y/n");
                string shopChoice = Console.ReadLine().Trim().ToLower();
                if(shopChoice == "y")
                {
                    newOrder(repo);
                }
                else
                {
                    menuWriter.writeStatement("Thanks for visiting Acme Online, please come again soon!");
                    shoppingLoop = false;
                }
            }
        }
    


    




        /// <summary> Method to check if a customer exists in the DB and sets them to the active user </summary>
        /// <params> Takes in a repository object</params>
        public void returningCustomer(Repository repo)
        {
            menuWriter.writeStatement("What is your name? (No Middle)");
            string userName = Console.ReadLine().Trim();
            string[] customerSearchName = userName.Split(" ");
            DataAccessLibrary.Customer searchCustomer = new DataAccessLibrary.Customer();
            searchCustomer.FirstName = customerSearchName[0];
            searchCustomer.LastName = customerSearchName[1];
            activeUser = repo.getcustomerByName(searchCustomer).FirstOrDefault();
            if (activeUser != null)
            {
                menuWriter.writeStatement($"Welcome back {activeUser.FirstName} {activeUser.LastName}!");
            }
            else
            {
                menuWriter.writeStatement("I'm sorry, we couldn't find your information.");
            }
        }

        /// <summary> Method to add a new User to the DB </summary>
        /// <params> Takes in a repository object</params>
        public void newCustomer(Repository repo)
        {
            menuWriter.writeStatement("Great! Welcome to Acme! Let's get you signed up. What is your first name?");
            string newFirstName = Console.ReadLine();
            menuWriter.writeStatement("What is your last name?");
            string newLastName = Console.ReadLine();
            DataAccessLibrary.Customer newCustomer = new DataAccessLibrary.Customer();
            newCustomer.FirstName = newFirstName;
            newCustomer.LastName = newLastName;
            repo.addCustomer(newCustomer);
            activeUser = repo.getcustomerByName(newCustomer).FirstOrDefault();
            menuWriter.writeStatement($"You have been sucesffuly added, {activeUser.FirstName} {activeUser.LastName}");

        }

        /// <summary> Method providing admin functionality for stores, checking customers, orders, etc </summary>
        /// <params> Takes in a repository object</params>
        public void manageStore(Repository repo)
        {
            bool adminLoop = true;
            while (adminLoop)
            {
                menuWriter.writeStatement("\nWhat would you like to do?");
                menuWriter.writeStatement("[1] View Customers \n[2] View Locations \n[3] View Order History by Customer \n[4] View Order History by Location \nE[x]it");
                string adminInput = Console.ReadLine().Trim().ToLower();
                switch (adminInput)
                {
                    case "1":
                        IEnumerable<DataAccessLibrary.Customer> customerList = repo.getCustomers();
                        count = 0;
                        foreach (var x in customerList)
                        {
                            menuWriter.writeStatement($"{count}. {x.FirstName} {x.LastName}");
                            count++;
                        }
                        break;
                    case "2":
                        IEnumerable<DataAccessLibrary.Location> locationList = repo.getLocations();
                        count = 0;
                        foreach (var x in locationList)
                        {
                            menuWriter.writeStatement($"{count}. Acme {x.City}: {x.Address}, {x.City}, {x.State}, {x.Country}");
                            count++;
                        }
                        break;
                    case "3":
                        var ordersByCustomer = repo.getOrdersByCustomers();
                        count = 0;
                        menuWriter.writeStatement("Customer ID   Total Orders");
                        foreach (var x in ordersByCustomer)
                        {
                            Console.WriteLine($"{x.CustomerId}            {x.orders}" );
                        }
                        break;
                    case "4":
                        IEnumerable<DataAccessLibrary.Order> ordersByLocation = repo.getOrdersByLocations();
                        var ordersgrouped = ordersByLocation.GroupBy(order => order.LocationId);
                        menuWriter.writeStatement("Location ID   Total Orders");
                        foreach (var x in ordersgrouped)
                        {
                            menuWriter.writeStatement($"{x.Key} {x.Count()} ");
                            
                        }
                        break;
                    case "x":
                        adminLoop = false;
                        break;
                    default:
                        break;

                }

            }

            

        }

        /// <summary> Method to create a new order in the DB and populate it and related tables </summary>
        /// <params> Takes in a repository object</params>
        public void newOrder(Repository repo)
        {
            bool morePurchases = true;
            int orderID = repo.createOrder(activeUser);
            menuWriter.writeStatement("What store would you like to order from?");
            // lists current locations and displays to user
            IEnumerable<DataAccessLibrary.Location> locationList = repo.getLocations();
            count = 0;
            foreach (var x in locationList)
            {
                count++;
                menuWriter.writeStatement($"[{count}] Acme {x.City}: {x.Address}, {x.City}, {x.State}, {x.Country}");
                
            }
            // takes user input as the current location, checks if user would like to add that store as their default (default store not fully implemented yet)
            int storeChoice = Int32.Parse(Console.ReadLine().Trim());
            DataAccessLibrary.Location chosenLocation = locationList.ElementAt<Location>(storeChoice);
            menuWriter.writeStatement("Would you like to make this store your default? y/n");
            string newDefault = Console.ReadLine().Trim().ToLower();
            if(newDefault == "y")
            {
                repo.setFavoriteStore(activeUser, chosenLocation);

            }
            // loops through purchasing path as user adds more products to order
            while (morePurchases)
            {
                menuWriter.writeStatement("What product would you like to buy?");
                IEnumerable<DataAccessLibrary.Product> productList = repo.getProducts();
                count = 0;
                foreach (var x in productList)
                {
                    count++;
                    menuWriter.writeStatement($"[{count}] {x.Name}: ${x.Price}");

                }
                int productChoice = Int32.Parse(Console.ReadLine().Trim());
                Order newOrder = new Order();
                newOrder.ProductId = productList.ElementAt<DataAccessLibrary.Product>(productChoice).Id;
                menuWriter.writeStatement("How many would you like?");
                int purchaseQuantity = Int32.Parse(Console.ReadLine());
                newOrder.Quantity = purchaseQuantity;
                //boolean returns false is quantity too low
                bool orderPlaced = repo.addProductToOrder(orderID, newOrder, chosenLocation);
                //checks if an order was sucessfully placed
                if (!orderPlaced)
                {
                    menuWriter.writeStatement("We're sorry but the product and quantity you requested is not in stock.");
                }
                menuWriter.writeStatement("Would you like to buy anything else? y/n");
                string buyMore = Console.ReadLine().Trim().ToLower();
                if(buyMore == "n")
                {
                    morePurchases = false;
                }

            }




        }
    }

    
}
