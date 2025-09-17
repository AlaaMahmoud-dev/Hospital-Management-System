namespace HMS
{
    partial class frmAddUpdateDoctorInfo
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblModeTitle = new System.Windows.Forms.Label();
            this.tcAddUpdateDoctorInfo = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardWithFilter1 = new HMS.People.ctrlPersonCardWithFilter();
            this.tpDoctorInfo = new System.Windows.Forms.TabPage();
            this.pDoctorInfoConrols = new System.Windows.Forms.Panel();
            this.cbMedicalStaffPosition = new System.Windows.Forms.ComboBox();
            this.gbAvailabilityOfWeed = new System.Windows.Forms.GroupBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkTuseday = new System.Windows.Forms.CheckBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.cbSpecialization = new System.Windows.Forms.ComboBox();
            this.lblRegisteredByUserName = new System.Windows.Forms.Label();
            this.txtCertificates = new System.Windows.Forms.TextBox();
            this.txtYearsOfExperience = new System.Windows.Forms.TextBox();
            this.lblDoctorID = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblMedicalStaffID = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.tcAddUpdateDoctorInfo.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpDoctorInfo.SuspendLayout();
            this.pDoctorInfoConrols.SuspendLayout();
            this.gbAvailabilityOfWeed.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.lblModeTitle);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 52);
            this.panel2.TabIndex = 36;
            // 
            // lblModeTitle
            // 
            this.lblModeTitle.AutoSize = true;
            this.lblModeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblModeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblModeTitle.Location = new System.Drawing.Point(300, 9);
            this.lblModeTitle.Name = "lblModeTitle";
            this.lblModeTitle.Size = new System.Drawing.Size(320, 31);
            this.lblModeTitle.TabIndex = 15;
            this.lblModeTitle.Text = "Add Update Doctor Info";
            // 
            // tcAddUpdateDoctorInfo
            // 
            this.tcAddUpdateDoctorInfo.Controls.Add(this.tpPersonInfo);
            this.tcAddUpdateDoctorInfo.Controls.Add(this.tpDoctorInfo);
            this.tcAddUpdateDoctorInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAddUpdateDoctorInfo.Location = new System.Drawing.Point(12, 69);
            this.tcAddUpdateDoctorInfo.Name = "tcAddUpdateDoctorInfo";
            this.tcAddUpdateDoctorInfo.SelectedIndex = 0;
            this.tcAddUpdateDoctorInfo.Size = new System.Drawing.Size(881, 421);
            this.tcAddUpdateDoctorInfo.TabIndex = 38;
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tpPersonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 27);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonInfo.Size = new System.Drawing.Size(873, 390);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Person Info";
            this.tpPersonInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(56, 33);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(754, 325);
            this.ctrlPersonCardWithFilter1.TabIndex = 40;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // tpDoctorInfo
            // 
            this.tpDoctorInfo.Controls.Add(this.pDoctorInfoConrols);
            this.tpDoctorInfo.Location = new System.Drawing.Point(4, 27);
            this.tpDoctorInfo.Name = "tpDoctorInfo";
            this.tpDoctorInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpDoctorInfo.Size = new System.Drawing.Size(873, 390);
            this.tpDoctorInfo.TabIndex = 2;
            this.tpDoctorInfo.Text = "Doctor Info";
            this.tpDoctorInfo.UseVisualStyleBackColor = true;
            // 
            // pDoctorInfoConrols
            // 
            this.pDoctorInfoConrols.Controls.Add(this.cbMedicalStaffPosition);
            this.pDoctorInfoConrols.Controls.Add(this.gbAvailabilityOfWeed);
            this.pDoctorInfoConrols.Controls.Add(this.cbDepartment);
            this.pDoctorInfoConrols.Controls.Add(this.cbSpecialization);
            this.pDoctorInfoConrols.Controls.Add(this.lblRegisteredByUserName);
            this.pDoctorInfoConrols.Controls.Add(this.txtCertificates);
            this.pDoctorInfoConrols.Controls.Add(this.txtYearsOfExperience);
            this.pDoctorInfoConrols.Controls.Add(this.lblDoctorID);
            this.pDoctorInfoConrols.Controls.Add(this.label19);
            this.pDoctorInfoConrols.Controls.Add(this.lblMedicalStaffID);
            this.pDoctorInfoConrols.Controls.Add(this.label17);
            this.pDoctorInfoConrols.Controls.Add(this.label12);
            this.pDoctorInfoConrols.Controls.Add(this.label7);
            this.pDoctorInfoConrols.Controls.Add(this.label6);
            this.pDoctorInfoConrols.Controls.Add(this.label4);
            this.pDoctorInfoConrols.Controls.Add(this.label3);
            this.pDoctorInfoConrols.Controls.Add(this.label1);
            this.pDoctorInfoConrols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDoctorInfoConrols.Location = new System.Drawing.Point(3, 3);
            this.pDoctorInfoConrols.Name = "pDoctorInfoConrols";
            this.pDoctorInfoConrols.Size = new System.Drawing.Size(867, 384);
            this.pDoctorInfoConrols.TabIndex = 0;
            // 
            // cbMedicalStaffPosition
            // 
            this.cbMedicalStaffPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMedicalStaffPosition.FormattingEnabled = true;
            this.cbMedicalStaffPosition.Location = new System.Drawing.Point(587, 77);
            this.cbMedicalStaffPosition.Name = "cbMedicalStaffPosition";
            this.cbMedicalStaffPosition.Size = new System.Drawing.Size(221, 26);
            this.cbMedicalStaffPosition.Sorted = true;
            this.cbMedicalStaffPosition.TabIndex = 69;
            // 
            // gbAvailabilityOfWeed
            // 
            this.gbAvailabilityOfWeed.Controls.Add(this.chkSaturday);
            this.gbAvailabilityOfWeed.Controls.Add(this.chkFriday);
            this.gbAvailabilityOfWeed.Controls.Add(this.chkWednesday);
            this.gbAvailabilityOfWeed.Controls.Add(this.chkMonday);
            this.gbAvailabilityOfWeed.Controls.Add(this.chkThursday);
            this.gbAvailabilityOfWeed.Controls.Add(this.chkTuseday);
            this.gbAvailabilityOfWeed.Controls.Add(this.chkSunday);
            this.gbAvailabilityOfWeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAvailabilityOfWeed.Location = new System.Drawing.Point(17, 189);
            this.gbAvailabilityOfWeed.Name = "gbAvailabilityOfWeed";
            this.gbAvailabilityOfWeed.Size = new System.Drawing.Size(272, 173);
            this.gbAvailabilityOfWeed.TabIndex = 68;
            this.gbAvailabilityOfWeed.TabStop = false;
            this.gbAvailabilityOfWeed.Text = "Doctor\'s Availability Of Week";
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaturday.Location = new System.Drawing.Point(94, 147);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(88, 20);
            this.chkSaturday.TabIndex = 6;
            this.chkSaturday.Text = "Saturday";
            this.chkSaturday.UseVisualStyleBackColor = true;
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFriday.Location = new System.Drawing.Point(154, 114);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(70, 20);
            this.chkFriday.TabIndex = 5;
            this.chkFriday.Text = "Friday";
            this.chkFriday.UseVisualStyleBackColor = true;
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWednesday.Location = new System.Drawing.Point(154, 38);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(109, 20);
            this.chkWednesday.TabIndex = 4;
            this.chkWednesday.Text = "Wednesday";
            this.chkWednesday.UseVisualStyleBackColor = true;
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMonday.Location = new System.Drawing.Point(47, 77);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(81, 20);
            this.chkMonday.TabIndex = 3;
            this.chkMonday.Text = "Monday";
            this.chkMonday.UseVisualStyleBackColor = true;
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkThursday.Location = new System.Drawing.Point(154, 77);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(91, 20);
            this.chkThursday.TabIndex = 2;
            this.chkThursday.Text = "Thursday";
            this.chkThursday.UseVisualStyleBackColor = true;
            // 
            // chkTuseday
            // 
            this.chkTuseday.AutoSize = true;
            this.chkTuseday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTuseday.Location = new System.Drawing.Point(47, 114);
            this.chkTuseday.Name = "chkTuseday";
            this.chkTuseday.Size = new System.Drawing.Size(87, 20);
            this.chkTuseday.TabIndex = 1;
            this.chkTuseday.Text = "Tuseday";
            this.chkTuseday.UseVisualStyleBackColor = true;
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSunday.Location = new System.Drawing.Point(47, 38);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSunday.Size = new System.Drawing.Size(78, 20);
            this.chkSunday.TabIndex = 0;
            this.chkSunday.Text = "Sunday";
            this.chkSunday.UseVisualStyleBackColor = true;
            // 
            // cbDepartment
            // 
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(587, 186);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(221, 26);
            this.cbDepartment.Sorted = true;
            this.cbDepartment.TabIndex = 67;
            // 
            // cbSpecialization
            // 
            this.cbSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecialization.FormattingEnabled = true;
            this.cbSpecialization.Location = new System.Drawing.Point(587, 132);
            this.cbSpecialization.Name = "cbSpecialization";
            this.cbSpecialization.Size = new System.Drawing.Size(221, 26);
            this.cbSpecialization.Sorted = true;
            this.cbSpecialization.TabIndex = 66;
            // 
            // lblRegisteredByUserName
            // 
            this.lblRegisteredByUserName.AutoSize = true;
            this.lblRegisteredByUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisteredByUserName.Location = new System.Drawing.Point(584, 28);
            this.lblRegisteredByUserName.Name = "lblRegisteredByUserName";
            this.lblRegisteredByUserName.Size = new System.Drawing.Size(49, 16);
            this.lblRegisteredByUserName.TabIndex = 65;
            this.lblRegisteredByUserName.Text = "[????]";
            // 
            // txtCertificates
            // 
            this.txtCertificates.Location = new System.Drawing.Point(587, 241);
            this.txtCertificates.Multiline = true;
            this.txtCertificates.Name = "txtCertificates";
            this.txtCertificates.PasswordChar = '*';
            this.txtCertificates.Size = new System.Drawing.Size(268, 96);
            this.txtCertificates.TabIndex = 64;
            // 
            // txtYearsOfExperience
            // 
            this.txtYearsOfExperience.Location = new System.Drawing.Point(193, 136);
            this.txtYearsOfExperience.Multiline = true;
            this.txtYearsOfExperience.Name = "txtYearsOfExperience";
            this.txtYearsOfExperience.Size = new System.Drawing.Size(168, 20);
            this.txtYearsOfExperience.TabIndex = 63;
            // 
            // lblDoctorID
            // 
            this.lblDoctorID.AutoSize = true;
            this.lblDoctorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorID.Location = new System.Drawing.Point(190, 85);
            this.lblDoctorID.Name = "lblDoctorID";
            this.lblDoctorID.Size = new System.Drawing.Size(49, 16);
            this.lblDoctorID.TabIndex = 62;
            this.lblDoctorID.Text = "[????]";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(95, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 18);
            this.label19.TabIndex = 61;
            this.label19.Text = "Doctor ID:";
            // 
            // lblMedicalStaffID
            // 
            this.lblMedicalStaffID.AutoSize = true;
            this.lblMedicalStaffID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicalStaffID.Location = new System.Drawing.Point(190, 33);
            this.lblMedicalStaffID.Name = "lblMedicalStaffID";
            this.lblMedicalStaffID.Size = new System.Drawing.Size(49, 16);
            this.lblMedicalStaffID.TabIndex = 60;
            this.lblMedicalStaffID.Text = "[????]";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(51, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(132, 18);
            this.label17.TabIndex = 59;
            this.label17.Text = "Medical Staff ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(397, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 18);
            this.label12.TabIndex = 58;
            this.label12.Text = "Cetificates:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(397, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 18);
            this.label7.TabIndex = 57;
            this.label7.Text = "Doctor Specialization:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(397, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 18);
            this.label6.TabIndex = 56;
            this.label6.Text = "Select Department:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 18);
            this.label4.TabIndex = 55;
            this.label4.Text = "Years Of Experience:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(397, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 18);
            this.label3.TabIndex = 54;
            this.label3.Text = "Select Position:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 53;
            this.label1.Text = "Registered By:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 492);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(902, 54);
            this.panel4.TabIndex = 39;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::HMS.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(674, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::HMS.Properties.Resources.diskette_check;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(780, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 37);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddUpdateDoctorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 546);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tcAddUpdateDoctorInfo);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateDoctorInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Update Doctor Info";
            this.Load += new System.EventHandler(this.frmAddUpdateDoctorInfo_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tcAddUpdateDoctorInfo.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpDoctorInfo.ResumeLayout(false);
            this.pDoctorInfoConrols.ResumeLayout(false);
            this.pDoctorInfoConrols.PerformLayout();
            this.gbAvailabilityOfWeed.ResumeLayout(false);
            this.gbAvailabilityOfWeed.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblModeTitle;
        private System.Windows.Forms.TabControl tcAddUpdateDoctorInfo;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.TabPage tpDoctorInfo;
        private People.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pDoctorInfoConrols;
        private System.Windows.Forms.ComboBox cbMedicalStaffPosition;
        private System.Windows.Forms.GroupBox gbAvailabilityOfWeed;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkTuseday;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.ComboBox cbSpecialization;
        private System.Windows.Forms.Label lblRegisteredByUserName;
        private System.Windows.Forms.TextBox txtCertificates;
        private System.Windows.Forms.TextBox txtYearsOfExperience;
        private System.Windows.Forms.Label lblDoctorID;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblMedicalStaffID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}