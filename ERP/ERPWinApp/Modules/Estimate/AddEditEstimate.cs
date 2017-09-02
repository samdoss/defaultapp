using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using ERP.DataLayer;
using ERP.CommonLayer;


namespace ERPWinApp
{
	public partial class AddEditEstimate : Form
	{
		ScreenMode userMode;
		Variables _variables = new Variables();
		ApplicationConnection _appConnection = new ApplicationConnection();

		Client clientService = new Client();
		Company companyService = new Company();
		Tax masterService = new Tax();
		Product productService = new Product();
		Estimate Estimateervice = new Estimate();
		List<EstimateProduct> lstEstimateProduct = new List<EstimateProduct>();
		EstimateProduct EstimateProduct = null;
		public string CompanyFolderName { get; set; }
		public string ClientName { get; set; }
		public int ClientId { get; set; }
		private int unitID { get; set; }
		private string unitCode { get; set; }
		private decimal totalValue = decimal.Zero;
		public decimal TotalValue
		{
			get
			{
				return totalValue;
			}
			set
			{
				totalValue = value;
			}
		}

		public string EstimateFolderPath
		{
			get
			{
				return string.Format(ConfigurationManager.AppSettings["EstimatePath"], CompanyFolderName, ClientName);
			}
		}

		public AddEditEstimate()
		{
			InitializeComponent();
		}

		private void AddEditEstimate_Load(object sender, EventArgs e)
		{
			try
			{
                lblShippingRupees.Text = MDIForm.CurrencySymbol;
				SettingGridColumnOrder();
				Common.SetLargeDialogCoordinate(this);
				SetDefaultData();
				BindClientNameDropdown();
				BindPaymentTermDropdown();
				BindPaymentTypeDropdown();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error :" + ex.Message);
			}
		}

		private void BindPaymentTypeDropdown()
		{
			List<PaymentType> lstPaymentType = new List<PaymentType>();
			lstPaymentType.Add(new PaymentType((int)ePaymentType.Cash, "Cash"));
			lstPaymentType.Add(new PaymentType((int)ePaymentType.CreditCard, "Credit Card"));
			lstPaymentType.Add(new PaymentType((int)ePaymentType.DebitCard, "Debit Card"));
			lstPaymentType.Add(new PaymentType((int)ePaymentType.Check, "Check"));
			lstPaymentType.Add(new PaymentType((int)ePaymentType.BankTransfer, "Bank Transfer"));
			lstPaymentType.Add(new PaymentType((int)ePaymentType.Other, "Other"));

			cmbPaymentType.DataSource = lstPaymentType;
			cmbPaymentType.DisplayMember = "PaymentTypeName";
			cmbPaymentType.ValueMember = "PaymentTypeId";
		}

		private void LoadTaxDropDown()
		{
			List<Tax> lstTax = (from tax in masterService.GetAllTaxList()
							   .Where(v => v.Status == true)
								select new Tax
								{
									TaxId = tax.TaxId,
									TaxName = tax.TaxName + " (" + tax.TaxPercentage + ")"
								}).ToList<Tax>();
			lstTax.Insert(0, new Tax(0, "-- Select Tax --"));
			cmbTax.DataSource = lstTax;
			cmbTax.DisplayMember = "TaxName";
			cmbTax.ValueMember = "TaxId";

		}

		private void SetDefaultData()
		{
			txtEstimateNumber.Enabled = false;
			var lstEstimate = Estimateervice.GetAllEstimateList();

			if (lstEstimate != null && lstEstimate.Count == 0)
				txtEstimateNumber.Text = Constants.CONSTANT_INOVICE_NO;
			else
			{
				int EstimateId = lstEstimate.Max(v => v.EstimateId);
				txtEstimateNumber.Text = Convert.ToString(++EstimateId);
			}

			var lstCompany = (from Company in companyService.GetAllCompanyList()
							 .Where(v => v.Status == true)
							  select Company).SingleOrDefault();
			CompanyFolderName = lstCompany.CompanyName;
		}

		private void BindProductDropdown()
		{
			List<Product> lstProduct = productService.GetAllProductList();
			lstProduct.Insert(0, new Product(0, "-- Select Product --"));
			cmbProduct.DataSource = lstProduct;
			cmbProduct.DisplayMember = "ProductName";
			cmbProduct.ValueMember = "ProductId";
		}

		private void BindMaterialDropdown()
		{
			if (cmbProduct.SelectedIndex != 0)
			{
				List<Material> lstMaterial = Material.GetMaterialRequisition(_appConnection, Convert.ToInt32(cmbProduct.SelectedValue));
				lstMaterial.Insert(0, new Material(0, "-- Select Material --"));
				ddlMaterial.DataSource = lstMaterial;
				ddlMaterial.DisplayMember = "MaterialDescription";
				ddlMaterial.ValueMember = "MaterialID";
			}
			else
			{
				List<Material> lstMaterial = new List<Material>();
				lstMaterial.Insert(0, new Material(0, "-- Select Material --"));
				ddlMaterial.DataSource = lstMaterial;
				ddlMaterial.DisplayMember = "MaterialDescription";
				ddlMaterial.ValueMember = "MaterialID";
			}
		}
		private void BindPaymentTermDropdown()
		{
			PaymentTerms terms = new PaymentTerms();
			List<PaymentTerms> lstPaymentTerms = terms.GetAllPaymentTermsList();
			cmbPaymentTerms.DataSource = lstPaymentTerms;
			cmbPaymentTerms.DisplayMember = "PaymentTermName";
			cmbPaymentTerms.ValueMember = "PaymentTermId";
		}

		private void BindClientNameDropdown()
		{
			List<Client> lstClient = clientService.GetAllClientsList();
			lstClient.Insert(0, new Client(0, "-- Select Client --"));
			cmbClient.DataSource = lstClient;
			cmbClient.DisplayMember = "ClientName";
			cmbClient.ValueMember = "ClientId";
		}

		private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbProduct.SelectedIndex != 0)
			{
				int productId = Convert.ToInt32(cmbProduct.SelectedValue);
				Product product = new Product(productId);
				txtDescription.Text = product.Description;
				//txtQuantity.Text = Convert.ToString(1);
				//txtUnitPrice.Text = Convert.ToString(product.UnitPrice);
				//cmbTax.SelectedValue = product.TaxId;
				BindMaterialDropdown();
				btnAdd.Enabled = false;
			}
			else
			{
				BindMaterialDropdown();
				btnAdd.Enabled = false;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			List<Tax> lstTax = masterService.GetAllTaxList();
			EstimateProduct = new EstimateProduct();
			EstimateProduct.EstimateProductId = lstEstimateProduct.Count;
			EstimateProduct.EstimateId = String.IsNullOrEmpty(txtEstimateNumber.Text) ? 0 : Convert.ToInt32(txtEstimateNumber.Text);
			EstimateProduct.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
			EstimateProduct.ProductName = cmbProduct.Text.Trim();

			EstimateProduct.MaterialID = Convert.ToInt32(ddlMaterial.SelectedValue);
			EstimateProduct.MaterialName = ddlMaterial.Text.Trim();
			EstimateProduct.MaterialCode = lblMaterialCode.Text;

			EstimateProduct.UnitID = unitID;
			EstimateProduct.UnitCode = lblUnitValue.Text;

			EstimateProduct.ProductName = cmbProduct.Text.Trim();

			EstimateProduct.Description = ddlMaterial.Text.Trim();//txtDescription.Text.Trim();
			EstimateProduct.Quantity = String.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToInt32(txtQuantity.Text);
			EstimateProduct.UnitPrice = String.IsNullOrEmpty(txtUnitPrice.Text) ? decimal.Zero : Math.Round(Convert.ToDecimal(txtUnitPrice.Text), 2);
			EstimateProduct.TotalPrice = Math.Round(EstimateProduct.Quantity * EstimateProduct.UnitPrice, 2);
			if (!string.IsNullOrEmpty(cmbTax.SelectedValue.ToString()))
			{
				EstimateProduct.TaxId = Convert.ToInt32(cmbTax.SelectedValue);
			}

			var objTax = (from tax in lstTax
					  .Where(v => v.TaxId == EstimateProduct.TaxId)
						  select tax).SingleOrDefault();

			EstimateProduct.TaxValue = Math.Round((EstimateProduct.Quantity * EstimateProduct.UnitPrice) * objTax.TaxPercentage * (decimal)0.01, 2);
			
            dgvTaxHandle.Rows.Add();
            dgvTaxHandle.Rows[dgvTaxHandle.Rows.Count-1].Cells[0].Value = lblMaterialCode.Text;
            dgvTaxHandle.Rows[dgvTaxHandle.Rows.Count - 1].Cells[1].Value = EstimateProduct.TotalPrice;
            dgvTaxHandle.Rows[dgvTaxHandle.Rows.Count - 1].Cells[2].Value = Convert.ToDecimal(objTax.TaxPercentage) / 2;
            dgvTaxHandle.Rows[dgvTaxHandle.Rows.Count - 1].Cells[3].Value = Math.Round((EstimateProduct.Quantity * EstimateProduct.UnitPrice) * objTax.TaxPercentage * (decimal)0.01, 2) / 2;
            dgvTaxHandle.Rows[dgvTaxHandle.Rows.Count - 1].Cells[4].Value = Convert.ToDecimal(objTax.TaxPercentage) / 2;
            dgvTaxHandle.Rows[dgvTaxHandle.Rows.Count - 1].Cells[5].Value = Math.Round((EstimateProduct.Quantity * EstimateProduct.UnitPrice) * objTax.TaxPercentage * (decimal)0.01, 2) / 2;
            dgvTaxHandle.Rows[dgvTaxHandle.Rows.Count - 1].Cells[6].Value = Math.Round((EstimateProduct.Quantity * EstimateProduct.UnitPrice) * objTax.TaxPercentage * (decimal)0.01, 2);
            lstEstimateProduct.Add(EstimateProduct);


			BindEstimateProductGrid();
			ClearProductControls();
			CalculateEstimate();
            cmbProduct.Focus();
		}

