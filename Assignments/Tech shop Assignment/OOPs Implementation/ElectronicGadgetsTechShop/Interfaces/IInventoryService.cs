using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElectronicGadgetsTechShop.Models;
using System.Threading.Tasks;

namespace ElectronicGadgetsTechShop.Interfaces
{
    public interface IInventoryService
    {
        void AddToInventory(int productId, Inventory inventory);
        void UpdateInventory(int productId, int quantityChange);
        void ViewInventory();
        
    }
}
