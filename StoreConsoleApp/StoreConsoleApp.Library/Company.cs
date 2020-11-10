using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Store.Library
{
    public class Company
    {
        private string name;
        private List<StoreLocation> storeList;
        private List<Customer> customerList;

        public Company(string _name)
        {
            name = _name;
            storeList = new List<StoreLocation>();
            customerList = new List<Customer>();

            
        }

        public void addStore(StoreLocation store)
        {
            storeList.Add(store);
        }

        public void addCustomer(Customer customer)
        {
            customerList.Add(customer);
        }
        public string getCompanyName()
        {
            return name;
        }
        public ArrayList getStoreList()
        {
            ArrayList returnArr = new ArrayList();
            foreach (StoreLocation store in storeList)
            {
                returnArr.Add(store);  
            }
            return returnArr;
        }
        public List<Customer> getCustomerList()
        {
            List<Customer> returnList = new List<Customer>();
            foreach (Customer customer in customerList)
            {
                returnList.Add(customer);
            }
            return returnList;
        }
    }
}
