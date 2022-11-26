using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheakley.WC.Sims.Common;
using System.Windows.Forms;

namespace SIClientImport
{
    public class Claim
    {
        public bool ValidateClaim (DataTable dtSpreadsheet, string strDateFormat, string strPolicyNumber)
        {
            bool _overallValidation = true;
            bool isValid;
            double dtvalue;
            DateTime dateInfo;
            string dateString;
            bool isDuplicateClaimNumber;
            int rowcount = 0;

            Form1.dtFinalLoad = BuildFinalClaimTable(dtSpreadsheet);

            if (Form1.dtFinalLoad == null)
            {
                return false;
            }

            if (Form1.dtFinalClaimLoad == null)
            {
                Form1.dtFinalClaimLoad = Form1.dtFinalLoad.Clone();
            }


            foreach (DataRow row in dtSpreadsheet.Rows)
            {
                try
                {

                    _overallValidation = true;
                    int i = 0;
                    rowcount++;

                    //ClaimId
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    //isValid = Validate.checkInt(row[i].ToString());
                    //if (!isValid)
                    //{
                    //    _overallValidation = false;
                    //}
                    i++;

                    //InsuranceLineID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value is 1
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
						
                    }
                    i++;

                    //PolicyID - need to get this from Sims
                    row[i] = SQLMethods.RetrievePolicyID(strPolicyNumber); //default value

                    if (string.IsNullOrEmpty(row[i].ToString()))
                    {
                        _overallValidation = false;
                        //
                        Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), "Policy ID not found for Policy Number");
                        //Form1.dtBadData.ImportRow(row);
                        //MessageBox.Show("PolicyID not found for Policy Number: " + strPolicyNumber + Environment.NewLine + "Please verify policy number is correct. Processing stopped.");
                        //break;
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //PolicyPeriodID - need to get this from Sims
                    row[i] = SQLMethods.RetrievePolicyPeriodID(row["PolicyID"].ToString()); //default value

                    if (string.IsNullOrEmpty(row[i].ToString()))
                    {
                        _overallValidation = false;

                        Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), "PolicyPeriodID not found for Policy Number");
                        //
                        //Form1.dtBadData.ImportRow(row);
                        //MessageBox.Show("PolicyPeriodID not found for Policy Number: " + strPolicyNumber + Environment.NewLine + "Please verify policy number is correct. Processing stopped.");
                        //break;
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ClaimNumber
                    isDuplicateClaimNumber = true;
                    if (row[i].ToString().Length != 0)
                    {
                        isDuplicateClaimNumber = SQLMethods.CheckForExistingClaimNumber(row[i].ToString());
                    }
                    if ((row[i].ToString().Length == 0) || isDuplicateClaimNumber)
                    {
                        Form1.dtBadData.ImportRow(row);
                        MessageBox.Show("Claim Number " + row[i].ToString() + " already exists in dbo.Claim. " + Environment.NewLine + "Please verify claim number is correct and hasn't been loaded previously. Processing stopped.");
                        break;
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //LossDate
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        dateString = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        if (dateString == "fail")
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //LossTime
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        dtvalue = double.Parse(row[i].ToString());
                        dateInfo = DateTime.FromOADate(dtvalue);
                        row[i] = dateInfo.ToShortTimeString();
                        //row[i] = dateInfo;
                    }
                    isValid = Validate.checkString(row[i].ToString(), 11);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //JurisdictionID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ClassCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 10);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ManualClassCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ReportingLocationID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ExaminerCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ClaimsAssistantCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ExaminerCode2
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ExaminerCode3
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //BusinessNatureID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryLocationID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //EmployerPremises
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //OthersInjured
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkBit(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryLocationDesc
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 500);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryAddress1
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryAddress2
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryCity
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryZipCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 10);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryState
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryCounty
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryDepartment
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryCauseID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //MasterClaimID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //MasterClaimNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ExternalClaimNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InsurerClaimNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //AffiliateClaimNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //FileLocation
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //FileCheckedOutBy
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //CatastropheID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //MPNStatusID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //WCABCaseNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 20);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //WCABClosedDate
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        dateString = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        if (dateString == "fail")
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //WCABActionDesc
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 255);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //HCOCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //NumberOfEmployees
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ClaimSourceID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
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
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
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
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
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
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //UpdatedBy
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = " "; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //LockedBy
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //LockedDate
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        dateString = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        if (dateString == "fail")
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
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
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ClaimLossDesc
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 500);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //LossDateSecondary
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        dateString = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        if (dateString == "fail")
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //OrganizationID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
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
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InsuredUnitID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //JurisdictionClaimNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
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
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ClassCodeID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ClaimsMadeDate
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        dateString = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        if (dateString == "fail")
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
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
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryCountry
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //NoticeDate
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        dateString = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        if (dateString == "fail")
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                        else
                        {
                            row[i] = Validate.applyDateFormat(row[i].ToString(), strDateFormat);
                        }
                    }
                    isValid = Validate.checkDate(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //PayReasonID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //ClaimCauseID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //CounselChoiceID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //AllegedDamages
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    isValid = Validate.checkMoney(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //LiquidatorClaimNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
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
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //AdditionalInsuredAddress1
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //AdditionalInsuredAddress2
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //AdditionalInsuredCity
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //AdditionalInsuredCounty
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //AdditionalInsuredState
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //AdditionalInsuredZipCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 10);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //AdditionalInsuredCountry
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //TPAClaimNumber
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //SendToEBIXOverride
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //AccidentPremisesTypeID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value
                    }
                    isValid = Validate.checkTinyInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryCountryCode
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = "USA"; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 3);
                    if (!isValid)
                    {
                        _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                    }
                    i++;

                    //InjuryFormattedAddress
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        isValid = Validate.checkString(row[i].ToString(), 1000);
                        if (!isValid)
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                    }
                    i++;

                    //AccidentSiteOrganizationName
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        isValid = Validate.checkString(row[i].ToString(), 50);
                        if (!isValid)
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
					        
                        }
                    }
                    i++;

                    //InsuredREportNUmber
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        isValid = Validate.checkString(row[i].ToString(), 25);
                        if (!isValid)
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                    }
                    i++;

                    //JurisdictionBranchOfficeCode
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        isValid = Validate.checkString(row[i].ToString(), 2);
                        if (!isValid)
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                    }
                    i++;

                    //WCIRBClaimNumber
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        isValid = Validate.checkString(row[i].ToString(), 25);
                        if (!isValid)
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                    }
                    i++;

                    //InsuredLocationIdentifier
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        isValid = Validate.checkString(row[i].ToString(), 15);
                        if (!isValid)
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                    }
                    i++;

                    //CollectiveBargainingAgreementCode
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        isValid = Validate.checkString(row[i].ToString(), 1);
                        if (!isValid)
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
                    }
                    i++;

                    //ManualSubClassCode
                    if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    else
                    {
                        isValid = Validate.checkString(row[i].ToString(), 2);
                        if (!isValid)
                        {
                            _overallValidation = false; 
							Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
							 
                        }
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

        public static DataTable BuildFinalClaimTable (DataTable dt)
        {
            DataTable dtFinal = new DataTable();
            foreach (DataColumn column in dt.Columns)
            {
                dtFinal.Columns.Add(column.ColumnName);
            }
            try
            {
                dtFinal.Columns[0].DataType = System.Type.GetType("System.Guid");//ClaimID
                dtFinal.Columns[1].DataType = System.Type.GetType("System.Int32");//InsuranceLineId
                dtFinal.Columns[2].DataType = System.Type.GetType("System.Int32");//PolicyId
                dtFinal.Columns[3].DataType = System.Type.GetType("System.Int32");//PolicyPeriodId
                dtFinal.Columns[4].DataType = System.Type.GetType("System.String");//ClaimNumber
                dtFinal.Columns[5].DataType = System.Type.GetType("System.DateTime");//LossDate
                dtFinal.Columns[6].DataType = System.Type.GetType("System.String");//LossTime
                dtFinal.Columns[7].DataType = System.Type.GetType("System.Byte");//JurisdictionID
                dtFinal.Columns[8].DataType = System.Type.GetType("System.String");//ClassCode
                dtFinal.Columns[9].DataType = System.Type.GetType("System.String");//ManualClassCode
                dtFinal.Columns[10].DataType = System.Type.GetType("System.Int32");//ReportingLocationID
                dtFinal.Columns[11].DataType = System.Type.GetType("System.String");//ExaminerCode
                dtFinal.Columns[12].DataType = System.Type.GetType("System.String");//ClaimsAssistantCode
                dtFinal.Columns[13].DataType = System.Type.GetType("System.String");//ExaminerCode2
                dtFinal.Columns[14].DataType = System.Type.GetType("System.String");//ExaminerCode3
                dtFinal.Columns[15].DataType = System.Type.GetType("System.Int32");//BusinessNatureID
                dtFinal.Columns[16].DataType = System.Type.GetType("System.Int32");//InjuryLocationID
                dtFinal.Columns[17].DataType = System.Type.GetType("System.Boolean");//EmployerPremises
                dtFinal.Columns[18].DataType = System.Type.GetType("System.Boolean");//OthersInjured
                dtFinal.Columns[19].DataType = System.Type.GetType("System.String");//InjuryLocationDesc
                dtFinal.Columns[20].DataType = System.Type.GetType("System.String");//InjuryAddress1
                dtFinal.Columns[21].DataType = System.Type.GetType("System.String");//InjuryAddress2
                dtFinal.Columns[22].DataType = System.Type.GetType("System.String");//InjuryCity
                dtFinal.Columns[23].DataType = System.Type.GetType("System.String");//InjuryZipCode
                dtFinal.Columns[24].DataType = System.Type.GetType("System.String");//InjuryState
                dtFinal.Columns[25].DataType = System.Type.GetType("System.String");//InjuryCounty
                dtFinal.Columns[26].DataType = System.Type.GetType("System.String");//InjuryDepartment
                dtFinal.Columns[27].DataType = System.Type.GetType("System.Int32");//InjuryCauseID
                dtFinal.Columns[28].DataType = System.Type.GetType("System.Int32");//MasterClaimID
                dtFinal.Columns[29].DataType = System.Type.GetType("System.String");//MasterClaimNumber
                dtFinal.Columns[30].DataType = System.Type.GetType("System.String");//ExternalClaimNumber
                dtFinal.Columns[31].DataType = System.Type.GetType("System.String");//InsurerClaimNumber
                dtFinal.Columns[32].DataType = System.Type.GetType("System.String");//AffiliateClaimNumber
                dtFinal.Columns[33].DataType = System.Type.GetType("System.String");//FileLocation
                dtFinal.Columns[34].DataType = System.Type.GetType("System.String");//FileCheckedOutBy
                dtFinal.Columns[35].DataType = System.Type.GetType("System.Int32");//CatastropheID
                dtFinal.Columns[36].DataType = System.Type.GetType("System.Int32");//MPNStatusID
                dtFinal.Columns[37].DataType = System.Type.GetType("System.String");//WCABCaseNumber
                dtFinal.Columns[38].DataType = System.Type.GetType("System.DateTime");//WCABClosedDate
                dtFinal.Columns[39].DataType = System.Type.GetType("System.String");//WCABActionDesc
                dtFinal.Columns[40].DataType = System.Type.GetType("System.String");//HCOCode
                dtFinal.Columns[41].DataType = System.Type.GetType("System.Int32");//NumberOfEmployees
                dtFinal.Columns[42].DataType = System.Type.GetType("System.Int32");//ClaimSourceID
                dtFinal.Columns[43].DataType = System.Type.GetType("System.DateTime");//EntryDate
                dtFinal.Columns[44].DataType = System.Type.GetType("System.String");//EnteredBy
                dtFinal.Columns[45].DataType = System.Type.GetType("System.DateTime");//UpdatedDate
                dtFinal.Columns[46].DataType = System.Type.GetType("System.String");//UpdatedBy
                dtFinal.Columns[47].DataType = System.Type.GetType("System.String");//LockedBy
                dtFinal.Columns[48].DataType = System.Type.GetType("System.DateTime");//LockedDate
                dtFinal.Columns[49].DataType = System.Type.GetType("System.Int32");//InsuredDriverID
                dtFinal.Columns[50].DataType = System.Type.GetType("System.String");//ClaimLossDesc
                dtFinal.Columns[51].DataType = System.Type.GetType("System.DateTime");//LossDateSecondary
                dtFinal.Columns[52].DataType = System.Type.GetType("System.Int32");//OrganizationID
                dtFinal.Columns[53].DataType = System.Type.GetType("System.Int32");//InsuredUnitTypeID
                dtFinal.Columns[54].DataType = System.Type.GetType("System.Int32");//InsuredUnitID
                dtFinal.Columns[55].DataType = System.Type.GetType("System.String");//JurisdictionClaimNumber
                dtFinal.Columns[56].DataType = System.Type.GetType("System.Int32");//InsuredDriverTypeID
                dtFinal.Columns[57].DataType = System.Type.GetType("System.Int32");//ClassCodeID
                dtFinal.Columns[58].DataType = System.Type.GetType("System.DateTime");//ClaimsMadeDate
                dtFinal.Columns[59].DataType = System.Type.GetType("System.Int32");//InsuredBuildingID
                dtFinal.Columns[60].DataType = System.Type.GetType("System.String");//InjuryCountry
                dtFinal.Columns[61].DataType = System.Type.GetType("System.DateTime");//NoticeDate
                dtFinal.Columns[62].DataType = System.Type.GetType("System.Int32");//PayReasonID
                dtFinal.Columns[63].DataType = System.Type.GetType("System.Int32");//ClaimCauseID
                dtFinal.Columns[64].DataType = System.Type.GetType("System.Int32");//CounselChoiceID
                dtFinal.Columns[65].DataType = System.Type.GetType("System.Single");//AllegedDamages
                dtFinal.Columns[66].DataType = System.Type.GetType("System.String");//LiquidatorClaimNumber
                dtFinal.Columns[67].DataType = System.Type.GetType("System.Int32");//BenefitClassID
                dtFinal.Columns[68].DataType = System.Type.GetType("System.String");//AdditionalInsuredAddress1
                dtFinal.Columns[69].DataType = System.Type.GetType("System.String");//AdditionalInsuredAddress2
                dtFinal.Columns[70].DataType = System.Type.GetType("System.String");//AdditionalInsuredCity
                dtFinal.Columns[71].DataType = System.Type.GetType("System.String");//AdditionalInsuredCounty
                dtFinal.Columns[72].DataType = System.Type.GetType("System.String");//AdditionalInsuredState
                dtFinal.Columns[73].DataType = System.Type.GetType("System.String");//AdditionalInsuredZipCode
                dtFinal.Columns[74].DataType = System.Type.GetType("System.String");//AdditionalInsuredCountry
                dtFinal.Columns[75].DataType = System.Type.GetType("System.String");//TPAClaimNumber
                dtFinal.Columns[76].DataType = System.Type.GetType("System.String");//SendToEBIXOverride
                dtFinal.Columns[77].DataType = System.Type.GetType("System.Byte");//AccidentPremisesTypeID
                dtFinal.Columns[78].DataType = System.Type.GetType("System.String");//InjuryCountryCode
                dtFinal.Columns[79].DataType = System.Type.GetType("System.String");//InjuryFormattedAddress
                dtFinal.Columns[80].DataType = System.Type.GetType("System.String");//AccidentSiteOrganizationName
                dtFinal.Columns[81].DataType = System.Type.GetType("System.String");//InsuredReportNumber
                dtFinal.Columns[82].DataType = System.Type.GetType("System.String");//JurisdictionBranchOfficeCode
                dtFinal.Columns[83].DataType = System.Type.GetType("System.String");//WCIRBClaimNumber
                dtFinal.Columns[84].DataType = System.Type.GetType("System.String");//InsuredLocationIdentifier
                dtFinal.Columns[85].DataType = System.Type.GetType("System.String");//CollectiveBargainingAgreementCode
                dtFinal.Columns[86].DataType = System.Type.GetType("System.String");//ManualSubClassCode

                if (dtFinal.Columns[86].ColumnName !="ManualSubClassCode")
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
                for (int j = 0; j <= cl-1; j++)
                {
                    if (Form1.dtFinalLoad.Columns[j].DataType == typeof(string))
                    {
                        //data is already string
                    }
                    else if (Form1.dtFinalLoad.Columns[j].DataType == typeof(Int32))
                    {
                        //drResult[j].GetType = typeof(Int32);
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
