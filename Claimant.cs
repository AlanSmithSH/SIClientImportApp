using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIClientImport
{
    class Claimant
    {
        public bool ValidateClaimant(DataTable dtSpreadsheet)
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

                //ClaimantID
                if (row[i].ToString().Length == 0)
                {
                    row[i] = null; //default value
                }
                isValid = Validate.checkInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //ClaimID
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

                //ClaimantTypeID
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

                //ClaimantStatusID
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkTinyInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //AddressBookID
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

                //DeathDate
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

                //DeathResultOfInjury
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

                //DriverLicense
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

                //Accepted
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

                //AcceptedDate
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

                //Delayed
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

                //DelayedDate
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

                //DelayedReasonID
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

                //DelayedComments
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

                //Denied
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

                //DeniedDate
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

                //DeniedReasonID
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

                //DeniedComments
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

                //ClosedDate
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

                //ReopenedDate
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

                //ReopenedReasonID
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

                //SeverityID
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

                //SettlementTypeID
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

                //FraudID
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

                //JointCoverage
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

                //TotalGrossIncurred
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

                //BodyPartID
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

                //NatureOfInjuryID
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

                //InjuryTypeID
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

                //ActivityDesc
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

                //InjuryDesc
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

                //HowInjuryOccurred
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

                //InjuryEquipment
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

                //InsuredReportedDate
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

                //AdministratorReportedDate
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

                //NoticeOfInjuryDate
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

                //Litigated
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

                //Subrogated
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

                //SubroStatuteDate
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

                //SubroPotential
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

                //NumberDependents
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

                //BeginWorkTime
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

                //LastWorkedDate
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

                //UnableWorkDay
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

                //ReturnedWorkDate
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

                //OffWork
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

                //FullDayPaid
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

                //SalaryContinued
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

                //PhysicianFirstName
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

                //PhysicianMiddleName
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

                //PhysicianLastName
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

                //PhysicianWorkPhone
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

                //PhysicianAddress1
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

                //PhysicianAddress2
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

                //PhysicianCity
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

                //PhysicianState
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

                //PhysicianZipCode
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

                //PhysicianCounty
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

                //HospitalizedOvernight
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

                //HospitalAddressBookID
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

                //ERTreatment
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

                //TDRate
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

                //PDRate
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

                //VRRate
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

                //DeathRate
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

                //LifePensionRate
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

                //SupplementalBenefits
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

                //PDWeeks
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkNumeric(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //DWCProvideDate
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

                //DWCReceivedDate
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

                //ContinuousTraumaBeginDate
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

                //ContinuousTraumaEndDate
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

                //PDRating
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkNumeric(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //DisabilityRatingDate
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

                //DisabilityBeginDate
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

                //PermanentStationaryDate
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

                //ModifiedDutyOffered
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

                //WageStatementReceived
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

                //MedicalManagement
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

                //ClaimantComments
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

                //PbmTerminationDate
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

                //LossTypeID
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

                //Totaled
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

                //TotaledDate
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

                //TotaledComments
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

                //InsuredIsClaimant
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

                //ClaimantUnitTypeID
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

                //ClaimantUnitType
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

                //Benefits4850
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

                //InsuredLiabilityPercentage
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkDecimal(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
                }
                i++;

                //SpecialInstructions
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 4000);
                if (!isValid)
                {
                    _overallValidation = false;
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
                    _overallValidation = false;
                }
                i++;

                //SuffixCode
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

                //InsuredUnitType
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

                //PhysicianCountry
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

                //ClosingCodeID
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

                //CalculationInstructions
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 4000);
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

                //MemberTypeID
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

                //HospitalAdmissionDate
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

                //HospitalDischargeDate
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

                //ConditionCode
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

                //OtherName
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

                //OtherDesc
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

                //OtherPhone
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

                //OtherEmail
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

                //PermanentImpairmentPct
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

                //DismembermentParalysisPct
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

                //CosmeticDisfigurementPct
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

                //OtherProviderAddressBookID
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

                //OtherProviderAdmissionDate
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

                //OtherProviderDischargeDate
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

                //WCWeeklyRate
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

                //WCStatus
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

                //WCCarrier
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

                //WCContactName
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

                //WCPhone
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

                //WCEmail
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

                //WCAddress1
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

                //WCAddress2
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

                //WCCity
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

                //WCState
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

                //WCZipCode
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

                //WCCounty
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

                //WCCountry
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

                //CoordinatedTDBenefit
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

                //Retroactive
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

                //EliminationPeriod
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

                //CPIPct
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

                //IPIRate
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

                //OtherAddress1
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

                //OtherAddress2
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

                //OtherCity
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

                //OtherState
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

                //OtherZipCode
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

                //OtherCounty
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

                //OtherCountry
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

                //HeartPermanentImpairmentID
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

                //EjectionFractionID
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

                //NYHeartAssocFuncClassificationID
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

                //OdgComorbidityDepression
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

                //OdgComorbidityDiabetes
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

                //OdgComorbidityHypertension
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

                //OdgComorbidityLegalRepresentation
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

                //OdgComorbidityObesity
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

                //OdgComorbiditySmoker
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

                //OdgComorbiditySubstanceAbuse
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

                //OdgComorbiditySurgery
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

                //OdgComorbidityOpiods
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

                //OdgComorbidityJobClass
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

                //LumpSumIndicator
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

                //BenefitOffsetID
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '1'; //default value
                }
                isValid = Validate.checkInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
                }
                i++;

                //EducationLevel
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

                //FirstDateOfDisabilityAfterWaitingPeriod
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

                //DateClaimAdminKnewOfEmployeeRepresentation
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

                //AgreementToCompensateID
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkTinyInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //DenialRescissionDate
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

                //PartialDenialID
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkTinyInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //PartialDenialEffectiveDate
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

                //AwardOrderDate
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

                //ReducedBenefitAmountTypeID
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkTinyInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
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
                    _overallValidation = false;
                }
                i++;

                //InitialRTWPhysicalRestrictionsIndicator
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

                //InitialRTWWithSameEmployer
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

                //InitialEmployerKnowledgeOfDisabilityDate
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

                //InitialDateAdminKnewOfLossTime
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

                //CurrentLastWorkDate
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

                //CurrentDisabilityBeginDate
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

                //LatestRTWDate
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

                //LatestRTWTypeID
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkTinyInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //LatestRTWPhysicalRestrictionsIndicator
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

                //LatestRTWWithSameEmployerIndicator
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

                //NonConsecutivePeriodID
                if (row[i].ToString().Length == 0)
                {
                    row[i] = '0'; //default value
                }
                isValid = Validate.checkTinyInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //DateEmployerKnewOfCurrentLossTime
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

                //CurrentDateAdminKnewOfLossTime
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

                //FirstNameOverride
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

                //LastNameOverride
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

                //SuspensionEffectiveDateOverride
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

                //SuspensionNarrative
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

                //EEIDAssignedByJurisdiction
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

                //CancelReasonNarrative
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

                //RelatedJurisdictionClaimNumber
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 25);
                if (!isValid)
                {
                    _overallValidation = false;
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
                    _overallValidation = false;
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
                    _overallValidation = false;
                }
                i++;

                //ERIDAssignedByJurisdiction
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 15);
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //InsolventInsurerFEIN
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

                //IndemnityThruDateForAcquiredClaim
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

                //CurrentOverpaymentAmount
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

                //ManagedCareOrganizationCode
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

                //ManagedCareOrganizationID
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

                //ManagedCareOrganizationName
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 40);
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //ManualStateInterventionResolved
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

                //InitialTreatmentID
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

                //BodyPartLocationCode
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

                //BodyPartFingerToeLocationCode
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

                //AnticipatedWageLoss
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

                //PreexistingDisability
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

                //DiscontinuedFringeBenefits
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

                //PermanentImpairmentMinimumPayment
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

                //WeeklyIncomeAmountForOffset
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

                //CancelReasonID
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

                //EDIClaimTypeID
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

                //AcquisitionStatusID
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

                //DependentExtentOfDependencyID
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

                //PhysicianFormattedAddress
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

                //OtherFormattedAddress
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

                //WCFormattedAddress
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

                //DateClaimAdministratorKnewClaimMetReportingRequirement
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

                //DateClaimAdministratorKnewCurrentDisabilityDate
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

                //DateEmployerKnewOfDisability
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

                //AcquisitionDate
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

                //PermanentImpairmentBodyPartCode
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

                //PermanentImpairmentBodyPartLocationCode
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

                //BenefitChangeReasonCode
                if (row[i].ToString().Length == 0)
                {
                    row[i] = ' '; //default value
                }
                isValid = Validate.checkString(row[i].ToString(), 1);
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