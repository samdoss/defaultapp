using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Drawing;


namespace ERP.DataLayer
{
    public class Theme
    {
        #region Constructor(s)

        public Theme(){}

        #endregion

        #region Private Variables

        private Color bc = Color.Blue;
        private Font f = new Font("Verdana", 10);
        private float fsz = 10;
        private Color c = Color.Blue;
        
        #endregion

        #region Public Properties

        public Color BackColor
        {
            get { return bc; }
        }


        public Color ForeColor
        {
            get { return c; }
        }

        public Font Font
        {
            get { return f; }
        }

        public float FontSize
        {
            get { return fsz; }
        }

        #endregion
    }
}
