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

namespace SIClientImport
{
    public partial class Form1 : Form
    {
        public static DataTable dtGoodData;
        public static DataTable dtBadData;
        public DataTable dtRawSpreadsheet;
        public bool dataAcceptable;
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
            txtFilename.Text = openFileDialog1.FileName;
            lblLoadType.Visible = true;
            cboLoadType.Visible = true;
        }

        public void btnValidate_Click(object sender, EventArgs e)
        {
            if (txtFilename.Text == "" || cboLoadType.Text == "") 
            {
                MessageBox.Show("Please select a file and load type to validate.");
            }

            lblWait.Visible = true;
            dtRawSpreadsheet = ReadSpreadsheet(txtFilename.Text);
            dtGoodData = dtRawSpreadsheet.Clone();
            dtBadData = dtRawSpreadsheet.Clone();

            string load = cboLoadType.Text;
            
            switch (load)
            {
                case "Claim":
                    Claim cl = new Claim();
                    cl.ValidateClaim(dtRawSpreadsheet);
                    break;
                case "Address Book":
                    AddressBook ab = new AddressBook();
                    ab.ValidateAddressBook(dtRawSpreadsheet);
                    break;
                case "Claimant":
                    Claimant claimant = new Claimant();
                    claimant.ValidateClaimant(dtRawSpreadsheet);
                    break;
                case "Employment":
                    break;
                case "UI Custom Control":
                    break;
                case "Notepad":
                    break;
                case "Reserve":
                    break;
                case "Payment":
                    break;
                case "Payee":
                    break;
                case "Attachment":
                    break;
                default:
                    break;

            }


            dgvPreview.DataSource = dtGoodData;
            dgvErrors.DataSource = dtBadData;

            dgvPreview.Visible = true;
            lblPreview.Visible = true;

            if (dgvPreview.RowCount > 1 && dgvErrors.RowCount < 2)
            {
                btnLoad.Visible = true;
            }
            
            if (dgvErrors.RowCount>1)
            {
                dgvErrors.Visible = true;
                lblError.Visible = true;
                btnLoad.Visible = false;
            }
            else
            {
                dgvErrors.Visible = false;
                lblError.Visible = false;
            }
            lblWait.Visible = false;

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
                    dtResult.Columns.Add(Convert.ToString(sheet.Cells[1, j].Value2), typeof(string));
                }

                for (int i = 2; i <= rowcount; i++)
                {
                    DataRow dr = dtResult.NewRow();
                    for (int k = 1; k <= cl; k++)
                    {
                        dr[k-1] = Convert.ToString(sheet.Cells[i, k].Value2);
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

        private void cboLoadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoadType.Text == "Claim")
            {
                lblPolicyNumber.Visible = true;
                txtPolicyNumber.Visible = true;
            }

            btnValidate.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetScreen();
        }

        private void ResetScreen()
        {
            txtFilename.Text = "";
            dgvErrors.Visible = false;
            lblError.Visible = false;
            lblLoadType.Visible = false;
            cboLoadType.Text = "";
            cboLoadType.Visible = false;
            dgvPreview.Visible = false;
            lblPreview.Visible = false;
            btnValidate.Visible = false;
            lblPolicyNumber.Visible = false;
            txtPolicyNumber.Visible = false;
            btnLoad.Visible = false;
            lblWait.Visible = false;
        }
    }
}
