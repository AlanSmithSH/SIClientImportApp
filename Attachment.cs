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
    public class Attachment
    {
        public bool ValidateAttachment(DataTable dtSpreadsheet, string strDateFormat)
        {
            bool _overallValidation = true;
            bool isValid;
            string dateString;
            int rowcount = 0;
            Form1.dtFinalLoad = BuildFinalAttachmentTable(dtSpreadsheet);
            if (Form1.dtFinalLoad == null)
            {
                return false;
            }
            if (Form1.dtFinalAttachmentLoad == null)
            {
                Form1.dtFinalAttachmentLoad = Form1.dtFinalLoad.Clone();
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

                    //AttachmentID
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

                    //ClaimantID
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

                    //FileName
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

                    //Title
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

                    //Description
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

                    //AttachmentTypeID
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

                    //StatusID
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

                    //RoleName
                    if (row[i].ToString().Length == 0)
                    {
                        row[i] = null; //default value
                    }
                    isValid = Validate.checkString(row[i].ToString(), 256);
                    if (!isValid)
                    {
                        _overallValidation = false; Form1.CollectErrorDetail(rowcount.ToString(), dtSpreadsheet.Columns[i].ColumnName, row[i].ToString(), Form1.strErrorDetail);
                    }
                    i++;

                    //BatchPrintDate
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

                    //FileSize
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

                    //Local
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

                    //CategoryID
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

                    //SubCategoryID
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

                    //ExternalTrackingID
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

                    //ExternalID
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

                    //ExternalURL
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

                    //ExternalVersion
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

                    //ExternalError
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

                    //DocumentDate
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

                    //AttachmentActionID
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

                    //IsClaimLevel
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

                    //FileSizeInBytes
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


                }
                catch { _overallValidation = false;
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

        public static DataTable BuildFinalAttachmentTable(DataTable dt)
        {
            DataTable dtFinal = new DataTable();
            foreach (DataColumn column in dt.Columns)
            {
                dtFinal.Columns.Add(column.ColumnName);
            }
            try 
            {
            dtFinal.Columns[0].DataType = System.Type.GetType("System.String");//ClaimNumber
            dtFinal.Columns[1].DataType = System.Type.GetType("System.Guid");//AttachmentID
            dtFinal.Columns[2].DataType = System.Type.GetType("System.Int32");//ClaimantID
            dtFinal.Columns[3].DataType = System.Type.GetType("System.String");//FileName
            dtFinal.Columns[4].DataType = System.Type.GetType("System.String");//Title
            dtFinal.Columns[5].DataType = System.Type.GetType("System.String");//Description
            dtFinal.Columns[6].DataType = System.Type.GetType("System.DateTime");//EntryDate
            dtFinal.Columns[7].DataType = System.Type.GetType("System.String");//EnteredBy
            dtFinal.Columns[8].DataType = System.Type.GetType("System.DateTime");//UpdatedDate
            dtFinal.Columns[9].DataType = System.Type.GetType("System.String");//UpdatedBy
            dtFinal.Columns[10].DataType = System.Type.GetType("System.Int32");//AttachmentTypeID
            dtFinal.Columns[11].DataType = System.Type.GetType("System.Int32");//StatusID
            dtFinal.Columns[12].DataType = System.Type.GetType("System.String");//RoleName
            dtFinal.Columns[13].DataType = System.Type.GetType("System.DateTime");//BatchPrintDate
            dtFinal.Columns[14].DataType = System.Type.GetType("System.String");//FileSize
            dtFinal.Columns[15].DataType = System.Type.GetType("System.Boolean");//Local
            dtFinal.Columns[16].DataType = System.Type.GetType("System.Int32");//CategoryID
            dtFinal.Columns[17].DataType = System.Type.GetType("System.Int32");//SubCategoryID
            dtFinal.Columns[18].DataType = System.Type.GetType("System.String");//ExternalTrackingID
            dtFinal.Columns[19].DataType = System.Type.GetType("System.String");//ExternalID
            dtFinal.Columns[20].DataType = System.Type.GetType("System.String");//ExternalURL
            dtFinal.Columns[21].DataType = System.Type.GetType("System.String");//ExternalVersion
            dtFinal.Columns[22].DataType = System.Type.GetType("System.String");//ExternalError
            dtFinal.Columns[23].DataType = System.Type.GetType("System.DateTime");//DocumentDate
            dtFinal.Columns[24].DataType = System.Type.GetType("System.Int32");//AttachmentActionID
            dtFinal.Columns[25].DataType = System.Type.GetType("System.Boolean");//IsClaimLevel
            dtFinal.Columns[26].DataType = System.Type.GetType("System.Int32");//FileSizeInBytes
                
            if (dtFinal.Columns[26].ColumnName != "FileSizeInBytes")
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
