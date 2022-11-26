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
    public partial class frmStagedData : Form
    {
        public frmStagedData()
        {
            InitializeComponent();
        }

        private void cboLoadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtStagedData = null;
            
            switch (cboLoadType.Text)
            {
                case "Claim":
                    dtStagedData = SQLMethods.ClaimStage();
                    break;
                case "Claimant":
                    dtStagedData = SQLMethods.ClaimantStage();
                    break;
                case "Address Book":
                    dtStagedData = SQLMethods.AddressBookStage();
                    break;
                case "Employment":
                    dtStagedData = SQLMethods.EmploymentStage();
                    break;
                case "Address Book Payment":
                    dtStagedData = SQLMethods.AddressBookPaymentStage();
                    break;
                case "UI Custom Control Value":
                    dtStagedData = SQLMethods.UICustomControlsStage();
                    break;
                case "Notepad":
                    dtStagedData = SQLMethods.NotepadStage();
                    break;
                case "Reserve":
                    dtStagedData = SQLMethods.ReserveStage();
                    break;
                case "Payment":
                    dtStagedData = SQLMethods.PaymentStage();
                    break;
                case "Payee":
                    dtStagedData = SQLMethods.PayeeStage();
                    break;
                case "Attachment":
                    dtStagedData = SQLMethods.AttachmentStage();
                    break;
                case "ICD Claimant":
                    dtStagedData = SQLMethods.ClaimantICDStage();
                    break;
                case "Bill Review Header":
                    dtStagedData = SQLMethods.BillReviewHeaderStage();
                    break;
                case "Bill Review Detail":
                    dtStagedData = SQLMethods.BillReviewDetailStage();
                    break;
                default:
                    break;
            }
            dgvStaged.DataSource = dtStagedData;
        }
    }
}
