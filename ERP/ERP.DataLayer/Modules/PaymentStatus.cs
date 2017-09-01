using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.DataLayer
{
    public class PaymentStatus
    {
        public int PaymentStatusId { get; set; }
        public string PaymentStatusName { get; set; }

        public PaymentStatus(int paymentStatusId, string paymentStatusName)
        {
            this.PaymentStatusId = paymentStatusId;
            this.PaymentStatusName = paymentStatusName;
        }
    }
}
