using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIClientImport
{
    public class AddressBook_Payments
    {
        public bool ValidateAddressBookPayments(DataTable dtSpreadsheet, string strDateFormat)
        {
            bool _overallValidation = true;
            bool isValid;
            double dtvalue;
            DateTime dateInfo;
            string dateString;
            int rowcount = 0;

            Form1.dtFinalLoad = BuildFinalAddressBookPaymentsTable(dtSpreadsheet);
            if (Form1.dtFinalLoad == null)
            {
                return false;
            }
            if (Form1.dtFinalAddressBookPaymentsLoad == null)
            {
                Form1.dtFinalAddressBookPaymentsLoad = Form1.dtFinalLoad.Clone();
            }
            foreach (DataRow row in dtSpreadsheet.Rows)
            {
                _overallValidation = true;
                int i = 0;
                rowcount++;
                try
                {
                    //AddressBookID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    //isValid = Validate.checkInt(row[i].ToString());
                    //if (!isValid)
                    //{
                    //    _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    //}
                    i++;

                    //AddressBookTypeCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkChar(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //TaxID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 11);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BusinessName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 102);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //AddressBookTypeName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 102);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //VendorName1
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 80);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //VendorName2
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 80);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //NatureOfBusinessID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //FirstName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MiddleName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //LastName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //LastFirstName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 102);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Address1
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Address2
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //City
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //State
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Zipcode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 10);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //County
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //HomePhone
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WorkPhone
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MobilePhone
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Fax
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Email
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Website
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BirthDate
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        dateString = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        if (dateString == "fail")
                        {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MaritalStatusCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkChar(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //GenderCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkChar(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //LanguageID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //EthnicGroupID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Active
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ApprovedVendor
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Process1099ID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //CombinePayments
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //EntryDate
                    if (row[i].ToString().Length == 0 || row[i].ToString() == "NULL")
                    {
                        row[i] = DateTime.Now.ToString(strDateFormat); //default value
                        row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                    }
                    else
                    {
                        dateString = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        if (dateString == "fail")
                        {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //EnteredBy
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //UpdatedDate
                    if (row[i].ToString().Length == 0 || row[i].ToString() == "NULL")
                    {
                        row[i] = DateTime.Now.ToString(strDateFormat); //default value
                        row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                    }
                    else
                    {
                        dateString = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        if (dateString == "fail")
                        {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //UpdatedBy
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BlockPayments
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Comments
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 255);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //RenderLocation
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BeneficiaryTypeID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DriverLicenseNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DriverLicenseState
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 2);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DriverLicenseExpirationDate
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        dtvalue = double.Parse(row[i].ToString());
                        dateInfo = DateTime.FromOADate(dtvalue);
                        row[i] = dateInfo;
                        isValid = Validate.checkDate(row[i].ToString());
                        if (!isValid)
                        {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                        }
                    }
                    i++;

                    //HasAttachment
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ExternalKey
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 250);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MailingAddress1
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MailingAddress2
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MailingCity
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MailingState
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MailingZipCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 10);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MailingCounty
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //UseMailingAddress
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //NPI
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Country
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MailingCountry
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InsuranceLineID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Height
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Weight
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //IsMinor
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ReceiverRoutingNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 9);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ReceiverAcctNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 17);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DFIAcctTypeID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PreferredPmtMethodID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //SendPrenote
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PrenoteStatusID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ReceiverBankName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DisableEFT
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DBA
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 100);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ProviderTaxonomyCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Suffix
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = ' '; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MailingFormattedAddress
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1000);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    ////InlineFormattedAddress
                    //if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    //{
                    //    row[i] = null; //default value
                    //}
                    //isValid = Validate.checkString(row[i].ToString(), 1000);
                    //if (!isValid)
                    //{
                    //    _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    //}
                    //i++;

                    ////FormattedAddress
                    //if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    //{
                    //    row[i] = null; //default value
                    //}
                    //isValid = Validate.checkString(row[i].ToString(), 1000);
                    //if (!isValid)
                    //{
                    //    _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    //}
                    //i++;

                    ////HtmlFormattedAddress
                    //if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    //{
                    //    row[i] = null; //default value
                    //}
                    //isValid = Validate.checkString(row[i].ToString(), 1000);
                    //if (!isValid)
                    //{
                    //    _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    //}
                    //i++;

                    //DependencyExtentID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                }
                catch
                {
                    _overallValidation = false;
                }



                if (!_overallValidation)
                {
                    Form1.dtBadData.ImportRow(row);
                }
                else
                {
                    //Form1.dtGoodData.ImportRow(row);
                    DataRow rowFinal = ConvertRowToDataType(row);
                    Form1.dtFinalLoad.ImportRow(rowFinal);
                    Form1.dtGoodData.ImportRow(rowFinal);
                }
            }
            return true;

        }

        public static DataTable BuildFinalAddressBookPaymentsTable(DataTable dt)
        {
            DataTable dtFinal = new DataTable();
            foreach (DataColumn column in dt.Columns)
            {
                dtFinal.Columns.Add(column.ColumnName);
            }
            try
            {
                dtFinal.Columns[0].DataType = System.Type.GetType("System.Guid");//AddressBookID
                dtFinal.Columns[1].DataType = System.Type.GetType("System.Char");//AddressBookTypeCode
                dtFinal.Columns[2].DataType = System.Type.GetType("System.String");//TaxID
                dtFinal.Columns[3].DataType = System.Type.GetType("System.String");//BusinessName
                dtFinal.Columns[4].DataType = System.Type.GetType("System.String");//AddressBookTypeName
                dtFinal.Columns[5].DataType = System.Type.GetType("System.String");//VendorName1
                dtFinal.Columns[6].DataType = System.Type.GetType("System.String");//VendorName2
                dtFinal.Columns[7].DataType = System.Type.GetType("System.Int32");//NatureOfBusinessID
                dtFinal.Columns[8].DataType = System.Type.GetType("System.String");//FirstName
                dtFinal.Columns[9].DataType = System.Type.GetType("System.String");//MiddleName
                dtFinal.Columns[10].DataType = System.Type.GetType("System.String");//LastName
                dtFinal.Columns[11].DataType = System.Type.GetType("System.String");//LastFirstName
                dtFinal.Columns[12].DataType = System.Type.GetType("System.String");//Address1
                dtFinal.Columns[13].DataType = System.Type.GetType("System.String");//Address2
                dtFinal.Columns[14].DataType = System.Type.GetType("System.String");//City
                dtFinal.Columns[15].DataType = System.Type.GetType("System.String");//State
                dtFinal.Columns[16].DataType = System.Type.GetType("System.String");//ZipCode
                dtFinal.Columns[17].DataType = System.Type.GetType("System.String");//County
                dtFinal.Columns[18].DataType = System.Type.GetType("System.String");//HomePhone
                dtFinal.Columns[19].DataType = System.Type.GetType("System.String");//WorkPhone
                dtFinal.Columns[20].DataType = System.Type.GetType("System.String");//MobilePhone
                dtFinal.Columns[21].DataType = System.Type.GetType("System.String");//Fax
                dtFinal.Columns[22].DataType = System.Type.GetType("System.String");//Email
                dtFinal.Columns[23].DataType = System.Type.GetType("System.String");//Website
                dtFinal.Columns[24].DataType = System.Type.GetType("System.DateTime");//BirthDate
                dtFinal.Columns[25].DataType = System.Type.GetType("System.Char");//MaritalStatusCode
                dtFinal.Columns[26].DataType = System.Type.GetType("System.Char");//GenderCode
                dtFinal.Columns[27].DataType = System.Type.GetType("System.Int32");//LanguageID
                dtFinal.Columns[28].DataType = System.Type.GetType("System.Int32");//EthnicGroupID
                dtFinal.Columns[29].DataType = System.Type.GetType("System.Boolean");//Active
                dtFinal.Columns[30].DataType = System.Type.GetType("System.Boolean");//ApprovedVendor
                dtFinal.Columns[31].DataType = System.Type.GetType("System.Int32");//Process1099ID
                dtFinal.Columns[32].DataType = System.Type.GetType("System.Boolean");//CombinePayments
                dtFinal.Columns[33].DataType = System.Type.GetType("System.DateTime");//EntryDate
                dtFinal.Columns[34].DataType = System.Type.GetType("System.String");//EnteredBy
                dtFinal.Columns[35].DataType = System.Type.GetType("System.DateTime");//UpdatedDate
                dtFinal.Columns[36].DataType = System.Type.GetType("System.String");//UpdatedBy
                dtFinal.Columns[37].DataType = System.Type.GetType("System.Boolean");//BlockPayments
                dtFinal.Columns[38].DataType = System.Type.GetType("System.String");//Comments
                dtFinal.Columns[39].DataType = System.Type.GetType("System.Boolean");//RenderLocation
                dtFinal.Columns[40].DataType = System.Type.GetType("System.Int32");//BeneficiaryTypeID
                dtFinal.Columns[41].DataType = System.Type.GetType("System.String");//DriverLicenseNumber
                dtFinal.Columns[42].DataType = System.Type.GetType("System.String");//DriverLicenseState
                dtFinal.Columns[43].DataType = System.Type.GetType("System.DateTime");//DriverLicenseExpirationDate
                dtFinal.Columns[44].DataType = System.Type.GetType("System.Boolean");//HasAttachment
                dtFinal.Columns[45].DataType = System.Type.GetType("System.String");//ExternalKey
                dtFinal.Columns[46].DataType = System.Type.GetType("System.String");//MailingAddress1
                dtFinal.Columns[47].DataType = System.Type.GetType("System.String");//MailingAddress2
                dtFinal.Columns[48].DataType = System.Type.GetType("System.String");//MailingCity
                dtFinal.Columns[49].DataType = System.Type.GetType("System.String");//MailingState
                dtFinal.Columns[50].DataType = System.Type.GetType("System.String");//MailingZipCode
                dtFinal.Columns[51].DataType = System.Type.GetType("System.String");//MailingCounty
                dtFinal.Columns[52].DataType = System.Type.GetType("System.Boolean");//UseMailingAddress
                dtFinal.Columns[53].DataType = System.Type.GetType("System.String");//NPI
                dtFinal.Columns[54].DataType = System.Type.GetType("System.String");//Country
                dtFinal.Columns[55].DataType = System.Type.GetType("System.String");//MailingCountry
                dtFinal.Columns[56].DataType = System.Type.GetType("System.Int32");//InsuranceLineID
                dtFinal.Columns[57].DataType = System.Type.GetType("System.String");//Height
                dtFinal.Columns[58].DataType = System.Type.GetType("System.String");//Weight
                dtFinal.Columns[59].DataType = System.Type.GetType("System.Boolean");//IsMinor
                dtFinal.Columns[60].DataType = System.Type.GetType("System.String");//ReceiverRoutingNumber
                dtFinal.Columns[61].DataType = System.Type.GetType("System.String");//ReceiverAcctNumber
                dtFinal.Columns[62].DataType = System.Type.GetType("System.Int32");//DFIAcctTypeID
                dtFinal.Columns[63].DataType = System.Type.GetType("System.Int32");//PreferredPmtMethodID
                dtFinal.Columns[64].DataType = System.Type.GetType("System.Boolean");//SendPrenote
                dtFinal.Columns[65].DataType = System.Type.GetType("System.Int32");//PrenoteStatusID
                dtFinal.Columns[66].DataType = System.Type.GetType("System.String");//ReceiverBankName
                dtFinal.Columns[67].DataType = System.Type.GetType("System.Boolean");//DisableEFT
                dtFinal.Columns[68].DataType = System.Type.GetType("System.String");//DBA
                dtFinal.Columns[69].DataType = System.Type.GetType("System.String");//ProviderTaxonomyCode
                dtFinal.Columns[70].DataType = System.Type.GetType("System.String");//Suffix
                dtFinal.Columns[71].DataType = System.Type.GetType("System.String");//MailingFormattedAddress
                //dtFinal.Columns[72].DataType = System.Type.GetType("System.String");//InlineFormattedAddress
                //dtFinal.Columns[73].DataType = System.Type.GetType("System.String");//FormattedAddress
                //dtFinal.Columns[74].DataType = System.Type.GetType("System.String");//HtmlFormattedAddress
                dtFinal.Columns[72].DataType = System.Type.GetType("System.Int32");//DependencyExtentID
                //dtFinal.Columns[76].DataType = System.Type.GetType("System.String");//ClaimNumber

                if (dtFinal.Columns[72].ColumnName != "DependencyExtentId")
                {
                    MessageBox.Show("Column count mismatch detected, please verify you are loading the correct spreadsheet with the related load type.");
                    dtFinal = null;
                }
                return dtFinal;
            }
            catch
            {
                MessageBox.Show("Column count mismatch detected, please verify you are loading the correct spreadsheet with the related load type.");
                return null;
            }
        }



        public DataRow ConvertRowToDataType(DataRow row)
        {
            int cl = row.Table.Columns.Count;
            DataRow drResult = row;

            try
            {
                for (int j = 0; j <= cl - 1; j++)
                {
                    if (Form1.dtFinalLoad.Columns[j].DataType == typeof(string))
                    {
                        //data is already string
                    }
                    else if (Form1.dtFinalLoad.Columns[j].DataType == typeof(Int32))
                    {
                        drResult[j] = Validate.convertToInt32(row[j].ToString());
                    }
                    else if (Form1.dtFinalLoad.Columns[j].DataType == typeof(Boolean))
                    {
                        drResult[j] = Validate.convertToBool(row[j].ToString());
                    }
                    else if (Form1.dtFinalLoad.Columns[j].DataType == typeof(DateTime))
                    {
                        drResult[j] = Validate.convertToDateTime(row[j].ToString());
                    }
                    else if (Form1.dtFinalLoad.Columns[j].DataType == typeof(Guid))
                    {
                        //Guid field is blank
                        //drResult[j] = Validate.convertToGuid(row[j].ToString());
                    }
                    else if (Form1.dtFinalLoad.Columns[j].DataType == typeof(Char))
                    {
                        drResult[j] = Validate.convertToChar(row[j].ToString());
                    }

                }
                return drResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}

