using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.DataLayer
{
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public PaymentType(int paymentTypeId, string paymentTypeName)
        {
            this.PaymentTypeId = paymentTypeId;
            this.PaymentTypeName = paymentTypeName;
        }


    }
}
