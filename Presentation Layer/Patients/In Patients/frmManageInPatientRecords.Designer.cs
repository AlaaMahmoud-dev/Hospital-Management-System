namespace HMS
{
    partial class frmManageInPatientRecords
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInPatientRecordsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvInPatientRecordsList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPatientInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPrescriptionsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPrescriptionOrTreatmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.startTreatmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInPatientRecordsList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(9, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "Search By:";
            // 
            // cbSearchType
            // 
            this.cbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Location = new System.Drawing.Point(111, 173);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(151, 21);
            this.cbSearchType.TabIndex = 54;
            this.cbSearchType.SelectedIndexChanged += new System.EventHandler(this.cbSearchType_SelectedIndexChanged);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(268, 173);
            this.txtSearchValue.Multiline = true;
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(203, 21);
            this.txtSearchValue.TabIndex = 53;
            this.txtSearchValue.TextChanged += new System.EventHandler(this.txtSearchValue_TextChanged);
            this.txtSearchValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchValue_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1293, 61);
            this.panel2.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(517, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "In Patients List";
            // 
            // lblInPatientRecordsCount
            // 
            this.lblInPatientRecordsCount.AutoSize = true;
            this.lblInPatientRecordsCount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblInPatientRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInPatientRecordsCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInPatientRecordsCount.Location = new System.Drawing.Point(114, 551);
            this.lblInPatientRecordsCount.Name = "lblInPatientRecordsCount";
            this.lblInPatientRecordsCount.Size = new System.Drawing.Size(59, 20);
            this.lblInPatientRecordsCount.TabIndex = 50;
            this.lblInPatientRecordsCount.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(13, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "# Patients:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvInPatientRecordsList);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1275, 333);
            this.panel1.TabIndex = 48;
            // 
            // dgvInPatientRecordsList
            // 
            this.dgvInPatientRecordsList.AllowUserToAddRows = false;
            this.dgvInPatientRecordsList.AllowUserToDeleteRows = false;
            this.dgvInPatientRecordsList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvInPatientRecordsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInPatientRecordsList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvInPatientRecordsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInPatientRecordsList.Location = new System.Drawing.Point(0, 0);
            this.dgvInPatientRecordsList.Name = "dgvInPatientRecordsList";
            this.dgvInPatientRecordsList.ReadOnly = true;
            this.dgvInPatientRecordsList.Size = new System.Drawing.Size(1275, 333);
            this.dgvInPatientRecordsList.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPrescriptionsListToolStripMenuItem,
            this.newPrescriptionOrTreatmentToolStripMenuItem,
            this.toolStripMenuItem2,
            this.startTreatmentToolStripMenuItem,
            this.newAppointmentToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cancelToolStripMenuItem,
            this.toolStripMenuItem3,
            this.showInfoToolStripMenuItem,
            this.showPatientInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(223, 198);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.showInfoToolStripMenuItem.Text = "Show Info";
            // 
            // showPatientInfoToolStripMenuItem
            // 
            this.showPatientInfoToolStripMenuItem.Name = "showPatientInfoToolStripMenuItem";
            this.showPatientInfoToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.showPatientInfoToolStripMenuItem.Text = "Show Patient Info";
            // 
            // showPrescriptionsListToolStripMenuItem
            // 
            this.showPrescriptionsListToolStripMenuItem.Name = "showPrescriptionsListToolStripMenuItem";
            this.showPrescriptionsListToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.showPrescriptionsListToolStripMenuItem.Text = "Show Prescriptions List";
            this.showPrescriptionsListToolStripMenuItem.Click += new System.EventHandler(this.showPrescriptionsListToolStripMenuItem_Click);
            // 
            // newPrescriptionOrTreatmentToolStripMenuItem
            // 
            this.newPrescriptionOrTreatmentToolStripMenuItem.Name = "newPrescriptionOrTreatmentToolStripMenuItem";
            this.newPrescriptionOrTreatmentToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.newPrescriptionOrTreatmentToolStripMenuItem.Text = "New Prescription\\Treatment";
            this.newPrescriptionOrTreatmentToolStripMenuItem.Click += new System.EventHandler(this.newPrescriptionOrTreatmentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(219, 6);
            // 
            // startTreatmentToolStripMenuItem
            // 
            this.startTreatmentToolStripMenuItem.Name = "startTreatmentToolStripMenuItem";
            this.startTreatmentToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.startTreatmentToolStripMenuItem.Text = "Start Treatment";
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            // 
            // newAppointmentToolStripMenuItem
            // 
            this.newAppointmentToolStripMenuItem.Name = "newAppointmentToolStripMenuItem";
            this.newAppointmentToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.newAppointmentToolStripMenuItem.Text = "New Appointment";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(219, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(219, 6);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::HMS.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(1174, 542);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 40);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmManageInPatientRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 591);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSearchType);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblInPatientRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageInPatientRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "In Patients";
            this.Load += new System.EventHandler(this.frmManageInPatientRecords_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInPatientRecordsList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInPatientRecordsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvInPatientRecordsList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPatientInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPrescriptionsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPrescriptionOrTreatmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem startTreatmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}