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

        public IEnumerable<DataAccessLibrary.Product> getProducts()
        {
            var productList = dbContext.Products.ToList();
            return productList.Select(x => new DataAccessLibrary.Product()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToList();
        }

        public void setFavoriteStore(Customer customer, Location location)
        {
            var query = dbContext.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
            query.FavoriteStore = location.Id;
            dbContext.SaveChanges();
        }

        public int createOrder(Customer customer)
        {
            CustomerOrder newCustomerOrder = new CustomerOrder();
            newCustomerOrder.CustomerId = customer.Id;
            dbContext.CustomerOrders.Add(newCustomerOrder);
            dbContext.SaveChanges();
            int newestOrder = dbContext.CustomerOrders.Max(x => x.Id);
            return newestOrder;
        }

        public void addProductToOrder(int orderId, Order order, Location location)
        {
            Order newOrder = new Order();
            newOrder.OrderId = orderId;
            newOrder.LocationId = location.Id;
            newOrder.ProductId = order.ProductId;
            newOrder.Quantity = order.Quantity;
            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();

        }

        public class ordersByCustomers
        {
            public int CustomerId { get; set; }
            public int orders { get; set; }

        }
        public IQueryable<ordersByCustomers> getOrdersByCustomers()
        {
            var orders = dbContext.CustomerOrders.GroupBy(x => x.CustomerId).Select(x => new ordersByCustomers{ CustomerId = x.Key, orders = x.Count() });
            return orders;

        }

        public IEnumerable<DataAccessLibrary.Order> getOrdersByLocations()
        {
            var orders = dbContext.Orders.ToList();
            return orders;

        }






    }

    
        
    
}
