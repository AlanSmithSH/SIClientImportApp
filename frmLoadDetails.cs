using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIClientImport
{
    public partial class frmLoadDetails : Form
    {
        public frmLoadDetails()
        {
            InitializeComponent();
        }

        private void frmLoadDetails_Load(object sender, EventArgs e)
        {
            bool newEntry = true;
            lblFile.Text = Form1.strShortFilename;
            lblFile.Enabled = false;
            lblPolicyNumber.Visible = false;
            txtPolicyNumber.Visible = false;
            txtPolicyNumber.Text = "N/A";

            foreach (DataRow row in Form1.dtFileList.Rows)
            {
                string value = (string)row["Filename"];
                if (value == Form1.strLongFilename)
                {
                    newEntry = false;
                }
            }
            if (!newEntry)
            {
                MessageBox.Show("This filename already exists in the list of files to be processed.");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if((cboLoadType.Text=="") || (cboDateFormat.Text==""))
            {
                MessageBox.Show("Please select a load type and date format.");
                return;
            }
            if((cboLoadType.Text=="Claim") && (txtPolicyNumber.Text==""))
            {
                MessageBox.Show("Please enter a Policy Number for this claim file.");
                return;
            }

            Form1.dtFileList.Rows.Add(cboLoadType.Text.ToString(), Form1.strLongFilename, cboDateFormat.Text.ToString(), txtPolicyNumber.Text, false);
         
            this.Close();
        }

        private void cboLoadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoadType.Text == "Claim")
            {
                lblPolicyNumber.Visible = true;
                txtPolicyNumber.Visible = true;
                txtPolicyNumber.Text = "";
            }
            else
            {
                lblPolicyNumber.Visible = false;
                txtPolicyNumber.Visible = false;
                txtPolicyNumber.Text = "N/A";
            }

        }
    }
}
