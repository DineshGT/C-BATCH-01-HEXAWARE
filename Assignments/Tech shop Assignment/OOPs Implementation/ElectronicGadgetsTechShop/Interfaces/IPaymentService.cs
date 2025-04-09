using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicGadgetsTechShop.Models;

namespace ElectronicGadgetsTechShop.Interfaces
{
    public interface IPaymentService
    {
        bool ProcessPayment(PaymentRecord payment);
        void RecordPayment(PaymentRecord payment);
    }
}
