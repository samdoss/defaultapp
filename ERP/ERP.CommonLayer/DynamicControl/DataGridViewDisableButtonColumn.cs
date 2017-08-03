using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ERP.CommonLayer
{
    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        #region Constructor(s)

        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }

        #endregion
    }
}
