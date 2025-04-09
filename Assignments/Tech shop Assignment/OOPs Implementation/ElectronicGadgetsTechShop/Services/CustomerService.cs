using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicGadgetsTechShop.Models;
using ElectronicGadgetsTechShop.Interfaces;

namespace ElectronicGadgetsTechShop.Services
{
    public class CustomerService : ICustomerService
    {
        public void RegisterCustomer(Customers customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer cannot be null.");

            DataBaseConnector.InsertCustomer(customer);
        }

        bool ICustomerService.RegisterCustomer(Customers customer)
        {
            throw new NotImplementedException();
        }
    }
}
