using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
    public partial class frmTheme : Form
    {
        #region Constructor(s)

        public frmTheme()
        {
            InitializeComponent();
            
        }

        #endregion

        #region Private Variables

        Variables objVariables = new Variables();
        
        FontDialog fd = new FontDialog();
        ColorDialog cd = new ColorDialog();
        SqlDataReader sqlDR;
        internal string helpFile = "\\Help\\HelpFile.chm";
        private string _sSQL = "";
        private float _titleFsz, _subTitleFsz;
        SqlDataReader drThemes;
        ApplicationConnection _appConnection = new ApplicationConnection();

        #endregion

        #region Private Events

        private void frmTheme_Load(object sender, EventArgs e)
        {
            try
            {
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmTheme.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                LoadDefaultFont();
                LoadDefaultColor();
                _titleFsz = lblTitle.Font.Size;
                _subTitleFsz = lblSubHeading.Font.Size;
                objVariables.FnSetDisabledButton(btnSave);
                LoadDefaultColorandFonts();
                LoadGetDefaultSettings();
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool x = SaveValidation();
                if (x == true)
                {
                    int RV = 0, retID; //objApp.spAddColorXFont();
                    objVariables.FontID = int.Parse(ddlFontName.SelectedValue.ToString());
                    objVariables.SubHeadFontID = int.Parse(ddlSubHeadFontName.SelectedValue.ToString());
                    objVariables.ColorID = int.Parse(ddlColorName.SelectedValue.ToString());
                    _sSQL = "Delete from ColorXFont";
                    retID = objVariables.FnDeleteAllRecords(_sSQL);
                    RV = objVariables.spAddColorXFont();

                    if (RV <= 0)
                    {
                        MessageBox.Show("There was a Problem Adding Font Settings to The System.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Your Font Settings Successfully Added.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    Close();
                }
            }
            catch { }
        }

        private void ddlFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlFontName.SelectedIndex != -1)
                {
                    int i = 0;
                    if (int.TryParse(ddlFontName.SelectedValue.ToString(), out i))
                    {
                        lblTitle.Font = new Font(ddlFontName.Text, _titleFsz, FontStyle.Bold);
                    }

                }
                if (ddlFontName.SelectedIndex == 0)
                {
                    objVariables.FnSetDisabledButton(btnSave);
                    btnSave.BackColor = btnClose.BackColor;
                }
                else
                {
                    objVariables.FnSetEnabledButton(btnSave);
                    btnSave.BackColor = btnClose.BackColor;
                }
            }
            catch { }
        }

        private void ddlSubHeadFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSubHeadFontName.SelectedIndex != -1)
                {
                    int i = 0;
                    if (int.TryParse(ddlSubHeadFontName.SelectedValue.ToString(), out i))
                    {
                        lblSubHeading.Font = new Font(ddlSubHeadFontName.Text, _subTitleFsz, FontStyle.Bold);
                    }
                }
            }
            catch { }
        }

        private void ddlColorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlColorName.SelectedIndex != -1)
                {
                    int i = 0, selColorID;
                    if (int.TryParse(ddlColorName.SelectedValue.ToString(), out i))
                    {
                        selColorID = int.Parse(ddlColorName.SelectedValue.ToString());
                        sqlDR = objVariables.spGetAllColors(selColorID);

                        while (sqlDR.Read())
                        {
                            objVariables.BackColor = Color.FromName(sqlDR["Heading"].ToString());
                            lblTitle.BackColor = objVariables.BackColor;
                            objVariables.ForeColor = Color.FromName(sqlDR["SubHeading"].ToString());
                            lblSubHeading.ForeColor = objVariables.ForeColor;
                            objVariables.BackColor = Color.FromName(sqlDR["Button"].ToString());
                            btnSave.BackColor = objVariables.BackColor;
                            btnClose.BackColor = objVariables.BackColor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Theme", "frmTheme", "ddlColorName_SelectedIndexChanged", ex.Message);
            }
        }

        private void frmTheme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Private Methods

        private void LoadDefaultFont()
        {
            //code for heading
            ddlFontName.DataSource = objVariables.spGetFontList("Times New Roman").Tables[0]; //Green is not used ie., dummy name.
            ddlFontName.DisplayMember = "FontName";
            ddlFontName.ValueMember = "FontID";
            ddlFontName.SelectedIndex = 0;

            //code for sub heading
            ddlSubHeadFontName.DataSource = objVariables.spGetFontList("Times New Roman").Tables[0];
            ddlSubHeadFontName.DisplayMember = "FontName";
            ddlSubHeadFontName.ValueMember = "FontID";
            ddlSubHeadFontName.SelectedIndex = 0;
        }

        private void LoadDefaultColor()
        {
            //code for heading
            ddlColorName.DataSource = objVariables.spGetColorList("Green").Tables[0]; //Green is not used ie., dummy name.
            ddlColorName.DisplayMember = "ColorName";
            ddlColorName.ValueMember = "ColorID";
            ddlColorName.SelectedIndex = 0;
        }

        private bool SaveValidation()
        {
            if (ddlFontName.SelectedIndex.ToString() == "0")
            {
                MessageBox.Show("Font Name Should be Selected.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ddlFontName.Focus();
                return false;
            }

            if (ddlSubHeadFontName.SelectedIndex.ToString() == "0")
            {
                MessageBox.Show("Sub Heading Font Name Should be Selected.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ddlSubHeadFontName.Focus();
                return false;
            }

            if (ddlColorName.SelectedIndex.ToString() == "0")
            {
                MessageBox.Show("Color Family Should be Selected.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ddlColorName.Focus();
                return false;
            }
            return true;
        }

        private void LoadDefaultColorandFonts()
        {
            objVariables.FnTitleTheme(lblTitle);
            objVariables.FnSubTitleTheme(lblSubHeading);
            objVariables.FnButtonTheme(btnSave);
            objVariables.FnButtonTheme(btnClose);
            objVariables.FnSetToolTip(btnClose, "Alt+C Close");
            objVariables.FnSetToolTip(btnSave, "Alt+S Save");
        }

        private void LoadGetDefaultSettings()
        {
            drThemes = null;
            drThemes = objVariables.FnGetDefaultSettings("Select ColorXFontID, ColorID, FontID, SubHeadFontID From ColorXFont");
        }

        #endregion
    }
}