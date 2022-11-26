
namespace SIClientImport
{
    partial class frmLoadDetails
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
            this.cboDateFormat = new System.Windows.Forms.ComboBox();
            this.lblDateFormat = new System.Windows.Forms.Label();
            this.txtPolicyNumber = new System.Windows.Forms.TextBox();
            this.lblPolicyNumber = new System.Windows.Forms.Label();
            this.cboLoadType = new System.Windows.Forms.ComboBox();
            this.lblLoadType = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboDateFormat
            // 
            this.cboDateFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDateFormat.FormattingEnabled = true;
            this.cboDateFormat.Items.AddRange(new object[] {
            "yyyyMMdd",
            "MM/dd/yy",
            "MM/dd/yyyy",
            "MM-dd-yy",
            "MM-dd-yyyy"});
            this.cboDateFormat.Location = new System.Drawing.Point(237, 79);
            this.cboDateFormat.Name = "cboDateFormat";
            this.cboDateFormat.Size = new System.Drawing.Size(288, 33);
            this.cboDateFormat.TabIndex = 29;
            // 
            // lblDateFormat
            // 
            this.lblDateFormat.AutoSize = true;
            this.lblDateFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFormat.Location = new System.Drawing.Point(12, 82);
            this.lblDateFormat.Name = "lblDateFormat";
            this.lblDateFormat.Size = new System.Drawing.Size(202, 25);
            this.lblDateFormat.TabIndex = 28;
            this.lblDateFormat.Text = "Select Date Format:";
            // 
            // txtPolicyNumber
            // 
            this.txtPolicyNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPolicyNumber.Location = new System.Drawing.Point(237, 118);
            this.txtPolicyNumber.Name = "txtPolicyNumber";
            this.txtPolicyNumber.Size = new System.Drawing.Size(288, 31);
            this.txtPolicyNumber.TabIndex = 26;
            // 
            // lblPolicyNumber
            // 
            this.lblPolicyNumber.AutoSize = true;
            this.lblPolicyNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPolicyNumber.Location = new System.Drawing.Point(12, 121);
            this.lblPolicyNumber.Name = "lblPolicyNumber";
            this.lblPolicyNumber.Size = new System.Drawing.Size(214, 25);
            this.lblPolicyNumber.TabIndex = 25;
            this.lblPolicyNumber.Text = "Enter Policy Number:";
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
            this.cboLoadType.Location = new System.Drawing.Point(237, 39);
            this.cboLoadType.Name = "cboLoadType";
            this.cboLoadType.Size = new System.Drawing.Size(288, 33);
            this.cboLoadType.TabIndex = 24;
            this.cboLoadType.SelectedIndexChanged += new System.EventHandler(this.cboLoadType_SelectedIndexChanged);
            // 
            // lblLoadType
            // 
            this.lblLoadType.AutoSize = true;
            this.lblLoadType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadType.Location = new System.Drawing.Point(12, 42);
            this.lblLoadType.Name = "lblLoadType";
            this.lblLoadType.Size = new System.Drawing.Size(186, 25);
            this.lblLoadType.TabIndex = 23;
            this.lblLoadType.Text = "Select Load Type:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xlsx";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnAdd.Location = new System.Drawing.Point(17, 213);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 47);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "Add File";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.Location = new System.Drawing.Point(364, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 47);
            this.button1.TabIndex = 32;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblFilename.Location = new System.Drawing.Point(12, 9);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(108, 26);
            this.lblFilename.TabIndex = 33;
            this.lblFilename.Text = "Filename:";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblFile.Location = new System.Drawing.Point(232, 9);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(0, 26);
            this.lblFile.TabIndex = 34;
            // 
            // frmLoadDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 299);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboDateFormat);
            this.Controls.Add(this.lblDateFormat);
            this.Controls.Add(this.txtPolicyNumber);
            this.Controls.Add(this.lblPolicyNumber);
            this.Controls.Add(this.cboLoadType);
            this.Controls.Add(this.lblLoadType);
            this.Name = "frmLoadDetails";
            this.Text = "File Details";
            this.Load += new System.EventHandler(this.frmLoadDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboDateFormat;
        private System.Windows.Forms.Label lblDateFormat;
        private System.Windows.Forms.TextBox txtPolicyNumber;
        private System.Windows.Forms.Label lblPolicyNumber;
        private System.Windows.Forms.ComboBox cboLoadType;
        private System.Windows.Forms.Label lblLoadType;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label lblFile;
    }
}