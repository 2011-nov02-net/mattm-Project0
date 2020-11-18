using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.IO;
using System.Linq;
//using BusinessLogicLibrary;


namespace DataAccessLibrary.Repository
{
    public class Repository
    {

        private readonly project0dbContext dbContext;

        public Repository(project0dbContext context)
        {
            dbContext = context;
        }

        /// <summary> Method to add a new customer to the DB </summary>
        /// <params> Takes in a customer object</params>
        public void addCustomer(DataAccessLibrary.Customer customer)
        {

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

        }
        /// <summary> Method to return a list of current Customers</summary>
   
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
        /// <summary> Method to find a customer by name </summary>
        /// <params> Takes in a customer object of the customer to be searched on</params>
        public IEnumerable<DataAccessLibrary.Customer> getcustomerByName(Customer searchCustomer)
        {
            var matchList = dbContext.Customers.Where(x => x.FirstName.Contains(searchCustomer.FirstName) && x.LastName.Contains(searchCustomer.LastName)).ToList();

            return matchList;
        }

        public void addProduct(Product newProduct)        
        {
            throw new NotImplementedException("Not Implemented");
             
        }
        /// <summary> Method to return a list of current locations </summary>
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
        /// <summary> Method to return a list of current products </summary>
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
        /// <summary> Method to set a customer's favorite store </summary>
        /// <params> Takes in a customer object of the customer to be updated and the location to be set to Favorite</params>
        public void setFavoriteStore(Customer customer, Location location)
        {
            var query = dbContext.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
            query.FavoriteStore = location.Id;
            dbContext.SaveChanges();
        }
        /// <summary> Method to create a new order </summary>
        /// <params> Takes in a customer object of the customer making the order</params>
        public int createOrder(Customer customer)
        {
            CustomerOrder newCustomerOrder = new CustomerOrder();
            newCustomerOrder.CustomerId = customer.Id;
            dbContext.CustomerOrders.Add(newCustomerOrder);
            dbContext.SaveChanges();
            int newestOrder = dbContext.CustomerOrders.Max(x => x.Id);
            return newestOrder;
        }
        /// <summary> Method to add a product and quantity to the order </summary>
        /// <params> Takes in a customer object of the customer to be searched on</params>
        public bool addProductToOrder(int orderId, Order order, Location location)
        {
            //checks if the required product has sufficient stock
            bool inStock = checkInStock(order.ProductId, location.Id, order.Quantity);

            // if in stock, order is updated and stock is reduced
            if (inStock)
            {
                updateStock(order.ProductId, location.Id, order.Quantity);
                Order newOrder = new Order();
                newOrder.OrderId = orderId;
                newOrder.LocationId = location.Id;
                newOrder.ProductId = order.ProductId;
                newOrder.Quantity = order.Quantity;
                dbContext.Orders.Add(newOrder);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        
            

        }

  

  

  

        public List<DataAccessLibrary.CustomerOrder> getOrdersByCustomer(Customer customer)
        {
            var orderList = dbContext.CustomerOrders.Where(x => x.CustomerId == customer.Id).ToList();
            return orderList;
        }

        /// <summary> Method to return a list of orders </summary>

        public List<DataAccessLibrary.Order> getOrdersByLocation(Location location)
        {
            var orders = dbContext.Orders.ToList();
            return orders;

        }
        /// <summary> Method to check a products stock against order requirement, returns true/false </summary>
        /// <params> takes in thr required product id, the location id, and the quantity sought</params>
        public bool checkInStock(int productId, int locationId, int Quantity)
        {
            int stockCheck = dbContext.LocationStocks.Where(x => x.ProductId == productId && x.LocationId == locationId).ToList().First().Quantity;
            if(stockCheck >= Quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void updateStock(int productId, int locationId, int Quantity)
        {
           dbContext.LocationStocks.Where(x => x.ProductId == productId && x.LocationId == locationId).First().Quantity -= Quantity;
            dbContext.SaveChanges();

        }
        public List<Order> getOrderDetails(int orderId)
        {
            var details = dbContext.Orders.Where(x => x.OrderId == orderId).ToList();
            return details;

        }






    }

    
        
    
}
