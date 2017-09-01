using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ERP.DataLayer
{

    public struct ContactInformation
    {
        public int AddressID;
        public Int16 ContactTypeID;
        public string ContactSTD;
        public string ContactNumber;
        public int AuditUserID;
        public DateTime AuditDate;
    }

    #region class Address

    /// <summary>
    /// class to hold information about Address
    /// </summary>

    public class Address
    {
        public int AddressID;
        public int PHUDID;
        public Int16 AddressCategoryID;
        public string Address1;
        public string Address2;
        public string Address3;
        public string Area;
        public int CityID;
        public int StateID;
        public int CountryID;
        public string ZipCode;
        public string Email;
        public int AuditUserID;
        public DateTime AuditDate;
    }

    #endregion

    #region class PatientAdditionalContact

    /// <summary>
    /// class to hold information about PatientAdditionalContact
    /// </summary>

    public class  AdditionalContact
    {
        public int AdditionalContactID;
        public Int16 TitleID;
        public string Name;
        public string STD;
        public string Telephone;
        public int AuditUserID;
        public DateTime AuditDate;
    }

    #endregion

    //#region class HospitalAddress

    ///// <summary>
    ///// class to hold information about Address
    ///// </summary>

    //public class HospitalAddress
    //{
    //    public int HAddressID;
    //    public int HPHUDID;
    //    public Int16 HAddressCategoryID;
    //    public string HAddress1;
    //    public string HAddress2;
    //    public string HAddress3;
    //    public string HArea;
    //    public int HCityID;
    //    public int HStateID;
    //    public int HCountryID;
    //    public string HZipCode;
    //    public string HEmail;
    //    public string HWebsite;
    //    public int HAuditUserID;
    //    public DateTime HAuditDate;
    //}

    //#endregion

    //#region class Hospital Information

    ///// <summary>
    ///// class to hold information about Hospital Information
    ///// </summary>

    //public class CompanyInformation
    //{
    //    public int HospitalID;
    //    public int DoctorID;
    //    public string HospitalName;
    //    public string WorkingHoursMorning;
    //    public string WorkingHoursEvening;
    //}

    //#endregion

    //#region class Contact Information

    ///// <summary>
    ///// class to hold information about Contact Information
    ///// </summary>

    //public class ContactInformation
    //{
    //    public int AddressID;
    //    public Int16 ContactTypeID;
    //    public string ContactSTD;
    //    public string ContactNumber;
    //    public int AuditUserID;
    //    public DateTime AuditDate;
    //}

    //#endregion

    

    

    //#region class Unit

    ///// <summary>
    ///// class to hold information about Unit
    ///// </summary>

    //public class Unit
    //{
    //    public int UnitID;
    //    public string Units;
    //    public int AuditUserID;
    //    public bool IsEnabled;
    //}

    //#endregion

    //#region class BillDescription

    ///// <summary>
    ///// class to hold information about BillDescription
    ///// </summary>

    //public class BillMaster
    //{
    //    public int BillDescriptionID;
    //    public string BillCode;
    //    public string Description;
    //    public decimal Price;
    //    public decimal ServiceTax;
    //    public bool IsEnabled;
    //    public int AuditUserID;
    //}

    //#endregion

    #region class PatientBillingDetails

    /// <summary>
    /// class to hold information about Patient Billing Details
    /// </summary>

    public class PatientBillDetails
    {
        public int PatientBillingDetailID;
        public int PatientBillingID;
        public int BillDescriptionID;
        public string BillCode;
        public string BillDescription;
        public decimal ServiceTax;
        public decimal Price;
        public decimal Total;
    }

    #endregion

    #region class PatientBill Cheque Payment

    /// <summary>
    /// class to hold information about Patient Bill Cheque Payment
    /// </summary>

    public class PatientChequePayment
    {
        public int PatientBillingXChequeID;
        public int PatientBillingID;
        public int ChequeNumber;
        public DateTime ChequeDate;
        public string BankName;
        public string Place;
        public decimal Amount;
    }

    #endregion

    #region class PatientBill DD Payment

    /// <summary>
    /// class to hold information about Patient Bill DD Payment
    /// </summary>

    public class PatientDDPayment
    {
        public int PatientBillingXDDID;
        public int PatientBillingID;
        public int DDNumber;
        public DateTime DDDate;
        public string BankName;
        public string Place;
        public decimal Amount;
    }

    #endregion

    #region class PatientBill Credit / Debit Card Payment

    /// <summary>
    /// class to hold information about Patient Bill Credit / Debit Card Payment
    /// </summary>

    public class PatientCardPayment
    {
        public int PatientBillingXCardID;
        public int PatientBillingID;
        public int CardType;
        public string CardNumber;
        public string HolderName;
        public decimal Amount;
    }

    #endregion

    //#region class Complaint

    ///// <summary>
    ///// class to hold information about Complaint
    ///// </summary>

    //public class Complaint
    //{
    //    public int ComplaintID;
    //    public string Complaints;
    //    public int SpecialityID;
    //    public int AuditUserID;
    //    public bool IsEnabled;
    //}

    //#endregion

    
    //#region class Country

    ///// <summary>
    ///// class to hold information about Country
    ///// </summary>

    //public class Country
    //{
    //    public int CountryID;
    //    public string CountryName;
    //}

    //#endregion

    //#region class State

    ///// <summary>
    ///// class to hold information about State
    ///// </summary>

    //public class State
    //{
    //    public int StateID;
    //    public string StateName;
    //    public int CountryID;
    //}

    //#endregion

    //#region class City

    ///// <summary>
    ///// class to hold information about City
    ///// </summary>

    //public class City
    //{
    //    public int CityID;
    //    public string CityName;
    //    public int StateID;
    //}

    //#endregion

    //#region class Role

    ///// <summary>
    ///// class to hold information about Role
    ///// </summary>

    //public class Role
    //{
    //    public int RoleID;
    //    public string Roles;
    //    public int AuditUserID;
    //    public bool IsEnabled;
    //}

    //#endregion

    
    public class TR
    {

    }
}
