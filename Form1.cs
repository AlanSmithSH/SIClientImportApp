using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Sheakley.WC.Sims.Common;
using Sheakley.ICS.Common.FunctionClasses;
using System.IO;

namespace SIClientImport
{
    public partial class Form1 : Form
    {
        public static string strDateFormat;
        public static DataTable dtGoodData;
        public static DataTable dtBadData;
        public static DataTable dtFinalLoad; 
        public static DataTable dtFinalClaimLoad;
        public static DataTable dtFinalAddressBookLoad;
        public static DataTable dtFinalClaimantLoad;
        public static DataTable dtFinalEmploymentLoad;
        public static DataTable dtFinalAddressBookPaymentsLoad;
        public static DataTable dtFinalReserveLoad;
        public static DataTable dtFinalNotepadLoad;
        public static DataTable dtFinalAttachmentLoad;
        public static DataTable dtFinalPayeeLoad;
        public static DataTable dtFinalPaymentLoad;
        public static DataTable dtFinalClaimantICDLoad;
        public static DataTable dtFinalBillReviewHeaderLoad;
        public static DataTable dtFinalBillReviewDetailLoad;
        public static DataTable dtFinalUICustomControlLoad;


        public DataTable dtRawSpreadsheet;
        public bool dataAcceptable;
        public static string strPolicyNumber;
        public static DataTable dtErrorList = new DataTable();
        public static DataTable dtFileList = new DataTable();

