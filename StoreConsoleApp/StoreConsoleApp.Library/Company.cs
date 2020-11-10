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

        public Company(string _name)
        {
            name = _name;
            storeList = new List<StoreLocation>();

            
        }

        public void addStore(StoreLocation store)
        {
            storeList.Add(store);
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
    }
}
