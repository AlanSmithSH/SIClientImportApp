
namespace SIClientImport
{
    partial class frmStagedData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboLoadType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStaged = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaged)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLoadType
            // 
            this.cboLoadType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoadType.FormattingEnabled = true;
            this.cboLoadType.Items.AddRange(new object[] {
            "Claim",
            "Address Book",
            "Address Book Payment",
            "Claimant",
            "Employment",
            "UI Custom Control Value",
            "Notepad",
            "Reserve",
            "Payment",
            "Payee",
            "Attachment",
            "Claimant ICD",
            "Bill Review Header",
            "Bill Review Detail"});
            this.cboLoadType.Location = new System.Drawing.Point(219, 12);
            this.cboLoadType.Name = "cboLoadType";
            this.cboLoadType.Size = new System.Drawing.Size(288, 33);
            this.cboLoadType.TabIndex = 25;
            this.cboLoadType.SelectedIndexChanged += new System.EventHandler(this.cboLoadType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 26);
            this.label1.TabIndex = 26;
            this.label1.Text = "Select data to view:";
            // 
            // dgvStaged
            // 
            this.dgvStaged.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaged.Location = new System.Drawing.Point(17, 67);
            this.dgvStaged.Name = "dgvStaged";
            this.dgvStaged.Size = new System.Drawing.Size(1297, 591);
            this.dgvStaged.TabIndex = 27;
            // 
            // frmStagedData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 690);
            this.Controls.Add(this.dgvStaged);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLoadType);
            this.Name = "frmStagedData";
            this.Text = "View Staged Data";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaged)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLoadType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStaged;
    }
}