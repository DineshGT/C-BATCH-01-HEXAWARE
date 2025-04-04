using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TechShop.Techshop_class;

namespace Tech_Shop
{
    public class OrderDetails
    {

        //Attributes

        private int order_id { get; set; }

        // adding composition for OrderDetails with products and orders tables..

        private Orders _orders { get; set; }
        private Products _products { get; set; }
        private int quantity { get; set; }


        public int orderquantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                {
                    throw new InsufficientStockException("Warning! Quantity must be Positive");

                }
                else quantity = value;
            }
        }
        private double discount { get; set; } = 0;

        public double Discount
        {
            get { return discount; }
            set
            {
                if (value < 0 || value > 100)
                    throw new InvalidDataException("Invalid discount!");
                discount = value;
            }
        }



        //Parameterized Constructor
        public OrderDetails(int order_id, Orders _orders, Products _products, int quantity)
        {
            this.order_id = order_id;
            this._orders = _orders;
            if (_products == null)
            {
                throw new IncompleteOrderException("Error: The order must have a valid product reference.");
            }

            this._products = _products;
            this.quantity = quantity;
        }

        //Methods
        // To calculate subtotal
        public double CalculateSubtotal()
        {
            return quantity * _products.productprice * (1 - discount / 100);
        }

        // To get info about order details
        public void GetOrderDetailInfo()
        {
            Console.WriteLine("------------ Order Details ------------");
            Console.WriteLine($"Order ID   : {order_id}");
            Console.WriteLine($"Product    : {_products.product_name}");
            Console.WriteLine($"Quantity   : {quantity}");
            Console.WriteLine($"Unit Price : {_products.productprice:C}");
            Console.WriteLine($"Discount   : {discount}%");
            Console.WriteLine($"Subtotal   : {CalculateSubtotal()}");
            Console.WriteLine("--------------------------------------");

        }

        // To update quantity of products
        public void UpdateQuantity(int new_quantity)
        {
            if (new_quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0");
                return;
            }
            this.quantity = new_quantity;
            Console.WriteLine($"Quantity updated to {quantity}.");
        }

        // To apply a discount
        public void AddDiscount(double discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new InvalidDataException("Warning! Invalid discount value! Must be between 0 to 100%.");

                //Console.WriteLine("Invalid discount value! Must be between 0 to 100%.");

            }
            this.discount = discountPercentage;
            Console.WriteLine($"Discount of {discount}% is applied!!");
        }
    }
}
