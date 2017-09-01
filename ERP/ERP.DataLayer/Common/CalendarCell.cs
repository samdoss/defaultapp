using ERP.CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ERP.DataLayer
{
    public class CalendarCell : DataGridViewTextBoxCell
    {
        #region Constructor(s)
        public CalendarCell()
            : base()
        {
            // Use the short date format.
            this.Style.Format = "dd/MM/yyyy";

        }
        #endregion

        #region Public Properties

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that CalendarCell uses.
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.
                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                DateTime dateTime = new DateTime();
                dateTime = Utility.GetServerDate(new ApplicationConnection());
                return dateTime.ToString("dd/MM/yyyy");
            }
        }

        #endregion

        #region Public Methods

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl =
                DataGridView.EditingControl as CalendarEditingControl;
        }
        #endregion
    }
}
