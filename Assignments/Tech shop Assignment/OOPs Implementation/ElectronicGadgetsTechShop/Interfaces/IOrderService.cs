using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicGadgetsTechShop.Models;

namespace ElectronicGadgetsTechShop.Interfaces
{
    public interface IOrderService
    {
        bool PlaceOrder(Orders order);
        bool CancelOrder(int orderId);
        void AddOrder(Orders order);
        void AddOrderDetail(int orderId, Products product, int quantity);
        void RemoveCancelledOrders();
        void SortOrdersByDate(bool ascending = true);
        List<Orders> GetAllOrders();
        List<string> GetOrderStatusByCustomerId(int customerId);
    }
}
