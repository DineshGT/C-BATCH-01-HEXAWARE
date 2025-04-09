using ElectronicGadgetsTechShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicGadgetsTechShop.Interfaces
{
    public interface ICustomerService
    {
        bool RegisterCustomer(Customers customer);
    }
}
