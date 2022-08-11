using GroceryDataBase;

namespace PurchaseCounter
{
    public class GroceryShop
    {
        CustomerInfo customer = new CustomerInfo();
        public Dictionary<string, int[]> GetGroceryPrices()
        {
            GroceryInfo? Grocery = new GroceryInfo();
            Dictionary<string, int[]>? GroceryList = CalculateDiscount(Grocery.Getprices());
            return GroceryList;
        }
        public int GetDiscounts(string Item, int OriginalPrice)
        {
            if (Item == "Milk")
                return OriginalPrice - (OriginalPrice / 10);
            else if (Item == "Yogurt")
                return OriginalPrice - (OriginalPrice / 5);
            return OriginalPrice;
        }
        public int GetFinalPrice(Dictionary<string, int[]> ShoppingCart)
        {
            int price = 0;
            foreach (KeyValuePair<string, int[]> item in ShoppingCart)
            {
                price += item.Value[1];
            }
            int DiscountPrice = price - price / 5;
            if (customer.Membership)
            {
                return DiscountPrice;
            }    
            else
                return price;

        }
        public Dictionary<string, int[]> CalculateDiscount(Dictionary<string, int> ShoppingCart)
        {
            Dictionary<string, int[]>? GroceryDiscounts = new Dictionary<string, int[]>();
            foreach (KeyValuePair<string, int> Item in ShoppingCart)
            {
                int[] PriceList = { Item.Value, GetDiscounts(Item.Key, Item.Value) };
                GroceryDiscounts[Item.Key] = PriceList;
            }
            return GroceryDiscounts;
        }

    }
    public class CustomerShoppingCart
    {
        public string? CustomerID;
        public string? FirstName;
        public string? LastName;
        public bool Membership;
        public string? OrderID;
        public int? FinalPrice;
        public Dictionary<string, int[]>? ShoppingList;

        public CustomerShoppingCart GetCustomerShoppingCart(string CustomerID)
        {
            CustomerInfo? customer = new();
            customer = customer.GetCustomerInfo(CustomerID);

            GroceryInfo? grocery = new();
            var groceryList = grocery.Getprices();

            GroceryShop? GroceryInfo = new();
            var ShoppingList = GroceryInfo.GetGroceryPrices();
            var FinalPrice = GroceryInfo.GetFinalPrice(ShoppingList);

            CustomerShoppingCart? customerShoppingCart = new()
            {
                CustomerID = customer.CustomerID,
                Membership = customer.Membership,
                FinalPrice = FinalPrice,
                ShoppingList = ShoppingList,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                OrderID = customer.OrderID
            };

            return customerShoppingCart;
        }
    }
}