        public static string strErrorDetail;
        public static string strShortFilename;
        public static string strLongFilename;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            ResetScreen(); 


        }


        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Properties.Settings.Default.DefaultFileLocation;
            openFileDialog1.Filter = "Excel Worksheets|*.xlsx";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }
        private void lblPreview_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            strLongFilename = openFileDialog1.FileName;
            strShortFilename = Path.GetFileName(strLongFilename);
            frmLoadDetails myDetails = new frmLoadDetails();
            myDetails.ShowDialog();
            dgvProcess.DataSource = dtFileList;
            if (dtFileList.Rows.Count > 0)
            {
                lblProcess.Visible = true;
                dgvProcess.Visible = true;
            }
            dgvProcess.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProcess.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ButtonActions();
        }


        public DataTable ReadSpreadsheet(string filename) 
        {
            System.Data.DataTable dtResult = new DataTable();
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = app.Workbooks.Open(filename);
            app.Visible = false;
            app.DisplayAlerts = false;
            Sheets sheets = xlWorkbook.Sheets;
            Worksheet sheet = sheets[1];
            Range range = sheet.UsedRange;
            int cl = range.Columns.Count;
            int rowcount = range.Rows.Count;
            try
            {
                for (int j = 1; j <= cl; j++)
                {
                    string colName = Convert.ToString(sheet.Cells[1, j].Value2);
                    string colNameSubstring = colName.Substring(colName.Length - 2);
                    bool containsID = colNameSubstring.Contains("ID");
                    if (containsID) 
                    { 
                        colName = colName.Substring(0,colName.Length-2);
                        colName = colName + "Id";
                    }
                    dtResult.Columns.Add(colName, typeof(string));
                }

                for (int i = 2; i <= rowcount; i++)
                {
                    DataRow dr = dtResult.NewRow();
                    for (int k = 1; k <= cl; k++)
                    {
                        string _cell = Convert.ToString(sheet.Cells[i, k].Value2);

                        if (string.IsNullOrEmpty(_cell))
                        {
                            dr[k - 1] = Convert.ToString(sheet.Cells[i, k].Value2);
                        }
                        else
                        {
                            dr[k - 1] = _cell.Trim();
                        }
                        //dr[k-1] = Convert.ToString(sheet.Cells[i, k].Value2);
                    }
                    dtResult.Rows.InsertAt(dr, dtResult.Rows.Count + 1);
                }

                xlWorkbook.Close();

                return dtResult;
            }
            catch (Exception ex)
            {
                xlWorkbook.Close();
                app.Quit();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetScreen();
        }

        private void ResetScreen()
        {
            if (dtFinalLoad != null)
            {
                dtFinalLoad.Clear();
                dtFinalLoad.Columns.Clear();
            }
            if (dtGoodData != null) 
            { 
                dtGoodData.Clear();
                dtGoodData.Columns.Clear();
            }
            if (dtBadData != null) 
            { 
                dtBadData.Clear();
                dtBadData.Columns.Clear();
            }
            if (dtRawSpreadsheet != null) 
            { 
                dtRawSpreadsheet.Clear();
                dtRawSpreadsheet.Columns.Clear();
            }
            if (dtErrorList != null)
            {
                dtErrorList.Clear();
                dtErrorList.Columns.Clear();
            }
            if (dtFileList != null)
            {
                dtFileList.Clear();
                dtFileList.Columns.Clear();
            }
            dtFileList.Columns.Add("Load Type", typeof(String));
            dtFileList.Columns.Add("Filename", typeof(String));
            dtFileList.Columns.Add("Date Format", typeof(String));
            dtFileList.Columns.Add("Policy Number", typeof(String));
            dtFileList.Columns.Add("Validated?", typeof(Boolean));
            dtErrorList.Columns.Add("Row Number", typeof(String));
            dtErrorList.Columns.Add("Column Name", typeof(String));
            dtErrorList.Columns.Add("Cell Value", typeof(String));
            dtErrorList.Columns.Add("Error Detail", typeof(String));

            tsbtnViewStagedData.Enabled = true;
            cboEnvironment.Enabled = true;
            tsbtnValidate.Enabled = false;
            dgvPreview.Visible = false;
            lblPreview.Visible = false;
            tsbtnLoad.Enabled = false;
            lblWait.Visible = false;
            tsbtnSelectFile.Enabled = false;
            cboEnvironment.Text = "";
            cboEnvironment.Enabled = true;
            chkTruncate.Visible = false;
            tsbtnFinalLoad.Enabled = false;
            if (dtFileList.Rows.Count != 0)
            { dtFileList.Clear(); }
            dgvProcess.Visible = false;
            lblProcess.Visible = false;
            dgvErrorList.Visible = false;
            lblErrorDetails.Visible = false;
            dgvProcess.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ButtonActions();
            lblPreview.Text = "Data Preview (not all records passed validation):";
        }

        private void cboEnvironment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEnvironment.Text !="")
            {
                tsbtnSelectFile.Enabled = true;
                cboEnvironment.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectFile_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Properties.Settings.Default.DefaultFileLocation;
            openFileDialog1.Filter = "Excel Worksheets|*.xlsx";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }

        private void tsbtnValidate_Click(object sender, EventArgs e)
        {
            BeginValidation();
        }


        public void BeginValidation()
        {
            bool success = true;
            dtErrorList.Clear();
            tsbtnValidate.Enabled = false;
            tsbtnSelectFile.Enabled = false;
            lblWait.Visible = true;
            foreach (DataRow row in dtFileList.Rows)
            {
                string load = (string)row["Load Type"];
                string file = (string)row["Filename"];
                strShortFilename = Path.GetFileName(file);
                string strDateFormat = (string)row["Date Format"];
                string strPolicyNumber = (string)row["Policy Number"];

                dtRawSpreadsheet = ReadSpreadsheet(file);
                dtGoodData = dtRawSpreadsheet.Clone();
                dtBadData = dtRawSpreadsheet.Clone();

                switch (load)
                {
                    case "Claim":
                        Claim cl = new Claim();
                        success = cl.ValidateClaim(dtRawSpreadsheet, strDateFormat, strPolicyNumber);
                        if (!success) { ResetScreen(); return; }
                        dtFinalClaimLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Address Book":
                        AddressBook ab = new AddressBook();
                        success = ab.ValidateAddressBook(dtRawSpreadsheet, strDateFormat);
                        if (!success) { ResetScreen(); return; }
                        dtFinalAddressBookLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Address Book Payment":
                        AddressBook_Payments abp = new AddressBook_Payments();
                        success = abp.ValidateAddressBookPayments(dtRawSpreadsheet, strDateFormat);
                        if (!success) { ResetScreen(); return; }
                        dtFinalAddressBookPaymentsLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Claimant":
                        Claimant claimant = new Claimant();
                        success = claimant.ValidateClaimant(dtRawSpreadsheet, strDateFormat);
                        if (!success) { ResetScreen(); return; }
                        dtFinalClaimantLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Employment":
                        Employment employment = new Employment();
                        success = employment.ValidateEmployment(dtRawSpreadsheet, strDateFormat);
                        if (!success)
                        {
                            ResetScreen(); return;
                        }
                        dtFinalEmploymentLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "UI Custom Control Value":
                        UICustomControlValue uICustomControlValue = new UICustomControlValue();
                        success = uICustomControlValue.ValidateUICustomControlValue(dtRawSpreadsheet, strDateFormat);
                        if (!success)
                        {
                            ResetScreen(); return;
                        }
                        dtFinalUICustomControlLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Notepad":
                        Notepad notepad = new Notepad();
                        success = notepad.ValidateNotepad(dtRawSpreadsheet, strDateFormat);
                        if (!success)
                        {
                            ResetScreen(); return;
                        }
                        dtFinalNotepadLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Reserve":
                        Reserve reserve = new Reserve();
                        success = reserve.ValidateReserve(dtRawSpreadsheet, strDateFormat);
                        if (!success)
                        {
                            ResetScreen(); return;
                        }
                        dtFinalReserveLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Payment":
                        Payment payment = new Payment();
                        success = payment.ValidatePayment(dtRawSpreadsheet, strDateFormat);
                        if (!success)
                        {
                            ResetScreen(); return;
                        }
                        dtFinalPaymentLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Payee":
                        Payee payee = new Payee();
                        success = payee.ValidatePayee(dtRawSpreadsheet, strDateFormat);
                        if (!success)
                        {
                            ResetScreen(); return;
                        }
                        dtFinalPayeeLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Attachment":
                        Attachment attachment = new Attachment();
                        success = attachment.ValidateAttachment(dtRawSpreadsheet, strDateFormat);
                        if (!success)
                        {
                            ResetScreen(); return;
                        }
                        dtFinalAttachmentLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "ICD Claimant":
                        ClaimantICD claimantICD = new ClaimantICD();
                        success = claimantICD.ValidateClaimantICD(dtRawSpreadsheet, strDateFormat);
                        if (!success)
                        {
                            ResetScreen(); return;
                        }
                        dtFinalClaimantICDLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Bill Review Header":
                        BillReviewHeader billReviewHeader = new BillReviewHeader();
                        success = billReviewHeader.ValidateBillReviewHeader(dtRawSpreadsheet, strDateFormat);
                        if (!success)
                        {
                            ResetScreen(); return;
                        }
                        dtFinalBillReviewHeaderLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    case "Bill Review Detail":
                        BillReviewDetail billReviewDetail = new BillReviewDetail();
                        success = billReviewDetail.ValidateBillReviewDetail(dtRawSpreadsheet, strDateFormat);
                        if (!success)
                        {
                            ResetScreen(); return;
                        }
                        dtFinalBillReviewDetailLoad.Merge(dtFinalLoad);
                        dtFinalLoad.Clear();
                        dtFinalLoad.Columns.Clear();
                        break;
                    default:
                        break;

                }

                dgvPreview.DataSource = dtGoodData;

                if (dtGoodData.Rows.Count > 1 && dtBadData.Rows.Count < 1) //Validates GOOD and ready to load
                {
                    chkTruncate.Visible = true;

                    row["Validated?"] = true;
                }

                dgvErrorList.DataSource = dtErrorList;

            }

            if (dgvPreview.RowCount > 1)
            {
                dgvPreview.Visible = true;
                lblPreview.Visible = true;
                dgvProcess.AutoResizeColumns();
                dgvProcess.Refresh();
                dgvProcess.CurrentCell = dgvProcess.Rows[0].Cells[0];
                dgvProcess_CellClick(this.dgvProcess, new DataGridViewCellEventArgs(0, 0));
                dgvProcess.Rows[0].Selected = false;
                dgvProcess.Rows[0].Selected = true;
            }

            if (dtErrorList.Rows.Count > 0)
            {
                dgvErrorList.Visible = true;
                lblErrorDetails.Visible = true;
                lblPreview.Text = "Data preview - not all data is validated for loading.";
                dgvErrorList.AutoResizeColumns();
                dgvErrorList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvErrorList.Refresh();
            }
            else
            {
                lblPreview.Text = "All files have been validated and are acceptable for loading.";
            }

            ButtonActions();

            lblWait.Visible = false;
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            ResetScreen();
        }


        private void tsbtnViewStagedData_Click(object sender, EventArgs e)
        {
            frmStagedData stagedData = new frmStagedData();
            stagedData.ShowDialog();
        }

        public static void CollectErrorDetail(string rownum, string colname, string value, string detail)
        {
            DataRow row = dtErrorList.NewRow();
            row["Row Number"] = strShortFilename + ": Row " + rownum;
            row["Column Name"] = colname;
            row["Cell Value"] = value;
            row["Error Detail"] = detail;
            dtErrorList.Rows.Add(row);

        }

        public void LoadToStagingTable()
        {
            tsbtnValidate.Enabled = false;
            tsbtnLoad.Enabled = false;
            lblWait.Visible = true;
            foreach (DataRow row in dtFileList.Rows)
            {
                string load = (string)row["Load Type"];
                string file = (string)row["Filename"];

                switch (load)
                {
                    case "Claim":
                        try
                        {
                            List<DbClaim> claimRecords = Conversion.DatatableToClass<DbClaim>(dtFinalClaimLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Address Book":
                        try
                        {
                            List<DbAddressBook> addressRecords = Conversion.DatatableToClass<DbAddressBook>(dtFinalAddressBookLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Address Book Payment":
                        try
                        {
                            List<AddressBookPayment> addressPaymentRecords = Conversion.DatatableToClass<AddressBookPayment>(dtFinalAddressBookPaymentsLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Claimant":
                        try
                        {
                            List<DbClaimant> claimantRecords = Conversion.DatatableToClass<DbClaimant>(dtFinalClaimantLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Employment":
                        try
                        {
                            List<DbEmployment> employmentRecords = Conversion.DatatableToClass<DbEmployment>(dtFinalEmploymentLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "UI Custom Control Value":
                        try
                        {
                            List<DbUICustomControlValue> uiCustomControlsRecords = Conversion.DatatableToClass<DbUICustomControlValue>(dtFinalUICustomControlLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Notepad":
                        try
                        {
                            List<DbNotepad> notepadRecords = Conversion.DatatableToClass<DbNotepad>(dtFinalNotepadLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Reserve":
                        try
                        {
                            List<DbReserve> reserveRecords = Conversion.DatatableToClass<DbReserve>(dtFinalReserveLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Payment":
                        try
                        {
                            List<DbPayment> paymentRecords = Conversion.DatatableToClass<DbPayment>(dtFinalPaymentLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Payee":
                        try
                        {
                            List<DbPayee> payeeRecords = Conversion.DatatableToClass<DbPayee>(dtFinalPayeeLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Attachment":
                        try
                        {
                            List<DbAttachment> attachmentRecords = Conversion.DatatableToClass<DbAttachment>(dtFinalAttachmentLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Claimant ICD":
                        try
                        {
                            List<DbClaimantICD> claimantICDRecords = Conversion.DatatableToClass<DbClaimantICD>(dtFinalClaimantICDLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Bill Review Header":
                        try
                        {
                            List<DbBillReviewHeader> billReviewHeaderRecords = Conversion.DatatableToClass<DbBillReviewHeader>(dtFinalBillReviewHeaderLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Bill Review Detail":
                        try
                        {
                            List<DbBillReviewDetail> billReviewDetailRecords = Conversion.DatatableToClass<DbBillReviewDetail>(dtFinalBillReviewDetailLoad).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            lblWait.Visible = false;
        }
        private void ButtonActions()
        {
            if (dtFileList.Rows.Count > 0)
            {
                bool enableValidate = true;
                bool enableStagedLoad = true;
                foreach (DataRow row in dtFileList.Rows)
                {
                    bool rowBool = (bool)row["Validated?"];
                    if (rowBool)
                    {
                        enableValidate = false;
                    }
                    if (!rowBool)
                    {
                        enableStagedLoad = false;
                    }
                }
                tsbtnValidate.Enabled = enableValidate;
                tsbtnLoad.Enabled = enableStagedLoad;
            }
            else
            {
                tsbtnValidate.Enabled = false;
                tsbtnLoad.Enabled = false;
                tsbtnFinalLoad.Enabled = false;
            }
            if (dgvPreview.Visible)
            {
                tsbtnValidate.Enabled = false;
            }
        }

        private void dgvProcess_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                int index = dgvProcess.CurrentRow.Index;
                string load = dtFileList.Rows[index]["Load Type"].ToString();
                switch (load)
                {
                    case "Claim":
                        dgvPreview.DataSource = dtFinalClaimLoad;
                        break;
                    case "Address Book":
                        dgvPreview.DataSource = dtFinalAddressBookLoad;
                        break;
                    case "Address Book Payment":
                        dgvPreview.DataSource = dtFinalAddressBookPaymentsLoad;
                        break;
                    case "Claimant":
                        dgvPreview.DataSource = dtFinalClaimantLoad;
                        break;
                    case "Employment":
                        dgvPreview.DataSource = dtFinalEmploymentLoad;
                        break;
                    case "UI Custom Control Value":
                        dgvPreview.DataSource = dtFinalUICustomControlLoad;
                        break;
                    case "Notepad":
                        dgvPreview.DataSource = dtFinalNotepadLoad;
                        break;
                    case "Reserve":
                        dgvPreview.DataSource = dtFinalReserveLoad;
                        break;
                    case "Payment":
                        dgvPreview.DataSource = dtFinalPaymentLoad;
                        break;
                    case "Payee":
                        dgvPreview.DataSource = dtFinalPayeeLoad;
                        break;
                    case "Attachment":
                        dgvPreview.DataSource = dtFinalAttachmentLoad;
                        break;
                    case "ICD Claimant":
                        dgvPreview.DataSource = dtFinalClaimantICDLoad;
                        break;
                    case "Bill Review Header":
                        dgvPreview.DataSource = dtFinalBillReviewHeaderLoad;
                        break;
                    case "Bill Review Detail":
                        dgvPreview.DataSource = dtFinalBillReviewDetailLoad;
                        break;
                    default:
                        break;
                }
            }
        }

        private void tsbtnLoad_Click(object sender, EventArgs e)
        {
            LoadToStagingTable();
        }
    }
}

