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
    public partial class PreviewEstimate : Form
    {
        public string EstimateFolderPath { get; set; }
        public int EstimateId { get; set; }

        public PreviewEstimate()
        {
            InitializeComponent();
        }

        private void PreviewEstimate_Load(object sender, EventArgs e)
        {
            axAcroPDF1.src = Path.Combine(EstimateFolderPath, string.Format("Estimate{0}.pdf",EstimateId));
            axAcroPDF1.setZoom(50);     
        }
    }
}
