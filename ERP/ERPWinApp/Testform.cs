using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;

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
			////SMS Package send code
			////try
			////{
			////	using (var client = new WebClient())
			////	{
			////		var values = new NameValueCollection();
			////		String message = HttpUtility.UrlEncode("Test SMS");
			////		using (var wb = new WebClient())
			////		{
			////			//http://bhashsms.com/api/sendmsg.php?user=username&pass=password&sender=Sender ID&phone=Mobile No&text=Test SMS&priority=Priority&stype=smstype
			////			byte[] response = wb.UploadValues("http://api.textlocal.in/send/", new NameValueCollection()
			////			{
			////				{"username" , "naseer036@gmail.com"},
			////				{"hash" , "30d4019a197f1e8f318c7b39f886312e54c8fb6b"},
			////				{"numbers" , "1234567890"},
			////				{"message" , message},
			////				{"sender" , "TXTLCL"}
			////			});
			////			string result = System.Text.Encoding.UTF8.GetString(response);
			////			MessageBox.Show(result);
			////		}
			////	}
			////}
			////catch (Exception es)
			////{
			////	MessageBox.Show(es.Message);
			////}

			////Itextsharp workout


			////List<string> lst = new List<string>();
			////int totalfonts = FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");
			//////StringBuilder sb = new StringBuilder();
			////foreach (string fontname in FontFactory.RegisteredFonts)
			////{
			////	lst.Add(fontname);
			////}
			//////doc.Add(new Paragraph("All Fonts:\n" + sb.ToString()));

			//Document document = new Document(PageSize.A8, 5f, 5f, 5f, 5f);
			//try
			//{
			//	string directoryPDFPath = string.Empty;
			//	directoryPDFPath = Path.Combine("e://", "ATest");
			//	if (!Directory.Exists(directoryPDFPath))
			//	{
			//		Directory.CreateDirectory(directoryPDFPath);
			//	}

			//	PdfWriter.GetInstance(document, new FileStream(string.Format(directoryPDFPath + @"//pdftestfile{0}.pdf", DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + +DateTime.Now.Millisecond), FileMode.Create));
			//	document.Open();

			//	PdfPTable topicPdf = new PdfPTable(1);
			//	topicPdf.DefaultCell.BorderWidth = 0;
			//	topicPdf.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

			//	Phrase phrase = new Phrase();
			//	phrase.Add(new Chunk("PDF Test Page" + Chunk.NEWLINE, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			//	topicPdf.AddCell(phrase);

			//	phrase = new Phrase();
			//	phrase.Add(new Chunk(tbText.Text + Chunk.NEWLINE));
			//	topicPdf.AddCell(phrase);

			//	string lathaFontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\latha.TTF";
			//	if (File.Exists(fontpath))
			//	{
			//		BaseFont basefont = BaseFont.CreateFont(lathaFontPath, BaseFont.IDENTITY_H, true);
			//		iTextSharp.text.Font fontLatha = new iTextSharp.text.Font(basefont, 11, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
			//		Paragraph pr1 = new Paragraph(tbText.Text, fontLatha);
			//		topicPdf.AddCell(pr1);
			//	}

			//	document.Add(topicPdf);
			//	document.Close();
			//}
			//catch (Exception ex)
			//{
			//	if (document.IsOpen())
			//	{
			//		document.CloseDocument();
			//	}

			//	MessageBox.Show("Error previwing Invoice :" + ex.Message);
			//}
		}
	}
}
