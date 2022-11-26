using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIClientImport
{
    public class Claimant
    {
        public bool ValidateClaimant(DataTable dtSpreadsheet, string strDateFormat)
        {
            bool _overallValidation = true;
            bool isValid;
            bool isValidClaimID;
            bool isValidAddressBookID;
            string dateString;
            Form1.dtFinalLoad = BuildFinalClaimantTable(dtSpreadsheet);
            if (Form1.dtFinalLoad == null)
            {
                return false;
            }
            if (Form1.dtFinalClaimantLoad == null)
            {
                Form1.dtFinalClaimantLoad = Form1.dtFinalLoad.Clone();
            }
            int rowcount = 0;
            foreach (DataRow row in dtSpreadsheet.Rows)
            {
                try { 
                    _overallValidation = true;
                    int i = 0;
                    rowcount++;

                    //ClaimNumber
                    isValid = Validate.checkString(row[i].ToString(), 50); if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ClaimantID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    //isValid = Validate.checkInt(row[i].ToString());
                    //if (!isValid)
                    //{
                    //        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    //}
                    i++;

                    //ClaimID
                    isValidClaimID = SQLMethods.CheckForExistingClaimID(row[i].ToString());

                    if ((row[i].ToString().Length == 0) || (!isValidClaimID))
                    {
                        _overallValidation = false; 
                        Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), "Claim ID not found.");


                        //_overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ClaimantTypeID
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

                    //ClaimantStatusID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //AddressBookID
                    isValidAddressBookID = SQLMethods.CheckForExistingAddressBookID(row[i].ToString());

                    if ((row[i].ToString().Length == 0) || (!isValidAddressBookID))
                    {
                        //Form1.dtBadData.ImportRow(row);
                        //MessageBox.Show("AddressBookID " + row[i].ToString() + " not found in dbo.AddressBook table. " + Environment.NewLine + "Please verify address book table has been loaded. Processing stopped.");
                        //break;

                        _overallValidation = false; 
                        Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), "AddressBookID not found in dboAddressBook table.");
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DeathDate
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

                    //DeathResultOfInjury
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

                    //DriverLicenseState
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 2);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DriverLicense
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Accepted
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

                    //AcceptedDate
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

                    //Delayed
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

                    //DelayedDate
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

                    //DelayedReasonID
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

                    //DelayedComments
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 255);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Denied
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

                    //DeniedDate
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

                    //DeniedReasonID
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

                    //DeniedComments
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 500);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ClosedDate
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

                    //ReopenedDate
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

                    //ReopenedReasonID
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

                    //SeverityID
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

                    //SettlementTypeID
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

                    //FraudID
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

                    //JointCoverage
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

                    //TotalGrossIncurred
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BodyPartID
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

                    //NatureOfInjuryID
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

                    //InjuryTypeID
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

                    //ActivityDesc
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 500);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InjuryDesc
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 500);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //HowInjuryOccurred
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 500);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InjuryEquipment
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 500);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InsuredReportedDate
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

                    //AdministratorReportedDate
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

                    //NoticeOfInjuryDate
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

                    //Litigated
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

                    //Subrogated
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

                    //SubroStatuteDate
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

                    //SubroPotential
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

                    //NumberDependents
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

                    //BeginWorkTime
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 10);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //LastWorkedDate
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

                    //UnableWorkDay
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

                    //ReturnedWorkDate
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

                    //OffWork
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

                    //FullDayPaid
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

                    //SalaryContinued
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

                    //PhysicianFirstName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PhysicianMiddleName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PhysicianLastName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PhysicianWorkPhone
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PhysicianAddress1
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PhysicianAddress2
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PhysicianCity
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PhysicianState
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PhysicianZipCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PhysicianCounty
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //HospitalizedOvernight
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

                    //HospitalAddressBookID
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

                    //ERTreatment
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

                    //TDRate
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PDRate
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //VRRate
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DeathRate
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //LifePensionRate
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //SupplementalBenefits
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PDWeeks
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkNumeric(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DWCProvideDate
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

                    //DWCReceivedDate
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

                    //ContinuousTraumaBeginDate
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

                    //ContinuousTraumaEndDate
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

                    //PDRating
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkNumeric(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DisabilityRatingDate
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

                    //DisabilityBeginDate
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

                    //PermanentStationaryDate
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

                    //ModifiedDutyOffered
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

                    //WageStatementReceived
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

                    //MedicalManagement
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

                    //ClaimantComments
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 255);
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
                        row[i] = null; //default value
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
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PbmTerminationDate
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

                    //LossTypeID
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

                    //Totaled
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

                    //TotaledDate
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

                    //TotaledComments
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 255);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InsuredIsClaimant
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

                    //ClaimantUnitTypeID
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

                    //ClaimantUnitType
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

                    //Benefits4850
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

                    //InsuredLiabilityPercentage
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkDecimal(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //EstimatedSettlementValue
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //FullValue
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ICD9Code
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PTDRate
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //TPDRate
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PostInjuryWage
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //SpecialInstructions
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 4000);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //AutomaticBenefitsCalculation
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

                    //SuffixCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InsuredUnitTypeID
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

                    //InsuredUnitType
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

                    //InsuredDriverID
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

                    //InsuredDriverTypeID
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

                    //InsuredBuildingID
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

                    //PhysicianCountry
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ClosingCodeID
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

                    //CalculationInstructions
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 4000);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BenefitClassID
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

                    //MemberTypeID
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

                    //HospitalAdmissionDate
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

                    //HospitalDischargeDate
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

                    //ConditionCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 10);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherDesc
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherPhone
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherEmail
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PermanentImpairmentPct
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DismembermentParalysisPct
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //CosmeticDisfigurementPct
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherProviderAddressBookID
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

                    //OtherProviderAdmissionDate
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

                    //OtherProviderDischargeDate
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

                    //WCWeeklyRate
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCStatus
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCCarrier
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCContactName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCPhone
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCEmail
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCAddress1
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCAddress2
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCCity
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCState
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCZipCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 10);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCCounty
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WCCountry
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //CoordinatedTDBenefit
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //Retroactive
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

                    //EliminationPeriod
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //CPIPct
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //CPIDate
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

                    //IPIRate
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherAddress1
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherAddress2
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherCity
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherState
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherZipCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 10);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherCounty
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //OtherCountry
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //HeartPermanentImpairmentID
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

                    //EjectionFractionID
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

                    //NYHeartAssocFuncClassificationID
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

                    //OdgComorbidityDepression
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

                    //OdgComorbidityDiabetes
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

                    //OdgComorbidityHypertension
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

                    //OdgComorbidityLegalRepresentation
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

                    //OdgComorbidityObesity
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

                    //OdgComorbiditySmoker
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

                    //OdgComorbiditySubstanceAbuse
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

                    //OdgComorbiditySurgery
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

                    //OdgComorbidityOpiods
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

                    //OdgComorbidityJobClass
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

                    //LumpSumIndicator
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BenefitOffsetID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //LossOfEarningCapacityPct
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

                    //PreExistingDisabilityPct
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

                    //TDBenefitExtinguishmentID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //TaxFilingStatusID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //NumberOfEntitledExemptions
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //EducationLevel
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 2);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //FirstDateOfDisabilityAfterWaitingPeriod
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

                    //DateClaimAdminKnewOfEmployeeRepresentation
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

                    //AgreementToCompensateID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DenialRescissionDate
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

                    //PartialDenialID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PartialDenialEffectiveDate
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

                    //AwardOrderDate
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

                    //ReducedBenefitAmountTypeID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InitialRTWTypeID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InitialRTWPhysicalRestrictionsIndicator
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InitialRTWWithSameEmployer
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InitialEmployerKnowledgeOfDisabilityDate
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

                    //InitialDateAdminKnewOfLossTime
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

                    //CurrentLastWorkDate
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

                    //CurrentDisabilityBeginDate
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

                    //LatestRTWDate
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

                    //LatestRTWTypeID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //LatestRTWPhysicalRestrictionsIndicator
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //LatestRTWWithSameEmployerIndicator
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //NonConsecutivePeriodID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DateEmployerKnewOfCurrentLossTime
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

                    //CurrentDateAdminKnewOfLossTime
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

                    //FirstNameOverride
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //LastNameOverride
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //SuspensionEffectiveDateOverride
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

                    //SuspensionNarrative
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 500);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //EEIDAssignedByJurisdiction
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //CancelReasonNarrative
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 500);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //RelatedJurisdictionClaimNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 25);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //MedRecordReleaseOnFile
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

                    //EmployeeSSNReleaseOnFile
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

                    //ERIDAssignedByJurisdiction
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 15);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InsolventInsurerFEIN
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 10);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //IndemnityThruDateForAcquiredClaim
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

                    //CurrentOverpaymentAmount
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ManagedCareOrganizationCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 2);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ManagedCareOrganizationID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 9);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ManagedCareOrganizationName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 40);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //ManualStateInterventionResolved
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InitialTreatmentID
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

                    //BodyPartLocationCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BodyPartFingerToeLocationCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //AnticipatedWageLoss
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PreexistingDisability
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DiscontinuedFringeBenefits
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PermanentImpairmentMinimumPayment
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //WeeklyIncomeAmountForOffset
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //CancelReasonID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //EDIClaimTypeID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //AcquisitionStatusID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //DependentExtentOfDependencyID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PhysicianFormattedAddress
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

                    //OtherFormattedAddress
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

                    //WCFormattedAddress
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

                    //DateClaimAdministratorKnewClaimMetReportingRequirement
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

                    //DateClaimAdministratorKnewCurrentDisabilityDate
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

                    //DateEmployerKnewOfDisability
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

                    //AcquisitionDate
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

                    //PermanentImpairmentBodyPartCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PermanentImpairmentBodyPartLocationCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BenefitChangeReasonCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                            _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;


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

        public static DataTable BuildFinalClaimantTable(DataTable dt)
        {
            DataTable dtFinal = new DataTable();
            foreach (DataColumn column in dt.Columns)
            {
                dtFinal.Columns.Add(column.ColumnName);
            }
            try
            {
                dtFinal.Columns[0].DataType = System.Type.GetType("System.String");//ClaimNumber
                dtFinal.Columns[1].DataType = System.Type.GetType("System.Guid");//ClaimantID
                dtFinal.Columns[2].DataType = System.Type.GetType("System.Int32");//ClaimID
                dtFinal.Columns[3].DataType = System.Type.GetType("System.Int32");//ClaimantTypeID
                dtFinal.Columns[4].DataType = System.Type.GetType("System.Int32");//ClaimantStatusID
                dtFinal.Columns[5].DataType = System.Type.GetType("System.Int32");//AddressBookID
                dtFinal.Columns[6].DataType = System.Type.GetType("System.DateTime");//DeathDate
                dtFinal.Columns[7].DataType = System.Type.GetType("System.Boolean");//DeathResultOfInjury
                dtFinal.Columns[8].DataType = System.Type.GetType("System.String");//DriverLicenseState
                dtFinal.Columns[9].DataType = System.Type.GetType("System.String");//DriverLicense
                dtFinal.Columns[10].DataType = System.Type.GetType("System.Boolean");//Accepted
                dtFinal.Columns[11].DataType = System.Type.GetType("System.DateTime");//AcceptedDate
                dtFinal.Columns[12].DataType = System.Type.GetType("System.Boolean");//Delayed
                dtFinal.Columns[13].DataType = System.Type.GetType("System.DateTime");//DelayedDate
                dtFinal.Columns[14].DataType = System.Type.GetType("System.Int32");//DelayedReasonID
                dtFinal.Columns[15].DataType = System.Type.GetType("System.String");//DelayedComments
                dtFinal.Columns[16].DataType = System.Type.GetType("System.Boolean");//Denied
                dtFinal.Columns[17].DataType = System.Type.GetType("System.DateTime");//DeniedDate
                dtFinal.Columns[18].DataType = System.Type.GetType("System.Int32");//DeniedReasonID
                dtFinal.Columns[19].DataType = System.Type.GetType("System.String");//DeniedComments
                dtFinal.Columns[20].DataType = System.Type.GetType("System.DateTime");//ClosedDate
                dtFinal.Columns[21].DataType = System.Type.GetType("System.DateTime");//ReopenedDate
                dtFinal.Columns[22].DataType = System.Type.GetType("System.Int32");//ReopenedReasonID
                dtFinal.Columns[23].DataType = System.Type.GetType("System.Int32");//SeverityID
                dtFinal.Columns[24].DataType = System.Type.GetType("System.Int32");//SettlementTypeID
                dtFinal.Columns[25].DataType = System.Type.GetType("System.Int32");//FraudID
                dtFinal.Columns[26].DataType = System.Type.GetType("System.Boolean");//JointCoverage
                dtFinal.Columns[27].DataType = System.Type.GetType("System.Single");//TotalGrossIncurred
                dtFinal.Columns[28].DataType = System.Type.GetType("System.Int32");//BodyPartID
                dtFinal.Columns[29].DataType = System.Type.GetType("System.Int32");//NatureOfInjuryID
                dtFinal.Columns[30].DataType = System.Type.GetType("System.Int32");//InjuryTypeID
                dtFinal.Columns[31].DataType = System.Type.GetType("System.String");//ActivityDesc
                dtFinal.Columns[32].DataType = System.Type.GetType("System.String");//InjuryDesc
                dtFinal.Columns[33].DataType = System.Type.GetType("System.String");//HowInjuryOccurred
                dtFinal.Columns[34].DataType = System.Type.GetType("System.String");//InjuryEquipment
                dtFinal.Columns[35].DataType = System.Type.GetType("System.DateTime");//InsuredReportedDate
                dtFinal.Columns[36].DataType = System.Type.GetType("System.DateTime");//AdministratorReportedDate
                dtFinal.Columns[37].DataType = System.Type.GetType("System.DateTime");//NoticeOfInjuryDate
                dtFinal.Columns[38].DataType = System.Type.GetType("System.Boolean");//Litigated
                dtFinal.Columns[39].DataType = System.Type.GetType("System.Boolean");//Subrogated
                dtFinal.Columns[40].DataType = System.Type.GetType("System.DateTime");//SubroStatuteDate
                dtFinal.Columns[41].DataType = System.Type.GetType("System.Boolean");//SubroPotential
                dtFinal.Columns[42].DataType = System.Type.GetType("System.Int32");//NumberDependents
                dtFinal.Columns[43].DataType = System.Type.GetType("System.String");//BeginWorkTime
                dtFinal.Columns[44].DataType = System.Type.GetType("System.DateTime");//LastWorkedDate
                dtFinal.Columns[45].DataType = System.Type.GetType("System.Boolean");//UnableWorkDay
                dtFinal.Columns[46].DataType = System.Type.GetType("System.DateTime");//ReturnedWorkDate
                dtFinal.Columns[47].DataType = System.Type.GetType("System.Boolean");//OffWork
                dtFinal.Columns[48].DataType = System.Type.GetType("System.Boolean");//FullDayPaid
                dtFinal.Columns[49].DataType = System.Type.GetType("System.Boolean");//SalaryContinued
                dtFinal.Columns[50].DataType = System.Type.GetType("System.String");//PhysicianFirstName
                dtFinal.Columns[51].DataType = System.Type.GetType("System.String");//PhysicianMiddleName
                dtFinal.Columns[52].DataType = System.Type.GetType("System.String");//PhysicianLastName
                dtFinal.Columns[53].DataType = System.Type.GetType("System.String");//PhysicianWorkPhone
                dtFinal.Columns[54].DataType = System.Type.GetType("System.String");//PhysicianAddress1
                dtFinal.Columns[55].DataType = System.Type.GetType("System.String");//PhysicianAddress2
                dtFinal.Columns[56].DataType = System.Type.GetType("System.String");//PhysicianCity
                dtFinal.Columns[57].DataType = System.Type.GetType("System.String");//PhysicianState
                dtFinal.Columns[58].DataType = System.Type.GetType("System.String");//PhysicianZipCode
                dtFinal.Columns[59].DataType = System.Type.GetType("System.String");//PhysicianCounty
                dtFinal.Columns[60].DataType = System.Type.GetType("System.Boolean");//HospitalizedOvernight
                dtFinal.Columns[61].DataType = System.Type.GetType("System.Int32");//HospitalAddressBookID
                dtFinal.Columns[62].DataType = System.Type.GetType("System.Boolean");//ERTreatment
                dtFinal.Columns[63].DataType = System.Type.GetType("System.Single");//TDRate
                dtFinal.Columns[64].DataType = System.Type.GetType("System.Single");//PDRate
                dtFinal.Columns[65].DataType = System.Type.GetType("System.Single");//VRRate
                dtFinal.Columns[66].DataType = System.Type.GetType("System.Single");//DeathRate
                dtFinal.Columns[67].DataType = System.Type.GetType("System.Single");//LifePensionRate
                dtFinal.Columns[68].DataType = System.Type.GetType("System.Single");//SupplementalBenefits
                dtFinal.Columns[69].DataType = System.Type.GetType("System.Single");//PDWeeks
                dtFinal.Columns[70].DataType = System.Type.GetType("System.DateTime");//DWCProvideDate
                dtFinal.Columns[71].DataType = System.Type.GetType("System.DateTime");//DWCReceivedDate
                dtFinal.Columns[72].DataType = System.Type.GetType("System.DateTime");//ContinuousTraumaBeginDate
                dtFinal.Columns[73].DataType = System.Type.GetType("System.DateTime");//ContinuousTraumaEndDate
                dtFinal.Columns[74].DataType = System.Type.GetType("System.Single");//PDRating
                dtFinal.Columns[75].DataType = System.Type.GetType("System.DateTime");//DisabilityRatingDate
                dtFinal.Columns[76].DataType = System.Type.GetType("System.DateTime");//DisabilityBeginDate
                dtFinal.Columns[77].DataType = System.Type.GetType("System.DateTime");//PermanentStationaryDate
                dtFinal.Columns[78].DataType = System.Type.GetType("System.Boolean");//ModifiedDutyOffered
                dtFinal.Columns[79].DataType = System.Type.GetType("System.Boolean");//WageStatementReceived
                dtFinal.Columns[80].DataType = System.Type.GetType("System.Boolean");//MedicalManagement
                dtFinal.Columns[81].DataType = System.Type.GetType("System.String");//ClaimantComments
                dtFinal.Columns[82].DataType = System.Type.GetType("System.DateTime");//EntryDate
                dtFinal.Columns[83].DataType = System.Type.GetType("System.String");//EnteredBy
                dtFinal.Columns[84].DataType = System.Type.GetType("System.DateTime");//UpdatedDate
                dtFinal.Columns[85].DataType = System.Type.GetType("System.String");//UpdatedBy
                dtFinal.Columns[86].DataType = System.Type.GetType("System.DateTime");//PbmTerminationDate
                dtFinal.Columns[87].DataType = System.Type.GetType("System.Int32");//LossTypeID
                dtFinal.Columns[88].DataType = System.Type.GetType("System.Boolean");//Totaled
                dtFinal.Columns[89].DataType = System.Type.GetType("System.DateTime");//TotaledDate
                dtFinal.Columns[90].DataType = System.Type.GetType("System.String");//TotaledComments
                dtFinal.Columns[91].DataType = System.Type.GetType("System.Boolean");//InsuredIsClaimant
                dtFinal.Columns[92].DataType = System.Type.GetType("System.Int32");//ClaimantUnitTypeID
                dtFinal.Columns[93].DataType = System.Type.GetType("System.Int32");//ClaimantUnitID
                dtFinal.Columns[94].DataType = System.Type.GetType("System.Boolean");//Benefits4850
                dtFinal.Columns[95].DataType = System.Type.GetType("System.Decimal");//InsuredLiabilityPercentage
                dtFinal.Columns[96].DataType = System.Type.GetType("System.Single");//EstimatedSettlementValue
                dtFinal.Columns[97].DataType = System.Type.GetType("System.Single");//FullValue
                dtFinal.Columns[98].DataType = System.Type.GetType("System.String");//ICD9Code
                dtFinal.Columns[99].DataType = System.Type.GetType("System.Single");//PTDRate
                dtFinal.Columns[100].DataType = System.Type.GetType("System.Single");//TPDRate
                dtFinal.Columns[101].DataType = System.Type.GetType("System.Single");//PostInjuryWage
                dtFinal.Columns[102].DataType = System.Type.GetType("System.String");//SpecialInstructions
                dtFinal.Columns[103].DataType = System.Type.GetType("System.Boolean");//AutomaticBenefitsCalculation
                dtFinal.Columns[104].DataType = System.Type.GetType("System.String");//SuffixCode
                dtFinal.Columns[105].DataType = System.Type.GetType("System.Int32");//InsuredUnitTypeID
                dtFinal.Columns[106].DataType = System.Type.GetType("System.Int32");//InsuredUnitID
                dtFinal.Columns[107].DataType = System.Type.GetType("System.Int32");//InsuredDriverID
                dtFinal.Columns[108].DataType = System.Type.GetType("System.Int32");//InsuredDriverTypeID
                dtFinal.Columns[109].DataType = System.Type.GetType("System.Int32");//InsuredBuildingID
                dtFinal.Columns[110].DataType = System.Type.GetType("System.String");//PhysicianCountry
                dtFinal.Columns[111].DataType = System.Type.GetType("System.Int32");//ClosingCodeID
                dtFinal.Columns[112].DataType = System.Type.GetType("System.String");//CalculationInstructions
                dtFinal.Columns[113].DataType = System.Type.GetType("System.Int32");//BenefitClassID
                dtFinal.Columns[114].DataType = System.Type.GetType("System.Int32");//MemberTypeID
                dtFinal.Columns[115].DataType = System.Type.GetType("System.DateTime");//HospitalAdmissionDate
                dtFinal.Columns[116].DataType = System.Type.GetType("System.DateTime");//HospitalDischargeDate
                dtFinal.Columns[117].DataType = System.Type.GetType("System.String");//ConditionCode
                dtFinal.Columns[118].DataType = System.Type.GetType("System.String");//OtherName
                dtFinal.Columns[119].DataType = System.Type.GetType("System.String");//OtherDesc
                dtFinal.Columns[120].DataType = System.Type.GetType("System.String");//OtherPhone
                dtFinal.Columns[121].DataType = System.Type.GetType("System.String");//OtherEmail
                dtFinal.Columns[122].DataType = System.Type.GetType("System.String");//PermanentImpairmentPct
                dtFinal.Columns[123].DataType = System.Type.GetType("System.String");//DismembermentParalysisPct
                dtFinal.Columns[124].DataType = System.Type.GetType("System.String");//CosmeticDisfigurementPct
                dtFinal.Columns[125].DataType = System.Type.GetType("System.Int32");//OtherProviderAddressBookID
                dtFinal.Columns[126].DataType = System.Type.GetType("System.DateTime");//OtherProviderAdmissionDate
                dtFinal.Columns[127].DataType = System.Type.GetType("System.DateTime");//OtherProviderDischargeDate
                dtFinal.Columns[128].DataType = System.Type.GetType("System.Single");//WCWeeklyRate
                dtFinal.Columns[129].DataType = System.Type.GetType("System.String");//WCStatus
                dtFinal.Columns[130].DataType = System.Type.GetType("System.String");//WCCarrier
                dtFinal.Columns[131].DataType = System.Type.GetType("System.String");//WCContactName
                dtFinal.Columns[132].DataType = System.Type.GetType("System.String");//WCPhone
                dtFinal.Columns[133].DataType = System.Type.GetType("System.String");//WCEmail
                dtFinal.Columns[134].DataType = System.Type.GetType("System.String");//WCAddress1
                dtFinal.Columns[135].DataType = System.Type.GetType("System.String");//WCAddress2
                dtFinal.Columns[136].DataType = System.Type.GetType("System.String");//WCCity
                dtFinal.Columns[137].DataType = System.Type.GetType("System.String");//WCState
                dtFinal.Columns[138].DataType = System.Type.GetType("System.String");//WCZipCode
                dtFinal.Columns[139].DataType = System.Type.GetType("System.String");//WCCounty
                dtFinal.Columns[140].DataType = System.Type.GetType("System.String");//WCCountry
                dtFinal.Columns[141].DataType = System.Type.GetType("System.String");//CoordinatedTDBenefit
                dtFinal.Columns[142].DataType = System.Type.GetType("System.Boolean");//Retroactive
                dtFinal.Columns[143].DataType = System.Type.GetType("System.String");//EliminationPeriod
                dtFinal.Columns[144].DataType = System.Type.GetType("System.String");//CPIPct
                dtFinal.Columns[145].DataType = System.Type.GetType("System.DateTime");//CPIDate
                dtFinal.Columns[146].DataType = System.Type.GetType("System.Single");//IPIRate
                dtFinal.Columns[147].DataType = System.Type.GetType("System.String");//OtherAddress1
                dtFinal.Columns[148].DataType = System.Type.GetType("System.String");//OtherAddress2
                dtFinal.Columns[149].DataType = System.Type.GetType("System.String");//OtherCity
                dtFinal.Columns[150].DataType = System.Type.GetType("System.String");//OtherState
                dtFinal.Columns[151].DataType = System.Type.GetType("System.String");//OtherZipCode
                dtFinal.Columns[152].DataType = System.Type.GetType("System.String");//OtherCounty
                dtFinal.Columns[153].DataType = System.Type.GetType("System.String");//OtherCountry
                dtFinal.Columns[154].DataType = System.Type.GetType("System.Int32");//HeartPermanentImpairmentID
                dtFinal.Columns[155].DataType = System.Type.GetType("System.Int32");//EjectionFractionID
                dtFinal.Columns[156].DataType = System.Type.GetType("System.Int32");//NYHeartAssocFuncClassificationID
                dtFinal.Columns[157].DataType = System.Type.GetType("System.Boolean");//OdgComorbidityDepression
                dtFinal.Columns[158].DataType = System.Type.GetType("System.Boolean");//OdgComorbidityDiabetes
                dtFinal.Columns[159].DataType = System.Type.GetType("System.Boolean");//OdgComorbidityHypertension
                dtFinal.Columns[160].DataType = System.Type.GetType("System.Boolean");//OdgComorbidityLegalRepresentation
                dtFinal.Columns[161].DataType = System.Type.GetType("System.Boolean");//OdgComorbidityObesity
                dtFinal.Columns[162].DataType = System.Type.GetType("System.Boolean");//OdgComorbiditySmoker
                dtFinal.Columns[163].DataType = System.Type.GetType("System.Boolean");//OdgComorbiditySubstanceAbuse
                dtFinal.Columns[164].DataType = System.Type.GetType("System.Boolean");//OdgComorbiditySurgery
                dtFinal.Columns[165].DataType = System.Type.GetType("System.Int32");//OdgComorbidityOpioids
                dtFinal.Columns[166].DataType = System.Type.GetType("System.Int32");//OdgComorbidityJobClass
                dtFinal.Columns[167].DataType = System.Type.GetType("System.String");//LumpSumIndicator
                dtFinal.Columns[168].DataType = System.Type.GetType("System.Int32");//BenefitOffsetID
                dtFinal.Columns[169].DataType = System.Type.GetType("System.Int32");//LossOfEarningCapacityPct
                dtFinal.Columns[170].DataType = System.Type.GetType("System.Int32");//PreExistingDisabilityPct
                dtFinal.Columns[171].DataType = System.Type.GetType("System.Int32");//TDBenefitExtinguishmentID
                dtFinal.Columns[172].DataType = System.Type.GetType("System.Int32");//TaxFilingStatusID
                dtFinal.Columns[173].DataType = System.Type.GetType("System.Int32");//NumberOfEntitledExemptions
                dtFinal.Columns[174].DataType = System.Type.GetType("System.String");//EducationLevel
                dtFinal.Columns[175].DataType = System.Type.GetType("System.DateTime");//FirstDayOfDisabilityAfterWaitingPeriod
                dtFinal.Columns[176].DataType = System.Type.GetType("System.DateTime");//DateClaimAdminKnewOfEmployeeRepresentation
                dtFinal.Columns[177].DataType = System.Type.GetType("System.Int32");//AgreementToCompensateID
                dtFinal.Columns[178].DataType = System.Type.GetType("System.DateTime");//DenialRescissionDate
                dtFinal.Columns[179].DataType = System.Type.GetType("System.Int32");//PartialDenialID
                dtFinal.Columns[180].DataType = System.Type.GetType("System.DateTime");//PartialDenialEffectiveDate
                dtFinal.Columns[181].DataType = System.Type.GetType("System.DateTime");//AwardOrderDate
                dtFinal.Columns[182].DataType = System.Type.GetType("System.Int32");//ReducedBenefitAmountTypeID
                dtFinal.Columns[183].DataType = System.Type.GetType("System.Int32");//InitialRTWTypeID
                dtFinal.Columns[184].DataType = System.Type.GetType("System.String");//InitialRTWPhysicalRestrictionsIndicator
                dtFinal.Columns[185].DataType = System.Type.GetType("System.String");//InitialRTWWithSameEmployerIndicator
                dtFinal.Columns[186].DataType = System.Type.GetType("System.DateTime");//InitialEmployerKnowledgeOfDisabilityDate
                dtFinal.Columns[187].DataType = System.Type.GetType("System.DateTime");//InitialDateAdminKnewOfLossTime
                dtFinal.Columns[188].DataType = System.Type.GetType("System.DateTime");//CurrentLastWorkedDate
                dtFinal.Columns[189].DataType = System.Type.GetType("System.DateTime");//CurrentDisabiltyBeginDate
                dtFinal.Columns[190].DataType = System.Type.GetType("System.DateTime");//LatestRTWDate
                dtFinal.Columns[191].DataType = System.Type.GetType("System.Int32");//LatestRTWTypeID
                dtFinal.Columns[192].DataType = System.Type.GetType("System.String");//LatestRTWPhysicalRestrictionsIndicator
                dtFinal.Columns[193].DataType = System.Type.GetType("System.String");//LatestRTWWithSameEmployerIndicator
                dtFinal.Columns[194].DataType = System.Type.GetType("System.Int32");//NonConsecutivePeriodID
                dtFinal.Columns[195].DataType = System.Type.GetType("System.DateTime");//DateEmployerKnewOfCurrentLossTime
                dtFinal.Columns[196].DataType = System.Type.GetType("System.DateTime");//CurrentDateAdminKnewOfLossTime
                dtFinal.Columns[197].DataType = System.Type.GetType("System.String");//FirstNameOverride
                dtFinal.Columns[198].DataType = System.Type.GetType("System.String");//LastNameOverride
                dtFinal.Columns[199].DataType = System.Type.GetType("System.DateTime");//SuspensionEffectiveDateOverride
                dtFinal.Columns[200].DataType = System.Type.GetType("System.String");//SuspensionNarrative
                dtFinal.Columns[201].DataType = System.Type.GetType("System.String");//EEIDAssignedByJurisdiction
                dtFinal.Columns[202].DataType = System.Type.GetType("System.String");//CancelReasonNarrative
                dtFinal.Columns[203].DataType = System.Type.GetType("System.String");//RelatedJurisdictionClaimNumber
                dtFinal.Columns[204].DataType = System.Type.GetType("System.Boolean");//MedRecordReleaseOnFile
                dtFinal.Columns[205].DataType = System.Type.GetType("System.Boolean");//EmployeeSSNReleaseOnFile
                dtFinal.Columns[206].DataType = System.Type.GetType("System.String");//ERIDAssignedByJurisdiction
                dtFinal.Columns[207].DataType = System.Type.GetType("System.String");//InsolventInsurerFEIN
                dtFinal.Columns[208].DataType = System.Type.GetType("System.DateTime");//IndemnityThruDateForAcquiredClaim
                dtFinal.Columns[209].DataType = System.Type.GetType("System.Single");//CurrentOverpaymentAmount
                dtFinal.Columns[210].DataType = System.Type.GetType("System.String");//ManagedCareOrganizationCode
                dtFinal.Columns[211].DataType = System.Type.GetType("System.String");//ManagedCareOrganizationID
                dtFinal.Columns[212].DataType = System.Type.GetType("System.String");//ManagedCareOrganizationName
                dtFinal.Columns[213].DataType = System.Type.GetType("System.String");//ManualStateInterventionResolved
                dtFinal.Columns[214].DataType = System.Type.GetType("System.Int32");//InitialTreatmentID
                dtFinal.Columns[215].DataType = System.Type.GetType("System.String");//BodyPartLocationCode
                dtFinal.Columns[216].DataType = System.Type.GetType("System.String");//BodyPartFingerToeLocationCode
                dtFinal.Columns[217].DataType = System.Type.GetType("System.String");//AnticipatedWageLoss
                dtFinal.Columns[218].DataType = System.Type.GetType("System.String");//PreexistingDisability
                dtFinal.Columns[219].DataType = System.Type.GetType("System.Single");//DiscontinuedFringeBenefits
                dtFinal.Columns[220].DataType = System.Type.GetType("System.String");//PermanentImpairmentMinimumPayment
                dtFinal.Columns[221].DataType = System.Type.GetType("System.Single");//WeeklyIncomeAmountForOffset
                dtFinal.Columns[222].DataType = System.Type.GetType("System.Int32");//CancelReasonID
                dtFinal.Columns[223].DataType = System.Type.GetType("System.Int32");//EDIClaimTypeID
                dtFinal.Columns[224].DataType = System.Type.GetType("System.Int32");//AcquisitionStatusID
                dtFinal.Columns[225].DataType = System.Type.GetType("System.Int32");//DependentExtentOfDependencyID
                dtFinal.Columns[226].DataType = System.Type.GetType("System.String");//PhysicianFormattedAddress
                dtFinal.Columns[227].DataType = System.Type.GetType("System.String");//OtherFormattedAddress
                dtFinal.Columns[228].DataType = System.Type.GetType("System.String");//WCFormattedAddress
                dtFinal.Columns[229].DataType = System.Type.GetType("System.DateTime");//DateClaimAdministratorKnewClaimMetReportingRequirement
                dtFinal.Columns[230].DataType = System.Type.GetType("System.DateTime");//DateClaimAdministratorKnewCurrentDisabilityDate
                dtFinal.Columns[231].DataType = System.Type.GetType("System.DateTime");//DateEmployerKnewOfDisability
                dtFinal.Columns[232].DataType = System.Type.GetType("System.DateTime");//AcquisitionDate
                dtFinal.Columns[233].DataType = System.Type.GetType("System.String");//PermanentImpairmentBodyPartCode
                dtFinal.Columns[234].DataType = System.Type.GetType("System.String");//PermanentImpairmentBodyPartLocationCode
                dtFinal.Columns[235].DataType = System.Type.GetType("System.String");//BenefitChangeReasonCode

                if (dtFinal.Columns[235].ColumnName != "BenefitChangeReasonCode")
                {
                    MessageBox.Show("Column count mismatch detected, please verify you are loading the correct spreadsheet with the related load type.");
                    dtFinal = null;
                }
                return dtFinal;
            }
            catch
            {
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