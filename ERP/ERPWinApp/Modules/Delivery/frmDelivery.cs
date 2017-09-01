using ERP.CommonLayer;
using ERP.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPWinApp
{
    public partial class frmDelivery : Form
    {
        public int invoiceID { get; set; }
        public int clientID { get; set; }


        public frmDelivery()
        {
            InitializeComponent();
        }

        private void frmDelivery_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DialogResult isQuit;
                TransactionResult _result = null;

                isQuit = MessageBox.Show("Are You Sure This Invoice Items Delivered?", "ApplicationName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (isQuit == DialogResult.Yes)
                {
                    InvoiceProduct ip = new InvoiceProduct();
                    ip.InvoiceId = invoiceID;
                    ip.IsDelivered = true;
                    _result = ip.Commit(ScreenMode.Delete);
                    smssend();

                    if (_result.Status == TransactionStatus.Success)
                        MessageBox.Show("SMS Successfully Sent.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("SMS failued.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                this.Close();
            }
        }

        private void smssend()
        {
            Client cl = new Client(Convert.ToInt32(clientID));

            using (var web = new System.Net.WebClient())
            {
                try
                {
                    string userName = "9789017256";
                    string userPassword = "SAMDOSS147";
                    string msgRecepient = "";
                    string msgText = "Dear Client, Your Order is ready";
                    string url = "http://bhashsms.com/api/sendmsg.php?" +
                        "user=" + System.Web.HttpUtility.UrlEncode(userName) +
                        "&pass=" + userPassword +
                        "&sender=" + "CSICHU" +
                        "&phone=" + cl.Phone +
                        "&text=" + msgText + //System.Web.HttpUtility.UrlEncode(msgText, System.Text.Encoding.GetEncoding("ISO-8859-1")) +
                        "&priority=" + "ndnd" +
                        "&stype=" + "normal";
                    string smsResult = web.DownloadString(url);
                    if (smsResult.Contains("S."))
                    {
                        MessageBox.Show("Sms sent successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Some issue delivering", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    //Catch and show the exception if needed. Donot supress. :)  

                }
            }
        }
    }
}
