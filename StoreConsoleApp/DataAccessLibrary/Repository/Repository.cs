using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.IO;
using System.Linq;


namespace DataAccessLibrary.Repository
{
    public class Repository 
    {

        private readonly project0dbContext dbContext;

        public Repository(project0dbContext context)
        {
            dbContext = context;
        }

        public void addCustomer(DataAccessLibrary.Customer customer)
        {
         
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

        }

        public IEnumerable<DataAccessLibrary.Customer> getCustomers()
        {
            var customerList = dbContext.Customers.ToList();

            return customerList.Select(x => new DataAccessLibrary.Customer()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FavoriteStore = x.FavoriteStore
            }).ToList();
               
        }

        public IEnumerable<DataAccessLibrary.Customer> getcustomerByName(Customer searchCustomer)
        {
            var matchList = dbContext.Customers.Where(x => x.FirstName.Contains(searchCustomer.FirstName) && x.LastName.Contains(searchCustomer.LastName)).ToList();

            return matchList;
        }

        public void addProduct(Product newProduct)
        {

        }

        public IEnumerable<DataAccessLibrary.Location> getLocations()
        {
            var locationList = dbContext.Locations.ToList();
            return locationList.Select(x => new DataAccessLibrary.Location()
            {
                Id = x.Id,
                Address = x.Address,
                City = x.City,
                State = x.State,
                Country = x.Country
            }).ToList();
        }

      


    }

    
        
    
}
