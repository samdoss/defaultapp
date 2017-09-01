using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.CommonLayer
{
	public static class Common
	{

        static string Number = String.Empty;
        static string deciml = String.Empty;
        static string _number = String.Empty;
        static string _deciml = String.Empty;
        static string[] US = new string[1003];
        static string[] SNu = new string[20];
        static string[] SNt = new string[10];

        public static void SetFormCoordinate(Form form)
        {
            form.Left = (form.MdiParent.ClientRectangle.Width - form.Width) / 2;
            form.Top = (form.MdiParent.ClientRectangle.Height - form.Height) / 2;
        }

        public static void SetDialogCoordinate(Form form)
        {
            var parentForm = form;
            if(form.MdiParent != null)
                parentForm = form.MdiParent.MdiChildren[0];
            else
                parentForm = form.Owner.MdiChildren[0];
            form.Left = parentForm.Left;
            form.Top = parentForm.Top;
        }

        public static void SetLargeDialogCoordinate(Form form)
        {
	        if (form.MdiParent != null)
	        {
				var childForm = form.MdiParent.MdiChildren[0];
				var parentForm = form.MdiParent.MdiChildren[0].ParentForm;
		        form.Left = childForm.Left; //- parentForm.Left;
		        form.Top = childForm.Top / 2 + parentForm.Top;
	        }
	        else
	        {
				var childForm = form.Owner.MdiChildren[0];
		        var parentForm = form.Owner.MdiChildren[0].ParentForm;
				form.Left = childForm.Left; //- parentForm.Left;
		        form.Top = childForm.Top / 2 + parentForm.Top;    
	        }
        }

        public static string GetCompanyLogoFolderPath()
        {
            string absolutePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            if (absolutePath.EndsWith("\\bin\\Debug"))
            {
                absolutePath = absolutePath.Replace("\\bin\\Debug", "");
            }

            string imagePath = System.IO.Path.Combine(absolutePath, Constants.CONSTANT_IMAGES, Constants.CONSTANT_CompanyLogo);

            return imagePath;
        }

        public static string ConvertDecimalToWord(string amount)
        {
            string currency = String.Empty;
            string _currency = " Paise Only";
            Initialize();
            amount = String.Format("{0:0.00}", Convert.ToDecimal(amount));

            if (Convert.ToDouble(amount) == 0)
            {
                return String.Empty;
            }

            if (Convert.ToDouble(amount) < 0)
            {
                return String.Empty;
            }

            string[] no = amount.Split('.');

            if ((no[0] != null) && (no[1] != "00"))
            {
                Number = no[0];
                deciml = no[1];
                _number = (NameOfNumber(Number));
                _deciml = (NameOfNumber(deciml));

                return currency + _number.Trim() + " Rupees And " + _deciml.Trim() + _currency;
            }

            if ((no[0] != null) && (no[1] == "00"))
            {
                Number = no[0];
                _number = (NameOfNumber(Number));

                return currency + _number + " Rupees Only";
            }

            if ((Convert.ToDouble(no[0]) == 0) && (no[1] != null))
            {
                deciml = no[1];
                _deciml = (NameOfNumber(deciml));

                return _deciml + _currency;
            }

            return String.Empty;
        }

        public static string NameOfNumber(string Number)
        {
            string GroupName = String.Empty;
            string OutPut = String.Empty;

            if ((Number.Length % 3) != 0)
            {
                Number = Number.PadLeft((Number.Length + (3 - (Number.Length % 3))), '0');
            }

            string[] Array = new string[Number.Length / 3];
            Int16 Element = -1;
            Int32 DisplayCount = -1;
            bool LimitGroupsShowAll = false;
            int LimitGroups = 0;
            bool GroupToWords = true;

            for (Int16 Count = 0; Count <= Number.Length - 3; Count += 3)
            {
                Element += 1;
                Array[Element] = Number.Substring(Count, 3);
            }

            if (LimitGroups == 0)
            {
                LimitGroupsShowAll = true;
            }

            for (Int16 Count = 0; (Count <= ((Number.Length / 3) - 1)); Count++)
            {
                DisplayCount++;

                if (((DisplayCount < LimitGroups) || LimitGroupsShowAll))
                {
                    if (Array[Count] == "000") continue;

                    {
                        GroupName = US[((Number.Length / 3) - 1) - Count + 1];
                    }

                    if ((GroupToWords == true))
                    {
                        OutPut += Group(Array[Count]).TrimEnd(' ') + " " + GroupName + " ";
                    }

                    else
                    {
                        OutPut += Array[Count].TrimStart('0') + " " + GroupName;
                    }
                }
            }

            Array = null;

            return OutPut;
        }

        private static string Group(string Argument)
        {
            string Hyphen = "";
            string OutPut = "";
            Int16 d1 = Convert.ToInt16(Argument.Substring(0, 1));
            Int16 d2 = Convert.ToInt16(Argument.Substring(1, 1));
            Int16 d3 = Convert.ToInt16(Argument.Substring(2, 1));

            if ((d1 >= 1))
            {
                OutPut += SNu[d1] + " Hundred ";
            }

            if ((double.Parse(Argument.Substring(1, 2)) < 20))
            {
                OutPut += SNu[Convert.ToInt16(Argument.Substring(1, 2))];
            }

            if ((double.Parse(Argument.Substring(1, 2)) >= 20))
            {
                if (Convert.ToInt16(Argument.Substring(2, 1)) == 0)
                {
                    Hyphen += " ";
                }
                else
                {
                    Hyphen += " ";
                }

                OutPut += SNt[d2] + Hyphen + SNu[d3];
            }

            return OutPut;
        }

        private static void Initialize()
        {
            SNu[0] = "";
            SNu[1] = "One";
            SNu[2] = "Two";
            SNu[3] = "Three";
            SNu[4] = "Four";
            SNu[5] = "Five";
            SNu[6] = "Six";
            SNu[7] = "Seven";
            SNu[8] = "Eight";
            SNu[9] = "Nine";
            SNu[10] = "Ten";
            SNu[11] = "Eleven";
            SNu[12] = "Twelve";
            SNu[13] = "Thirteen";
            SNu[14] = "Fourteen";
            SNu[15] = "Fifteen";
            SNu[16] = "Sixteen";
            SNu[17] = "Seventeen";
            SNu[18] = "Eighteen";
            SNu[19] = "Nineteen";
            SNt[2] = "Twenty";
            SNt[3] = "Thirty";
            SNt[4] = "Forty";
            SNt[5] = "Fifty";
            SNt[6] = "Sixty";
            SNt[7] = "Seventy";
            SNt[8] = "Eighty";
            SNt[9] = "Ninety";
            US[1] = "";
            US[2] = "Thousand";
            US[3] = "Million";
            US[4] = "Billion";
            US[5] = "Trillion";
            US[6] = "Quadrillion";
            US[7] = "Quintillion";
            US[8] = "Sextillion";
            US[9] = "Septillion";
            US[10] = "Octillion";
        }
		/// <summary>
		/// Get all user path
		/// </summary>
		/// <returns></returns>
		public static string GetAllUserPath()
		{
			string allUserPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			allUserPath = Path.Combine(allUserPath, "ERP");
			allUserPath = Path.Combine(allUserPath, "default");
			return allUserPath;
		}

		/// <summary>
		/// Get all user AppPath Alone
		/// </summary>
		/// <returns></returns>
		public static string GetAllUserAppPath()
		{
			string allUserPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			return allUserPath;
		}

        /// <summary>
        /// CheckNull
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string CheckNull(object obj)
        {
            if (obj != null)
                return obj.ToString();
            else
                return string.Empty;
        }

        /// <summary>
        /// CheckIntNull
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int CheckIntNull(object obj)
        {
            if (!string.IsNullOrEmpty(obj.ToString()))
                return Convert.ToInt32(obj, null);
            else
                return 0;
        }

        /// <summary>
        /// CheckBlank
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns></returns>
        public static string CheckBlank(string checkString)
        {
            if (checkString.Trim().Length == 0)
                return "--";
            else
                return checkString;
        }
        /// <summary>
        /// ValidateDate
        /// </summary>
        /// <param name="date"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool ValidateDate(String date, String format)
        {
            try
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = format;
                DateTime dt = DateTime.ParseExact(date, "d", dtfi);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
	}
}
