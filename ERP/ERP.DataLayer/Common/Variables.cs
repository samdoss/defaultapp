using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data.SqlClient;
using System.Data.Common;  
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.CommonLayer;

namespace ERP.DataLayer
{
    public class Variables
    {
        #region Constructor(s)

        public Variables()
        {
            try
            {
                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetTheme";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "dummyColor", DbType.String, "Blue");
                using (SqlDataReader drThemes = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader) // (SqlDataReader)db.ExecuteReader(dbCommand))
                {
                    if (drThemes.HasRows)
                    {
                        drThemes.Read();
                        //Please provide the correct labelname for Heading, SubHeading and Button controls.
                        //Heading Settings
                        BackColor = Color.FromName(drThemes["Heading"].ToString()); //Please don't change this line.
                        TitleFont = new Font(drThemes["FontName"].ToString(), 30F, FontStyle.Bold);
                        //Sub Heading Settings
                        ForeColor = Color.FromName(drThemes["SubHeading"].ToString());//Please don't change this line.
                        SubTitleFont = new Font(drThemes["SubHeadingFont"].ToString(), 9.75F, FontStyle.Bold);
                        //Button Settings
                        ButtonBackColor = Color.FromName(drThemes["Button"].ToString());//Please don't change this line.
                    }
                }
            }
            catch {  }
        }

        #endregion

        #region Public Variables

            public int ColorID;
            public int FontID;
            public int SubHeadFontID;

        #endregion

        #region Private Variables

            ApplicationConnection _appConnection = new ApplicationConnection(); 
        private Color c = Color.Blue;       //subTilte fore color
        private Color bc = Color.Blue;      //Title back color
        private Color bbc = Color.Blue;     //button back color
        private Color dbc = Color.Gray;     //Disabled back color

        private Font f = new Font("Verdana", 10);   //Title font
        private Font stf = new Font("Verdana", 10); //subt title font

        private float fsz = 10;
        private float subfsz = 10;

        #endregion

        #region Public Properties

        public Color DisabledButton
        {
            get { return dbc; }
            set { dbc = value; }
        }

        public Color BackColor
        {
            get { return bc; }
            set { bc = value; }
        }

        public Font SubTitleFont
        {
            get { return stf; }
            set { stf = value; }
        }

        public float SubTitleFontSize
        {
            get { return subfsz; }
            set { subfsz = value; }
        }

        public Color ForeColor
        {
            get { return c; }
            set { c = value; }
        }

        public Font TitleFont
        {
            get { return f; }
            set { f = value; }
        }

        public float FontSize
        {
            get { return fsz; }
            set { fsz = value; }
        }

        public Color ButtonBackColor
        {
            get { return bbc; }
            set { bbc = value; }
        }

        #endregion

        #region Public Methods

        //Code for Common 
        public void FnSetToolTip(Control objControls, string paramToolTipMsg)
        {
            try
            {
                ToolTip tp = new ToolTip();
                tp.AutoPopDelay = 5000;
                tp.InitialDelay = 1000;
                tp.ReshowDelay = 500;
                tp.ShowAlways = true;
                tp.SetToolTip(objControls, paramToolTipMsg);
                objControls.BackColor = ButtonBackColor;
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "FnSetToolTip", "FnSetToolTip", ex.Message);
            }
        }

       //Calling from Theme Page
        public SqlDataReader spGetTheme(string paramDummyColor)
        {
            try
            {
                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetTheme";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "dummyColor", DbType.String, paramDummyColor);
                return ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "spGetTheme","spGetTheme",ex.Message);
            }
            return null;
        }

        public SqlDataReader FnGetDefaultSettings(string paramSQL)
        {
            try
            {
                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(paramSQL);
                return ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "FnGetDefaultSettings", "FnGetDefaultSettings", ex.Message);
            }
            return null;
        }

        //Calling from Theme page. This param is not used.
        public DataSet spGetFontList(string fontName)
        {
            try
            {
                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetFontList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "FontName", DbType.String, fontName);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "spGetFontList", "spGetFontList", ex.Message);
            }
            return null;
        }

        //Calling from Theme page. This param is not used
        public DataSet spGetColorList(string colorName)
        {
            try
            {
                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetColorList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ColorName", DbType.String, colorName);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "spGetColorList", "spGetColorList", ex.Message);
            }
            return null;
        }

        //Calling from Theme page.
        public SqlDataReader spGetAllColors(int paramColorID)
        {
            try
            {
                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetAllColors";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ColorID", DbType.Int32, paramColorID);
                return ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "spGetAllColors", "spGetAllColors", ex.Message);
            }
            return null;
        }

        //Calling From Theme Page.
        public int spAddColorXFont()
        {
            try
            {
                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spAddColorXFont";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ColorID", DbType.Int16, ColorID);
                db.AddInParameter(dbCommand, "FontID", DbType.Int16, FontID);
                db.AddInParameter(dbCommand, "SubHeadFontID", DbType.Int16, SubHeadFontID);
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "spAddColorXFont", "", ex.Message);
            }
            return 0;
        }
        //Calling from Each Forms and SubForms

        public void FnTitleTheme(Control objTitle)
        {
            try
            {
                objTitle.BackColor = BackColor;
                objTitle.Font = TitleFont;
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "FnTitleTheme", "", ex.Message);
            }
        }

        public void FnSetDisabledButton(Control objButton)
        {
            try
            {
                objButton.BackColor = ButtonBackColor;
                objButton.Enabled = false;
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "FnSetDisabledButton", "", ex.Message);
            }
        }

        public void FnSetEnabledButton(Control objButton)
        {
            try
            {
                objButton.BackColor = ButtonBackColor;
                objButton.Enabled = true;
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "FnSetEnabledButton", "", ex.Message);
            }
        }

        public void FnSubTitleTheme(Control objSubTitle)
        {
            try
            {
                objSubTitle.ForeColor = ForeColor;
                objSubTitle.Font = SubTitleFont;
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "FnSubTitleTheme", "", ex.Message);
            }
        }

        public void FnButtonTheme(Control objButton)
        {
            try
            {
                objButton.BackColor = ButtonBackColor;
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "FnButtonTheme", "", ex.Message);
            }
        }

        public void FnGridTheme(DataGridView objDgv)
        {
            try
            {
                objDgv.EnableHeadersVisualStyles = false;
                objDgv.ColumnHeadersDefaultCellStyle.BackColor = ButtonBackColor;
                objDgv.RowHeadersDefaultCellStyle.BackColor = ButtonBackColor;
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "FnGridTheme", "", ex.Message);
            }
        }
       
        public int FnDeleteAllRecords(string paramSQL)
        {
            try
            {
                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                DbCommand dbCommand = db.GetSqlStringCommand(paramSQL);
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Variables", "FnDeleteAllRecords", "", ex.Message);
            }
            return 0;
        }

        #endregion
    }
}
