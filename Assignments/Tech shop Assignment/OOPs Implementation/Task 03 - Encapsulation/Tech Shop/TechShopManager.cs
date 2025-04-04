using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech_Shop
{
    public class TechShopManager
    {
        private List<Products> productList = new List<Products>();
        private List<Orders> orderList = new List<Orders>();
        private SortedList<int, Inventory> inventoryMap = new SortedList<int, Inventory>();
        private List<PaymentRecord> paymentRecords = new List<PaymentRecord>();

        public void AddProduct(Products product)
        {
            if (productList.Any(p => p.product_name == product.product_name))
                throw new InvalidDataException("Duplicate product detected.");
            productList.Add(product);
        }

        public void UpdateProduct(Products updatedProduct)
        {
            var existing = productList.FirstOrDefault(p => p.product_name == updatedProduct.product_name);
            if (existing == null) throw new InvalidDataException("Product not found.");
            existing.UpdateProductInfo(updatedProduct.product_name, null, updatedProduct.productprice);
        }

        public void RemoveProduct(string productName)
        {
            var product = productList.FirstOrDefault(p => p.product_name == productName);
            if (product == null) return;

            if (orderList.Any(o => o.CalculateTotalAmount(null) > 0))
                throw new InvalidOperationException("Cannot remove product with existing orders.");

            productList.Remove(product);
        }

        public void AddOrder(Orders order)
        {
            orderList.Add(order);
        }

        public void RemoveCancelledOrders()
        {
            orderList.RemoveAll(o => o.ToString().Contains("Cancelled"));
        }

        public void SortOrdersByDate(bool ascending = true)
        {
            orderList = ascending
                ? orderList.OrderBy(o => o.ToString()).ToList()
                : orderList.OrderByDescending(o => o.ToString()).ToList();
        }

        public void AddToInventory(int productId, Inventory inventory)
        {
            inventoryMap[productId] = inventory;
        }

        public void UpdateInventory(int productId, int quantityChange)
        {
            if (!inventoryMap.ContainsKey(productId)) throw new InvalidOperationException("Product not in inventory");

            if (quantityChange < 0)
                inventoryMap[productId].RemoveFromInventory(-quantityChange);
            else
                inventoryMap[productId].AddToInventory(quantityChange);
        }

        public List<Products> SearchProducts(string name)
        {
            return productList.Where(p => p.product_name.Contains(name)).ToList();
        }

        public void RecordPayment(PaymentRecord payment)
        {
            paymentRecords.Add(payment);
        }

    }
}
