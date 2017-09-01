using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ERPWinApp
{
	public partial class Testform : Form
	{
		public Testform()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				using (var client = new WebClient())
				{
					var values = new NameValueCollection();
					String message = HttpUtility.UrlEncode("Test SMS");
					using (var wb = new WebClient())
					{
						//http://bhashsms.com/api/sendmsg.php?user=9789017256&pass=SAMDOSS147&sender=Sender ID&phone=Mobile No&text=Test SMS&priority=Priority&stype=smstype
						byte[] response = wb.UploadValues("http://api.textlocal.in/send/", new NameValueCollection()
						{
							{"username" , "naseer036@gmail.com"},
							{"hash" , "30d4019a197f1e8f318c7b39f886312e54c8fb6b"},
							{"numbers" , "9789017256"},
							{"message" , message},
							{"sender" , "TXTLCL"}
						});
						string result = System.Text.Encoding.UTF8.GetString(response);
						MessageBox.Show(result);
					}
				}
			}
			catch (Exception es)
			{
				MessageBox.Show(es.Message);
			}
		}
	}
}
