using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.CommonLayer
{
    public enum ePaymentType
    {
        Cash = 1,
        CreditCard,
        DebitCard,
        Check,
        BankTransfer,
        Other
    }
}
