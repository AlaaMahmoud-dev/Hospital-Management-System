namespace HMS
{
    partial class frmNewPrescription
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.llShowPatientInfo = new System.Windows.Forms.LinkLabel();
            this.gbMedicinesAndTestsList = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnShowSelectedItemInfo = new System.Windows.Forms.Button();
            this.btnSelectItem = new System.Windows.Forms.Button();
            this.dgvMedicinesAndTestsList = new System.Windows.Forms.DataGridView();
            this.gbSelectedMedicinesOrTestsList = new System.Windows.Forms.GroupBox();
            this.dgvSelectedMedicinesOrTestsList = new System.Windows.Forms.DataGridView();
            this.btnClearAllSelectedList = new System.Windows.Forms.Button();
            this.btnDeleteSelectedMedicineOrTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrescriptionType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.gbMedicinesAndTestsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinesAndTestsList)).BeginInit();
            this.gbSelectedMedicinesOrTestsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedMedicinesOrTestsList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Controls.Add(this.lblMainTitle);
            this.panel3.Location = new System.Drawing.Point(0, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1103, 43);
            this.panel3.TabIndex = 15;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblMainTitle.Location = new System.Drawing.Point(437, 8);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(203, 32);
            this.lblMainTitle.TabIndex = 1;
            this.lblMainTitle.Text = "New Prescription";
            // 
            // llShowPatientInfo
            // 
            this.llShowPatientInfo.AutoSize = true;
            this.llShowPatientInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.llShowPatientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowPatientInfo.Location = new System.Drawing.Point(939, 96);
            this.llShowPatientInfo.Name = "llShowPatientInfo";
            this.llShowPatientInfo.Size = new System.Drawing.Size(152, 20);
            this.llShowPatientInfo.TabIndex = 47;
            this.llShowPatientInfo.TabStop = true;
            this.llShowPatientInfo.Text = "Show Patient Info";
            this.llShowPatientInfo.Visible = false;
            this.llShowPatientInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowPatientInfo_LinkClicked);
            // 
            // gbMedicinesAndTestsList
            // 
            this.gbMedicinesAndTestsList.Controls.Add(this.txtSearchValue);
            this.gbMedicinesAndTestsList.Controls.Add(this.lblSearchType);
            this.gbMedicinesAndTestsList.Controls.Add(this.label2);
            this.gbMedicinesAndTestsList.Controls.Add(this.numericUpDown1);
            this.gbMedicinesAndTestsList.Controls.Add(this.btnShowSelectedItemInfo);
            this.gbMedicinesAndTestsList.Controls.Add(this.btnSelectItem);
            this.gbMedicinesAndTestsList.Controls.Add(this.dgvMedicinesAndTestsList);
            this.gbMedicinesAndTestsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMedicinesAndTestsList.Location = new System.Drawing.Point(12, 393);
            this.gbMedicinesAndTestsList.Name = "gbMedicinesAndTestsList";
            this.gbMedicinesAndTestsList.Size = new System.Drawing.Size(1079, 396);
            this.gbMedicinesAndTestsList.TabIndex = 48;
            this.gbMedicinesAndTestsList.TabStop = false;
            this.gbMedicinesAndTestsList.Text = "groupBox1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 51;
            this.label2.Text = "Quantity:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(99, 358);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(130, 24);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnShowSelectedItemInfo
            // 
            this.btnShowSelectedItemInfo.BackColor = System.Drawing.Color.Silver;
            this.btnShowSelectedItemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowSelectedItemInfo.Location = new System.Drawing.Point(931, 162);
            this.btnShowSelectedItemInfo.Name = "btnShowSelectedItemInfo";
            this.btnShowSelectedItemInfo.Size = new System.Drawing.Size(130, 37);
            this.btnShowSelectedItemInfo.TabIndex = 4;
            this.btnShowSelectedItemInfo.Text = "Show Info";
            this.btnShowSelectedItemInfo.UseVisualStyleBackColor = false;
            // 
            // btnSelectItem
            // 
            this.btnSelectItem.BackColor = System.Drawing.Color.Silver;
            this.btnSelectItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectItem.Location = new System.Drawing.Point(931, 106);
            this.btnSelectItem.Name = "btnSelectItem";
            this.btnSelectItem.Size = new System.Drawing.Size(130, 37);
            this.btnSelectItem.TabIndex = 3;
            this.btnSelectItem.Text = "Select";
            this.btnSelectItem.UseVisualStyleBackColor = false;
            this.btnSelectItem.Click += new System.EventHandler(this.btnSelectItem_Click);
            // 
            // dgvMedicinesAndTestsList
            // 
            this.dgvMedicinesAndTestsList.AllowUserToAddRows = false;
            this.dgvMedicinesAndTestsList.AllowUserToDeleteRows = false;
            this.dgvMedicinesAndTestsList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMedicinesAndTestsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicinesAndTestsList.Location = new System.Drawing.Point(21, 75);
            this.dgvMedicinesAndTestsList.MultiSelect = false;
            this.dgvMedicinesAndTestsList.Name = "dgvMedicinesAndTestsList";
            this.dgvMedicinesAndTestsList.ReadOnly = true;
            this.dgvMedicinesAndTestsList.Size = new System.Drawing.Size(895, 267);
            this.dgvMedicinesAndTestsList.TabIndex = 2;
            // 
            // gbSelectedMedicinesOrTestsList
            // 
            this.gbSelectedMedicinesOrTestsList.Controls.Add(this.dgvSelectedMedicinesOrTestsList);
            this.gbSelectedMedicinesOrTestsList.Controls.Add(this.btnClearAllSelectedList);
            this.gbSelectedMedicinesOrTestsList.Controls.Add(this.btnDeleteSelectedMedicineOrTest);
            this.gbSelectedMedicinesOrTestsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSelectedMedicinesOrTestsList.Location = new System.Drawing.Point(12, 138);
            this.gbSelectedMedicinesOrTestsList.Name = "gbSelectedMedicinesOrTestsList";
            this.gbSelectedMedicinesOrTestsList.Size = new System.Drawing.Size(1079, 230);
            this.gbSelectedMedicinesOrTestsList.TabIndex = 49;
            this.gbSelectedMedicinesOrTestsList.TabStop = false;
            this.gbSelectedMedicinesOrTestsList.Text = "groupBox1";
            // 
            // dgvSelectedMedicinesOrTestsList
            // 
            this.dgvSelectedMedicinesOrTestsList.AllowUserToAddRows = false;
            this.dgvSelectedMedicinesOrTestsList.AllowUserToDeleteRows = false;
            this.dgvSelectedMedicinesOrTestsList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSelectedMedicinesOrTestsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedMedicinesOrTestsList.Location = new System.Drawing.Point(21, 32);
            this.dgvSelectedMedicinesOrTestsList.MultiSelect = false;
            this.dgvSelectedMedicinesOrTestsList.Name = "dgvSelectedMedicinesOrTestsList";
            this.dgvSelectedMedicinesOrTestsList.ReadOnly = true;
            this.dgvSelectedMedicinesOrTestsList.Size = new System.Drawing.Size(895, 167);
            this.dgvSelectedMedicinesOrTestsList.TabIndex = 49;
            // 
            // btnClearAllSelectedList
            // 
            this.btnClearAllSelectedList.BackColor = System.Drawing.Color.Silver;
            this.btnClearAllSelectedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAllSelectedList.Location = new System.Drawing.Point(933, 105);
            this.btnClearAllSelectedList.Name = "btnClearAllSelectedList";
            this.btnClearAllSelectedList.Size = new System.Drawing.Size(130, 37);
            this.btnClearAllSelectedList.TabIndex = 4;
            this.btnClearAllSelectedList.Text = "Clear All";
            this.btnClearAllSelectedList.UseVisualStyleBackColor = false;
            this.btnClearAllSelectedList.Click += new System.EventHandler(this.btnClearAllSelectedList_Click);
            // 
            // btnDeleteSelectedMedicineOrTest
            // 
            this.btnDeleteSelectedMedicineOrTest.BackColor = System.Drawing.Color.Silver;
            this.btnDeleteSelectedMedicineOrTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSelectedMedicineOrTest.Location = new System.Drawing.Point(933, 52);
            this.btnDeleteSelectedMedicineOrTest.Name = "btnDeleteSelectedMedicineOrTest";
            this.btnDeleteSelectedMedicineOrTest.Size = new System.Drawing.Size(130, 37);
            this.btnDeleteSelectedMedicineOrTest.TabIndex = 3;
            this.btnDeleteSelectedMedicineOrTest.Text = "Delete";
            this.btnDeleteSelectedMedicineOrTest.UseVisualStyleBackColor = false;
            this.btnDeleteSelectedMedicineOrTest.Click += new System.EventHandler(this.btnDeleteSelectedMedicineOrTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 18);
            this.label1.TabIndex = 50;
            this.label1.Text = "Select Prescription Type:";
            // 
            // cbPrescriptionType
            // 
            this.cbPrescriptionType.BackColor = System.Drawing.Color.Silver;
            this.cbPrescriptionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrescriptionType.FormattingEnabled = true;
            this.cbPrescriptionType.Location = new System.Drawing.Point(251, 99);
            this.cbPrescriptionType.Name = "cbPrescriptionType";
            this.cbPrescriptionType.Size = new System.Drawing.Size(144, 21);
            this.cbPrescriptionType.TabIndex = 51;
            this.cbPrescriptionType.SelectedIndexChanged += new System.EventHandler(this.cbPrescriptionType_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::HMS.Properties.Resources.diskette_check;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(978, 795);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 37);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::HMS.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(859, 795);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 40);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchType.Location = new System.Drawing.Point(18, 45);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(129, 18);
            this.lblSearchType.TabIndex = 52;
            this.lblSearchType.Text = "Medicine Name:";
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(153, 42);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(189, 24);
            this.txtSearchValue.TabIndex = 53;
            this.txtSearchValue.TextChanged += new System.EventHandler(this.txtSearchValue_TextChanged);
            // 
            // frmNewPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1103, 844);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbPrescriptionType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbSelectedMedicinesOrTestsList);
            this.Controls.Add(this.gbMedicinesAndTestsList);
            this.Controls.Add(this.llShowPatientInfo);
            this.Controls.Add(this.panel3);
            this.Name = "frmNewPrescription";
            this.Text = "New Prescription Screen";
            this.Load += new System.EventHandler(this.frmNewPrescription_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gbMedicinesAndTestsList.ResumeLayout(false);
            this.gbMedicinesAndTestsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinesAndTestsList)).EndInit();
            this.gbSelectedMedicinesOrTestsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedMedicinesOrTestsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel llShowPatientInfo;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.GroupBox gbMedicinesAndTestsList;
        private System.Windows.Forms.Button btnShowSelectedItemInfo;
        private System.Windows.Forms.Button btnSelectItem;
        private System.Windows.Forms.DataGridView dgvMedicinesAndTestsList;
        private System.Windows.Forms.GroupBox gbSelectedMedicinesOrTestsList;
        private System.Windows.Forms.DataGridView dgvSelectedMedicinesOrTestsList;
        private System.Windows.Forms.Button btnClearAllSelectedList;
        private System.Windows.Forms.Button btnDeleteSelectedMedicineOrTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPrescriptionType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label lblSearchType;
    }
}