using System;
using System.Buffers.Text;
using System.Net;
using System.Numerics;
using System.Text.RegularExpressions;

namespace TechShop
{
    public class Techshop_class
    {
       
        public class IncompleteOrderException : Exception
        {
            public IncompleteOrderException(string message) : base(message) { }
        }
        public class InsufficientStockException : Exception
        {
            public InsufficientStockException(string message) : base(message) { }
        }
        public class InvalidDataException : Exception
        {
            public InvalidDataException(string message) : base(message) { }
        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Simple email regex
            return Regex.IsMatch(email, emailPattern);
        }


        public class Customers
        {
            //Attributes..
            private int customer_id { get; set; }
            private string first_name { get; set; }
            private string ? last_name { get; set; }
            private string ? cust_email { get; set; }

            public string custemail
            {
                get { return cust_email; }
                set
                {
                    if (!IsValidEmail(value))
                    {
                        throw new InvalidDataException("Warning! Invalid email format. Please enter a valid email.");
                    }
                    cust_email = value;
                }
            }

            private string cust_phone;
            public string custphone
            {
                get { return cust_phone; }
                set
                {
                    if (value.Length != 10)
                    {
                        throw new InvalidDataException("Warning! Phone number must be 10 digits");
                    }
                    cust_phone = value;
                }
            }
            private string ? cust_address { get; set; }


            //parameterized constructor
            public Customers(int cust_id, string first_name, string last_name, string cust_email, string cust_phone, string cust_address)
            {
                customer_id = cust_id;
                this.first_name = first_name;
                this.last_name = last_name;
                this.cust_email = cust_email;
                this.cust_phone = cust_phone;
                this.cust_address = cust_address;

            }

            //Methods
            // To calcuate total orders present
            public int CalculateTotalOrders(List<Orders> orders)
            {
                //return orders.Count(sql logic here);
                return 0;
            }

            // To get customer details
            public void GetCustomerDetails()
            {
                Console.WriteLine("-------------Customer Details-------------");
                Console.WriteLine($"Customer ID: {customer_id}");
                Console.WriteLine($"Customer Name: {first_name} {last_name} ");
                Console.WriteLine($"Email: {cust_email}");
                Console.WriteLine($"Phone: {cust_phone}");
                Console.WriteLine($"Address: {cust_address}");
                Console.WriteLine("------------------------------------------");

            }

            // To update customer information
            public void UpdateCustomerInfo(string ? first_name = null, string ? last_name = null, string ? cust_email = null, string? cust_phone = null, string? cust_address = null)
            {
                if(!string.IsNullOrEmpty(first_name)) this.first_name = first_name;
                if (!string.IsNullOrEmpty(last_name)) this.last_name = last_name;
                if (!string.IsNullOrEmpty(cust_email)) this.cust_email = cust_email;
                if (!string.IsNullOrEmpty(cust_phone)) this.cust_phone = cust_phone;
                if (!string.IsNullOrEmpty(cust_address)) this.cust_address = cust_address;

                Console.WriteLine("Customer information updated successfully!");

            }

        }

        public class Products
        {

            // Attributes
            private int product_id { get; set; }
            public string product_name { get; set; }
            private string product_description { get; set; }
            private double product_price;
            //product price should not have -ve values..
            public double productprice
            {
                get { return product_price; }
                set
                {
                    if (value < 0)
                    {
                        throw new InvalidDataException("Warning! Negative value is not allowed");
                       
                    }
                    else product_price = value;
                }
            }



            //parametrized constructor

            public Products(int product_id, string product_name, string product_description, double product_price)
            {
                this.product_id = product_id;
                this.product_name = product_name;
                this.product_description = product_description;
                this.product_price = product_price;
            }


            //Methods
            
            // To get product information
            public void GetProductDetails()
            {
                Console.WriteLine("-----------Product Details------------");
                Console.WriteLine($"Product Name :{product_name}");
                Console.WriteLine($"Description :{product_description}");
                Console.WriteLine($"Price :{product_price}");
                Console.WriteLine("--------------------------------------");

            }

