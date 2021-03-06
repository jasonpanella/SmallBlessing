﻿using System;
namespace SmallBlessing.Desktop.Forms.Membership
{
    partial class Person
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Person));
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoGuardian2 = new System.Windows.Forms.RadioButton();
            this.rdoGuardian1 = new System.Windows.Forms.RadioButton();
            this.txtContactNumber = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoChurchHome2 = new System.Windows.Forms.RadioButton();
            this.rdoChurchHome1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoLeaveMessage2 = new System.Windows.Forms.RadioButton();
            this.rdoLeaveMessage1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.dataGridViewDependents = new System.Windows.Forms.DataGridView();
            this.txtOpinion = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtChurchName = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMiddleInitial = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.dtDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.tabSearchManage = new System.Windows.Forms.TabPage();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.PrintReport = new System.Drawing.Printing.PrintDocument();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dependentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.smallBlessingsDataSet = new SmallBlessing.Desktop.SmallBlessingsDataSet();
            this.dependentsTableAdapter = new SmallBlessing.Desktop.SmallBlessingsDataSetTableAdapters.DependentsTableAdapter();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDependents)).BeginInit();
            this.tabSearchManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dependentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallBlessingsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabSearchManage);
            this.tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab.Location = new System.Drawing.Point(12, 12);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(787, 658);
            this.tab.TabIndex = 0;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.Tab_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.txtContactNumber);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtZip);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtState);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtCity);
            this.tabPage1.Controls.Add(this.dataGridViewDependents);
            this.tabPage1.Controls.Add(this.txtOpinion);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.txtChurchName);
            this.tabPage1.Controls.Add(this.label39);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtMiddleInitial);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.txtLastName);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.label33);
            this.tabPage1.Controls.Add(this.label34);
            this.tabPage1.Controls.Add(this.lblAddress);
            this.tabPage1.Controls.Add(this.txtAddress);
            this.tabPage1.Controls.Add(this.dtDateOfBirth);
            this.tabPage1.Controls.Add(this.txtFirstName);
            this.tabPage1.Controls.Add(this.lblDateOfBirth);
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(779, 630);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Member Info";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoGuardian2);
            this.groupBox4.Controls.Add(this.rdoGuardian1);
            this.groupBox4.Location = new System.Drawing.Point(446, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(203, 53);
            this.groupBox4.TabIndex = 115;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Provided Proof of Guardianship?";
            // 
            // rdoGuardian2
            // 
            this.rdoGuardian2.AutoSize = true;
            this.rdoGuardian2.Location = new System.Drawing.Point(79, 24);
            this.rdoGuardian2.Name = "rdoGuardian2";
            this.rdoGuardian2.Size = new System.Drawing.Size(41, 19);
            this.rdoGuardian2.TabIndex = 12;
            this.rdoGuardian2.TabStop = true;
            this.rdoGuardian2.Text = "No";
            this.rdoGuardian2.UseVisualStyleBackColor = true;
            // 
            // rdoGuardian1
            // 
            this.rdoGuardian1.AutoSize = true;
            this.rdoGuardian1.Location = new System.Drawing.Point(26, 24);
            this.rdoGuardian1.Name = "rdoGuardian1";
            this.rdoGuardian1.Size = new System.Drawing.Size(45, 19);
            this.rdoGuardian1.TabIndex = 11;
            this.rdoGuardian1.TabStop = true;
            this.rdoGuardian1.Text = "Yes";
            this.rdoGuardian1.UseVisualStyleBackColor = true;
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(23, 208);
            this.txtContactNumber.Mask = "(999) 000-0000";
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(100, 21);
            this.txtContactNumber.TabIndex = 102;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoChurchHome2);
            this.groupBox2.Controls.Add(this.rdoChurchHome1);
            this.groupBox2.Location = new System.Drawing.Point(24, 391);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 51);
            this.groupBox2.TabIndex = 112;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Do you have a church home?";
            // 
            // rdoChurchHome2
            // 
            this.rdoChurchHome2.AutoSize = true;
            this.rdoChurchHome2.Location = new System.Drawing.Point(68, 22);
            this.rdoChurchHome2.Name = "rdoChurchHome2";
            this.rdoChurchHome2.Size = new System.Drawing.Size(41, 19);
            this.rdoChurchHome2.TabIndex = 101;
            this.rdoChurchHome2.TabStop = true;
            this.rdoChurchHome2.Text = "No";
            this.rdoChurchHome2.UseVisualStyleBackColor = true;
            // 
            // rdoChurchHome1
            // 
            this.rdoChurchHome1.AutoSize = true;
            this.rdoChurchHome1.Location = new System.Drawing.Point(17, 22);
            this.rdoChurchHome1.Name = "rdoChurchHome1";
            this.rdoChurchHome1.Size = new System.Drawing.Size(45, 19);
            this.rdoChurchHome1.TabIndex = 100;
            this.rdoChurchHome1.TabStop = true;
            this.rdoChurchHome1.Text = "Yes";
            this.rdoChurchHome1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoLeaveMessage2);
            this.groupBox1.Controls.Add(this.rdoLeaveMessage1);
            this.groupBox1.Location = new System.Drawing.Point(141, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 53);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Can we leave a message or text at this number?";
            // 
            // rdoLeaveMessage2
            // 
            this.rdoLeaveMessage2.AutoSize = true;
            this.rdoLeaveMessage2.Location = new System.Drawing.Point(79, 24);
            this.rdoLeaveMessage2.Name = "rdoLeaveMessage2";
            this.rdoLeaveMessage2.Size = new System.Drawing.Size(41, 19);
            this.rdoLeaveMessage2.TabIndex = 113;
            this.rdoLeaveMessage2.TabStop = true;
            this.rdoLeaveMessage2.Text = "No";
            this.rdoLeaveMessage2.UseVisualStyleBackColor = true;
            // 
            // rdoLeaveMessage1
            // 
            this.rdoLeaveMessage1.AutoSize = true;
            this.rdoLeaveMessage1.Location = new System.Drawing.Point(26, 24);
            this.rdoLeaveMessage1.Name = "rdoLeaveMessage1";
            this.rdoLeaveMessage1.Size = new System.Drawing.Size(45, 19);
            this.rdoLeaveMessage1.TabIndex = 112;
            this.rdoLeaveMessage1.TabStop = true;
            this.rdoLeaveMessage1.Text = "Yes";
            this.rdoLeaveMessage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 15);
            this.label4.TabIndex = 110;
            this.label4.Text = "Zip";
            // 
            // txtZip
            // 
            this.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZip.Location = new System.Drawing.Point(277, 151);
            this.txtZip.MaxLength = 5;
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(72, 21);
            this.txtZip.TabIndex = 109;
            this.txtZip.TextChanged += new System.EventHandler(this.txtZip_TextChanged);
            this.txtZip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Zip_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 108;
            this.label2.Text = "State";
            // 
            // txtState
            // 
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.Location = new System.Drawing.Point(217, 151);
            this.txtState.MaxLength = 75;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(40, 21);
            this.txtState.TabIndex = 107;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 15);
            this.label1.TabIndex = 106;
            this.label1.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Location = new System.Drawing.Point(24, 151);
            this.txtCity.MaxLength = 75;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(171, 21);
            this.txtCity.TabIndex = 105;
            // 
            // dataGridViewDependents
            // 
            this.dataGridViewDependents.AllowUserToResizeColumns = false;
            this.dataGridViewDependents.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewDependents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDependents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDependents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDependents.Location = new System.Drawing.Point(24, 256);
            this.dataGridViewDependents.Name = "dataGridViewDependents";
            this.dataGridViewDependents.Size = new System.Drawing.Size(625, 113);
            this.dataGridViewDependents.TabIndex = 104;
            this.dataGridViewDependents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDependents_CellClick);
            this.dataGridViewDependents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDependents_CellContentClick);
            this.dataGridViewDependents.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDependents_CellMouseUp);
            this.dataGridViewDependents.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewDependents_RowPostPaint);
            // 
            // txtOpinion
            // 
            this.txtOpinion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpinion.Location = new System.Drawing.Point(23, 494);
            this.txtOpinion.MaxLength = 12;
            this.txtOpinion.Multiline = true;
            this.txtOpinion.Name = "txtOpinion";
            this.txtOpinion.Size = new System.Drawing.Size(468, 99);
            this.txtOpinion.TabIndex = 103;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(20, 472);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(396, 15);
            this.label38.TabIndex = 102;
            this.label38.Text = "In your personal opinion, what does it take for a person to go to heaven?";
            // 
            // txtChurchName
            // 
            this.txtChurchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChurchName.Location = new System.Drawing.Point(277, 418);
            this.txtChurchName.MaxLength = 12;
            this.txtChurchName.Name = "txtChurchName";
            this.txtChurchName.Size = new System.Drawing.Size(214, 21);
            this.txtChurchName.TabIndex = 101;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(277, 400);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(152, 15);
            this.label39.TabIndex = 100;
            this.label39.Text = "If so, where do you attend?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 15);
            this.label3.TabIndex = 94;
            this.label3.Text = "MI";
            // 
            // txtMiddleInitial
            // 
            this.txtMiddleInitial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMiddleInitial.Location = new System.Drawing.Point(199, 47);
            this.txtMiddleInitial.Name = "txtMiddleInitial";
            this.txtMiddleInitial.Size = new System.Drawing.Size(36, 21);
            this.txtMiddleInitial.TabIndex = 93;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(314, 21);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(21, 25);
            this.label24.TabIndex = 92;
            this.label24.Text = "*";
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLastName.Location = new System.Drawing.Point(253, 47);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(152, 21);
            this.txtLastName.TabIndex = 91;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(250, 30);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(67, 15);
            this.label30.TabIndex = 90;
            this.label30.Text = "Last Name";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(20, 184);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(96, 15);
            this.label32.TabIndex = 86;
            this.label32.Text = "Contact Number";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Red;
            this.label33.Location = new System.Drawing.Point(491, 22);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(21, 25);
            this.label33.TabIndex = 84;
            this.label33.Text = "*";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Red;
            this.label34.Location = new System.Drawing.Point(82, 21);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(21, 25);
            this.label34.TabIndex = 83;
            this.label34.Text = "*";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 80);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(86, 15);
            this.lblAddress.TabIndex = 82;
            this.lblAddress.Text = "Street Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(23, 99);
            this.txtAddress.MaxLength = 150;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(326, 21);
            this.txtAddress.TabIndex = 81;
            // 
            // dtDateOfBirth
            // 
            this.dtDateOfBirth.AllowDrop = true;
            this.dtDateOfBirth.CustomFormat = "MM/dd/yyyy";
            this.dtDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfBirth.Location = new System.Drawing.Point(425, 47);
            this.dtDateOfBirth.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.dtDateOfBirth.Name = "dtDateOfBirth";
            this.dtDateOfBirth.Size = new System.Drawing.Size(103, 21);
            this.dtDateOfBirth.TabIndex = 80;
            this.dtDateOfBirth.Value = new System.DateTime(2012, 12, 25, 0, 0, 0, 0);
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Location = new System.Drawing.Point(23, 47);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(152, 21);
            this.txtFirstName.TabIndex = 79;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(422, 29);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(74, 15);
            this.lblDateOfBirth.TabIndex = 78;
            this.lblDateOfBirth.Text = "Date of Birth";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(20, 26);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(67, 15);
            this.label37.TabIndex = 77;
            this.label37.Text = "First Name";
            // 
            // tabSearchManage
            // 
            this.tabSearchManage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabSearchManage.Controls.Add(this.dataGridViewItems);
            this.tabSearchManage.Location = new System.Drawing.Point(4, 24);
            this.tabSearchManage.Name = "tabSearchManage";
            this.tabSearchManage.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearchManage.Size = new System.Drawing.Size(779, 630);
            this.tabSearchManage.TabIndex = 1;
            this.tabSearchManage.Text = "Items";
            // 
            // dataGridViewItems
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItems.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewItems.Location = new System.Drawing.Point(18, 51);
            this.dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItems.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewItems.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dataGridViewItems.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItems.Size = new System.Drawing.Size(735, 329);
            this.dataGridViewItems.TabIndex = 3;
            this.dataGridViewItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItems_CellClick);
            this.dataGridViewItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItems_CellContentClick);
            this.dataGridViewItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewItems_CellFormatting);
            this.dataGridViewItems.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewItems_CellMouseUp);
            this.dataGridViewItems.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewItems_RowPostPaint);
            // 
            // PrintReport
            // 
            this.PrintReport.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(40, 676);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 27);
            this.btnUpdate.TabIndex = 96;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(149, 676);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 27);
            this.btnClose.TabIndex = 97;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Enabled = false;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 26);
            this.contextMenuStrip1.Text = "Context Menu";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem1.Text = "Delete Row";
            this.toolStripMenuItem1.Visible = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Enabled = false;
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(134, 26);
            this.contextMenuStrip2.Text = "Context Menu";
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem2.Text = "Delete Row";
            this.toolStripMenuItem2.Visible = false;
            // 
            // dependentsBindingSource
            // 
            this.dependentsBindingSource.DataMember = "Dependents";
            this.dependentsBindingSource.DataSource = this.smallBlessingsDataSet;
            // 
            // smallBlessingsDataSet
            // 
            this.smallBlessingsDataSet.DataSetName = "SmallBlessingsDataSet";
            this.smallBlessingsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dependentsTableAdapter
            // 
            this.dependentsTableAdapter.ClearBeforeFill = true;
            // 
            // Person
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(811, 715);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.btnUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Person";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Small Blessing Information Sheet";
            this.Load += new System.EventHandler(this.Manage_Load);
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDependents)).EndInit();
            this.tabSearchManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dependentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallBlessingsDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabSearchManage;
        //private System.Windows.Forms.DataGridView dataGridViewDependents;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Drawing.Printing.PrintDocument PrintReport;
        private SmallBlessingsDataSet smallBlessingsDataSet;
        private System.Windows.Forms.BindingSource dependentsBindingSource;
        private SmallBlessingsDataSetTableAdapters.DependentsTableAdapter dependentsTableAdapter;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewDependents;
        private System.Windows.Forms.TextBox txtOpinion;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtChurchName;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMiddleInitial;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.DateTimePicker dtDateOfBirth;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoLeaveMessage2;
        private System.Windows.Forms.RadioButton rdoLeaveMessage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoChurchHome2;
        private System.Windows.Forms.RadioButton rdoChurchHome1;
        private System.Windows.Forms.MaskedTextBox txtContactNumber;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoGuardian2;
        private System.Windows.Forms.RadioButton rdoGuardian1;
    }
}