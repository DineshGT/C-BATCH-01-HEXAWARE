using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TechShop.Techshop_class;

namespace Tech_Shop
{
    public class Orders
    {
        //Attributes
        private int order_id { get; set; }
        // adding composition for Orders with customers table

        private Customers _customer { get; set; }
        private DateTime order_date { get; set; }
        private double total_amount { get; set; }
        private string order_status { get; set; }

        private List<OrderDetails> _orderDetails;

        //parameterized constructor
        public Orders(int order_id, Customers _customer, DateTime order_date, double total_amount)
        {
            this.order_id = order_id;
            this._customer = _customer;
            this.order_date = order_date;
            this.total_amount = total_amount;
            this.order_status = "Pending"; // it is default here
        }

        // Methods

        // To get total amount of orders
        public double CalculateTotalAmount(List<OrderDetails> order_details)
        {
            double total = 0;
            foreach (var detail in order_details)
            {
                total += detail.CalculateSubtotal();
            }
            return total;
        }

        // To get details or orders
        public void GetOrderDetails()
        {
            Console.WriteLine("-------------Order Details--------------");
            Console.WriteLine($"Order ID: {order_id}");
            Console.WriteLine($"Order Date: {order_date}");
            Console.WriteLine($"Total Amount: {total_amount}");
            Console.WriteLine($"Order Status: {order_status}");
            Console.WriteLine("-----------------------------------------");

        }

        //To update order status
        public void UpdateOrderStatus(DateTime? order_date = null, double? total_amount = null, string? order_status = null)
        {
            if (order_date != null) this.order_date = order_date.Value;
            if (total_amount != null) this.total_amount = total_amount.Value;
            if (!string.IsNullOrEmpty(order_status)) this.order_status = order_status;

            Console.WriteLine("Order Details updated successfully!");
        }

        //To cancel order
        public void CancelOrder()
        {
            this.order_status = "Cancelled";
            Console.WriteLine($"Order {order_id} has been cancelled.");
        }



    }
}
