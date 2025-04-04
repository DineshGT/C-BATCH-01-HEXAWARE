using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tech_Shop.Techshop_class;

namespace Tech_Shop
{
    public class PaymentRecord
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; } // Paid, Failed, Pending

        public PaymentRecord(int paymentId, int orderId, double amount)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Amount = amount;
            Status = "Pending";
        }

        public void ProcessPayment(bool isSuccess)
        {
            Status = isSuccess ? "Paid" : throw new PaymentFailedException("Payment Declined");
        }

    }
}
