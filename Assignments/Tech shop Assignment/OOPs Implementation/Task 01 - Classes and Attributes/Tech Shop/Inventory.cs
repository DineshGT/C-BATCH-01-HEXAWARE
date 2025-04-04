using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TechShop.Techshop_class;

namespace Tech_Shop
{
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
                throw new InsufficientStockException("Insufficient stock for the requested quantity.");

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
}