            // To update product infor
            public void UpdateProductInfo(string ? product_name = null, string ? product_description = null, double ? product_price = null)
            {
                if(!string.IsNullOrEmpty(product_name)) this.product_name = product_name;
                if(!string.IsNullOrEmpty(product_description)) this.product_description = product_description;
                if(product_price != null) this.product_price = Convert.ToDouble(product_price);

                Console.WriteLine("Product information updated successfully!");
            }
            
            //To check product is in stock or not
            public bool IsProductInStock(int StockQuantity)
            {
                return StockQuantity>0;
            }


        }

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
            public void UpdateOrderStatus(DateTime ? order_date = null, double ? total_amount = null, string ? order_status = null)
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

        public class Inventory
        {
            //Attributes

            private int inventory_id { get; set; }
            // adding composition for Inventory with products table
            private Products _product { get; set; }
            private int quantity_in_stock { get; set; }
            private DateTime last_stock_update { get; set; }

            // Parameterized constructor

            public Inventory(int inventory_id, Products _product, int quantity_in_stock)
            {
                this.inventory_id = inventory_id;
                this._product = _product;
                this.quantity_in_stock = quantity_in_stock;
                last_stock_update = DateTime.Now;
            }

            //Methods
            //A method to retrieve the product associated with this inventory item.
            public Products GetProduct()
            {
                return _product;
            }

            //A method to get the current quantity of the product in stock.
            public int GetQuantityInStock()
            {
                return quantity_in_stock;
            }

            //A method to add a specified quantity of the product to the inventory.
            public void AddToInventory(int quantity)
            {
                if (quantity <= 0)
                {
                    throw new InvalidDataException("Warning! Invalid quantity to add. Must be greater than zero. ");
                    //Console.WriteLine("Invalid quantity to add. Must be greater than zero.");
                    
                }
                quantity_in_stock += quantity;
                last_stock_update = DateTime.Now;
                Console.WriteLine($"Added {quantity} units. New stock: {quantity_in_stock}");
            }

            //A method to remove a specified quantity of the product
            public bool RemoveFromInventory(int quantity)
            {
                if (quantity <= 0)
                {
                    
                    Console.WriteLine("Invalid quantity to remove.");
                    return false;
                }
                if (quantity > quantity_in_stock)
                {
                    Console.WriteLine("Insufficient stock!");
                    return false;
                }
                quantity_in_stock -= quantity;
                last_stock_update = DateTime.Now;
                Console.WriteLine($"Removed {quantity} units. Remaining stock: {quantity_in_stock}");
                return true;
            }

            //A method to update the stock quantity to a new value
            public void UpdateStockQuantity(int newQuantity)
            {
                if (newQuantity < 0)
                {
                    throw new InsufficientStockException("Warning! Stock quantity cannot be negative. ");

                }
                quantity_in_stock = newQuantity;
                last_stock_update = DateTime.Now;
                Console.WriteLine($"Stock updated to {quantity_in_stock}");
            }

            //A method to check if a specified quantity of the product is available
            public bool IsProductAvailable(int quantityToCheck)
            {
                return quantity_in_stock >= quantityToCheck;
            }

            //A method to calculate the total value of the products in the inventory based on their prices and quantities.
            public double GetInventoryValue()
            {
                return quantity_in_stock * _product.productprice;
            }

            //: A method to list products with quantities below a specified threshold, indicating low stock.
            public bool ListLowStockProducts(int threshold)
            {
                return quantity_in_stock < threshold;
            }

            // A method to list products that are out of stock.
            public bool ListOutOfStockProducts()
            {
                return quantity_in_stock == 0;
            }

            // A method to list all products in the inventory, along with their quantities
            public void ListAllProducts()
            {
                // query to retur all products details...
            }

        }   


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
