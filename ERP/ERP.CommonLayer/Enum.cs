using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.CommonLayer
{
    
        #region Enum for Transactions
        // TransactionStatus defines whether the transaction was successful or failed.
        public enum TransactionStatus
        {
            Success,
            Failure
        }
        #endregion
    
        #region Enum Screen Mode
        //Enums for User's Screen Mode
        public enum ScreenMode
        {
            Add = 1,
            Edit = 2,
            View = 3,
            Delete = 4,
            Exists = 5,
            Expire = 6
        }
        #endregion

    
}
