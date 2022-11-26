
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.lblPreview = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblWait = new System.Windows.Forms.Label();
            this.lblEnvironment = new System.Windows.Forms.Label();
            this.cboEnvironment = new System.Windows.Forms.ComboBox();
            this.chkTruncate = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSelectFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnValidate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnFinalLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnViewStagedData = new System.Windows.Forms.ToolStripButton();
            this.lblErrorDetails = new System.Windows.Forms.Label();
            this.dgvErrorList = new System.Windows.Forms.DataGridView();
            this.dgvProcess = new System.Windows.Forms.DataGridView();
            this.lblProcess = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(45, 329);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.Size = new System.Drawing.Size(1618, 254);
            this.dgvPreview.TabIndex = 5;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreview.Location = new System.Drawing.Point(42, 301);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(145, 25);
            this.lblPreview.TabIndex = 6;
            this.lblPreview.Text = "Data Preview:";
            this.lblPreview.Click += new System.EventHandler(this.lblPreview_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xlsx";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lblWait.Location = new System.Drawing.Point(40, 301);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(379, 37);
            this.lblWait.TabIndex = 16;
            this.lblWait.Text = "Please wait, processing...";
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.AutoSize = true;
            this.lblEnvironment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvironment.Location = new System.Drawing.Point(42, 41);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Size = new System.Drawing.Size(204, 25);
            this.lblEnvironment.TabIndex = 17;
            this.lblEnvironment.Text = "Select Environment:";
            // 
            // cboEnvironment
            // 
            this.cboEnvironment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEnvironment.FormattingEnabled = true;
            this.cboEnvironment.Items.AddRange(new object[] {
            "Test",
            "Production"});
            this.cboEnvironment.Location = new System.Drawing.Point(265, 38);
            this.cboEnvironment.Name = "cboEnvironment";
            this.cboEnvironment.Size = new System.Drawing.Size(229, 33);
            this.cboEnvironment.TabIndex = 18;
            this.cboEnvironment.SelectedIndexChanged += new System.EventHandler(this.cboEnvironment_SelectedIndexChanged);
            // 
            // chkTruncate
            // 
            this.chkTruncate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.chkTruncate.Location = new System.Drawing.Point(535, 35);
            this.chkTruncate.Name = "chkTruncate";
            this.chkTruncate.Size = new System.Drawing.Size(412, 38);
            this.chkTruncate.TabIndex = 22;
            this.chkTruncate.Text = "Deleting existing data prior to loading?\r\n";
            this.chkTruncate.UseVisualStyleBackColor = true;
            this.chkTruncate.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.tsbtnSelectFile,
            this.toolStripSeparator1,
            this.tsbtnValidate,
            this.toolStripSeparator2,
            this.tsbtnLoad,
            this.toolStripSeparator3,
            this.tsbtnFinalLoad,
            this.toolStripSeparator4,
            this.tsbtnExit,
            this.toolStripSeparator6,
            this.tsbtnClear,
            this.toolStripSeparator7,
            this.tsbtnViewStagedData});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1720, 37);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbtnSelectFile
            // 
            this.tsbtnSelectFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnSelectFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSelectFile.Image")));
            this.tsbtnSelectFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSelectFile.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this.tsbtnSelectFile.Name = "tsbtnSelectFile";
            this.tsbtnSelectFile.Size = new System.Drawing.Size(302, 34);
            this.tsbtnSelectFile.Text = "Add File to List for Processing";
            this.tsbtnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbtnValidate
            // 
            this.tsbtnValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnValidate.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnValidate.Image")));
            this.tsbtnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnValidate.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this.tsbtnValidate.Name = "tsbtnValidate";
            this.tsbtnValidate.Size = new System.Drawing.Size(155, 34);
            this.tsbtnValidate.Text = "Validate File(s)";
            this.tsbtnValidate.Click += new System.EventHandler(this.tsbtnValidate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbtnLoad
            // 
            this.tsbtnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLoad.Image")));
            this.tsbtnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLoad.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this.tsbtnLoad.Name = "tsbtnLoad";
            this.tsbtnLoad.Size = new System.Drawing.Size(287, 34);
            this.tsbtnLoad.Text = "Load File(s) to Staging Table";
            this.tsbtnLoad.Click += new System.EventHandler(this.tsbtnLoad_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbtnFinalLoad
            // 
            this.tsbtnFinalLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnFinalLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFinalLoad.Image")));
            this.tsbtnFinalLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFinalLoad.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this.tsbtnFinalLoad.Name = "tsbtnFinalLoad";
            this.tsbtnFinalLoad.Size = new System.Drawing.Size(332, 34);
            this.tsbtnFinalLoad.Text = "Load Staging Table to Final Table";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbtnExit
            // 
            this.tsbtnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExit.Image")));
            this.tsbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExit.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this.tsbtnExit.Name = "tsbtnExit";
            this.tsbtnExit.Size = new System.Drawing.Size(50, 34);
            this.tsbtnExit.Text = "Exit";
            this.tsbtnExit.Click += new System.EventHandler(this.tsbtnExit_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbtnClear
            // 
            this.tsbtnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClear.Image")));
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClear.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(160, 34);
            this.tsbtnClear.Text = "Reset All Fields";
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbtnViewStagedData
            // 
            this.tsbtnViewStagedData.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnViewStagedData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnViewStagedData.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnViewStagedData.Image")));
            this.tsbtnViewStagedData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnViewStagedData.Name = "tsbtnViewStagedData";
            this.tsbtnViewStagedData.Size = new System.Drawing.Size(244, 34);
            this.tsbtnViewStagedData.Text = "View Staged Table Data";
            this.tsbtnViewStagedData.Click += new System.EventHandler(this.tsbtnViewStagedData_Click);
            // 
            // lblErrorDetails
            // 
            this.lblErrorDetails.AutoSize = true;
            this.lblErrorDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblErrorDetails.Location = new System.Drawing.Point(40, 596);
            this.lblErrorDetails.Name = "lblErrorDetails";
            this.lblErrorDetails.Size = new System.Drawing.Size(139, 26);
            this.lblErrorDetails.TabIndex = 25;
            this.lblErrorDetails.Text = "Error Details:";
            // 
            // dgvErrorList
            // 
            this.dgvErrorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrorList.Location = new System.Drawing.Point(45, 625);
            this.dgvErrorList.Name = "dgvErrorList";
            this.dgvErrorList.Size = new System.Drawing.Size(722, 218);
            this.dgvErrorList.TabIndex = 26;
            // 
            // dgvProcess
            // 
            this.dgvProcess.AllowUserToAddRows = false;
            this.dgvProcess.AllowUserToDeleteRows = false;
            this.dgvProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcess.Location = new System.Drawing.Point(45, 134);
            this.dgvProcess.MultiSelect = false;
            this.dgvProcess.Name = "dgvProcess";
            this.dgvProcess.ReadOnly = true;
            this.dgvProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcess.Size = new System.Drawing.Size(922, 164);
            this.dgvProcess.TabIndex = 27;
            this.dgvProcess.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProcess_CellClick);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblProcess.Location = new System.Drawing.Point(42, 105);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(173, 26);
            this.lblProcess.TabIndex = 28;
            this.lblProcess.Text = "Files to Process:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1720, 1019);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.dgvProcess);
            this.Controls.Add(this.dgvErrorList);
            this.Controls.Add(this.lblErrorDetails);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.chkTruncate);
            this.Controls.Add(this.cboEnvironment);
            this.Controls.Add(this.lblEnvironment);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.dgvPreview);
            this.Name = "Form1";
            this.Text = "SI File Import Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.Label lblEnvironment;
        private System.Windows.Forms.ComboBox cboEnvironment;
        private System.Windows.Forms.CheckBox chkTruncate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnValidate;
        private System.Windows.Forms.ToolStripButton tsbtnLoad;
        private System.Windows.Forms.ToolStripButton tsbtnClear;
        private System.Windows.Forms.ToolStripButton tsbtnExit;
        private System.Windows.Forms.ToolStripButton tsbtnSelectFile;
        private System.Windows.Forms.ToolStripButton tsbtnFinalLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbtnViewStagedData;
        private System.Windows.Forms.Label lblErrorDetails;
        private System.Windows.Forms.DataGridView dgvErrorList;
        private System.Windows.Forms.DataGridView dgvProcess;
        private System.Windows.Forms.Label lblProcess;
    }
}

