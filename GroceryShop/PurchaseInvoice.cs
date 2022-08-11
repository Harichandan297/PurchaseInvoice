using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseCounter;

namespace GroceryShop
{
    public class PurchaseInvoice
    {
        public string? CustomerID;
        public string? FirstName;
        public string? LastName;
        public string? OrderID;
        public short month;
        public short year;
        public bool Membership;
        public Dictionary<string, int[]>? ShoppingList;
        public void PrintPaymentInvoice(string CustomerID)
        {
            CustomerShoppingCart shoppingCart = new CustomerShoppingCart();
            shoppingCart = shoppingCart.GetCustomerShoppingCart(CustomerID);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Purchase Invoice for the order with orderID " + shoppingCart.OrderID);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("------------------Customer ID :"+ CustomerID + "-------------------");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("For the Customer " + shoppingCart.FirstName + " " + shoppingCart.LastName);
            Console.WriteLine("---------------------------------------------------------");
            if (!shoppingCart.Membership)
                Console.WriteLine("Sorry Sir/Madam, You are not eligilble for Membership discount");
            else
            {
                Console.WriteLine("!!!!!YAAAAAY!!!! You are eligible for Membership Savings");
            }
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("--------------------#Your Order#-------------------------");
            Console.WriteLine("---------------------------------------------------------");
            foreach(KeyValuePair<string, int[]> Item in shoppingCart.ShoppingList)
            {
                Console.WriteLine("Item: " + Item.Key + "  Original Price: " + Item.Value[0] + "  Discount Price: " + Item.Value[1]);
            }
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("--------------------" + "Total Price: " + shoppingCart.FinalPrice +"----------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("--------------Thank You for Shopping with us--------------");
        }
    }
}