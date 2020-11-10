using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Library
{
    class Customer
    {
        private int customerIDSeed = 000001;
        private string firstName;
        private string lastName;
        private string customerID;
        private int phoneNumber;
        private string adress;
        private int favStore;


        public Customer(string first, string last, int phone, string _adress)
        {
            firstName = first;
            lastName = last;
            phoneNumber = phone;
            adress = _adress;
            customerID = customerIDSeed.ToString();
            customerIDSeed++;

        }
        public void addFavStore(int store)
        {
            this.favStore = store;
        }
    }
}
