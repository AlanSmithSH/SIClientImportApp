
using System;

namespace SIClientImport
{
    partial class Form1
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
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblLoadType = new System.Windows.Forms.Label();
            this.cboLoadType = new System.Windows.Forms.ComboBox();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.lblPreview = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.btnValidate = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblPolicyNumber = new System.Windows.Forms.Label();
            this.txtPolicyNumber = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblWait = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(45, 69);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(355, 20);
            this.txtFilename.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(45, 43);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(355, 23);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "Select File to Load";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lblLoadType
            // 
            this.lblLoadType.AutoSize = true;
            this.lblLoadType.Location = new System.Drawing.Point(413, 53);
            this.lblLoadType.Name = "lblLoadType";
            this.lblLoadType.Size = new System.Drawing.Size(86, 13);
            this.lblLoadType.TabIndex = 3;
            this.lblLoadType.Text = "Select load type:";
            // 
            // cboLoadType
            // 
            this.cboLoadType.FormattingEnabled = true;
            this.cboLoadType.Items.AddRange(new object[] {
            "Claim",
            "Address Book",
            "Claimant",
            "Employment",
            "UI Custom Control",
            "Notepad",
            "Reserve",
            "Payment",
            "Payee",
            "Attachment"});
            this.cboLoadType.Location = new System.Drawing.Point(416, 69);
            this.cboLoadType.Name = "cboLoadType";
            this.cboLoadType.Size = new System.Drawing.Size(230, 21);
            this.cboLoadType.TabIndex = 4;
            this.cboLoadType.SelectedIndexChanged += new System.EventHandler(this.cboLoadType_SelectedIndexChanged);
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(45, 115);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.Size = new System.Drawing.Size(1619, 456);
            this.dgvPreview.TabIndex = 5;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(42, 99);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(74, 13);
            this.lblPreview.TabIndex = 6;
            this.lblPreview.Text = "Data Preview:";
            this.lblPreview.Click += new System.EventHandler(this.lblPreview_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(42, 599);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(75, 13);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "Error Records:";
            this.lblError.Click += new System.EventHandler(this.label4_Click);
            // 
            // dgvErrors
            // 
            this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrors.Location = new System.Drawing.Point(45, 615);
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.Size = new System.Drawing.Size(1619, 231);
            this.dgvErrors.TabIndex = 8;
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(797, 67);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(116, 23);
            this.btnValidate.TabIndex = 9;
            this.btnValidate.Text = "Validate File";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xlsx";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1589, 69);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPolicyNumber
            // 
            this.lblPolicyNumber.AutoSize = true;
            this.lblPolicyNumber.Location = new System.Drawing.Point(652, 53);
            this.lblPolicyNumber.Name = "lblPolicyNumber";
            this.lblPolicyNumber.Size = new System.Drawing.Size(75, 13);
            this.lblPolicyNumber.TabIndex = 11;
            this.lblPolicyNumber.Text = "PolicyNumber:";
            // 
            // txtPolicyNumber
            // 
            this.txtPolicyNumber.Location = new System.Drawing.Point(655, 69);
            this.txtPolicyNumber.Name = "txtPolicyNumber";
            this.txtPolicyNumber.Size = new System.Drawing.Size(136, 20);
            this.txtPolicyNumber.TabIndex = 12;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1508, 69);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1182, 67);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(148, 23);
            this.btnLoad.TabIndex = 14;
            this.btnLoad.Text = "Load Table to Database";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Location = new System.Drawing.Point(919, 72);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(127, 13);
            this.lblWait.TabIndex = 16;
            this.lblWait.Text = "Please wait, processing...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1720, 911);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtPolicyNumber);
            this.Controls.Add(this.lblPolicyNumber);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.dgvErrors);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.dgvPreview);
            this.Controls.Add(this.cboLoadType);
            this.Controls.Add(this.lblLoadType);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtFilename);
            this.Name = "Form1";
            this.Text = "SI File Import Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblLoadType;
        private System.Windows.Forms.ComboBox cboLoadType;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblPolicyNumber;
        private System.Windows.Forms.TextBox txtPolicyNumber;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblWait;
    }
}

