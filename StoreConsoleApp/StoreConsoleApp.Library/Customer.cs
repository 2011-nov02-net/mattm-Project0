using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Library
{
    public class Customer
    {
        private int customerIDSeed = 000001;
        private string firstName;
        private string lastName;
        private string customerID;
        private int phoneNumber;
        private string adress;
        private int favStore;


        public Customer(string first, string last)
        {
            firstName = first;
            lastName = last;
            // phoneNumber = phone;
            // adress = _adress;
            customerID = customerIDSeed.ToString();
            customerIDSeed++;

        }
        public void addFavStore(int store)
        {
            this.favStore = store;
        }

        public string getName()
        {
            return ($"{firstName} {lastName}");
        }
    }
}
