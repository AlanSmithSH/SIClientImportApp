using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIClientImport
{
    class AddressBook
    {
        public bool ValidateAddressBook(DataTable dtSpreadsheet)
        {
            bool _overallValidation = true;
            bool isValid;
            double dtvalue;
            DateTime dateInfo;
            

            foreach (DataRow row in dtSpreadsheet.Rows)
            {
                _overallValidation = true;
                int i = 0;

                //ClaimNumber
                //isValid = Validate.checkInt(row[i].ToString());
                //if (!isValid)
                //{
                //    _overallValidation = false;
                //}
                //i++;

                //AddressBookID
                isValid = Validate.checkInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //AddressBookTypeCode
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkChar(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
                }
                i++;

                //BirthDate
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
                        _overallValidation = false;
                    }
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
                }
                i++;

                //EntryDate
                if (row[i].ToString().Length == 0 || row[i].ToString() == "NULL")
                {
                    row[i] = DateTime.Now.ToString(); //default value
                }
                else
                {
                    dtvalue = double.Parse(row[i].ToString());
                    dateInfo = DateTime.FromOADate(dtvalue);
                    row[i] = dateInfo;
                }
                isValid = Validate.checkDate(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
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
                    _overallValidation = false;
                }
                i++;

                //UpdatedDate
                if (row[i].ToString().Length == 0 || row[i].ToString() == "NULL")
                {
                    row[i] = DateTime.Now.ToString(); //default value
                }
                else
                {
                    dtvalue = double.Parse(row[i].ToString());
                    dateInfo = DateTime.FromOADate(dtvalue);
                    row[i] = dateInfo;
                }
                isValid = Validate.checkDate(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                        _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
                }
                i++;

                //InlineFormattedAddress
                if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                {
                    row[i] = null; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 1000);
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //FormattedAddress
                if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                {
                    row[i] = null; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 1000);
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //HtmlFormattedAddress
                if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                {
                    row[i] = null; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 1000);
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //DependencyExtentID
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkBit(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                //i++;


                if (!_overallValidation)
                {
                    Form1.dtBadData.ImportRow(row);
                }
                else
                {
                    Form1.dtGoodData.ImportRow(row);
                }
            }
            return true;

        }
    }
}

