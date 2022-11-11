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
        public DataTable dtGoodData;
        public DataTable dtBadData;
        public DataTable dtRawSpreadsheet;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
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
        }

        public void btnValidate_Click(object sender, EventArgs e)
        {
            if (txtFilename.Text == "" || cboLoadType.Text == "") 
            {
                MessageBox.Show("Please select a file and load type to validate.");
            }

            dtRawSpreadsheet = ReadSpreadsheet(txtFilename.Text);
            string load = cboLoadType.Text;
            switch (load)
            {
                case "Claim":
                    break;
                case "Address Book":
                    break;
                case "Claimant":
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


            dgvPreview.DataSource = dtRawSpreadsheet;
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
    }
}
