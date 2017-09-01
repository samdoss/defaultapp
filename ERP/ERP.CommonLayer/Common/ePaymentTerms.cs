using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.CommonLayer
{
    public enum ePaymentTerms
    {
        Default = 0,
        Net10  = 1,
        Net20 = 2,
        Net30 = 3,
        Net45 = 4,
        Net60 = 5,
        OnSpecifiedDate = 6,
        OnReceipt =7
    }
}
