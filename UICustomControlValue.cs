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
    public class UICustomControlValue
    {
        public bool ValidateUICustomControlValue(DataTable dtSpreadsheet, string strDateFormat)
        {
            bool _overallValidation = true;
            bool isValid;
            string dateString;
            int rowcount = 0;
            Form1.dtFinalLoad = BuildFinalUICustomControlValueTable(dtSpreadsheet);
            if (Form1.dtFinalLoad == null)
            {
                return false;
            }
            if (Form1.dtFinalUICustomControlLoad == null)
            {
                Form1.dtFinalUICustomControlLoad = Form1.dtFinalLoad.Clone();
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

                    //UICustomControlValueID
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

                    //UICustomControlID
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = '1'; //default value is 1
                    }
                    isValid = Validate.checkInt(row[i].ToString());
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //PK
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

                    //PKName
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

                    //ControlValue
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
                        row[i] = " "; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 50);
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

        public static DataTable BuildFinalUICustomControlValueTable(DataTable dt)
        {
            DataTable dtFinal = new DataTable();
            foreach (DataColumn column in dt.Columns)
            {
                dtFinal.Columns.Add(column.ColumnName);
            }
            try
            {
                dtFinal.Columns[0].DataType = System.Type.GetType("System.String");//ClaimNumber
                dtFinal.Columns[1].DataType = System.Type.GetType("System.Guid");//UICustomControlValueID
                dtFinal.Columns[2].DataType = System.Type.GetType("System.Int32");//UICustomControlID
                dtFinal.Columns[3].DataType = System.Type.GetType("System.String");//PK
                dtFinal.Columns[4].DataType = System.Type.GetType("System.String");//PKName
                dtFinal.Columns[5].DataType = System.Type.GetType("System.String");//ControlValue
                dtFinal.Columns[6].DataType = System.Type.GetType("System.DateTime");//EntryDate
                dtFinal.Columns[7].DataType = System.Type.GetType("System.String");//EnteredBy
                dtFinal.Columns[8].DataType = System.Type.GetType("System.DateTime");//UpdatedDate
                dtFinal.Columns[9].DataType = System.Type.GetType("System.String");//UpdatedBy
            
                
                if (dtFinal.Columns[9].ColumnName != "UpdatedBy")
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
