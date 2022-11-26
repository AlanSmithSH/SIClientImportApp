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
    public class Payee
    {
        public bool ValidatePayee(DataTable dtSpreadsheet, string strDateFormat)
        {
            bool _overallValidation = true;
            bool isValid;
            string dateString;
            int rowcount = 0;
            Form1.dtFinalLoad = BuildFinalPayeeTable(dtSpreadsheet);
            if (Form1.dtFinalLoad == null)
            {
                return false;
            }
            if (Form1.dtFinalPayeeLoad == null)
            {
                Form1.dtFinalPayeeLoad = Form1.dtFinalLoad.Clone();
            }
            foreach (DataRow row in dtSpreadsheet.Rows)
            {
                _overallValidation = true;
                int i = 0;
                rowcount++;
                try
                {
                    //ClaimNumber
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PaymentRunID
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

                    //PaymentID
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

                    //PayeeID
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

                    //PayeeTypeCode
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

                    //PayeeName1
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

                    //PayeeName2
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 80);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PayeeAddress1
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

                    //PayeeAddress2
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

                    //PayeeCity
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = 'I'; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PayeeState
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

                    //PayeeZip
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

                    //PayeeTaxID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 11);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //InsurerID
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

                    //ReserveTypeID
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

                    //PaymentTypeID
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

                    //PaymentMethodID
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

                    //Amount
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

                    //ProcessedDate
                    if (row[i].ToString().Length == 0)
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

                    //VoidDate
                    if (row[i].ToString().Length == 0)
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

                    //AddressInvalid
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

                    //AccountOverdrawn
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

                    //ReservesExceeded
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

                    //BlockedVendor
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

                    //InsurerCode
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

                    //EORPayment
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

                    //CheckDate
                    if (row[i].ToString().Length == 0)
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

                    //NoAccount
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

                    //ClaimVerificationBlock
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

                    //PharmacyPaymentCode
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

                    //CheckAddress1
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

                    //CheckAddress2
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

                    //CheckCity
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

                    //CheckState
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

                    //CheckZipCode
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

                    //SpecialHandling
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

                    //OfacMatch
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

                    //AdditionalPayee
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 2000);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PayeeIdentity
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '0'; //default value
                    }
                    //isValid = Validate.checkInt(row[i].ToString());
                    //if (!isValid)
                    //{
                    //    _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    //}
                    i++;

                    //FlagACH
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 100);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BankAccountID
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

                    //InsuredID
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

                    //EmailInvalid
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

                    //PhoneInvalid
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

        public static DataTable BuildFinalPayeeTable(DataTable dt)
        {
            DataTable dtFinal = new DataTable();
            foreach (DataColumn column in dt.Columns)
            {
                dtFinal.Columns.Add(column.ColumnName);
            }
            try 
            {
            dtFinal.Columns[0].DataType = System.Type.GetType("System.String");//ClaimNumber
            dtFinal.Columns[1].DataType = System.Type.GetType("System.Int32");//PaymentRunID
            dtFinal.Columns[2].DataType = System.Type.GetType("System.Int32");//PaymentID
            dtFinal.Columns[3].DataType = System.Type.GetType("System.Int32");//PayeeID
            dtFinal.Columns[4].DataType = System.Type.GetType("System.Char");//PayeeTypeCode
            dtFinal.Columns[5].DataType = System.Type.GetType("System.String");//PayeeName1
            dtFinal.Columns[6].DataType = System.Type.GetType("System.String");//PayeeName2
            dtFinal.Columns[7].DataType = System.Type.GetType("System.String");//PayeeAddress1
            dtFinal.Columns[8].DataType = System.Type.GetType("System.String");//PayeeAddress2
            dtFinal.Columns[9].DataType = System.Type.GetType("System.String");//PayeeCity
            dtFinal.Columns[10].DataType = System.Type.GetType("System.String");//PayeeState
            dtFinal.Columns[11].DataType = System.Type.GetType("System.String");//PayeeZip
            dtFinal.Columns[12].DataType = System.Type.GetType("System.String");//PayeeTaxID
            dtFinal.Columns[13].DataType = System.Type.GetType("System.Int32");//InsurerID
            dtFinal.Columns[14].DataType = System.Type.GetType("System.Int32");//ReserveTypeID
            dtFinal.Columns[15].DataType = System.Type.GetType("System.Int32");//PaymentTypeID
            dtFinal.Columns[16].DataType = System.Type.GetType("System.Int32");//PaymentMethodID
            dtFinal.Columns[17].DataType = System.Type.GetType("System.Single");//Amount
            dtFinal.Columns[18].DataType = System.Type.GetType("System.DateTime");//ProcessedDate
            dtFinal.Columns[19].DataType = System.Type.GetType("System.DateTime");//VoidDate
            dtFinal.Columns[20].DataType = System.Type.GetType("System.Boolean");//AddressInvalid
            dtFinal.Columns[21].DataType = System.Type.GetType("System.Boolean");//AccountOverdrawn
            dtFinal.Columns[22].DataType = System.Type.GetType("System.Boolean");//ReservesExceeded
            dtFinal.Columns[23].DataType = System.Type.GetType("System.Boolean");//BlockedVendor
            dtFinal.Columns[24].DataType = System.Type.GetType("System.String");//InsurerCode
            dtFinal.Columns[25].DataType = System.Type.GetType("System.Boolean");//EORPayment
            dtFinal.Columns[26].DataType = System.Type.GetType("System.DateTime");//CheckDate
            dtFinal.Columns[27].DataType = System.Type.GetType("System.Boolean");//NoAccount
            dtFinal.Columns[28].DataType = System.Type.GetType("System.Boolean");//ClaimVerificationBlock
            dtFinal.Columns[29].DataType = System.Type.GetType("System.Int32");//PharmacyPaymentCode
            dtFinal.Columns[30].DataType = System.Type.GetType("System.String");//CheckAddress1
            dtFinal.Columns[31].DataType = System.Type.GetType("System.String");//CheckAddress2
            dtFinal.Columns[32].DataType = System.Type.GetType("System.String");//CheckCity
            dtFinal.Columns[33].DataType = System.Type.GetType("System.String");//CheckState
            dtFinal.Columns[34].DataType = System.Type.GetType("System.String");//CheckZipCode
            dtFinal.Columns[35].DataType = System.Type.GetType("System.Boolean");//SpecialHandling
            dtFinal.Columns[36].DataType = System.Type.GetType("System.Boolean");//OfacMatch
            dtFinal.Columns[37].DataType = System.Type.GetType("System.String");//AdditionalPayee
            dtFinal.Columns[38].DataType = System.Type.GetType("System.Guid");//PayeeIdentity
            dtFinal.Columns[39].DataType = System.Type.GetType("System.String");//FlagACH
            dtFinal.Columns[40].DataType = System.Type.GetType("System.Int32");//BankAccountID
            dtFinal.Columns[41].DataType = System.Type.GetType("System.Int32");//InsuredID
            dtFinal.Columns[42].DataType = System.Type.GetType("System.Boolean");//EmailInvalid
            dtFinal.Columns[43].DataType = System.Type.GetType("System.Boolean");//PhoneInvalid

            if (dtFinal.Columns[43].ColumnName != "PhoneInvalid")
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
                    else if (Form1.dtFinalLoad.Columns[j].DataType == typeof(Decimal))
                    {
                        drResult[j] = Validate.convertToDecimal(row[j].ToString());
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