		private void CalculateEstimate()
		{
			pnlSubtotal.Visible = true;
			pnlTaxValue.Visible = true;
			decimal subTotal = decimal.Zero;
			decimal serviceTax = decimal.Zero;

			foreach (EstimateProduct product in lstEstimateProduct)
			{
				subTotal = Math.Round(subTotal + product.TotalPrice, 2);
				serviceTax = Math.Round(serviceTax + product.TaxValue, 2);
			}

			TotalValue = subTotal + serviceTax;
			decimal discPercentage = String.IsNullOrEmpty(txtDiscount.Text) ? decimal.Zero : Math.Round(Convert.ToDecimal(txtDiscount.Text), 2);
			decimal discountValue = Math.Round(TotalValue * discPercentage * (decimal)0.01, 2);
			TotalValue = TotalValue - discountValue;
			decimal shippingAndPackaging = String.IsNullOrEmpty(txtShippingnPackaging.Text) ? decimal.Zero : Math.Round(Convert.ToDecimal(txtShippingnPackaging.Text), 2);
			TotalValue = TotalValue + shippingAndPackaging;
			lblSubtotalValue.Text = subTotal.ToString();
			lblTaxValue.Text = serviceTax.ToString();
			lblDiscountValue.Text = "- " + discountValue.ToString();
			decimal roundedValue = decimal.Zero;

			if (chkRoundOff.Checked)
			{
				roundedValue = Math.Round(TotalValue);
				decimal value = roundedValue - TotalValue;
				TotalValue = roundedValue;
				lblRoundedOffValue.Text = Convert.ToString(value);
			}

			lblTotalValue.Text = Convert.ToString(TotalValue);

			if (chkMarkEstimatePaid.Checked)
			{
				txtAmountPaid.Text = TotalValue.ToString();
			}
		}

		private void BindEstimateProductGrid()
		{
			int srNo = 0;
			var columns = (from prod in lstEstimateProduct
						   select new
						   {
							   No = ++srNo,
							   ProductName = prod.ProductName,
							   Description = prod.Description,
							   Quantity = prod.Quantity,
							   UnitPrice = prod.UnitPrice,
							   Value = prod.TotalPrice,
							   Tax = prod.TaxValue,
							   MaterialCode = prod.MaterialCode,
							   MaterialID = prod.MaterialID,
							   MaterialDescription = prod.MaterialName,
							   UnitID = prod.UnitID,
							   MaterialUnit = prod.UnitCode
						   }).ToList();
			dgvEstimate.DataSource = columns;
		}

		private void ClearProductControls()
		{
			cmbProduct.SelectedIndex = 0;
			txtDescription.Text = String.Empty;
			txtQuantity.Text = String.Empty;
			txtUnitPrice.Text = String.Empty;
			cmbTax.SelectedIndex = 0;
			lblMaterialCode.Text = "";
			lblUnitValue.Text = "";
		}

