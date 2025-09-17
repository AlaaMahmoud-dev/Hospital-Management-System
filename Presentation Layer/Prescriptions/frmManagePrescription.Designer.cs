namespace HMS.Prescriptions
{
    partial class frmManagePrescription
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbMedicinesOrTests = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMedicines = new System.Windows.Forms.TabPage();
            this.dgvMedicinesList = new System.Windows.Forms.DataGridView();
            this.cmsMedicinesManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpTests = new System.Windows.Forms.TabPage();
            this.dgvTestsList = new System.Windows.Forms.DataGridView();
            this.cmsTestsManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlPrescriptionDetails1 = new HMS.Prescriptions.Controls.ctrlPrescriptionDetails();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbMedicinesOrTests.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpMedicines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinesList)).BeginInit();
            this.cmsMedicinesManager.SuspendLayout();
            this.tpTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsList)).BeginInit();
            this.cmsTestsManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMedicinesOrTests
            // 
            this.gbMedicinesOrTests.Controls.Add(this.tabControl1);
            this.gbMedicinesOrTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMedicinesOrTests.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbMedicinesOrTests.Location = new System.Drawing.Point(12, 265);
            this.gbMedicinesOrTests.Name = "gbMedicinesOrTests";
            this.gbMedicinesOrTests.Size = new System.Drawing.Size(844, 234);
            this.gbMedicinesOrTests.TabIndex = 3;
            this.gbMedicinesOrTests.TabStop = false;
            this.gbMedicinesOrTests.Text = "Medicines/Tests";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMedicines);
            this.tabControl1.Controls.Add(this.tpTests);
            this.tabControl1.Location = new System.Drawing.Point(18, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 174);
            this.tabControl1.TabIndex = 0;
            // 
            // tpMedicines
            // 
            this.tpMedicines.Controls.Add(this.dgvMedicinesList);
            this.tpMedicines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpMedicines.Location = new System.Drawing.Point(4, 27);
            this.tpMedicines.Name = "tpMedicines";
            this.tpMedicines.Padding = new System.Windows.Forms.Padding(3);
            this.tpMedicines.Size = new System.Drawing.Size(800, 143);
            this.tpMedicines.TabIndex = 0;
            this.tpMedicines.Text = "Medicines";
            this.tpMedicines.UseVisualStyleBackColor = true;
            // 
            // dgvMedicinesList
            // 
            this.dgvMedicinesList.AllowUserToAddRows = false;
            this.dgvMedicinesList.AllowUserToDeleteRows = false;
            this.dgvMedicinesList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedicinesList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedicinesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicinesList.ContextMenuStrip = this.cmsMedicinesManager;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMedicinesList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMedicinesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicinesList.Location = new System.Drawing.Point(3, 3);
            this.dgvMedicinesList.Name = "dgvMedicinesList";
            this.dgvMedicinesList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedicinesList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMedicinesList.Size = new System.Drawing.Size(794, 137);
            this.dgvMedicinesList.TabIndex = 1;
            // 
            // cmsMedicinesManager
            // 
            this.cmsMedicinesManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cancelToolStripMenuItem,
            this.confirmToolStripMenuItem});
            this.cmsMedicinesManager.Name = "cmsMedicinesManager";
            this.cmsMedicinesManager.Size = new System.Drawing.Size(128, 76);
            this.cmsMedicinesManager.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMedicinesManager_Opening);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.showInfoToolStripMenuItem.Text = "Show Info";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // confirmToolStripMenuItem
            // 
            this.confirmToolStripMenuItem.Name = "confirmToolStripMenuItem";
            this.confirmToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.confirmToolStripMenuItem.Text = "Confirm";
            this.confirmToolStripMenuItem.Click += new System.EventHandler(this.confirmToolStripMenuItem_Click);
            // 
            // tpTests
            // 
            this.tpTests.Controls.Add(this.dgvTestsList);
            this.tpTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpTests.Location = new System.Drawing.Point(4, 27);
            this.tpTests.Name = "tpTests";
            this.tpTests.Padding = new System.Windows.Forms.Padding(3);
            this.tpTests.Size = new System.Drawing.Size(710, 143);
            this.tpTests.TabIndex = 1;
            this.tpTests.Text = "Tests";
            this.tpTests.UseVisualStyleBackColor = true;
            // 
            // dgvTestsList
            // 
            this.dgvTestsList.AllowUserToAddRows = false;
            this.dgvTestsList.AllowUserToDeleteRows = false;
            this.dgvTestsList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTestsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestsList.ContextMenuStrip = this.cmsTestsManager;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestsList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTestsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestsList.Location = new System.Drawing.Point(3, 3);
            this.dgvTestsList.Name = "dgvTestsList";
            this.dgvTestsList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestsList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTestsList.Size = new System.Drawing.Size(704, 137);
            this.dgvTestsList.TabIndex = 0;
            // 
            // cmsTestsManager
            // 
            this.cmsTestsManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem1});
            this.cmsTestsManager.Name = "cmsTestsManager";
            this.cmsTestsManager.Size = new System.Drawing.Size(128, 26);
            // 
            // showInfoToolStripMenuItem1
            // 
            this.showInfoToolStripMenuItem1.Name = "showInfoToolStripMenuItem1";
            this.showInfoToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.showInfoToolStripMenuItem1.Text = "Show Info";
            // 
            // ctrlPrescriptionDetails1
            // 
            this.ctrlPrescriptionDetails1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlPrescriptionDetails1.Location = new System.Drawing.Point(12, 9);
            this.ctrlPrescriptionDetails1.Name = "ctrlPrescriptionDetails1";
            this.ctrlPrescriptionDetails1.Size = new System.Drawing.Size(754, 232);
            this.ctrlPrescriptionDetails1.TabIndex = 2;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Image = global::HMS.Properties.Resources.diskette_check;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(727, 505);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(129, 37);
            this.btnConfirm.TabIndex = 39;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::HMS.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(608, 505);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 37);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmManagePrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 552);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbMedicinesOrTests);
            this.Controls.Add(this.ctrlPrescriptionDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManagePrescription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmManagePrescription";
            this.Load += new System.EventHandler(this.frmManagePrescription_Load);
            this.gbMedicinesOrTests.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpMedicines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinesList)).EndInit();
            this.cmsMedicinesManager.ResumeLayout(false);
            this.tpTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsList)).EndInit();
            this.cmsTestsManager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMedicinesOrTests;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMedicines;
        private System.Windows.Forms.DataGridView dgvMedicinesList;
        private System.Windows.Forms.TabPage tpTests;
        private System.Windows.Forms.DataGridView dgvTestsList;
        private Controls.ctrlPrescriptionDetails ctrlPrescriptionDetails1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsMedicinesManager;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confirmToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsTestsManager;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem1;
    }
}