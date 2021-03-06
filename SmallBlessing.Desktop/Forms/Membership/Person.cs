﻿// -----------------------------------------------------------------------
// <copyright file="Manage.cs" company="John">
//  Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;

namespace SmallBlessing.Desktop.Forms.Membership
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    using SmallBlessing.Data.BusinessService;
    using SmallBlessing.Data.DataModel;
    using SmallBlessing.Data.Enum;
    using SmallBlessing.Desktop.Properties;

    /// <summary>
    /// Manage screen - To view, search, print, export club members information
    /// </summary>
    public partial class Person : Form
    {

        //DateTimePicker _datePicker = new DateTimePicker();
        DataGridView _dataGrid = new DataGridView();
        private int rowIndex = 0;
        /// <summary>
        /// Instance of DataGridViewPrinter
        /// </summary>
        private DataGridViewPrinter dataGridViewPrinter;

        /// <summary>
        /// Interface of ClubMemberService
        /// </summary>
        private IClubMemberService clubMemberService;

        /// <summary>
        /// Variable to store error message
        /// </summary>
        private string errorMessage;

        /// <summary>
        /// Member id
        /// </summary>
        private int memberId;

        private DateTime lockItemDate;

        private bool lockItemFlag;

        Manage _manage;



        /// <summary>
        /// Initializes a new instance of the Manage class
        /// </summary>
        public Person(int _memberId, Manage mainForm)
        {
            _manage = mainForm;
            memberId = _memberId;
            this.InitializeComponent();
            this.InitializeResourceString();
            this.InitializeDropDownList();
            this.InitilizeDataGridViewStyle();
            this.clubMemberService = new ClubMemberService();
            this.ResetRegistration();
            this.ResetSearch();


            PersonModel personObject = new PersonModel();
            try
            {
                DataRow dataRow = this.clubMemberService.GetFullClubMemberById(memberId);
                personObject.FirstName = dataRow["FirstName"].ToString();
                personObject.MiddleIntial = dataRow["MI"].ToString();
                personObject.LastName = dataRow["LastName"].ToString();
                personObject.Address = dataRow["Address"].ToString();
                personObject.City = dataRow["City"].ToString();
                personObject.State = dataRow["State"].ToString();
                personObject.Zip = dataRow["Zip"].ToString();
                personObject.PhoneNumber = dataRow["Phone"].ToString();
                personObject.LeaveMessage = Convert.ToBoolean(dataRow["PhoneContactFlag"].ToString());
                personObject.ChurchName = dataRow["ChurchHomeName"].ToString();
                personObject.DateOfBirth = Convert.ToDateTime(dataRow["BirthDate"]);
                personObject.Opinion = dataRow["Opinion"].ToString();
                personObject.ChurchHome = Convert.ToBoolean(dataRow["ChurchHomeFlag"].ToString());
                personObject.ChurchName = dataRow["ChurchHomeName"].ToString();
                personObject.PersonID = Convert.ToInt32(dataRow["PersonID"].ToString());
                personObject.DateUpdated = Convert.ToDateTime(dataRow["DateUpdated"]);
                personObject.ProofGuardianFlag = Convert.ToBoolean(dataRow["ProofGuardianFlag"].ToString());
                //personObject.LockItemsDate = dataRow["LockItemDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataRow["LockItemDate"]);
                personObject.LockItemsDate = dataRow["MaxDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataRow["MaxDate"]);
                personObject.LockItemsFlag = Convert.ToBoolean(dataRow["LockItemFlag"].ToString());
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }

            memberId = personObject.PersonID;
            txtFirstName.Text = personObject.FirstName.ToString();
            txtLastName.Text = personObject.LastName.ToString();
            txtMiddleInitial.Text = personObject.MiddleIntial.ToString();
            dtDateOfBirth.Value = Convert.ToDateTime(personObject.DateOfBirth.ToShortDateString());
            txtContactNumber.Text = personObject.PhoneNumber.ToString();
            txtAddress.Text = personObject.Address.ToString();
            txtCity.Text = personObject.City.ToString();
            txtState.Text = personObject.State.ToString();
            txtZip.Text = personObject.Zip.ToString();

            //grab first and last day of previous month
            DateTime today = DateTime.Now;

            int prevMonth = today.AddMonths(-1).Month;
            int year = today.AddMonths(-1).Year;
            int daysInPrevMonth = DateTime.DaysInMonth(year, prevMonth);
            DateTime firstDayPrevMonth = new DateTime(year, prevMonth, 1);
            DateTime lastDayPrevMonth = new DateTime(year, prevMonth, daysInPrevMonth);


            //is maxdate month in today month
            if (personObject.LockItemsDate.HasValue)
            {
                lockItemDate = Convert.ToDateTime(personObject.LockItemsDate.ToString());

                if ((lockItemDate.Month == DateTime.Now.Month) &&
                    (lockItemDate.Year == DateTime.Now.Year))
                {
                    //  Console.WriteLine("{0} {1}", firstDayPrevMonth.ToShortDateString(),
                    //lastDayPrevMonth.ToShortDateString());
                    lockItemFlag = true;
                }

                //var numVisits = this.clubMemberService.GetClubMemberVisits(memberId, lockItemDate.ToShortDateString());
                var numVisits = this.clubMemberService.GetClubMemberVisits(memberId);

                if (numVisits >= 6)
                {
                    lockItemFlag = true;
                }
            }

            //lockItemFlag = personObject.LockItemsFlag;
            //if (!string.IsNullOrEmpty(personObject.LockItemsDate.ToString()))
            //{
            //    lockItemDate = Convert.ToDateTime(personObject.LockItemsDate.ToString());

            //    //var numVisits = this.clubMemberService.GetClubMemberVisits(memberId, lockItemDate.ToShortDateString());
            //    if (numVisits >= 6)
            //    {
            //        lockItemFlag = true;
            //    }

            //    if (!lockItemFlag)
            //    {
            //        var numVisitsInMonth = this.clubMemberService.GetClubMemberVisitsInMonth(memberId, lockItemDate.ToShortDateString());
            //        if (numVisitsInMonth > 0)
            //        {
            //            lockItemFlag = true;
            //        }
            //        else { lockItemFlag = false; }
            //    }

            //    if (numVisits == 0)
            //        lockItemDate = DateTime.Today;



            //    lblNumVisits.Text = numVisits.ToString();
            //}
            //else
            //{
            //    lblNumVisits.Text = "0";
            //}

            rdoChurchHome2.Checked = true;
            if (personObject.ChurchHome)
            {
                rdoChurchHome1.Checked = true;
                rdoChurchHome2.Checked = false;
            }
            txtChurchName.Text = personObject.ChurchName.ToString();
            txtOpinion.Text = personObject.Opinion.ToString() == null ? string.Empty : personObject.Opinion.ToString();
            txtContactNumber.Text = personObject.PhoneNumber.ToString();

            rdoLeaveMessage2.Checked = true;
            if (personObject.LeaveMessage)
            {
                rdoLeaveMessage1.Checked = true;
                rdoLeaveMessage2.Checked = false;
            }

            rdoGuardian2.Checked = true;
            if (personObject.ProofGuardianFlag)
            {
                rdoGuardian1.Checked = true;
                rdoGuardian2.Checked = false;
            }

            DataTable data = this.clubMemberService.GetDependents(memberId);
            this.InitializeUpdate();
            this.LoadDataGridView(data);

            //lblLastVisit.Text = personObject.DateUpdated.ToString();

            //_datePicker.Visible = false;
            //_datePicker.CustomFormat = "dd/MM/yyyy";
            //_datePicker.ValueChanged += _datePicker_ValueChanged;

            //update lockItemFlag
            //if (lockItemFlag)
            //{
            //personObject.LockItemsFlag = lockItemFlag;
            //update flag on database
            this.clubMemberService.UpdateClubMemberLockItemFlag(personObject);
            //}
            //groupBox3.Hide();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.btnClose_Click);
        }

        /// <summary>
        /// Initializes resource strings
        /// </summary>
        private void InitializeResourceString()
        {
            // Registeration
            lblDateOfBirth.Text = Resources.Registration_DateOfBirth_Label_Text;
        }

        private void dataGridViewItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            //if (e.ColumnIndex == 4)
            //{
            //    //Initialized a new DateTimePicker Control  
            //    _datePicker = new DateTimePicker();

            //    //Adding DateTimePicker control into DataGridView   
            //    dataGridViewItems.Controls.Add(_datePicker);

            //    // Setting the format (i.e. 2014-10-10)  
            //    _datePicker.Format = DateTimePickerFormat.Short;

            //    // It returns the retangular area that represents the Display area for a cell  
            //    Rectangle oRectangle = dataGridViewItems.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            //    //Setting area for DateTimePicker Control  
            //    _datePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

            //    // Setting Location  
            //    _datePicker.Location = new Point(oRectangle.X, oRectangle.Y);

            //    // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            //    _datePicker.CloseUp += new EventHandler(_datePicker_CloseUp);

            //    // An event attached to dateTimePicker Control which is fired when any date is selected  
            //    _datePicker.TextChanged += new EventHandler(dateTimePickerItems_OnTextChange);

            //    // Now make it visible  
            //    _datePicker.Visible = true;
            //}
        }


        private void dataGridViewDependents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            //if (e.ColumnIndex == 2)
            //{
            //    //Initialized a new DateTimePicker Control  
            //    _datePicker = new DateTimePicker();

            //    //Adding DateTimePicker control into DataGridView   
            //    dataGridViewDependents.Controls.Add(_datePicker);

            //    // Setting the format (i.e. 2014-10-10)  
            //    _datePicker.Format = DateTimePickerFormat.Short;

            //    // It returns the retangular area that represents the Display area for a cell  
            //    Rectangle oRectangle = dataGridViewDependents.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            //    //Setting area for DateTimePicker Control  
            //    _datePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

            //    // Setting Location  
            //    _datePicker.Location = new Point(oRectangle.X, oRectangle.Y);

            //    // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            //    _datePicker.CloseUp += new EventHandler(_datePicker_CloseUp);

            //    // An event attached to dateTimePicker Control which is fired when any date is selected  
            //    _datePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

            //    // Now make it visible  
            //    _datePicker.Visible = true;
            //}
        }

        //void _datePicker_ValueChanged(object sender, EventArgs e)
        //{
        //    _dataGrid.CurrentCell.Value = _datePicker.Value.ToString("dd/MM/yyyy");
        //    _datePicker.Visible = false;
        //}

        //private void dateTimePickerItems_OnTextChange(object sender, EventArgs e)
        //{
        //    // Saving the 'Selected Date on Calendar' into DataGridView current cell  
        //    dataGridViewItems.CurrentCell.Value = _datePicker.Text.ToString();
        //}

        //private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        //{
        //    // Saving the 'Selected Date on Calendar' into DataGridView current cell  
        //    dataGridViewDependents.CurrentCell.Value = _datePicker.Text.ToString();
        //}

        //void _datePicker_CloseUp(object sender, EventArgs e)
        //{
        //    // Hiding the control after use   
        //    _datePicker.Visible = false;
        //}


        /// <summary>
        /// Initializes all dropdown controls
        /// </summary>
        private void InitializeDropDownList()
        {


            //cmbSearchOccupation.DataSource = Enum.GetValues(typeof(Occupation));
            //cmbSearchMaritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));
            //cmbOperand.SelectedIndex = 0;
        }

        /// <summary>
        /// Resets search criteria
        /// </summary>
        private void ResetSearch()
        {
            //cmbSearchMaritalStatus.SelectedIndex = -1;
            //cmbSearchOccupation.SelectedIndex = -1;
            //cmbOperand.SelectedIndex = 0;
        }

        /// <summary>
        /// Resets the registration screen
        /// </summary>
        private void ResetRegistration()
        {
            txtFirstName.Text = string.Empty;
            txtMiddleInitial.Text = string.Empty;
            txtLastName.Text = string.Empty;
            //txtSalary.Text = string.Empty;

        }

        /// <summary>
        /// Initializes all dropdown controls in update section
        /// </summary>
        private void InitializeUpdate()
        {
            //this.date
            //cmb2Occupation.DataSource = Enum.GetValues(typeof(Occupation));
            //cmb2MaritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));
            //cmb2HealthStatus.DataSource = Enum.GetValues(typeof(HealthStatus));
        }

        /// <summary>
        /// Resets the update section of manage screen
        /// </summary>
        private void ResetUpdate()
        {
            //txt2Name.Text = string.Empty;
            //txt2Salary.Text = string.Empty;
            //txt2NoOfChildren.Text = string.Empty;
            //cmb2Occupation.SelectedIndex = -1;
            //cmb2HealthStatus.SelectedIndex = -1;
            //cmb2MaritalStatus.SelectedIndex = -1;
        }

        /// <summary>
        /// Validates registration input
        /// </summary>
        /// <returns>true or false</returns>
        private bool ValidateRegistration()
        {
            this.errorMessage = string.Empty;

            if (txtFirstName.Text.Trim() == string.Empty)
            {
                this.AddErrorMessage(Resources.Registration_FirstName_Required_Text);
            }



            return this.errorMessage != string.Empty ? false : true;
        }

        /// <summary>
        /// Validates update data
        /// </summary>
        /// <returns>true or false</returns>
        private bool ValidateUpdate()
        {
            this.errorMessage = string.Empty;

            //if (txt2Name.Text.Trim() == string.Empty)
            //{
            //    this.AddErrorMessage(Resources.Registration_Name_Required_Text);
            //}

            //if (cmb2Occupation.SelectedIndex == -1)
            //{
            //    this.AddErrorMessage(Resources.Registration_Occupation_Select_Text);
            //}

            //if (cmb2MaritalStatus.SelectedIndex == -1)
            //{
            //    this.AddErrorMessage(Resources.Registration_MaritalStatus_Select_Text);
            //}

            //if (cmb2HealthStatus.SelectedIndex == -1)
            //{
            //    this.AddErrorMessage(Resources.Registration_HealthStatus_Select_Text);
            //}

            return this.errorMessage != string.Empty ? false : true;
        }

        /// <summary>
        /// To generate the error message
        /// </summary>
        /// <param name="error">error message</param>
        private void AddErrorMessage(string error)
        {
            if (this.errorMessage == string.Empty)
            {
                this.errorMessage = Resources.Error_Message_Header + "\n\n";
            }

            this.errorMessage += error + "\n";
        }

        /// <summary>
        /// Method to show general error message on any system level exception
        /// </summary>
        private void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                //Resources.System_Error_Message, 
                Resources.System_Error_Message_Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Initializes data grid view style
        /// </summary>
        private void InitilizeDataGridViewStyle()
        {
            // Setting the style of the DataGridView control
            //dataGridViewItems.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            //dataGridViewItems.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            //dataGridViewItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //dataGridViewItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridViewItems.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            //dataGridViewItems.DefaultCellStyle.BackColor = Color.Empty;
            //dataGridViewItems.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            //dataGridViewItems.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //dataGridViewItems.GridColor = SystemColors.ControlDarkDark;

        }

        private void LoadDataGridItemView(DataTable data)
        {

            //dataGridViewItems.AllowUserToResizeRows = false;

            //DataGridViewRow row = this.dataGridViewItems.RowTemplate;
            //row.DefaultCellStyle.BackColor = Color.Bisque;
            //row.Height = 35;
            //row.MinimumHeight = 20;


            dataGridViewItems.DataSource = data;
            dataGridViewItems.DataMember = data.TableName;
            dataGridViewItems.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //dataGridView1.DataSource = data;
            //dataGridView1.DataMember = data.TableName;

            dataGridViewItems.Columns[1].Width = 400;
            dataGridViewItems.Columns[2].Width = 400;
            dataGridViewItems.Columns[3].Width = 70;
            dataGridViewItems.Columns[4].Width = 70;
            this.dataGridViewItems.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dataGridViewItems.Columns[1].Width = 200;
            //dataGridViewItems.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //dataGridViewItems.Columns[4].Width = 420;

            //this.dataGridViewItems.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridViewItems.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridViewItems.Rows.Add("test" + Environment.NewLine + "test"); // Environment.NewLine = "\r\n" in Windows

            //dataGridViewItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //dataGridViewItems.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            this.dataGridViewItems.Columns["ItemId"].Visible = false;
            //this.dataGridView1.Columns["ItemId"].Visible = false;

            //DataGridViewColumn column = dataGridViewItems.Columns[4];
            //column.Width = 500;
            //dataGridViewItems.Columns[4].Width = 200;
            //this.dataGridView1.Columns[1].Width = 200;
            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            //this.dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        }


        /// <summary>
        /// Method to load data grid view
        /// </summary>
        /// <param name="data">data table</param>
        private void LoadDataGridView(DataTable data)
        {
            // Data grid view column setting            
            //dataGridViewMembers.DataSource = data;
            //dataGridViewMembers.DataMember = data.TableName;
            //dataGridViewMembers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dataGridViewDependents.DataSource = data;
            dataGridViewDependents.DataMember = data.TableName;
            dataGridViewDependents.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            this.dataGridViewDependents.Columns["DependentID"].Visible = false;
            //.HeaderText = "Birthdate (MM/DD/YYYY)";
        }

        /// <summary>
        /// Method to set up the printing
        /// </summary>
        /// <param name="isPrint">isPrint value</param>
        /// <returns>true or false</returns>
        private bool SetupPrinting(bool isPrint)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.AllowCurrentPage = false;
            printDialog.AllowPrintToFile = false;
            printDialog.AllowSelection = false;
            printDialog.AllowSomePages = false;
            printDialog.PrintToFile = false;
            printDialog.ShowHelp = false;
            printDialog.ShowNetwork = false;

            if (isPrint)
            {
                if (printDialog.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
            }

            this.PrintReport.DocumentName = "MembersReport";
            this.PrintReport.PrinterSettings = printDialog.PrinterSettings;
            this.PrintReport.DefaultPageSettings = printDialog.PrinterSettings.DefaultPageSettings;
            this.PrintReport.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            this.dataGridViewPrinter = new DataGridViewPrinter(dataGridViewItems, PrintReport, true, true, Resources.Report_Header, new Font("Tahoma", 13, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            return true;
        }



        /// <summary>
        /// Key press Event to accept only numeric value
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">key press event data</param>
        private void Salary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Key press Event to accept only numeric value
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">event data</param>
        private void Children_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Event to handle tab selection
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tab.SelectedIndex == 1)
                {
                    DataTable data = this.clubMemberService.GetClubMemberItemsById(this.memberId);
                    //this.InitializeUpdate();                    
                    this.LoadDataGridItemView(data);

                    //check if 6 visits in the current year or previous month////
                    var numVisits = this.clubMemberService.GetClubMemberVisits(memberId);
                    //lblNumVisits.Text = numVisits.ToString();
                    if (lockItemFlag)
                    {
                        //this.dataGridViewItems.AllowUserToAddRows = false;
                        //this.dataGridViewItems.AllowUserToDeleteRows = false;                        
                        //this.dataGridViewItems.ReadOnly = true;

                        MessageBox.Show(
                        "User has already been here in the past month or surpassed # of visits within an alloted year.",
                        Resources.System_Error_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    //DataGridViewColumn column = dataGridViewItems.Columns[3];
                    //column.Width = 30;
                    //DataGridViewColumn column = dataGridViewItems.Columns[3];
                    //column.Width = 70;
                    //this.dataGridViewItems.Columns["LockItemsDate"].Visible = false;

                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Event to handle the data formatting in data grid view
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    e.Value = string.Format("{0:dd/MM/yyyy}", (DateTime)e.Value);
                }

                if (e.ColumnIndex == 3)
                {
                    e.Value = Enum.GetName(typeof(Occupation), e.Value).ToString();
                }

                if (e.ColumnIndex == 4)
                {
                    e.Value = Enum.GetName(typeof(MaritalStatus), e.Value).ToString();
                }

                if (e.ColumnIndex == 5)
                {
                    e.Value = Enum.GetName(typeof(HealthStatus), e.Value).ToString();
                }

                if (e.ColumnIndex == 6)
                {
                    e.Value = Convert.ToDecimal(e.Value) == 0 ? string.Empty : e.Value;
                }

                if (e.ColumnIndex == 7)
                {
                    e.Value = Convert.ToInt16(e.Value) == 0 ? string.Empty : e.Value;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }


        private void DataGridViewItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex == 2)
                //{
                //    e.Value = string.Format("{0:dd/MM/yyyy}", (DateTime)e.Value);
                //}

                //if (e.ColumnIndex == 3)
                //{
                //    e.Value = Enum.GetName(typeof(Occupation), e.Value).ToString();
                //}

                //if (e.ColumnIndex == 4)
                //{
                //    e.Value = Enum.GetName(typeof(MaritalStatus), e.Value).ToString();
                //}

                //if (e.ColumnIndex == 5)
                //{
                //    e.Value = Enum.GetName(typeof(HealthStatus), e.Value).ToString();
                //}

                //if (e.ColumnIndex == 6)
                //{
                //    e.Value = Convert.ToDecimal(e.Value) == 0 ? string.Empty : e.Value;
                //}

                //if (e.ColumnIndex == 7)
                //{
                //    e.Value = Convert.ToInt16(e.Value) == 0 ? string.Empty : e.Value;
                //}
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }
        /// <summary>
        /// Click event to handle the refresh
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">event data</param>
        private void Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.ResetSearch();
                DataTable data = this.clubMemberService.GetAllClubMembers();
                this.LoadDataGridView(data);
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Click event to handle print preview
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void PrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SetupPrinting(false))
                {
                    PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                    printPreviewDialog.Document = this.PrintReport;
                    printPreviewDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Click event to handle print
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SetupPrinting(true))
                {
                    this.PrintReport.Print();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Event to handle print page
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                bool hasMorePages = this.dataGridViewPrinter.DrawDataGridView(e.Graphics);

                if (hasMorePages == true)
                {
                    e.HasMorePages = true;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Click event to handle the export to excel
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">event data</param>


        private void dataGridViewMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = dataGridViewItems.SelectedCells[0].RowIndex;
            //MessageBox.Show("cell content click");
            try
            {
                string clubMemberId = dataGridViewItems[0, currentRow].Value.ToString();
                memberId = int.Parse(clubMemberId);
            }
            catch (Exception ex)
            {

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Hide();
            _manage.PerformRefresh();
            this.Hide();
        }


        /// <summary>
        /// Click event to update the data
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateUpdate())
                {
                    List<DependentModel> depList = new List<DependentModel>();
                    //loop through all dependents datagrid view
                    foreach (DataGridViewRow row in dataGridViewDependents.Rows)
                    {
                        if (row.IsNewRow) continue;
                        DependentModel dependentModel = new DependentModel()
                        {
                            NameOfChild = row.Cells["Name of Child"].Value.ToString(),
                            BirthDate = Convert.ToDateTime(row.Cells["BirthDate"].Value.ToString()),
                            //BirthDate = Convert.ToDateTime(_datePicker.Value.ToShortDateString()),
                            ChildLivesWith = row.Cells["LivesWith"].Value.ToString(),
                            Relationship = row.Cells["Relationship"].Value.ToString(),
                            PersonID = this.memberId//,
                            //DependentID = Convert.ToInt32(row.Cells["DependentID"].Value.ToString())
                        };
                        depList.Add(dependentModel);
                    }
                    //if 
                    //var lockDate = Convert.ToDateTime(row.Cells["LockItemsDate"].Value.ToString());


                    List<ItemModel> itemList = new List<ItemModel>();
                    //loop through all dependents datagrid view
                    foreach (DataGridViewRow row in dataGridViewItems.Rows)
                    {
                        if (row.IsNewRow) continue;

                        //DateTime lockDate = Convert.ToDateTime(_datePicker.Value.ToShortDateString());
                        //if (!(string.IsNullOrEmpty(row.Cells["LockItemsDate"].Value.ToString())))
                        //lockDate = Convert.ToDateTime(row.Cells["LockItemsDate"].Value.ToString());

                        ItemModel itemModel = new ItemModel()
                        {
                            Description = row.Cells["Description"].Value.ToString(),
                            //Date = Convert.ToDateTime(row.Cells["Date"].Value.ToString()),
                            Date = Convert.ToDateTime(row.Cells["Date"].Value.ToString()),
                            //Date = Convert.ToDateTime(_datePicker.Value.ToShortDateString()),
                            Comments = row.Cells["Comments"].Value.ToString(),
                            Initials = row.Cells["Initials"].Value.ToString(),
                            PersonID = this.memberId
                        };
                        itemList.Add(itemModel);
                    }

                    string phone = string.Empty;
                    if (!(txtContactNumber.Text == "(   )    -"))
                        phone = txtContactNumber.Text;

                    //DateTime? start = (txtStartDate.Text == DateTime.MinValue.ToString()) ? null : (DateTime?)txtStartDate.Text;
                    //DBNull.Value
                    // <Nullable>DateTime start = lockItemDate == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(lockItemDate);

                    //DateTime? start = lockItemDate ?? (DateTime?)DBNull.Value;                   
                    DataRow dataRow = this.clubMemberService.GetFullClubMemberById(memberId);
                    //Person personObject = new Person();
                    DateTime? dt = dataRow["LockItemDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataRow["LockItemDate"]);
                    //personObject.LockItemsFlag = Convert.ToBoolean(dataRow["LockItemFlag"].ToString());

                    if ((!dt.HasValue) && (itemList.Count > 0))
                        dt = DateTime.Today;

                    //if (dt.HasValue)
                    //{
                    //    var date = Convert.ToDateTime(dataRow["LockItemDate"]);
                    //    //if it has been more than a year reset date
                    //    //bool resetLockDate = this.clubMemberService.GetClubMemberLockDate(dt, memberId);
                    //    var matchFound = (date - DateTime.Now).TotalDays > 365;
                    //    dt = DateTime.Today;
                    //}
                    //if (!dt.HasValue)

                    PersonModel clubMemberModel = new PersonModel()
                    {
                        PersonID = this.memberId,
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        MiddleIntial = txtMiddleInitial.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        PhoneNumber = phone.Trim(),
                        DateOfBirth = dtDateOfBirth.Value,
                        ChurchHome = bool.Parse(rdoChurchHome1.Checked.ToString()),
                        ChurchName = txtChurchName.Text.Trim(),
                        Opinion = txtOpinion.Text.Trim(),
                        LeaveMessage = bool.Parse(rdoLeaveMessage1.Checked.ToString()),
                        City = txtCity.Text.Trim(),
                        State = txtState.Text.Trim(),
                        Zip = txtZip.Text.Trim(),
                        DateUpdated = DateTime.Now,
                        ProofGuardianFlag = bool.Parse(rdoGuardian1.Checked.ToString()),
                        LockItemsDate = dt,//lockItemDate,
                        LockItemsFlag = lockItemFlag,
                        DependentModelList = depList,
                        ItemModelList = itemList
                    };

                    var flag = this.clubMemberService.UpdateClubMember(clubMemberModel);

                    if (flag)
                    {
                        MessageBox.Show(
                            Resources.Update_Successful_Message,
                            Resources.Update_Successful_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        _manage.PerformRefresh();
                    }
                }
                else
                {
                    MessageBox.Show(
                        this.errorMessage,
                        Resources.Registration_Error_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var flag = this.clubMemberService.DeleteClubMember(this.memberId);

                if (flag)
                {
                    DataTable data = this.clubMemberService.GetAllClubMembers();
                    this.LoadDataGridView(data);

                    MessageBox.Show(
                        Resources.Delete_Successful_Message,
                        Resources.Delete_Successful_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void dataGridViewMembers_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    string clubMemberId = dgv.SelectedRows[0].Cells[0].Value.ToString();
                    memberId = int.Parse(clubMemberId);

                    DataRow dataRow = this.clubMemberService.GetClubMemberById(memberId);

                    //txt2Name.Text = dataRow["Name"].ToString();
                    //dt2DateOfBirth.Value = Convert.ToDateTime(dataRow["DateOfBirth"]);
                    //cmb2Occupation.SelectedItem = (Occupation)dataRow["Occupation"];
                    //cmb2MaritalStatus.SelectedItem = (MaritalStatus)dataRow["MaritalStatus"];
                    //cmb2HealthStatus.SelectedItem = (HealthStatus)dataRow["HealthStatus"];
                    //txt2Salary.Text = dataRow["Salary"].ToString() == "0.0000" ? string.Empty : dataRow["Salary"].ToString();
                    //txt2NoOfChildren.Text = dataRow["NumberOfChildren"].ToString();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void dataGridViewItems_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            try
            {
                //if (dgv.SelectedRows.Count > 0)
                //{
                //    string clubMemberId = dgv.SelectedRows[0].Cells[0].Value.ToString();
                //    memberId = int.Parse(clubMemberId);

                //    DataRow dataRow = this.clubMemberService.GetClubMemberById(memberId);

                //    //txt2Name.Text = dataRow["Name"].ToString();
                //    //dt2DateOfBirth.Value = Convert.ToDateTime(dataRow["DateOfBirth"]);
                //    //cmb2Occupation.SelectedItem = (Occupation)dataRow["Occupation"];
                //    //cmb2MaritalStatus.SelectedItem = (MaritalStatus)dataRow["MaritalStatus"];
                //    //cmb2HealthStatus.SelectedItem = (HealthStatus)dataRow["HealthStatus"];
                //    //txt2Salary.Text = dataRow["Salary"].ToString() == "0.0000" ? string.Empty : dataRow["Salary"].ToString();
                //    //txt2NoOfChildren.Text = dataRow["NumberOfChildren"].ToString();
                //}
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Manage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'smallBlessingsDataSet.Dependents' table. You can move, or remove it, as needed.
            this.dependentsTableAdapter.Fill(this.smallBlessingsDataSet.Dependents);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewMembers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridViewDependents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            //if (e.ColumnIndex == 1)
            //{
            //    if (_datePicker.Text == "")
            //    {
            //        //Initialized a new DateTimePicker Control  
            //        _datePicker = new DateTimePicker();
            //    }
            //    //Adding DateTimePicker control into DataGridView   
            //    dataGridViewDependents.Controls.Add(_datePicker);

            //    // Setting the format (i.e. 2014-10-10)  
            //    _datePicker.Format = DateTimePickerFormat.Short;

            //    // It returns the retangular area that represents the Display area for a cell  
            //    Rectangle oRectangle = dataGridViewDependents.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            //    //Setting area for DateTimePicker Control  
            //    _datePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

            //    // Setting Location  
            //    _datePicker.Location = new Point(oRectangle.X, oRectangle.Y);

            //    // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            //    _datePicker.CloseUp += new EventHandler(_datePicker_CloseUp);

            //    // An event attached to dateTimePicker Control which is fired when any date is selected  
            //    _datePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

            //    // Now make it visible  
            //    _datePicker.Visible = true;
            //}
        }

        //void _datePicker_ValueChanged(object sender, EventArgs e)
        //{
        //    _dataGrid.CurrentCell.Value = _datePicker.Value.ToString("dd-MM-yyyy");
        //    _datePicker.Visible = false;
        //}

        //private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        //{
        //    // Saving the 'Selected Date on Calendar' into DataGridView current cell  
        //    dataGridViewDependents.CurrentCell.Value = _datePicker.Text.ToString();
        //}

        //void _datePicker_CloseUp(object sender, EventArgs e)
        //{
        //    // Hiding the control after use   
        //    _datePicker.Visible = false;
        //}

        private void dataGridViewDependents_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridViewDependents.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridViewDependents.CurrentCell = this.dataGridViewDependents.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridViewDependents, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void dataGridViewItems_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridViewItems.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridViewDependents_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridViewDependents.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridViewItems_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridViewItems.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridViewItems.CurrentCell = this.dataGridViewItems.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip2.Show(this.dataGridViewItems, e.Location);
                contextMenuStrip2.Show(Cursor.Position);
            }
        }


        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dataGridViewDependents.Rows[this.rowIndex].IsNewRow)
            {
                this.dataGridViewDependents.Rows.RemoveAt(this.rowIndex);
            }
        }

        private void contextMenuStrip2_Click(object sender, EventArgs e)
        {
            if (!this.dataGridViewItems.Rows[this.rowIndex].IsNewRow)
            {
                this.dataGridViewItems.Rows.RemoveAt(this.rowIndex);
            }
        }

        private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtZip_TextChanged(object sender, EventArgs e)
        {

        }

        private void Zip_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            // Check if the pressed character was a backspace or numeric.
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        //private void btnUpdate_Click(object sender, EventArgs e)
        //{

        //}


    }
}