		private void GenerateEstimatePDF()
		{
			Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
			try
			{
				if (!Directory.Exists(EstimateFolderPath))
				{
					Directory.CreateDirectory(EstimateFolderPath);
				}

				PdfWriter.GetInstance(document, new FileStream(string.Format(EstimateFolderPath + @"/Estimate{0}.pdf", txtEstimateNumber.Text), FileMode.Create));
				document.Open();

				PdfPTable topicPdf = new PdfPTable(1);
				topicPdf.DefaultCell.BorderWidth = 0;
				topicPdf.TotalWidth = 750f;
				topicPdf.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

				Phrase phrase = new Phrase();
				phrase.Add(new Chunk("Estimate" + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 15, iTextSharp.text.Font.BOLD)));
				topicPdf.AddCell(phrase);

				PdfPTable outerOuterHeader = new PdfPTable(1);
				outerOuterHeader.DefaultCell.BorderWidth = 0;
				outerOuterHeader.TotalWidth = 750f;
				outerOuterHeader.WidthPercentage = 100;
				outerOuterHeader.SpacingAfter = 0f;
				outerOuterHeader.HorizontalAlignment = Element.ALIGN_LEFT;


				//Tables for Logo and Estimate Details
				PdfPTable outerHeader = new PdfPTable(2);
				outerHeader.DefaultCell.BorderWidth = 1;
				outerHeader.TotalWidth = 750f;
				outerHeader.WidthPercentage = 100;
				outerHeader.SpacingAfter = 0f;
				outerHeader.HorizontalAlignment = Element.ALIGN_LEFT;



				PdfPTable pdfCompanyTable = CreateCompanyGrid();
				PdfPTable pdfEstimateTable = CreateEstimateGrid();
				outerHeader.AddCell(pdfCompanyTable);
				outerHeader.AddCell(pdfEstimateTable);

				outerOuterHeader.AddCell(outerHeader);

				//Product Table
				PdfPTable pdfProductTable = CreateProductsGrid();
				
				outerOuterHeader.AddCell(pdfProductTable);

				document.Add(topicPdf);
				document.Add(outerOuterHeader);
				document.Close();
			}
			catch (Exception ex)
			{
				if (document.IsOpen())
				{
					document.CloseDocument();
				}

				MessageBox.Show("Error previwing Estimate :" + ex.Message);
			}
		}

		//private void GenerateEstimatePDF()
		//{
		//	Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
		//	try
		//	{
		//		if (!Directory.Exists(EstimateFolderPath))
		//		{
		//			Directory.CreateDirectory(EstimateFolderPath);
		//		}

		//		PdfWriter.GetInstance(document, new FileStream(string.Format(EstimateFolderPath + @"/Estimate{0}.pdf", txtEstimateNumber.Text), FileMode.Create));
		//		document.Open();

		//		PdfPTable topicPdf = new PdfPTable(1);
		//		topicPdf.DefaultCell.BorderWidth = 0;
		//		topicPdf.TotalWidth = 750f;
		//		topicPdf.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

		//		Phrase phrase = new Phrase();
		//		phrase.Add(new Chunk("Purchase Order" + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 15, iTextSharp.text.Font.BOLD)));
		//		topicPdf.AddCell(phrase);

		//		PdfPTable outerOuterHeader = new PdfPTable(1);
		//		outerOuterHeader.DefaultCell.BorderWidth = 0;
		//		outerOuterHeader.TotalWidth = 750f;
		//		outerOuterHeader.WidthPercentage = 100;
		//		outerOuterHeader.SpacingAfter = 0f;
		//		outerOuterHeader.HorizontalAlignment = Element.ALIGN_LEFT;


		//		//Tables for Logo and Estimate Details
		//		PdfPTable outerHeader = new PdfPTable(2);
		//		outerHeader.DefaultCell.BorderWidth = 1;
		//		outerHeader.TotalWidth = 750f;
		//		outerHeader.WidthPercentage = 100;
		//		outerHeader.SpacingAfter = 0f;
		//		outerHeader.HorizontalAlignment = Element.ALIGN_LEFT;



		//		PdfPTable pdfCompanyTable = CreateCompanyGrid();
		//		PdfPTable pdfEstimateTable = CreateEstimateGrid();
		//		outerHeader.AddCell(pdfCompanyTable);
		//		outerHeader.AddCell(pdfEstimateTable);

		//		////Tables for Billing and Shipping Address
		//		//PdfPTable outerAddress = new PdfPTable(2);
		//		//outerAddress.DefaultCell.BorderWidth = 0;
		//		//outerAddress.TotalWidth = 750f;
		//		//outerAddress.WidthPercentage = 100;
		//		//outerAddress.SpacingAfter = 10f;
		//		//outerAddress.HorizontalAlignment = Element.ALIGN_LEFT;

		//		//Product Table
		//		PdfPTable pdfProductTable = CreateProductsGrid();


		//		outerOuterHeader.AddCell(outerHeader);
		//		//outerOuterHeader.AddCell(outerAddress);
		//		outerOuterHeader.AddCell(pdfProductTable);


		//		//document.Add(outerHeader);
		//		//document.Add(outerAddress);
		//		//document.Add(pdfProductTable);
		//		//document.Add(outerEstimateDetails);
		//		//document.Add(pdfNotes);
		//		document.Add(topicPdf);
		//		document.Add(outerOuterHeader);
		//		document.Close();
		//	}
		//	catch (Exception ex)
		//	{
		//		if (document.IsOpen())
		//		{
		//			document.CloseDocument();
		//		}

		//		MessageBox.Show("Error previwing Estimate :" + ex.Message);
		//	}
		//}

		private PdfPTable CreateNotesGrid()
		{
			PdfPTable pdfTable = new PdfPTable(1);
			pdfTable.DefaultCell.Padding = 3;
			pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTable.TotalWidth = 400f;
			pdfTable.WidthPercentage = 100;
			pdfTable.DefaultCell.BorderWidth = 0;
			pdfTable.SpacingAfter = 10;
			AddCustomCell(pdfTable, "Note:", 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.BOLD, 20f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, txtNoteForClient.Text, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 12, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, String.Empty, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 12, iTextSharp.text.Font.BOLD, 20f, PdfPCell.ALIGN_LEFT);

			return pdfTable;
		}

		private PdfPTable CreateEstimateAmountDetailsGrid()
		{
			PdfPTable pdfTable = new PdfPTable(2);
			pdfTable.DefaultCell.Padding = 3;
			pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTable.TotalWidth = 400f;
			pdfTable.WidthPercentage = 100;
			pdfTable.DefaultCell.BorderWidth = 0;
			pdfTable.SpacingAfter = 20;
			AddCustomCell(pdfTable, "Subtotal", 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, lblSubtotalValue.Text, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_RIGHT);
			AddCustomCell(pdfTable, "Service Tax ()", 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, lblTaxValue.Text, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_RIGHT);

			if (chkDiscount.Checked)
			{
				AddCustomCell(pdfTable, "Discount (" + txtDiscount.Text + ")", 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_LEFT);
				AddCustomCell(pdfTable, lblDiscountValue.Text, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_RIGHT);
			}

			AddCustomCell(pdfTable, "Shipping & Packaging", 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 40f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, txtShippingnPackaging.Text, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_RIGHT);

			if (chkRoundOff.Checked)
			{
				AddCustomCell(pdfTable, "Rounded off", 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_LEFT);
				AddCustomCell(pdfTable, lblRoundedOffValue.Text, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_RIGHT);
			}

			AddCustomCell(pdfTable, "Total Estimate", 1, 1, BaseColor.WHITE, new BaseColor(51, 102, 153), 14, iTextSharp.text.Font.NORMAL, 40f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, lblTotalValue.Text, 1, 1, BaseColor.WHITE, new BaseColor(51, 102, 153), 14, iTextSharp.text.Font.NORMAL, 40f, PdfPCell.ALIGN_RIGHT);
			AddCustomCell(pdfTable, Common.ConvertDecimalToWord(lblTotalValue.Text), 2, 2, BaseColor.DARK_GRAY, BaseColor.WHITE, 12, iTextSharp.text.Font.NORMAL, 40f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, String.Empty, 1, 2, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_RIGHT);

			return pdfTable;
		}

		private PdfPTable CreateAuthorizedSignatoryGrid()
		{
			PdfPTable pdfTable = new PdfPTable(2);
			pdfTable.DefaultCell.Padding = 3;
			pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTable.TotalWidth = 550f;
			pdfTable.WidthPercentage = 100;
			pdfTable.DefaultCell.BorderWidth = 0;
			pdfTable.SpacingAfter = 20;
			AddCustomCell(pdfTable, "Authorized Signatory ", 1, 1, BaseColor.BLACK, BaseColor.WHITE, 12, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, String.Empty, 8, 1, BaseColor.BLACK, BaseColor.WHITE, 12, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_LEFT);

			return pdfTable;
		}

		private PdfPTable CreateShippingAddressGrid()
		{
			var clientDetails = new Client(Convert.ToInt32(cmbClient.SelectedValue));
			var stateDetails = State.GetStateList(_appConnection, clientDetails.CountryID);

			PdfPTable pdfTable = new PdfPTable(1);
			pdfTable.DefaultCell.Padding = 3;
			pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTable.TotalWidth = 400f;
			pdfTable.WidthPercentage = 100;
			pdfTable.DefaultCell.BorderWidth = 0;

			if (clientDetails.ShipToDifferentAddress)
			{
				AddCustomCell(pdfTable, "Ship To: ", 1, 1, BaseColor.BLACK, BaseColor.WHITE, 12, iTextSharp.text.Font.BOLD, 20f, PdfPCell.ALIGN_LEFT);
				AddCustomCell(pdfTable, clientDetails.ClientName, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
				AddCustomCell(pdfTable, clientDetails.ShippingAddress, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
				var stateNames = stateDetails.Where(v => v.StateID == clientDetails.ShippingStateID).SingleOrDefault();
				string shippingAddress = string.Concat(clientDetails.ShippingCity, ",", stateNames.StateName, ",", clientDetails.ShippingZip, ",", clientDetails.Country);
				AddCustomCell(pdfTable, shippingAddress, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
				AddCustomCell(pdfTable, "Phone: " + clientDetails.Phone, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
				AddCustomCell(pdfTable, String.Empty, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
			}
			else
			{
				AddCustomCell(pdfTable, "Ship To: ", 1, 1, BaseColor.BLACK, BaseColor.WHITE, 12, iTextSharp.text.Font.BOLD, 20f, PdfPCell.ALIGN_LEFT);
				AddCustomCell(pdfTable, clientDetails.ClientName, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
				AddCustomCell(pdfTable, clientDetails.BillingAddress, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
				var stateNames = stateDetails.Where(v => v.StateID == clientDetails.StateID).SingleOrDefault();
				string billingAddress = string.Concat(clientDetails.City, ",", stateNames.StateName, ",", clientDetails.Zip, ",", clientDetails.Country);
				AddCustomCell(pdfTable, billingAddress, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
				AddCustomCell(pdfTable, "Phone: " + clientDetails.Phone, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
				AddCustomCell(pdfTable, String.Empty, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
			}

			return pdfTable;
		}

		private PdfPTable CreateBillingAddressGrid()
		{
			var clientDetails = new Client(Convert.ToInt32(cmbClient.SelectedValue));
			State st = new State();
			var stateDetails = State.GetStateList(_appConnection, Convert.ToInt32(clientDetails.CountryID));

			PdfPTable pdfTable = new PdfPTable(1);
			pdfTable.DefaultCell.Padding = 3;
			pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTable.TotalWidth = 350f;
			pdfTable.WidthPercentage = 100;
			pdfTable.DefaultCell.BorderWidth = 0;
			AddCustomCell(pdfTable, "Buyer ", 1, 1, BaseColor.BLACK, BaseColor.WHITE, 12, iTextSharp.text.Font.BOLD, 20f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, clientDetails.ClientName, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, clientDetails.BillingAddress, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
			var stateNames = stateDetails.Where(v => v.StateID == clientDetails.StateID).SingleOrDefault();
			string billingAddress = string.Concat(clientDetails.City, ", ", clientDetails.State, ", ", clientDetails.Country, ", ", clientDetails.Zip);
			AddCustomCell(pdfTable, billingAddress, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
			AddCustomCell(pdfTable, "Phone: " + clientDetails.Phone, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);

			//if (!String.IsNullOrEmpty(clientDetails.OtherClientDetails))
			//{
			//	AddCustomCell(pdfTable, clientDetails.OtherClientDetails, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
			//}

			//if (!String.IsNullOrEmpty(clientDetails.TIN))
			//{
			//	AddCustomCell(pdfTable, "TIN: " + clientDetails.TIN, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);
			//}

			//AddCustomCell(pdfTable, String.Empty, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 15f, PdfPCell.ALIGN_LEFT);

			return pdfTable;
		}

		private PdfPTable CreateEstimateGrid()
		{
			PdfPTable pdfTable = new PdfPTable(2);
			pdfTable.DefaultCell.Padding = 0;
			pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTable.TotalWidth = 400f;
			pdfTable.WidthPercentage = 100;
			pdfTable.DefaultCell.BorderColorLeft = BaseColor.WHITE;
			pdfTable.DefaultCell.BorderColorRight = BaseColor.WHITE;
			pdfTable.DefaultCell.BorderWidth = 1;
			pdfTable.SpacingBefore = 0;

			string currentdateformat = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + txtEstimateNumber.Text.ToString();

			Phrase phrase = new Phrase();
			phrase.Add(new Chunk("Purchase Order No. " + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk(currentdateformat, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);


			phrase = new Phrase();
			phrase.Add(new Chunk("Dated" + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk(DateTime.Now.Date.ToShortDateString(), new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			phrase = new Phrase();
			phrase.Add(new Chunk("Delivery Note" + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk("", new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			phrase = new Phrase();
			phrase.Add(new Chunk("Mode/Terms of Payment" + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk("", new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			phrase = new Phrase();
			phrase.Add(new Chunk("Supplier's Ref." + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk("", new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			phrase = new Phrase();
			phrase.Add(new Chunk("Other Reference(s)" + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk("", new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			phrase = new Phrase();
			phrase.Add(new Chunk("Buyer's Order No." + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk("", new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			phrase = new Phrase();
			phrase.Add(new Chunk("Dated" + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk("", new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			phrase = new Phrase();
			phrase.Add(new Chunk("Despatch Document No." + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk("", new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			phrase = new Phrase();
			phrase.Add(new Chunk("Payment Type" + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk(cmbPaymentType.SelectedText.ToString(), new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			phrase = new Phrase();
			phrase.Add(new Chunk("Despatched through." + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk("", new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			phrase = new Phrase();
			phrase.Add(new Chunk("Destination" + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk("", new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));
			AddCustomPhraseCell(pdfTable, phrase, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 28f, PdfPCell.ALIGN_LEFT);

			//AddCustomCell(pdfTable, "Terms of Delivery" + Chunk.NEWLINE, 1, 2, BaseColor.DARK_GRAY, BaseColor.WHITE, 10, iTextSharp.text.Font.NORMAL, 60f, PdfPCell.ALIGN_LEFT);

			//AddCustomCell(pdfTable, "Purchase Order No.", 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 24, iTextSharp.text.Font.NORMAL, 50f, PdfPCell.ALIGN_LEFT);
			//AddCustomCell(pdfTable, currentdateformat, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 24, iTextSharp.text.Font.NORMAL, 50f, PdfPCell.ALIGN_RIGHT);
			//AddCustomCell(pdfTable, "Amount Due", 1, 1, BaseColor.WHITE, new BaseColor(51, 102, 153), 14, iTextSharp.text.Font.NORMAL, 40f, PdfPCell.ALIGN_LEFT);

			//decimal amountDue = decimal.Zero;
			//if (chkMarkEstimatePaid.Checked)
			//{
			//	decimal amountPaid = String.IsNullOrEmpty(txtAmountPaid.Text) ? decimal.Zero : Convert.ToDecimal(txtAmountPaid.Text);
			//	amountDue = TotalValue - amountPaid;
			//}
			//else
			//{
			//	amountDue = TotalValue;
			//}

			//AddCustomCell(pdfTable, amountDue.ToString(), 1, 1, BaseColor.WHITE, new BaseColor(51, 102, 153), 14, iTextSharp.text.Font.NORMAL, 40f, PdfPCell.ALIGN_RIGHT);
			//AddCustomCell(pdfTable, "Estimate Date", 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 25f, PdfPCell.ALIGN_LEFT);
			//AddCustomCell(pdfTable, DateTime.Now.Date.ToString("MMMM dd,yyyy"), 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 25f, PdfPCell.ALIGN_RIGHT);
			//AddCustomCell(pdfTable, "Due Date", 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 25f, PdfPCell.ALIGN_LEFT);
			//AddCustomCell(pdfTable, Convert.ToDateTime(dtpDueDate.Value).ToString("MMMM dd,yyyy"), 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 25f, PdfPCell.ALIGN_RIGHT);
			//AddCustomCell(pdfTable, "P.O. Number", 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 25f, PdfPCell.ALIGN_LEFT);
			//AddCustomCell(pdfTable, txtPONumber.Text, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 25f, PdfPCell.ALIGN_RIGHT);
			//AddCustomCell(pdfTable, String.Empty, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 25f, PdfPCell.ALIGN_LEFT);
			//AddCustomCell(pdfTable, String.Empty, 1, 1, BaseColor.DARK_GRAY, BaseColor.WHITE, 14, iTextSharp.text.Font.NORMAL, 25f, PdfPCell.ALIGN_RIGHT);

			return pdfTable;
		}

		private PdfPTable CreateCompanyGrid()
		{

			PdfPTable pdfTableOuter = new PdfPTable(1);
			pdfTableOuter.SetWidths(new float[] { 350 });
			pdfTableOuter.DefaultCell.Padding = 0;
			pdfTableOuter.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTableOuter.TotalWidth = 350f;
			pdfTableOuter.WidthPercentage = 100;
			pdfTableOuter.DefaultCell.BorderWidth = 0;

			PdfPTable pdfTable = new PdfPTable(2);
			pdfTable.SetWidths(new float[] { 100, 250 });
			pdfTable.DefaultCell.Padding = 0;
			pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTable.TotalWidth = 350f;
			pdfTable.WidthPercentage = 100;
			pdfTable.DefaultCell.BorderWidth = 0;

			//AddCompanyInfo(pdfTable);

			//PdfPTable pdfempty = new PdfPTable(1);
			//pdfempty.SetWidths(new float[] { 350 });
			//pdfempty.DefaultCell.Padding = 1;
			//pdfempty.HorizontalAlignment = Element.ALIGN_LEFT;
			//pdfempty.TotalWidth = 350f;
			//pdfempty.WidthPercentage = 100;
			//pdfempty.DefaultCell.BorderWidth = 1;
			//pdfempty.AddCell(new PdfPCell(new Phrase(" ")));

			//pdfTableOuter.AddCell(pdfempty);

			pdfTableOuter.AddCell(pdfTable);

			//PdfPTable pdfBillingAddressTable = CreateBillingAddressGrid();
			//pdfTableOuter.AddCell(pdfBillingAddressTable);
			////PdfPTable pdfShippingAddressTable = CreateShippingAddressGrid();
			////pdfTableOuter.AddCell(pdfShippingAddressTable);

			return pdfTableOuter;
		}

		private void AddCompanyInfo(PdfPTable pdfTable)
		{
			try
			{
				PdfPTable pdfTableSubLeft = new PdfPTable(1);
				pdfTableSubLeft.DefaultCell.Padding = 1;
				pdfTableSubLeft.HorizontalAlignment = Element.ALIGN_LEFT;
				pdfTableSubLeft.TotalWidth = 75f;
				pdfTableSubLeft.WidthPercentage = 100;
				pdfTableSubLeft.DefaultCell.BorderWidth = 1;


				PdfPTable pdfTableSubRight = new PdfPTable(1);
				pdfTableSubRight.TotalWidth = 275f;
				pdfTableSubRight.WidthPercentage = 100;
				pdfTableSubRight.DefaultCell.BorderWidth = 1;
				pdfTableSubRight.HorizontalAlignment = Element.ALIGN_LEFT;
				pdfTableSubRight.DefaultCell.Padding = 1;

				string companyLogoFolderPath = Common.GetCompanyLogoFolderPath();
				var company = companyService.GetAllCompanyList().SingleOrDefault();
				string directoryImage = Path.GetDirectoryName(companyLogoFolderPath);
				directoryImage = Path.Combine(directoryImage, company.Logo);

				if (!String.IsNullOrEmpty(company.Logo) && File.Exists(directoryImage))
				{
					string logoUrl = directoryImage;
					Image image = Image.GetInstance(logoUrl);
					//Resize image depend upon your need
					image.ScaleToFit(70f, 60f);
					//Give some space after the image
					image.SpacingAfter = 2f;
					image.Alignment = Element.ALIGN_LEFT;
					PdfPCell imageCell = new PdfPCell(image);
					imageCell.Border = 0;
					pdfTableSubLeft.AddCell(imageCell);
				}
				else
				{
					AddCustomCell(pdfTableSubLeft, company.CompanyName, 1, 1, new BaseColor(51, 102, 153), BaseColor.WHITE, 15, iTextSharp.text.Font.NORMAL, 20f, PdfPCell.ALIGN_LEFT);
				}



				AddCompanyInfoHeaderCell(pdfTableSubRight, company.CompanyName, 1);
				AddCompanyInfoCell(pdfTableSubRight, company.Address, 1);
				string companyAddress = string.Concat(company.City, ",", company.State, ",", company.Zip, ",", company.Country);
				AddCompanyInfoCell(pdfTableSubRight, companyAddress, 1);
				AddCompanyInfoCell(pdfTableSubRight, "Phone: " + company.CompanyPhone, 1);
				AddCompanyInfoCell(pdfTableSubRight, "Email: " + company.Email, 1);

				//if (!String.IsNullOrEmpty(company.TIN))
				//{
				//	AddCompanyInfoCell(pdfTableSubRight, "TIN: " + company.TIN, 1);
				//}
				if (!String.IsNullOrEmpty(company.ServiceTaxNo))
				{
					AddCompanyInfoCell(pdfTableSubRight, "GSTIN/UIN: " + company.ServiceTaxNo, 1);
				}
				//if (!String.IsNullOrEmpty(company.PAN))
				//{
				//	AddCompanyInfoCell(pdfTableSubRight, "PAN: " + company.PAN, 1);
				//}

				pdfTable.AddCell(pdfTableSubLeft);
				pdfTable.AddCell(pdfTableSubRight);


			}
			catch (Exception ex)
			{

			}
		}

		private PdfPTable CreateProductsGrid()
		{

			PdfPTable rootPdfTable = new PdfPTable(1);
			rootPdfTable.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;
			rootPdfTable.DefaultCell.Padding = 0;
			rootPdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
			rootPdfTable.DefaultCell.BorderWidth = 0;
			rootPdfTable.TotalWidth = 550f;
			rootPdfTable.DefaultCell.MinimumHeight = 25f;
			rootPdfTable.LockedWidth = true;
			rootPdfTable.SpacingAfter = 0f;
			rootPdfTable.DefaultCell.Border = 0;
			float[] rootWidths = new float[] { 550f };
			rootPdfTable.SetWidths(rootWidths);



			PdfPTable pdfTable = new PdfPTable(6);
			pdfTable.DefaultCell.VerticalAlignment = Element.ALIGN_TOP;
			pdfTable.DefaultCell.Padding = 0;
			pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTable.DefaultCell.BorderWidth = 0;
			pdfTable.TotalWidth = 550f;
			pdfTable.LockedWidth = true;
			pdfTable.SpacingAfter = 0f;
			float[] widths = new float[] { 30f, 235f, 60f, 50f, 75f, 100f };
			pdfTable.SetWidths(widths);
			int count = 0;

			AddHeaderCell(pdfTable, "Sl No.", 1);
			AddHeaderCell(pdfTable, "Description of Goods", 1);
			AddHeaderCell(pdfTable, "Quantity", 1);
			AddHeaderCell(pdfTable, "Unit", 1);
			AddHeaderCell(pdfTable, "Rate", 1);
			AddHeaderCell(pdfTable, "Amount", 1);

			count = 1;
			PdfPCell pdfCell = new PdfPCell();
			int totalQuantity = 0;
			
			foreach (DataGridViewRow row in dgvEstimate.Rows)
			{
				totalQuantity = Convert.ToInt32(row.Cells[11].Value) + totalQuantity;
				
				pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
				AddGridCellValues(pdfTable, count.ToString(), 1, pdfCell);
				AddGridCellValues(pdfTable, row.Cells[9].Value.ToString() + " " + row.Cells[17].Value.ToString() + "   - " + row.Cells[15].Value.ToString(), 1, pdfCell);//Description
				pdfCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
				AddGridCellValues(pdfTable, row.Cells[11].Value.ToString(), 1, pdfCell);//quantity
				pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
				AddGridCellValues(pdfTable, row.Cells[19].Value.ToString(), 1, pdfCell);//Unit
				pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
				AddGridCellValues(pdfTable, row.Cells[12].Value.ToString(), 1, pdfCell);//Rate					
				AddGridCellValuesBold(pdfTable, row.Cells[13].Value.ToString(), 1, pdfCell);//Total Amount

				count++;
			}

			AddGridCellValues(pdfTable, "", 1, pdfCell);//S.No
			AddGridCellValues(pdfTable, "", 1, pdfCell);//Description
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//quantity
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//Unit
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//Rate					
			AddGridCellValuesBold(pdfTable, "--------------", 1, pdfCell);//Total Amount			

			AddGridCellValues(pdfTable, "", 1, pdfCell);//S.No
			AddGridCellValues(pdfTable, "", 1, pdfCell);//Description
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//quantity
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//Unit
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//Rate					
			AddGridCellValues(pdfTable, lblSubtotalValue.Text, 1, pdfCell);//Total Amount

			decimal taxValue = Convert.ToDecimal(lblTaxValue.Text);
			string cgst = Convert.ToString(taxValue / 2);
			string sgst = Convert.ToString(taxValue / 2);

			if (chkDiscount.Checked)
			{
				AddGridCellValues(pdfTable, "", 1, pdfCell); //S.No
				pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
				AddGridCellValuesBold(pdfTable, "Discount (" + txtDiscount.Text + "%)", 1, pdfCell); //Description
				AddGridCellValues(pdfTable, "", 1, pdfCell); //quantity
				pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
				AddGridCellValues(pdfTable, "", 1, pdfCell); //Unit
				pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
				AddGridCellValues(pdfTable, "", 1, pdfCell); //Rate					
				AddGridCellValuesBold(pdfTable, lblDiscountValue.Text, 1, pdfCell); //Total Amount
			}

			AddGridCellValues(pdfTable, "", 1, pdfCell);//S.No
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddGridCellValuesBold(pdfTable, "CENTERAL TAX (CGST) ", 1, pdfCell);//Description
			AddGridCellValues(pdfTable, "", 1, pdfCell);//quantity
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//Unit
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//Rate					
			AddGridCellValuesBold(pdfTable, cgst, 1, pdfCell);//Total Amount

			AddGridCellValues(pdfTable, "", 1, pdfCell);//S.No
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddGridCellValuesBold(pdfTable, "STATE TAX (SGST) ", 1, pdfCell);//Description
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//quantity
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//Unit
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddGridCellValues(pdfTable, "", 1, pdfCell);//Rate					
			AddGridCellValuesBold(pdfTable, sgst, 1, pdfCell);//Total Amount


			iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY);
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddCell(pdfTable, "", 1, pdfCell, times);
			AddCell(pdfTable, "Total", 1, pdfCell, times);
			times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
			AddCell(pdfTable, totalQuantity.ToString() + "(qty)", 1, pdfCell, times);
			AddCell(pdfTable, "", 1, pdfCell, times);
			AddCell(pdfTable, "", 1, pdfCell, times);
			AddCell(pdfTable, MDIForm.CurrencySymbol + " " + lblTotalValue.Text, 1, pdfCell, times);
			
			rootPdfTable.AddCell(pdfTable);

			PdfPTable pdfRupeeTable = new PdfPTable(2);
			pdfRupeeTable.DefaultCell.Padding = 0;
			pdfRupeeTable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfRupeeTable.DefaultCell.BorderWidth = 0;
			pdfRupeeTable.TotalWidth = 550f;			
			pdfRupeeTable.LockedWidth = true;
			pdfRupeeTable.SpacingAfter = 1f;
			widths = new float[] { 450f, 100f };
			pdfRupeeTable.SetWidths(widths);

			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY);
			AddCellwithoutBorder(pdfRupeeTable, "Amount Chargeable (in words)", 1, 1, pdfCell, times);
			times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.DARK_GRAY);
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddCellwithoutBorder(pdfRupeeTable, "E. & O.E", 1, 1, pdfCell, times);


			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
			AddCellwithoutBorder(pdfRupeeTable, Common.ConvertDecimalToWord(lblTotalValue.Text), 1, 1, pdfCell, times);
			times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.DARK_GRAY);
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddCellwithoutBorder(pdfRupeeTable, " ", 1, 1, pdfCell, times);

			rootPdfTable.AddCell(pdfRupeeTable);
			

			PdfPTable pdfTableTax = new PdfPTable(7);
			pdfTableTax.DefaultCell.Padding = 0;
			pdfTableTax.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTableTax.DefaultCell.BorderWidth = 0;
			pdfTableTax.TotalWidth = 550f;			
			pdfTableTax.LockedWidth = true;
			pdfTableTax.SpacingAfter = 1f;
			widths = new float[] { 100f, 80f, 70f, 70f, 70f, 70f, 90f };
			pdfTableTax.SetWidths(widths);

			decimal taxableValue = 0;
			decimal cGST = 0;
			decimal sGST = 0;

			int columnCount = 0;
			string columnHeaderTitle = string.Empty;
			foreach (DataGridViewColumn column in dgvTaxHandle.Columns)
			{				
				columnCount = columnCount + 1;

				if (columnCount == 1)
					columnHeaderTitle = "HSN/SAC";
				if (columnCount == 2)
					columnHeaderTitle = "Taxable Value";
				if (columnCount == 3)
					columnHeaderTitle = "CGST Rate";
				if (columnCount == 4)
					columnHeaderTitle = "CGST Amount";
				if (columnCount == 5)
					columnHeaderTitle = "SGST Rate";
				if (columnCount == 6)
					columnHeaderTitle = "SGST Amount";
				if (columnCount == 7)
					columnHeaderTitle = "Total Tax Amount";


				AddHeaderCell(pdfTableTax, columnHeaderTitle, 1);
			}
			times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY);
			foreach (DataGridViewRow row in dgvTaxHandle.Rows)
			{
				int i = 0;
				foreach (DataGridViewCell cell in row.Cells)
				{
					i = i + 1;
					if(i == 1)
						pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
					else
						pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;

					if(i == 2)
					{
						taxableValue = taxableValue + Convert.ToDecimal(cell.Value.ToString());
					}

					if (i == 4)
					{
						cGST = cGST + Convert.ToDecimal(cell.Value.ToString());
					}

					if (i == 6)
					{
						sGST = sGST + Convert.ToDecimal(cell.Value.ToString());
					}

					AddCell(pdfTableTax, cell.Value.ToString(), 1, pdfCell, times);
				}
			}

			decimal totalTaxValue = sGST + cGST;

			times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddCell(pdfTableTax, "Total", 1, pdfCell, times);
			AddCell(pdfTableTax, taxableValue.ToString(), 1, pdfCell, times);
			AddCell(pdfTableTax, " ", 1, pdfCell, times);
			AddCell(pdfTableTax, cGST.ToString(), 1, pdfCell, times);
			AddCell(pdfTableTax, " ", 1, pdfCell, times);
			AddCell(pdfTableTax, sGST.ToString(), 1, pdfCell, times);
			AddCell(pdfTableTax, Convert.ToString(totalTaxValue), 1, pdfCell, times);



			rootPdfTable.AddCell(pdfTableTax);

			PdfPTable pdfTaxRupeeTable = new PdfPTable(2);
			pdfTaxRupeeTable.DefaultCell.Padding = 0;
			pdfTaxRupeeTable.HorizontalAlignment = Element.ALIGN_LEFT;
			pdfTaxRupeeTable.DefaultCell.BorderWidth = 0;
			pdfTaxRupeeTable.TotalWidth = 550f;
			pdfTaxRupeeTable.LockedWidth = true;
			pdfTaxRupeeTable.SpacingAfter = 1f;
			widths = new float[] { 450f, 100f };
			pdfTaxRupeeTable.SetWidths(widths);

			Phrase phrase = new Phrase();
			phrase.Add(new Chunk(" Tax Amount (in words) : ", new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(Common.ConvertDecimalToWord(totalTaxValue.ToString()), new Font(iTextSharp.text.Font.FontFamily.COURIER, 11, iTextSharp.text.Font.BOLD)));
			
			pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
			AddCellwithoutBorderPhrase(pdfTaxRupeeTable, phrase, 1, 1, pdfCell, times);
            times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.DARK_GRAY);
            pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            AddCellwithoutBorder(pdfTaxRupeeTable, " ", 1, 1, pdfCell, times);

            rootPdfTable.AddCell(pdfTaxRupeeTable);

            pdfTaxRupeeTable = new PdfPTable(2);
            pdfTaxRupeeTable.DefaultCell.Padding = 0;
            pdfTaxRupeeTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTaxRupeeTable.DefaultCell.BorderWidth = 0;
            pdfTaxRupeeTable.TotalWidth = 550f;
            pdfTaxRupeeTable.LockedWidth = true;
            pdfTaxRupeeTable.DefaultCell.NoWrap = false;
            pdfTaxRupeeTable.SpacingAfter = 1f;
            widths = new float[] { 225f, 225f };
            pdfTaxRupeeTable.SetWidths(widths);


            phrase = new Phrase();
            phrase.Add(new Chunk(" Company's PAN     : " , new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
            phrase.Add(new Chunk(MDIForm.CompanyPan.ToString(), new Font(iTextSharp.text.Font.FontFamily.COURIER, 11, iTextSharp.text.Font.BOLD)));

            pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
            AddCellwithoutBorderPhrase(pdfTaxRupeeTable, phrase, 1, 1, pdfCell, times);
            times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.DARK_GRAY);
            pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            AddCellwithoutBorder(pdfTaxRupeeTable, " ", 1, 1, pdfCell, times);

            phrase = new Phrase();
            phrase.Add(new Chunk("Declaration " + Chunk.NEWLINE + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.UNDERLINE)));           
            phrase.Add(new Chunk("We declare that this Purchase Order shows the actual price of the " , new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL)));
            phrase.Add(new Chunk("goods described and that all particulars are true and correct.", new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL)));

            pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
            AddCellwithoutBorderPhrase(pdfTaxRupeeTable, phrase, 1, 1, pdfCell, times);
            phrase = new Phrase();
            phrase.Add(new Chunk("Company's Bank Details " + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL)));
            phrase.Add(new Chunk("Bank Name :", new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL)));
            phrase.Add(new Chunk(MDIForm.CompanyBankName.ToString() + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD)));
            phrase.Add(new Chunk("A/c No. :", new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL)));
            phrase.Add(new Chunk(MDIForm.CompanyBankAccountNumber.ToString() + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD)));
            phrase.Add(new Chunk("Bank IFSC Code :", new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL)));
            phrase.Add(new Chunk(MDIForm.CompanyBankIfscCode.ToString() + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD)));

            pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
            AddCellwithoutBorderPhrase(pdfTaxRupeeTable, phrase, 1, 1, pdfCell, times);


            rootPdfTable.AddCell(pdfTaxRupeeTable);

            pdfTaxRupeeTable = new PdfPTable(2);
            pdfTaxRupeeTable.DefaultCell.Padding = 0;
            pdfTaxRupeeTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTaxRupeeTable.DefaultCell.BorderWidth =  1f;
            pdfTaxRupeeTable.TotalWidth = 550f;
            pdfTaxRupeeTable.LockedWidth = true;
            pdfTaxRupeeTable.DefaultCell.NoWrap = false;
            pdfTaxRupeeTable.SpacingAfter = 1f;
            widths = new float[] { 225f, 225f };
            pdfTaxRupeeTable.SetWidths(widths);
            
            
            phrase = new Phrase();
            phrase.Add(new Chunk("Customer's Seal and Signature " + Chunk.NEWLINE + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL)));
          
            pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
            AddCellphrase(pdfTaxRupeeTable, phrase, 1, 1, pdfCell, times);
            pdfCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            phrase = new Phrase();
            phrase.Add(new Chunk("For " + MDIForm._CompanyName + Chunk.NEWLINE + Chunk.NEWLINE + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL)));
            phrase.Add(new Chunk("Authorised Signatory " + MDIForm._CompanyName + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL)));
            pdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
            AddCellphrase(pdfTaxRupeeTable, phrase, 1, 1, pdfCell, times);


			rootPdfTable.AddCell(pdfTaxRupeeTable);

			return rootPdfTable;
		}

		private PdfPTable AddInnerTableCell(PdfPTable table, string text, int rowspan, int colspan, PdfPCell cellHorizontalAlignment)
		{
			PdfPCell pdfCellva = new PdfPCell();
			pdfCellva.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			//Tables for Authorized Signatory and Estimate Amounts
			PdfPTable outerEstimateDetails = new PdfPTable(2);
			outerEstimateDetails.DefaultCell.BorderWidth = 0;
			outerEstimateDetails.TotalWidth = 750f;
			outerEstimateDetails.WidthPercentage = 100;
			outerEstimateDetails.SpacingAfter = 0f;
			outerEstimateDetails.HorizontalAlignment = Element.ALIGN_LEFT;
			iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY);

			AddCellwithoutBorder(outerEstimateDetails, "Amount Chargeable (in words)", 1,1, pdfCellva, times);
			times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.DARK_GRAY);
			pdfCellva.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			AddCellwithoutBorder(outerEstimateDetails, "E. & O.E", 1,1, pdfCellva, times);


            PdfPCell cell = new PdfPCell(outerEstimateDetails);
            cell.Rowspan = rowspan;
            cell.Colspan = colspan;
            cell.NoWrap = false;
            cell.FixedHeight = 20f;
            cell.HorizontalAlignment = cellHorizontalAlignment.HorizontalAlignment;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            table.AddCell(cell);



			times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);
			AddCellwithoutBorder(outerEstimateDetails, Common.ConvertDecimalToWord(lblTotalValue.Text), 1,2, pdfCellva, times);

            cell = new PdfPCell(outerEstimateDetails);
            cell.Rowspan = rowspan;
            cell.Colspan = colspan;
            cell.NoWrap = false;
            cell.FixedHeight = 20f;
            cell.HorizontalAlignment = cellHorizontalAlignment.HorizontalAlignment;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            table.AddCell(cell);
           
			//pdfCellva.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			//AddCellwithoutBorder(outerEstimateDetails, "", 1,1, pdfCellva, times);

			//PdfPTable pdfAuthorizedSignatoryTable = CreateAuthorizedSignatoryGrid();
			//outerEstimateDetails.AddCell(pdfAuthorizedSignatoryTable);
			//PdfPTable pdfEstimateAmountTable = CreateEstimateAmountDetailsGrid();
			//outerEstimateDetails.AddCell(pdfEstimateAmountTable);
			PdfPTable pdfNotes = CreateNotesGrid();
			//Adding all tables to the document

			//table.AddCell(outerEstimateDetails);
			//table.AddCell(pdfNotes);
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			

			cell = new PdfPCell(pdfNotes);
			cell.Rowspan = rowspan;
			cell.Colspan = colspan;
			cell.NoWrap = false;
			cell.FixedHeight = 20f;
			cell.HorizontalAlignment = cellHorizontalAlignment.HorizontalAlignment;
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

			table.AddCell(cell);
			return table;
		}


		private void AddHeaderCell(PdfPTable table, string text, int rowspan)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

			PdfPCell cell = new PdfPCell(new Phrase(text, times));
			cell.FixedHeight = 28f;
			cell.NoWrap = false;
			//cell.BackgroundColor = new BaseColor(51, 102, 153);
			cell.Rowspan = rowspan;
			cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
			cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
			table.AddCell(cell);
		}

		private void AddCustomCell(PdfPTable table, string text, int rowspan, int colSpan, BaseColor fontColor, BaseColor backgroundColor, int fontSize, int fontStyle, float fixedHeight, int horizontalAlignemnt)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, fontSize, fontStyle, fontColor);
			PdfPCell cell = new PdfPCell(new Phrase(text, times));
			cell.Border = 0;
			cell.NoWrap = false;
			cell.FixedHeight = fixedHeight;
			cell.BackgroundColor = backgroundColor;
			cell.Rowspan = rowspan;
			cell.Colspan = colSpan;
			cell.HorizontalAlignment = horizontalAlignemnt;
			cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
			table.AddCell(cell);
		}

		private void AddCustomPhraseCell(PdfPTable table, Phrase text, int rowspan, int colSpan, BaseColor fontColor, BaseColor backgroundColor, int fontSize, int fontStyle, float fixedHeight, int horizontalAlignemnt)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, fontSize, fontStyle, fontColor);
			PdfPCell cell = new PdfPCell(text);
			cell.NoWrap = false;
			cell.FixedHeight = fixedHeight;
			cell.BackgroundColor = backgroundColor;
			cell.Rowspan = rowspan;
			cell.Colspan = colSpan;
			cell.HorizontalAlignment = horizontalAlignemnt;
			cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
			table.AddCell(cell);
		}

		private void AddCompanyInfoHeaderCell(PdfPTable table, string text, int rowspan)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.DARK_GRAY);

			PdfPCell cell = new PdfPCell(new Phrase(text, times));
			//cell.FixedHeight = 10f;
			cell.NoWrap = false;
			cell.Rowspan = rowspan;
			cell.Border = 0;
			cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
			table.AddCell(cell);
		}

		private void AddCompanyInfoCell(PdfPTable table, string text, int rowspan)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY);

			PdfPCell cell = new PdfPCell(new Phrase(text, times));
			//cell.FixedHeight = 2f;
			cell.NoWrap = false;
			cell.Rowspan = rowspan;
			cell.Border = 0;
			cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
			table.AddCell(cell);
		}

		private void AddCell(PdfPTable table, string text, int rowspan, PdfPCell cellHorizontalAlignment, iTextSharp.text.Font fontType)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			PdfPCell cell = new PdfPCell(new Phrase(text, fontType));
			cell.Rowspan = rowspan;
			cell.NoWrap = false;
			cell.HorizontalAlignment = cellHorizontalAlignment.HorizontalAlignment;
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
			table.AddCell(cell);
		}

        private void AddCellphrase(PdfPTable table, Phrase phrase, int rowspan, int colspan, PdfPCell cellHorizontalAlignment, iTextSharp.text.Font fontType)
        {
            //BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            PdfPCell cell = new PdfPCell(phrase);
            cell.Rowspan = rowspan;
            cell.Colspan = colspan;
            cell.NoWrap = false;
            cell.HorizontalAlignment = cellHorizontalAlignment.HorizontalAlignment;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cell);
        }

		private void AddCellwithoutBorder(PdfPTable table, string text, int rowspan, int colspan, PdfPCell cellHorizontalAlignment, iTextSharp.text.Font fontType)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			PdfPCell cell = new PdfPCell(new Phrase(text, fontType));
			cell.Rowspan = rowspan;
			cell.Colspan = colspan;
			cell.Border = 0;
			cell.BorderColor = BaseColor.WHITE;
			cell.NoWrap = false;
			cell.HorizontalAlignment = cellHorizontalAlignment.HorizontalAlignment;
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
			table.AddCell(cell);
		}

		private void AddCellwithoutBorderPhrase(PdfPTable table, Phrase phrase, int rowspan, int colspan, PdfPCell cellHorizontalAlignment, iTextSharp.text.Font fontType)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			PdfPCell cell = new PdfPCell(phrase);
			cell.Rowspan = rowspan;
			cell.Colspan = colspan;
			cell.Border = 0;
            cell.BorderColor = BaseColor.WHITE;
			cell.NoWrap = false;

			cell.HorizontalAlignment = cellHorizontalAlignment.HorizontalAlignment;
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
			table.AddCell(cell);
		}


		private void AddGridCellValues(PdfPTable table, string text, int rowspan, PdfPCell cellHorizontalAlignment)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			//iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY);

			Phrase phrase = new Phrase();
			phrase.Add(new Chunk(text + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));


			PdfPCell cell = new PdfPCell(phrase);
			cell.NoWrap = false;
			cell.MinimumHeight = 20f;
			cell.Padding = 1;
			cell.Border = 1;
			cell.BorderWidthTop = 0;
			cell.BorderWidthBottom = 0;
			cell.BorderWidthLeft = .2f;
			cell.BorderWidthRight = .2f;
			cell.BorderColorBottom = BaseColor.WHITE;
			cell.BorderColorTop = BaseColor.WHITE;			
			cell.HorizontalAlignment = cellHorizontalAlignment.HorizontalAlignment;
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
			table.AddCell(cell);
			//table.AddCell(phrase);
		}

		private void AddGridCellBottomValues(PdfPTable table, string text, int rowspan, PdfPCell cellHorizontalAlignment)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			//iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY);

			Phrase phrase = new Phrase();
			phrase.Add(new Chunk(text + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));


			PdfPCell cell = new PdfPCell(phrase);
			cell.NoWrap = false;
			cell.MinimumHeight = 25f;
			cell.Padding = 5;
			cell.Border = 1;
			cell.BorderWidthTop = 0;
			cell.BorderWidthBottom = 0.2f;
			cell.BorderWidthLeft = .2f;
			cell.BorderWidthRight = .2f;
			cell.BorderColorBottom = BaseColor.BLACK;
			cell.BorderColorTop = BaseColor.WHITE;
			cell.HorizontalAlignment = cellHorizontalAlignment.HorizontalAlignment;
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
			table.AddCell(cell);
			//table.AddCell(phrase);
		}

		private void AddGridCellValuesBold(PdfPTable table, string text, int rowspan, PdfPCell cellHorizontalAlignment)
		{
			//BaseFont bfTimes = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			//iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY);

			Phrase phrase = new Phrase();
			phrase.Add(new Chunk(text + Chunk.NEWLINE, new Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD)));
			phrase.Add(new Chunk(string.Empty, new Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD)));


			PdfPCell cell = new PdfPCell(phrase);
			cell.NoWrap = false;
			cell.MinimumHeight = 25f;
			cell.Padding = 5;
			cell.Border = 1;
			cell.BorderWidthTop = 0;
			cell.BorderWidthBottom = 0;
			cell.BorderWidthLeft = .2f;
			cell.BorderWidthRight = .2f;
			cell.BorderColorBottom = BaseColor.WHITE;
			cell.BorderColorTop = BaseColor.WHITE;
			cell.HorizontalAlignment = cellHorizontalAlignment.HorizontalAlignment;
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
			table.AddCell(cell);
			//table.AddCell(phrase);
		}

		private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbClient.SelectedIndex != 0)
			{
				ClientName = cmbClient.Text;
				var clientDetails = new Client(Convert.ToInt32(cmbClient.SelectedValue));

				if (clientDetails == null)
				{
					MessageBox.Show("Error :" + "Loading client details failed");
				}
				else
				{
					ClientId = clientDetails.ClientId;
					var stateDetails = State.GetStateList(_appConnection, clientDetails.CountryID);

					if (clientDetails.ShipToDifferentAddress)
					{
						var stateName = stateDetails.Where(v => v.StateID == clientDetails.ShippingStateID).SingleOrDefault();
						lblShippingAddress.Text = String.Concat("Ship To: ", clientDetails.ShippingAddress, ", ", clientDetails.ShippingZip,
															" ", clientDetails.ShippingCity, ", ", stateName.StateName);
					}
					else
					{
						var stateName = stateDetails.Where(v => v.StateID == clientDetails.StateID).SingleOrDefault();
						lblShippingAddress.Text = String.Concat("Ship To: ", clientDetails.BillingAddress, ", ", clientDetails.Zip,
															" ", clientDetails.City, ", ", stateName.StateName);
					}

					BindProductDropdown();
					LoadTaxDropDown();
				}
			}
			else
			{
				cmbProduct.DataSource = null;
				cmbTax.DataSource = null;
				txtQuantity.Text = String.Empty;
				txtUnitPrice.Text = String.Empty;
				btnAdd.Enabled = false;
			}
		}

		private void chkDiscount_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDiscount.Checked)
			{
				txtDiscount.Enabled = true;
				pnlDiscount.Visible = true;
			}
			else
			{
				txtDiscount.Text = String.Empty;
				txtDiscount.Enabled = false;
				pnlDiscount.Visible = false;
			}
		}

		private void txtDiscount_TextChanged(object sender, EventArgs e)
		{
			CalculateEstimate();
		}

		private void cbShippingnPackaging_CheckedChanged(object sender, EventArgs e)
		{
			if (cbShippingnPackaging.Checked)
			{
				txtShippingnPackaging.Enabled = true;
				lblShippingAndPackValue.Text = String.Format("0.00");
				pnlShipping.Visible = true;
			}
			else
			{
				txtShippingnPackaging.Text = String.Empty;
				txtShippingnPackaging.Enabled = true;
				pnlShipping.Visible = false;
			}
		}

		private void txtShippingnPackaging_TextChanged(object sender, EventArgs e)
		{
			lblShippingAndPackValue.Text = txtShippingnPackaging.Text;
			CalculateEstimate();
		}

		private void chkMarkEstimatePaid_CheckedChanged(object sender, EventArgs e)
		{
			if (chkMarkEstimatePaid.Checked)
			{
				lblPaymentType.Visible = true;
				cmbPaymentType.Visible = true;
				lblAmountPaid.Visible = true;
				txtAmountPaid.Visible = true;
				lblNotes.Visible = true;
				txtNotes.Visible = true;
				cmbPaymentType.SelectedIndex = 0;
			}
			else
			{
				lblPaymentType.Visible = false;
				cmbPaymentType.Visible = false;
				lblAmountPaid.Visible = false;
				txtAmountPaid.Visible = false;
				lblNotes.Visible = false;
				txtNotes.Visible = false;
			}

			CalculateEstimate();
		}

		private void chkRoundOff_CheckedChanged(object sender, EventArgs e)
		{
			if (chkRoundOff.Checked)
			{
				pnlRoundedOff.Visible = true;

			}
			else
			{
				pnlRoundedOff.Visible = false;
				lblTotalValue.Text = Convert.ToString(TotalValue);
			}

			CalculateEstimate();
		}

		private void dgvEstimate_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == -1)
				return;

			if (dgvEstimate.Columns[e.ColumnIndex].Name == "Delete")
			{
				lstEstimateProduct.RemoveAt(e.RowIndex);
                dgvTaxHandle.Rows.RemoveAt(e.RowIndex);
				BindEstimateProductGrid();
			}
			if (dgvEstimate.Columns[e.ColumnIndex].Name == "Edit")
			{
                lstEstimateProduct.RemoveAt(e.RowIndex);
                dgvTaxHandle.Rows.RemoveAt(e.RowIndex);
				BindEstimateProductGrid();
			}
		}

		private void cmbPaymentTerms_SelectedIndexChanged(object sender, EventArgs e)
		{
			DateTime dtIssueDate = Convert.ToDateTime(dtpIssueDate.Value);
			int days = 0;

			if (cmbPaymentTerms.SelectedIndex == 0)
			{
				dtpDueDate.Enabled = true;
			}
			else if (cmbPaymentTerms.SelectedIndex == 1)
			{
				dtpDueDate.Value = dtIssueDate;
				dtpDueDate.Enabled = false;
			}
			else
			{
				days = Convert.ToInt32(cmbPaymentTerms.SelectedValue);
				dtpDueDate.Value = dtIssueDate.Date.AddDays(days);
				dtpDueDate.Enabled = false;
			}
		}

		private void btnPreviewEstimate_Click(object sender, EventArgs e)
		{
			GenerateEstimatePDF();
			PreviewEstimate previewEstimate = new PreviewEstimate();
			previewEstimate.EstimateId = String.IsNullOrEmpty(txtEstimateNumber.Text) ? 0 : Convert.ToInt32(txtEstimateNumber.Text);
			previewEstimate.EstimateFolderPath = EstimateFolderPath;
			previewEstimate.StartPosition = FormStartPosition.CenterParent;
			previewEstimate.ShowDialog(this);
		}

		//private void btnPreviewEstimate_Click(object sender, EventArgs e)
		//{
		//	string filePath = Path.Combine(EstimateFolderPath, string.Format("Estimate{0}.pdf", txtEstimateNumber.Text));

		//	if (File.Exists(filePath))
		//	{
		//		File.Delete(filePath);
		//	}

		//	string docName = string.Format("Estimate{0}.pdf", txtEstimateNumber.Text);
		//	GenerateEstimatePDF();
		//}

		private void btnSaveEstimate_Click(object sender, EventArgs e)
		{
			try
			{
				int EstimateId = string.IsNullOrEmpty(txtEstimateNumber.Text) ? 0 : Convert.ToInt32(txtEstimateNumber.Text);
				var EstimateDetails = new Estimate(EstimateId);
				var comapnyDetails = (from company in companyService.GetAllCompanyList()
									 .Where(v => v.Status == true)
									  select company).SingleOrDefault();

				Estimate Estimate = new Estimate();
				Estimate.EstimateId = EstimateId;
				Estimate.CompanyId = comapnyDetails.CompanyId;
				Estimate.ClientId = ClientId;
				Estimate.IssueDate = dtpIssueDate.Value.Date;

				string currentdateformat = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + EstimateId.ToString();

				Estimate.EstimateNo = currentdateformat; //string.IsNullOrEmpty(txtPONumber.Text) ? String.Empty : txtPONumber.Text;
				Estimate.PaymentTermId = Convert.ToInt32(cmbPaymentTerms.SelectedValue);
				Estimate.DueDate = dtpDueDate.Value.Date;
				Estimate.Discount = string.IsNullOrEmpty(txtDiscount.Text) ? decimal.Zero : Convert.ToDecimal(txtDiscount.Text);
				Estimate.RoundOffTotal = chkRoundOff.Checked;
				Estimate.MarkEstimatePaid = chkMarkEstimatePaid.Checked;
				Estimate.PaymentDate = DateTime.Now.Date;
				if (chkMarkEstimatePaid.Checked)
				{
					Estimate.PaymentTypeId = Convert.ToInt32(cmbPaymentType.SelectedValue);
					Estimate.AmountPaid = string.IsNullOrEmpty(txtAmountPaid.Text) ? decimal.Zero : Convert.ToDecimal(txtAmountPaid.Text);

					if (EstimateDetails == null || EstimateDetails.EstimateId == 0)
					{
						Estimate.PaymentDate = DateTime.Now.Date;
					}
					else
					{
						if (EstimateDetails.AmountPaid > 0)
						{
							if (EstimateDetails.AmountPaid == Estimate.AmountPaid)
							{
								Estimate.PaymentDate = EstimateDetails.PaymentDate;
							}
							else
							{
								Estimate.PaymentDate = DateTime.Now.Date;
							}
						}
					}
					string paymentStatus = String.Empty;

					if (Estimate.AmountPaid == 0)
					{
						paymentStatus = ePaymentStatus.Unpaid.ToString();
					}
					else if (Estimate.AmountPaid > 0)
					{
						if (Estimate.AmountPaid < TotalValue)
						{
							paymentStatus = ePaymentStatus.Partial.ToString();
						}
						else if (Estimate.AmountPaid == TotalValue)
						{
							paymentStatus = ePaymentStatus.Paid.ToString();
						}
						else
						{
							paymentStatus = ePaymentStatus.Paid.ToString();
						}
					}

					if (Estimate.PaymentDate.Date > Estimate.DueDate.Date)
					{
						if (String.IsNullOrEmpty(paymentStatus))
						{
							paymentStatus = String.Concat(paymentStatus, ",", ePaymentStatus.Overdue.ToString());
						}
						else
						{
							paymentStatus = ePaymentStatus.Overdue.ToString();
						}
					}

					Estimate.PaymentStatus = paymentStatus;
				}
				else
				{
					Estimate.PaymentTypeId = 0;
					Estimate.AmountPaid = decimal.Zero;
				}

				Estimate.Notes = string.IsNullOrEmpty(txtNotes.Text) ? String.Empty : txtNotes.Text;
				Estimate.TotalAmount = TotalValue;
				Estimate.NotesForClient = string.IsNullOrEmpty(txtNoteForClient.Text) ? String.Empty : txtNoteForClient.Text;
				Estimate.PrivateNotes = string.IsNullOrEmpty(txtprivateNotes.Text) ? String.Empty : txtprivateNotes.Text;
				Estimate.Status = true;

				if (EstimateDetails == null || EstimateDetails.EstimateId == 0)
				{
					TransactionResult result = null;
					result = Estimate.Commit(ScreenMode.Add);

					lstEstimateProduct = lstEstimateProduct.OrderBy(s => s.EstimateProductId).ToList<EstimateProduct>();
					for (int i = 0; i < lstEstimateProduct.Count; i++)
					{
						EstimateProduct EstimateProduct = new EstimateProduct();
						EstimateProduct.EstimateId = Estimate.EstimateId; //lstEstimateProduct[i].EstimateId;
						EstimateProduct.ProductId = lstEstimateProduct[i].ProductId;
						EstimateProduct.ProductName = lstEstimateProduct[i].ProductName;
						EstimateProduct.Description = lstEstimateProduct[i].Description;
						EstimateProduct.Quantity = lstEstimateProduct[i].Quantity;
						EstimateProduct.TaxId = lstEstimateProduct[i].TaxId;
						EstimateProduct.TaxValue = lstEstimateProduct[i].TaxValue;
						EstimateProduct.UnitPrice = lstEstimateProduct[i].UnitPrice;
						EstimateProduct.TotalPrice = lstEstimateProduct[i].TotalPrice;
						EstimateProduct.MaterialName = lstEstimateProduct[i].MaterialName;
						EstimateProduct.UnitID = lstEstimateProduct[i].UnitID;
						EstimateProduct.UnitCode = lstEstimateProduct[i].UnitCode;

						TransactionResult resultEstimateProduct = null;
						resultEstimateProduct = EstimateProduct.Commit(ScreenMode.Add);
						//Estimateervice.AddEstimateProducts(EstimateProduct);
					}
				}
				else
				{
					TransactionResult result = null;
					result = Estimate.Commit(ScreenMode.Edit);

					//Estimateervice.UpdateEstimate(Estimate);

					for (int i = 0; i < lstEstimateProduct.Count; i++)
					{
						EstimateProduct EstimateProduct = new EstimateProduct();
						EstimateProduct.EstimateId = Estimate.EstimateId; // lstEstimateProduct[i].EstimateId;
						EstimateProduct.ProductId = lstEstimateProduct[i].ProductId;
						EstimateProduct.ProductName = lstEstimateProduct[i].ProductName;
						EstimateProduct.Description = lstEstimateProduct[i].Description;
						EstimateProduct.Quantity = lstEstimateProduct[i].Quantity;
						EstimateProduct.TaxId = lstEstimateProduct[i].TaxId;
						EstimateProduct.TaxValue = lstEstimateProduct[i].TaxValue;
						EstimateProduct.UnitPrice = lstEstimateProduct[i].UnitPrice;
						EstimateProduct.TotalPrice = lstEstimateProduct[i].TotalPrice;

						EstimateProduct.MaterialName = lstEstimateProduct[i].MaterialName;
						EstimateProduct.MaterialCode = lstEstimateProduct[i].MaterialCode;
						EstimateProduct.UnitCode = lstEstimateProduct[i].UnitCode;


						TransactionResult resultEstimateProduct = null;
						resultEstimateProduct = EstimateProduct.Commit(ScreenMode.Edit);
					}
				}

				CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_ADD_Estimate_MESSAGE, Estimate.EstimateId),
															  Constants.CONSTANT_INFORMATION,
															  CustomMessageBox.eDialogButtons.OK,
															  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));

				btnPreviewEstimate_Click(sender, e);
				//this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Saving Estimate: " + ex.Message);
			}
		}

		private void dtpDueDate_ValueChanged(object sender, EventArgs e)
		{
			if (sender != null && sender.GetType() == typeof(DateTimePicker))
			{
				dtpDueDate.Format = DateTimePickerFormat.Custom;
				dtpDueDate.CustomFormat = "dd/MM/yyyy";
			}
		}

		private void ddlMaterial_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlMaterial.SelectedIndex != 0)
			{
				int materialId = Convert.ToInt32(ddlMaterial.SelectedValue);
				Material materialObj = new Material(materialId, true);
				lblMaterialCode.Text = materialObj.MaterialCode;
				txtQuantity.Text = Convert.ToString("1");
				txtUnitPrice.Text = Convert.ToString(materialObj.MaterialRate);
				cmbTax.SelectedValue = materialObj.TaxID;
				lblUnitValue.Text = materialObj.Unit;
				unitID = materialObj.UnitID;
				unitCode = materialObj.Unit;
				btnAdd.Enabled = true;
			}
			else
			{
				btnAdd.Enabled = false;
			}
		}

		private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsDigit(e.KeyChar)))
			{
				Keys key = (Keys)e.KeyChar;
				if (!(key == Keys.Back || key == Keys.Delete))
				{
					e.Handled = true;
				}
			}
			else
			{
				e.Handled = false;
			}
		}

        private void dgvEstimate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SettingGridColumnOrder()
        {
            tMaterialCode.DisplayIndex = 0;
            tTaxableValue.DisplayIndex = 1;
            tCGSTPercentage.DisplayIndex = 2;
            tCGSTAmount.DisplayIndex = 3;
            tSGSTPercentage.DisplayIndex = 4;
            tSGSTAmount.DisplayIndex = 5;
            tTotalTaxAmount.DisplayIndex = 6;
        }
	}
}
