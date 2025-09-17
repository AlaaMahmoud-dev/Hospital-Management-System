namespace HMS
{
    partial class frmShowPrescriptionInfo
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
            this.tpTests = new System.Windows.Forms.TabPage();
            this.dgvTestsList = new System.Windows.Forms.DataGridView();
            this.ctrlPrescriptionDetails1 = new HMS.Prescriptions.Controls.ctrlPrescriptionDetails();
            this.gbMedicinesOrTests.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpMedicines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinesList)).BeginInit();
            this.tpTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsList)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMedicinesOrTests
            // 
            this.gbMedicinesOrTests.Controls.Add(this.tabControl1);
            this.gbMedicinesOrTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMedicinesOrTests.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbMedicinesOrTests.Location = new System.Drawing.Point(12, 268);
            this.gbMedicinesOrTests.Name = "gbMedicinesOrTests";
            this.gbMedicinesOrTests.Size = new System.Drawing.Size(754, 227);
            this.gbMedicinesOrTests.TabIndex = 1;
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
            this.tabControl1.Size = new System.Drawing.Size(718, 174);
            this.tabControl1.TabIndex = 0;
            // 
            // tpMedicines
            // 
            this.tpMedicines.Controls.Add(this.dgvMedicinesList);
            this.tpMedicines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpMedicines.Location = new System.Drawing.Point(4, 27);
            this.tpMedicines.Name = "tpMedicines";
            this.tpMedicines.Padding = new System.Windows.Forms.Padding(3);
            this.tpMedicines.Size = new System.Drawing.Size(710, 143);
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
            this.dgvMedicinesList.Size = new System.Drawing.Size(704, 137);
            this.dgvMedicinesList.TabIndex = 1;
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
            // ctrlPrescriptionDetails1
            // 
            this.ctrlPrescriptionDetails1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlPrescriptionDetails1.Location = new System.Drawing.Point(12, 12);
            this.ctrlPrescriptionDetails1.Name = "ctrlPrescriptionDetails1";
            this.ctrlPrescriptionDetails1.Size = new System.Drawing.Size(754, 232);
            this.ctrlPrescriptionDetails1.TabIndex = 0;
            // 
            // frmShowPrescriptionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(778, 506);
            this.Controls.Add(this.gbMedicinesOrTests);
            this.Controls.Add(this.ctrlPrescriptionDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowPrescriptionInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmShowPrescriptionInfo";
            this.Load += new System.EventHandler(this.frmShowPrescriptionInfo_Load);
            this.gbMedicinesOrTests.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpMedicines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinesList)).EndInit();
            this.tpTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Prescriptions.Controls.ctrlPrescriptionDetails ctrlPrescriptionDetails1;
        private System.Windows.Forms.GroupBox gbMedicinesOrTests;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMedicines;
        private System.Windows.Forms.DataGridView dgvMedicinesList;
        private System.Windows.Forms.TabPage tpTests;
        private System.Windows.Forms.DataGridView dgvTestsList;
    }
}