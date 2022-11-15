using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIClientImport
{
    public class Claim
    {

        public bool ValidateClaim (DataTable dtSpreadsheet)
        {
            bool _overallValidation = true;
            bool isValid;
            double dtvalue;
            DateTime dateInfo;


            foreach (DataRow row in dtSpreadsheet.Rows)
            {
                _overallValidation = true;
                int i = 0;

                //ClaimID
                isValid = Validate.checkInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i ++;

                //InsuranceLineID
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '1'; //default value is 1
                }
                isValid = Validate.checkInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //PolicyID - need to get this from Sims
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

                //PolicyPeriodID - need to get this from Sims
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

                //ClaimNumber
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkString(row[i].ToString(),50);
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //LossDate
                if (row[i].ToString().Length == 0)
                {
                    row[i] = null; //default value
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

                //LossTime
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
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
                }
                i++;

                //ClassCode
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

                //ManualClassCode
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

                //ReportingLocationID
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

                //ExaminerCode
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

                //ClaimsAssistantCode
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

                //ExaminerCode2
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

                //ExaminerCode3
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

                //BusinessNatureID
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

                //InjuryLocationID
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

                //EmployerPremises
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

                //OthersInjured
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

                //InjuryLocationDesc
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 500);
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //InjuryAddress1
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

                //InjuryAddress2
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

                //InjuryCity
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

                //InjuryZipCode
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

                //InjuryState
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

                //InjuryCounty
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

                //InjuryDepartment
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

                //InjuryCauseID
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

                //MasterClaimID
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

                //MasterClaimNumber
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

                //ExternalClaimNumber
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

                //InsurerClaimNumber
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

                //AffiliateClaimNumber
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

                //FileLocation
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

                //FileCheckedOutBy
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

                //CatastropheID
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

                //MPNStatusID
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

                //WCABCaseNumber
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

                //WCABClosedDate
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

                //WCABActionDesc
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

                //HCOCode
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

                //NumberOfEmployees
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

                //ClaimSourceID
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
                    row[i] = " "; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 50);
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //LockedBy
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

                //LockedDate
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

                //InsuredDriverID
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

                //ClaimLossDesc
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 500);
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //LossDateSecondary
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

                //OrganizationID
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

                //InsuredUnitTypeID
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

                //InsuredUnitID
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

                //JurisdictionClaimNumber
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

                //InsuredDriverTypeID
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

                //ClassCodeID
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

                //ClaimsMadeDate
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

                //InsuredBuildingID
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

                //InjuryCountry
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

                //NoticeDate
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

                //PayReasonID
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

                //ClaimCauseID
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

                //CounselChoiceID
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

                //AllegedDamages
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkMoney(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //LiquidatorClaimNumber
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

                //BenefitClassID
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

                //AdditionalInsuredAddress1
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

                //AdditionalInsuredAddress2
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

                //AdditionalInsuredCity
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

                //AdditionalInsuredCounty
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

                //AdditionalInsuredState
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

                //AdditionalInsuredZipCode
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

                //AdditionalInsuredCountry
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

                //TPAClaimNumber
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

                //SendToEBIXOverride
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 1);
                if (!isValid)
                {
                    _overallValidation = false;
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
                    }
                }
                i++;

                //AccidentSiteOrganizationName
                if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                else
                {
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false;
                    }
                }
                i++;

                //InsuredREportNUmber
                if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                else
                {
                    isValid = Validate.checkString(row[i].ToString(), 25);
                    if (!isValid)
                    {
                        _overallValidation = false;
                    }
                }
                i++;

                //JurisdictionBranchOfficeCode
                if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                else
                {
                    isValid = Validate.checkString(row[i].ToString(), 2);
                    if (!isValid)
                    {
                        _overallValidation = false;
                    }
                }
                i++;

                //WCIRBClaimNumber
                if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                else
                {
                    isValid = Validate.checkString(row[i].ToString(), 25);
                    if (!isValid)
                    {
                        _overallValidation = false;
                    }
                }
                i++;

                //InsuredLocationIdentifier
                if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                else
                {
                    isValid = Validate.checkString(row[i].ToString(), 15);
                    if (!isValid)
                    {
                        _overallValidation = false;
                    }
                }
                i++;

                //CollectiveBargainingAgreementCode
                if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                else
                {
                    isValid = Validate.checkString(row[i].ToString(), 1);
                    if (!isValid)
                    {
                        _overallValidation = false;
                    }
                }
                i++;

                //ManualSubClassCode
                if (row[i].ToString() == "NULL" || row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                else
                {
                    isValid = Validate.checkString(row[i].ToString(), 2);
                    if (!isValid)
                    {
                         _overallValidation = false;
                    }
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
