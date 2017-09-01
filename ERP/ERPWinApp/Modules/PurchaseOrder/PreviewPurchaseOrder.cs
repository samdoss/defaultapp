using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ERPWinApp
{
    public partial class PreviewPurchaseOrder : Form
    {
        public string PurchaseOrderFolderPath { get; set; }
        public int PurchaseOrderId { get; set; }

        public PreviewPurchaseOrder()
        {
            InitializeComponent();
        }

        private void PreviewPurchaseOrder_Load(object sender, EventArgs e)
        {
            axAcroPDF1.src = Path.Combine(PurchaseOrderFolderPath, string.Format("PurchaseOrder{0}.pdf",PurchaseOrderId));
            axAcroPDF1.setZoom(50);     
        }
    }
}
