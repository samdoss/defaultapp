using ERP.CommonLayer;
using ERP.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ERPWinApp
{
    public partial class frmAttendance : Form
    {
        string a;
        string b;
        EmployeeDL employeeService;
        public frmAttendance()
        {
            InitializeComponent();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeDL();
            DataSet dsContractor = new DataSet();

            gvAttendance.DataSource = employeeService.GetEmployeeList(MDIForm.CompanyID).Tables[0];
            generate();
            int t;
            for (t = 0; t <= gvAttendance.Columns.Count - 1; t++)
            {
                gvAttendance.Columns[0].Visible = false;
                if (t == 0 || t == 1)
                {
                    gvAttendance.Columns[t].SortMode = DataGridViewColumnSortMode.NotSortable;
                    gvAttendance.Columns[t].ReadOnly = true;
                    gvAttendance.Columns[t].DefaultCellStyle.BackColor = Color.White;
                    gvAttendance.Columns[t].Width = 450;
                }
                else
                {
                    gvAttendance.Columns[t].SortMode = DataGridViewColumnSortMode.NotSortable;
                    gvAttendance.Columns[t].DefaultCellStyle.BackColor = Color.GreenYellow;
                    gvAttendance.Columns[t].Width = 170;
                }
                gvAttendance.Columns[5].Visible = false;
            }
            data();

        }

        public void data()
        {

            int t;
            int u;
            int employeID = 0;
            //DateTime dt1 ;
            string dt1 = "";
            for (u = 2; u <= gvAttendance.Columns.Count - 2; u++)
            {
                for (int i = 0; i <= gvAttendance.Rows.Count - 1; i++)
                {
                    employeID = Convert.ToInt32(gvAttendance.Rows[i].Cells[0].Value);

                    string dateValuestr = gvAttendance.Columns[u].HeaderText.ToString();

                    DateTime iValue;
                    iValue = DateTime.Now;
                    a = string.Format("{0:d2}", iValue.Day) + "/" + string.Format("{0:d2}", iValue.Month) + "/" + iValue.Year;

                    if (gvAttendance.Columns[u].HeaderText.ToString() == a)
                    {
                        gvAttendance.Columns[u].ReadOnly = false;
                    }
                    else
                    {
                        gvAttendance.Columns[u].ReadOnly = true;
                    }



                    string d = dateValuestr;
                    DateTime dtstr = DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    // for both "1/1/2000" or "25/1/2000" formats
                    string newString = dtstr.ToString("MM/dd/yyyy");

                    AttendanceDL oDal = new AttendanceDL();
                    DataTable dt = new DataTable();
                    dt = oDal.getAttendanceByDate(DateTime.Parse(newString), employeID, MDIForm.CompanyID);

                    if (dt.Rows.Count > 0)
                    {
                        //Forenoon, Afternoon, FullDay
                        if (dt.Rows[0]["FullDay"].ToString().ToLower() == "true")
                        {
                            gvAttendance.Rows[i].Cells[u].Value = true;
                        }
                        else
                        {
                            gvAttendance.Rows[i].Cells[u].Value = false;
                        }

                    }
                }
            }
        }

        public void generate()
        {
            DateTime i;
            DateTime j;
            string s;
            int t;
            //int[] a = new int[4];

            //DataTable dt1;

            //dt1 = d1.DisplayGrid("select convert(varchar,SDate,101) ,convert(varchar,EDate,101) from semester");
            //i = DateTime.Parse(dt1.Rows[0][0].ToString());
            //j = DateTime.Parse(dt1.Rows[0][1].ToString());

            DateTime dtTime = new DateTime();
            dtTime = DateTime.Now;
            i = Convert.ToDateTime(dtTime.AddDays(-2).ToShortDateString()); // FirstDayOfMonthFromDateTime(DateTime.Now);
            j = Convert.ToDateTime(dtTime.AddDays(1).ToShortDateString()); // LastDayOfMonthFromDateTime(DateTime.Now);

            while (i.CompareTo(j) != 0)
            {
                DataGridViewCheckBoxColumn dg = new DataGridViewCheckBoxColumn();
                dg.Name = "chkcol";
                dg.HeaderText = string.Format("{0:d2}", i.Day) + "/" + string.Format("{0:d2}", i.Month) + "/" + i.Year;
                dg.Width = 30;
                gvAttendance.Columns.Add(dg);

                i = i.Date.AddDays(1);
            }
            gvAttendance.Columns.Add("Total", "Total");
        }

        public DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        private void gvAttendance_Scroll(object sender, ScrollEventArgs e)
        {
            int t;
            for (t = 0; t <= 1; t++)
            {
                gvAttendance.Columns[t].Frozen = true;
            }
        }

        private void gvAttendance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            int u;
            int k;

            for (i = 0; i <= gvAttendance.Rows.Count - 1; i++)
            {
                k = 0;
                for (u = 2; u <= gvAttendance.Columns.Count - 2; u++)
                {
                    if (gvAttendance.Rows[i].Cells[u].Value != null)
                    {
                        k = k + 1;
                    }
                }
                if (k == 0)
                {
                    gvAttendance.Rows[i].Cells["Total"].Value = 0;
                }
                else
                {
                    gvAttendance.Rows[i].Cells["Total"].Value = k;
                }

            }
        }

        private void gvAttendance_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            a = gvAttendance.Columns[e.ColumnIndex].HeaderText;
            b = e.ColumnIndex.ToString();
            int t;

            for (t = 2; t <= gvAttendance.Columns.Count - 2; t++)
            {
                if (gvAttendance.Columns[t].HeaderText == gvAttendance.Columns[e.ColumnIndex].HeaderText)
                {
                    gvAttendance.Columns[t].ReadOnly = false;
                    gvAttendance.Columns[t].DefaultCellStyle.BackColor = Color.DarkTurquoise;
                }
                else
                {
                    gvAttendance.Columns[t].ReadOnly = true;
                    gvAttendance.Columns[t].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if ((chkAll.Checked))
            {
                int t;
                for (t = 2; t <= gvAttendance.Columns.Count - 2; t++)
                {
                    string g = gvAttendance.Columns[t].HeaderText.ToString();

                    //DateTime d;
                    //d = DateTime.Parse(gvAttendance.Columns[t].HeaderText);
                    if (g.CompareTo(a) == 0)
                    {
                        int i;
                        for (i = 0; i <= gvAttendance.Rows.Count - 1; i++)
                        {
                            gvAttendance.Rows[i].Cells[t].Value = true;
                        }
                    }
                }
            }
            else
            {
                int t;
                for (t = 2; t <= gvAttendance.Columns.Count - 2; t++)
                {
                    //DateTime d;
                    //d = DateTime.Parse(gvAttendance.Columns[t].HeaderText);
                    string g = gvAttendance.Columns[t].HeaderText.ToString();
                    if (g.CompareTo(a) == 0)
                    {
                        int i;
                        for (i = 0; i <= gvAttendance.Rows.Count - 1; i++)
                        {
                            gvAttendance.Rows[i].Cells[t].Value = false;
                        }
                    }
                }
            }
        }

        private void txtDateofPurchase_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btSaveItems_Click(object sender, EventArgs e)
        {
            DateTime dtstr = DateTime.ParseExact(a, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            // for both "1/1/2000" or "25/1/2000" formats
            string newString = dtstr.ToString("MM/dd/yyyy");
            string s = newString;
            int gridColumn = 0;
            int t;
            for (t = 2; t <= gvAttendance.Columns.Count - 1; t++)
            {
                //DateTime d;
                //d = DateTime.Parse(gvAttendance.Columns[t].HeaderText);
                string g = gvAttendance.Columns[t].HeaderText.ToString();
                if (g.CompareTo(a) == 0)
                {
                    gridColumn = t;
                    //int i;
                    //for (i = 0; i <= gvAttendance.Rows.Count - 1; i++)
                    //{
                    //    gvAttendance.Rows[i].Cells[t].Value = false;
                    //}
                }
            }
            int tt = 0;

            for (tt = 0; tt <= gvAttendance.Rows.Count - 1; tt++)
            {
                AttendanceDL attendanceObj = new AttendanceDL();
                attendanceObj.AttendanceDate = Convert.ToDateTime(s);

                if (gvAttendance.Rows[tt].Cells[gridColumn].Value == null || gvAttendance.Rows[tt].Cells[gridColumn].Value.ToString().ToLower() == "false")
                {
                   
                    attendanceObj.EmployeeID = Convert.ToInt32(gvAttendance.Rows[tt].Cells["ID"].Value.ToString());
                    attendanceObj.CompanyID = MDIForm.CompanyID;
                    if (gvAttendance.Rows[tt].Cells[gridColumn].Value.ToString().ToLower() == "false")
                    {
                        attendanceObj.Forenoon = false;
                    }
                    else
                    {
                        attendanceObj.Forenoon = true;
                    }
                    if (gvAttendance.Rows[tt].Cells[gridColumn].Value.ToString().ToLower() == "false")
                    {
                        attendanceObj.Afternoon = false;
                    }
                    else
                    {
                        attendanceObj.Afternoon = true;
                    }
                    if (gvAttendance.Rows[tt].Cells[gridColumn].Value.ToString().ToLower() == "false")
                    {
                        attendanceObj.FullDay = false;
                    }
                    else
                    {
                        attendanceObj.FullDay = true;
                    }
                    TransactionResult result = null;
                    result = attendanceObj.Commit(ScreenMode.Delete);
                    result = attendanceObj.Commit(ScreenMode.Add); 
                 
                    
                }
                else
                {
                    attendanceObj.EmployeeID = Convert.ToInt32(gvAttendance.Rows[tt].Cells["ID"].Value.ToString());
                    attendanceObj.CompanyID = MDIForm.CompanyID;

                    if (gvAttendance.Rows[tt].Cells[gridColumn].Value.ToString().ToLower() == "false")
                    {
                        attendanceObj.Forenoon = false;
                    }
                    else
                    {
                        attendanceObj.Forenoon = true;
                    }
                    if (gvAttendance.Rows[tt].Cells[gridColumn].Value.ToString().ToLower() == "false")
                    {
                        attendanceObj.Afternoon = false;
                    }
                    else
                    {
                        attendanceObj.Afternoon = true;
                    }
                    if (gvAttendance.Rows[tt].Cells[gridColumn].Value.ToString().ToLower() == "false")
                    {
                        attendanceObj.FullDay = false;
                    }
                    else
                    {
                        attendanceObj.FullDay = true;
                    }

                    TransactionResult result = null;
                    result = attendanceObj.Commit(ScreenMode.Delete);
                    result = attendanceObj.Commit(ScreenMode.Add); 
                }

                //d1.Delete("delete from attendence where no=" + gvAttendance.Rows[t].Cells["emp_code"].Value.ToString() + " and convert(varchar,d,101)='" + d.ToString() + "'");
            }

            for (t = 0; t <= gvAttendance.Rows.Count - 1; t++)
            {
                //d1.Insert("Insert into attendance (att_date,emp_code,is_present) values('" + s + "'," + gvAttendance.Rows[t].Cells["emp_code"].Value.ToString() + "," + "1" + ")");
            }


            MessageBox.Show("Saved Attendence Successfully.");
        }
    }
}
