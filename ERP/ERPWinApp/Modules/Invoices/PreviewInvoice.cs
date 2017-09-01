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
    public partial class PreviewInvoice : Form
    {
        public string InvoiceFolderPath { get; set; }
        public int InvoiceId { get; set; }

        public PreviewInvoice()
        {
            InitializeComponent();
        }

        private void PreviewInvoice_Load(object sender, EventArgs e)
        {
            axAcroPDF1.src = Path.Combine(InvoiceFolderPath, string.Format("Invoice{0}.pdf",InvoiceId));
            axAcroPDF1.setZoom(50);     
        }
    }
}
