using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicGadgetsTechShop.Models;

namespace ElectronicGadgetsTechShop.Interfaces
{
    public interface IProductService
    {
        bool AddProduct(Products product);
        void RemoveProduct(int productName);
        bool UpdateProduct(Products product);
        Products GetProductById(int productId);
        List<Products> SearchProducts(string keyword);
        List<Products> GetAllProducts();

    }
}
