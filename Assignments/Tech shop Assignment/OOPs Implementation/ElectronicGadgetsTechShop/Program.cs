using ElectronicGadgetsTechShop.Interfaces;
using ElectronicGadgetsTechShop.Services;
using ElectronicGadgetsTechShop.Models;
using ElectronicGadgetsTechShop;

namespace ElectronicGadgetsTechShop
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new ProductService();
            ICustomerService customerService = new CustomerService();
            IInventoryService inventoryService = new InventoryService();
            IOrderService orderService = new OrderService();
            IPaymentService paymentService = new PaymentService();

            TechShopManager manager = new TechShopManager(
                productService,
                customerService,
                inventoryService,
                orderService,
                paymentService
            );

            DataBaseConnector db = new DataBaseConnector();
            bool exit = false;

            Console.WriteLine("=======================Welcome to TechShop!==========================");

            while (!exit)
            {
                Console.WriteLine("\nSelect your role:");
                Console.WriteLine("1. Customer");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Exit");

                string? roleChoice = Console.ReadLine();

                switch (roleChoice)
                {
                    case "1":
                        Customer_menu(manager, db);
                        break;

                    case "2":
                        Admin_menu(manager, db);
                        break;

                    case "3":
                        exit = true;
                        Console.WriteLine("Thank you for visiting TechShop!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void Customer_menu(TechShopManager manager, DataBaseConnector db)
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("\nCustomer Menu:");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Order Product");
                Console.WriteLine("3. Check Order Status");
                Console.WriteLine("4. Cancel Order");
                Console.WriteLine("5. Back to Main Menu");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.DisplayAllProducts();
                        break;

                    case "2":
                        PlaceOrderFlow(manager, db);
                        break;

                    case "3":
                        Console.Write("Enter Your Customer ID to check status: ");
                        int custid = int.Parse(Console.ReadLine());
                        List<string> listofstatus = DataBaseConnector.GetCustomerOrderStatuses(custid);
                        foreach (var i in listofstatus)
                        {
                            Console.WriteLine(i);
                        }
                        break;

                    case "4":
                        Console.Write("Enter Order ID to cancel: ");
                        int cancelId = int.Parse(Console.ReadLine());
                        Orders.CancelOrder(cancelId, "Cancelled");
                        break;

                    case "5":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void PlaceOrderFlow(TechShopManager manager, DataBaseConnector db)
        {
            Console.WriteLine("\n--- Place Order ---");

            Console.Write("Enter your Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.Write("Enter your First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter your Address: ");
            string address = Console.ReadLine();

            Customers newCustomer = new Customers(customerId, firstName, lastName, email, phone, address);

            bool customerInserted = DataBaseConnector.InsertCustomer(newCustomer);
            if (!customerInserted)
            {
                Console.WriteLine("Failed to insert customer. Please try again.");
                return;
            }

            Console.WriteLine("\nCustomer registered successfully!");

            Console.Write("\nEnter product to search: ");
            string keyword = Console.ReadLine();

            List<Products> matchingProducts = DataBaseConnector.SearchProducts(keyword);
            if (matchingProducts.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            Console.WriteLine("\nMatching Products:");
            foreach (var p in matchingProducts)
            {
                Console.WriteLine(p.GetProductDetails());
            }

            Console.Write("\nEnter the Product ID you want to order: ");
            int selected_product = int.Parse(Console.ReadLine());

            Products selectedProduct = manager.GetProductById(selected_product);
            if (selectedProduct == null)
            {
                Console.WriteLine("Invalid product ID.");
                return;
            }

            Console.Write("Enter quantity to order: ");
            int quantity = int.Parse(Console.ReadLine());

            int orderId = new Random().Next(1000, 9999);
            DateTime orderDate = DateTime.Now;
            double totalAmount = selectedProduct.GetProductPrice() * quantity;

            Orders newOrder = new Orders(orderId, newCustomer, orderDate, totalAmount);

            int orderDetailId = new Random().Next(10000, 99999);
            OrderDetails orderDetail = new OrderDetails(orderDetailId, newOrder, selectedProduct, quantity);

            newOrder.AddOrderDetail(orderDetail);

            bool processed = DataBaseConnector.ProcessingOrder(newOrder);

            if (!processed)
            {
                Console.WriteLine("Order failed. Please try again.");
                return;
            }

            Console.WriteLine($"\nOrder placed successfully!");
            Console.WriteLine($"Order ID: {newOrder.GetOrderId()}");
            Console.WriteLine($"Customer ID: {newCustomer.GetCustomerId()}");
            Console.WriteLine($"Product: {selectedProduct.GetProductDetails()}");
            Console.WriteLine($"Quantity: {quantity}");
        }

        static void Admin_menu(TechShopManager manager, DataBaseConnector db)
        {

            bool back = true;
            Console.Write("Enter Admin ID: ");
            string? AdminId = Console.ReadLine();
            Console.Write("Enter Admin Password: ");
            string? Password = Console.ReadLine();

            if (AdminId == "DINESH2025" && Password == "verystrongpassword")
            {
                back = false;
            }
            else
            {
                Console.WriteLine("Invalid ID or Password Authentication!");
            }

            while (!back)
            {
                Console.WriteLine("\n ----------WELCOME TO ADMIN MENU----------");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Manage Inventory");
                Console.WriteLine("4. View All Orders");
                Console.WriteLine("5. Generate Sales Report");
                Console.WriteLine("6. Remove Product");
                Console.WriteLine("7. Remove Cancelled Orders");
                Console.WriteLine("8. Sort Orders By Date");
                Console.WriteLine("9. Record Payment");
                Console.WriteLine("10. Back to Main Menu");

                string getchoice = Console.ReadLine();

                switch (getchoice)
                {
                    case "1":
                        int prod_id = new Random().Next(1000, 9999);
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter description: ");
                        string desc = Console.ReadLine();

                        Console.Write("Enter Category: ");
                        string cate = Console.ReadLine();

                        Console.Write("Enter price: ");
                        double price = double.Parse(Console.ReadLine());

                        Products prod = new Products(prod_id, name, desc, cate, price);
                        bool inserted = DataBaseConnector.InsertProduct(prod);
                        if (inserted)
                        {
                            Console.WriteLine("Product Updated Successfully!");
                            Console.WriteLine($"Product ID is: {prod_id}");
                        }
                        else Console.WriteLine("Unable to Update Product");
                        break;

                    case "2":
                        Console.Write("Enter Product ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new Product Name: ");
                        string updatedName = Console.ReadLine();
                        Console.Write("Enter product Description: ");
                        string updatedDesc = Console.ReadLine();
                        Console.Write("Enter new Category: ");
                        string updatedCategory = Console.ReadLine();
                        Console.Write("Enter Updated price: ");
                        double updatedPrice = double.Parse(Console.ReadLine());

                        Products p = new Products(updateId, updatedName, updatedDesc, updatedCategory, updatedPrice);
                        bool isupdated = manager.UpdateProduct(p);
                        if (isupdated) Console.WriteLine("Updated Succesfully!");
                        break;

                    case "3":
                        Console.WriteLine("1. View Inventory");
                        Console.WriteLine("2. Restock Product");

                        string invchoice = Console.ReadLine();
                        if (invchoice == "1")
                        {
                            DataBaseConnector.ViewInventory();
                        }
                        else if (invchoice == "2")
                        {
                            Console.Write("Enter Product ID: ");
                            int pid = int.Parse(Console.ReadLine());

                            Console.Write("Enter quantity to add: ");
                            int qty = int.Parse(Console.ReadLine());

                            bool updated = DataBaseConnector.UpdateStock(pid, qty);
                            if(updated) Console.WriteLine("Quantity Added to Specified Product!");
                            else Console.WriteLine("Failed to Add!");

                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                        }
                        break;

                    case "4":
                        DataBaseConnector.GetAllOrders();
                        break;

                    case "5":
                        Console.Write("Enter Start Date: ");
                        DateTime starting = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter End Date: ");
                        DateTime ending = Convert.ToDateTime(Console.ReadLine());
                        DataBaseConnector.GenerateSalesReport(starting, ending);
                        break;

                    case "6":
                        Console.Write("Enter Product Name to remove: ");
                        int removename = int.Parse(Console.ReadLine());
                        bool removed = manager.RemoveProduct(removename);
                        if (removed)
                            Console.WriteLine("Product removed successfully.");
                        else
                            Console.WriteLine("Failed to remove product.");
                        break;

                    case "7":
                        manager.RemoveCancelledOrders();
                        Console.WriteLine("Cancelled orders removed.");
                        break;

                    case "8":
                        Console.WriteLine("Sort by Date (1. Ascending, 2. Descending): ");
                        string sortChoice = Console.ReadLine();
                        bool ascending = sortChoice == "1";
                        manager.SortOrdersByDate(ascending);
                        Console.WriteLine("Orders sorted successfully.");
                        break;

                    case "9":
                        Console.Write("Enter Payment ID: ");
                        int paymentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Order ID: ");
                        int paidOrderId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Amount Paid: ");
                        double amountPaid = double.Parse(Console.ReadLine());
                        

                        PaymentRecord pay = new PaymentRecord(paymentId, paidOrderId, amountPaid);
                        manager.RecordPayment(pay);
                        Console.WriteLine("Payment recorded.");
                        break;

                    case "10":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}


