using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries
{
    class Customer
    {

        private string firstName;
        private string lastName;
        private int phoneNumber;
        private string adress;
        private int favStore;


        public Customer(string first, string last, int phone, string _adress)
        {
            firstName = first;
            lastName = last;
            phoneNumber = phone;
            adress = _adress;

        }
        public void addFavStore(int store)
        {
            this.favStore = store;
        }
    }
}
