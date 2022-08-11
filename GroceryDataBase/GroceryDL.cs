using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDataBase
{
    public class GroceryInfo
    {
        public Dictionary<string, int> Getprices()
        {
            return new Dictionary<string, int>
            {
                {"Milk", 30 },
                {"Eggs", 60},
                {"Flour", 120},
                {"Yogurt", 50},
            };
        }
    }
    public class CustomerInfo
    {
        public string? CustomerID;
        public string? OrderID;
        public string? FirstName;
        public string? LastName;
        public bool Membership;

        public CustomerInfo GetCustomerInfo(string CustomerID)
        { 
            CustomerInfo customer = new CustomerInfo();
            customer.CustomerID = CustomerID;
            customer.FirstName = "Hari Chandan";
            customer.LastName = "Sadum";
            customer.OrderID = "M100297";
            customer.Membership = true;
            return customer;
        }

    }
}
