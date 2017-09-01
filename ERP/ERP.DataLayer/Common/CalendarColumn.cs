using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ERP.DataLayer
{
    public class CalendarColumn : DataGridViewColumn
    {
        #region Constructor(s)

        public CalendarColumn()
            : base(new CalendarCell())
        {
        }
        #endregion

        #region Public Properties
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
        #endregion
    }
}
