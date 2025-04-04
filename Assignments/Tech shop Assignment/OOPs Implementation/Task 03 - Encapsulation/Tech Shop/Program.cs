using System;
using System.Text.RegularExpressions;

namespace Tech_Shop
{
    public class Techshop_class
    {



        public static void Main(string[] args)
        {

            Console.WriteLine("Initialized TechShop!");
            Customers cust = null;
            Products phone = null;
            Orders order = null;
            OrderDetails detail = null;

            try
            {
                cust = new Customers(101, "Dinesh", "GT", "dinesh@gmail.com", "9344705630", "INDIA"); // Fixed phone number
            }
            catch (Exception e)
            {
                Console.WriteLine($"Warning! {e.Message}");
            }

            try
            {
                phone = new Products(1, "Smartphone", "Latest model", 9999.00);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Warning! {e.Message}");
            }

            try
            {
                if (cust != null)
                    order = new Orders(1001, cust, DateTime.Now, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Warning! {e.Message}");
            }

            try
            {
                if (order != null && phone != null)
                    detail = new OrderDetails(1001, order, phone, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Warning! {e.Message}");
            }


        }
    }
}
