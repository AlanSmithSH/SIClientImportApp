using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIClientImport
{
    class Employment
    {

        public bool ValidateEmployment(DataTable dtSpreadsheet)
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

                //EmploymentID
                isValid = Validate.checkInt(row[i].ToString());
                if (!isValid)
                {
                    _overallValidation = false;
                }
                i++;

                //ClaimantID
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

                //OccupationID
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

                //OccupationDesc
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

                //EmploymentStatusID
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

                //HoursPerDay
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

                //DaysPerWeek
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

                //WeeklyHours
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

                //Wages
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

                //WageFrequencyID
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

                //HireDate
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

                //TerminationDate
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

                //OtherPayments
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

                //SupervisorFirstName
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

                //SupervisorMiddleName
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

                //SupervisorLastName
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

                //SupervisorTitle
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

                //SupervisorWorkPhone
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

                //SupervisorFax
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

                //SupervisorEmail
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

                //ConcurrentEmployerIncome
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

                //ConcurrentEmployerFrequencyID
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

                //ConcurrentEmployerName
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

