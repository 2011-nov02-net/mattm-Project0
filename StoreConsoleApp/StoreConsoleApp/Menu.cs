using System;
using System.Collections.Generic;
using System.Text;
using Store.Library;
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
        public static bool loop = true;
        DataAccessLibrary.Customer activeUser = new DataAccessLibrary.Customer();
        Writer menuWriter = new Writer();
        Company acme = new Company("Acme Co.");
        int count = 0;
        public bool displayMenu(Repository repo)
        {
            
            menuWriter.writeTitle($"Acme Co.".ToUpper());
            menuWriter.writeStatement("Welcome to Acme's online ordering system!");
            while (loop)
            {
                // DataAccessLibrary.Customer activeUser;               
                menuWriter.writeStatement("Are you a returning customer? [y]es, [n]o, or E[x]it. [z] to access system administration");
                string input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "y":
                        returningCustomer(repo);  
                        break;
                    case "n":
                        newCustomer(repo);
                        break;
                    case "x":
                        loop = false;
                        break;
                    case "z":
                        manage(repo);
                        break;
                    default:
                        break;
                }


            }
            return false;

        }

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

        public void manage(Repository repo)
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
                        break;

                    case "x":
                        adminLoop = false;
                        break;
                    default:
                        break;

                }

            }

            

        }
    }
}
