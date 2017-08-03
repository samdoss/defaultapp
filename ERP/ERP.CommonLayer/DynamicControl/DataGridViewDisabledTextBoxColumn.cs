using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ERP.CommonLayer
{
    public class DataGridViewDisabledTextBoxColumn : DataGridViewTextBoxColumn
    {
        #region Constructor(s)

        public DataGridViewDisabledTextBoxColumn()
        {
            this.CellTemplate = new DataGridViewDisabledTextBoxCell();
        }

        #endregion
    }
}
