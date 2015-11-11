// -----------------------------------------------------------------------
// <copyright file="Manage.cs" company="John">
//  Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using System;
//using System.Windows.Forms;
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
    using System.IO;
    /// <summary>
    /// Manage screen - To view, search, print, export club members information
    /// </summary>
    public partial class Manage : Form
    {

        DateTimePicker _datePicker = new DateTimePicker();
        DataGridView _dataGrid = new DataGridView();

        private MainMenu mnuMain = new MainMenu();
        private MenuItem mnuFile;
        private MenuItem mnuExit;
        private MenuItem mnuExport;
        private MenuItem mnuSep1;
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

        /// <summary>
        /// Initializes a new instance of the Manage class
        /// </summary>
        public Manage()
        {
            this.InitializeComponent();
            this.InitializeResourceString();
            this.InitializeDropDownList();
            this.InitilizeDataGridViewStyle();
            this.clubMemberService = new ClubMemberService();
            this.ResetRegistration();
            this.ResetSearch();

            _datePicker.Visible = false;
            _datePicker.CustomFormat = "dd/MM/yyyy";
            _datePicker.ValueChanged += _datePicker_ValueChanged;


            this.Menu = mnuMain;
            mnuFile = mnuMain.MenuItems.Add("&File");
            mnuExport = mnuFile.MenuItems.Add("&Export");
            mnuExport.Click += new System.EventHandler(mnuExport_Click);
            mnuSep1 = mnuFile.MenuItems.Add("-");
            mnuExit = mnuFile.MenuItems.Add("&Exit");
            mnuExit.Click += new System.EventHandler(mnuExit_Click);

        }



        public void PerformRefresh()
        {
            DataTable data = this.clubMemberService.GetAllClubMembers();
            this.InitializeUpdate();
            this.LoadDataGridView(data);
        }

        private void mnuExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuExport_Click(object sender, System.EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        /// <summary>
        /// Initializes resource strings
        /// </summary>
        private void InitializeResourceString()
        {
            // Registeration
            lblName.Text = Resources.Registration_FirstName_Label_Text;
            lblDateOfBirth.Text = Resources.Registration_DateOfBirth_Label_Text;

            lblSalary.Text = Resources.Registration_Salary_Label_Text;
            btnRegister.Text = Resources.Registration_Register_Button_Text;

            // Search, Print, Export, Update, Delete
            btnSearch.Text = Resources.Search_Search_Button_Text;
            btnRefresh.Text = Resources.Search_Refresh_Button_Text;
            //btnPrintPreview.Text = Resources.Print_PrintPreview_Button_Text;
            //btnPrint.Text = Resources.Print_Print_Button_Text;
            btnExport.Text = Resources.Export_Button_Text;
            btnUpdate.Text = Resources.Update_Button_Text;

        }

        /// <summary>
        /// Initializes all dropdown controls
        /// </summary>
        private void InitializeDropDownList()
        {


            //cmbSearchOccupation.DataSource = Enum.GetValues(typeof(Occupation));
            //cmbSearchMaritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));
            cmbOperand.SelectedIndex = 0;
        }

        /// <summary>
        /// Resets search criteria
        /// </summary>
        private void ResetSearch()
        {
            //cmbSearchMaritalStatus.SelectedIndex = -1;
            //cmbSearchOccupation.SelectedIndex = -1;
            cmbOperand.SelectedIndex = 0;
        }

        /// <summary>
        /// Resets the registration screen
        /// </summary>
        private void ResetRegistration()
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes all dropdown controls in update section
        /// </summary>
        private void InitializeUpdate()
        {
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

            if (txtLastName.Text.Trim() == string.Empty)
            {
                this.AddErrorMessage(Resources.Registration_LastName_Required_Text);
            }

            if (dtDateOfBirth.Text.Trim() == string.Empty)
            {
                this.AddErrorMessage(Resources.Registration_LastName_Required_Text);
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
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dataGridViewMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMembers.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewMembers.DefaultCellStyle.BackColor = Color.Empty;
            dataGridViewMembers.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dataGridViewMembers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewMembers.GridColor = SystemColors.ControlDarkDark;

        }

        /// <summary>
        /// Method to load data grid view
        /// </summary>
        /// <param name="data">data table</param>
        private void LoadDataGridView(DataTable data)
        {

            // Data grid view column setting            
            dataGridViewMembers.DataSource = data;
            dataGridViewMembers.DataMember = data.TableName;
            dataGridViewMembers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            this.dataGridViewMembers.Columns["PersonID"].Visible = false;
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
            this.dataGridViewPrinter = new DataGridViewPrinter(dataGridViewMembers, PrintReport, true, true, Resources.Report_Header, new Font("Tahoma", 13, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            return true;
        }

        /// <summary>
        /// Click event to handle registration
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Register_Click(object sender, EventArgs e)
        {

            try
            {

                //string clubMemberId = dgv.SelectedRows[0].Cells[0].Value.ToString();
                // Check if the validation passes
                if (this.ValidateRegistration())
                {
                    List<DependentModel> depList = new List<DependentModel>();
                    //loop through all dependents datagrid view
                    foreach (DataGridViewRow row in dataGridViewDependents.Rows)
                    {
                        if (row.IsNewRow) continue;
                        DependentModel dependentModel = new DependentModel()
                        {
                            DependentID = 0,
                            NameOfChild = row.Cells["NameofChild"].Value.ToString(),
                            BirthDate = Convert.ToDateTime(_datePicker.Value.ToShortDateString()),
                            ChildLivesWith = row.Cells["LivesWith"].Value.ToString(),
                            Relationship = row.Cells["Relationship"].Value.ToString(),
                            PersonID = 0
                        };

                        //this.clubMemberService.RegisterDependent(dependentModel);

                        depList.Add(dependentModel);
                    }


                    // Assign the values to the model
                    PersonModel clubMemberModel = new PersonModel()
                    {
                        PersonID = 0,
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        MiddleIntial = txtMiddleInitial.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        PhoneNumber = txtContactNumber.Text.Trim(),
                        DateOfBirth = dtDateOfBirth.Value,
                        ChurchHome = bool.Parse(rdoChurchHome1.Checked.ToString()),
                        ChurchName = txtAttend.Text.Trim(),
                        Opinion = txtOpinion.Text.Trim(),
                        LeaveMessage = bool.Parse(rdoLeaveMessage1.Checked.ToString()),
                        City = txtCity.Text.Trim(),
                        State = txtState.Text.Trim(),
                        Zip = txtZip.Text.Trim(),
                        DependentModelList = depList
                    };

                    // Call the service method and assign the return status to variable
                    var success = this.clubMemberService.RegisterPerson(clubMemberModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {

                        //List<DependentModel> depList = new List<DependentModel>();
                        //loop through all dependents datagrid view
                        //while (success)
                        //{
                        //    foreach (DataGridViewRow row in dataGridViewDependents.Rows)
                        //    {
                        //        if (row.IsNewRow) continue;
                        //        DependentModel dependentModel = new DependentModel()
                        //        {
                        //            DependentID = 0,
                        //            NameOfChild = row.Cells["NameofChild"].Value.ToString(),
                        //            BirthDate = Convert.ToDateTime(row.Cells["Birthdate"].Value.ToString()),
                        //            ChildLivesWith = row.Cells["LivesWith"].Value.ToString(),
                        //            Relationship = row.Cells["Relationship"].Value.ToString(),
                        //            PersonID = 0
                        //        };

                        //        this.clubMemberService.RegisterDependent(dependentModel);

                        //        //depList.Add(dependentModel);
                        //    }
                        //}
                        //success = this.clubMemberService.RegisterDependent(depList);
                        //this.clubMemberService.RegisterDependent()
                        // display the message box
                        MessageBox.Show(
                            Resources.Registration_Successful_Message,
                            Resources.Registration_Successful_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Reset the screen
                        this.ResetRegistration();
                    }
                    else
                    {
                        // display the error messge
                        MessageBox.Show(
                            Resources.Registration_Error_Message,
                            Resources.Registration_Error_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Display the validation failed message
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
                    DataTable data = this.clubMemberService.GetAllClubMembers();
                    this.InitializeUpdate();
                    this.LoadDataGridView(data);

                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }


        private void dataGridViewDependents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 1)
            {
                if (_datePicker.Text == "")
                {
                    //Initialized a new DateTimePicker Control  
                    _datePicker = new DateTimePicker();
                }
                //Adding DateTimePicker control into DataGridView   
                dataGridViewDependents.Controls.Add(_datePicker);

                // Setting the format (i.e. 2014-10-10)  
                _datePicker.Format = DateTimePickerFormat.Short;

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridViewDependents.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                //Setting area for DateTimePicker Control  
                _datePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                _datePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                _datePicker.CloseUp += new EventHandler(_datePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                _datePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                _datePicker.Visible = true;
            }
        }

        void _datePicker_ValueChanged(object sender, EventArgs e)
        {
            _dataGrid.CurrentCell.Value = _datePicker.Value.ToString("dd-MM-yyyy");
            _datePicker.Visible = false;
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridViewDependents.CurrentCell.Value = _datePicker.Text.ToString();
        }

        void _datePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            _datePicker.Visible = false;
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

                if (e.ColumnIndex == 6)
                {
                    //e.Value = Enum.GetName(typeof(Occupation), e.Value).ToString();
                    //e.Value = Convert.ToInt16(e.Value) == 0 ? string.Empty : e.Value;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Click event to handle search
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = this.clubMemberService.SearchClubMembers(txtFirstNameSearch.Text.ToString(), txtLastNameSearch.Text.ToString(), cmbOperand.GetItemText(cmbOperand.SelectedItem));
                this.LoadDataGridView(data);
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
        private void Export_Click(object sender, EventArgs e)
        {
            try
            {
                var table = (DataTable)dataGridViewMembers.DataSource;
                StringBuilder sb = new StringBuilder();

                IEnumerable<string> columnNames = table.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in table.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }

                File.WriteAllText("test.csv", sb.ToString());

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void dataGridViewMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = dataGridViewMembers.SelectedCells[0].RowIndex;
            MessageBox.Show("cell content click");
            try
            {
                string clubMemberId = dataGridViewMembers[0, currentRow].Value.ToString();
                memberId = int.Parse(clubMemberId);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Click event to update the data
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;
            PersonModel p = new PersonModel();
            try
            {
                //if (dgv.SelectedRows.Count > 0)
                {
                    //string clubMemberId = dgv.SelectedRows[0].Cells[0].Value.ToString();
                    //memberId = int.Parse(clubMemberId);
                    // TODO add new method call to bring entire person object back.
                    DataRow dataRow = this.clubMemberService.GetFullClubMemberById(memberId);
                    p.FirstName = dataRow["FirstName"].ToString();
                    p.MiddleIntial = dataRow["MI"].ToString();
                    p.LastName = dataRow["LastName"].ToString();
                    p.Address = dataRow["Address"].ToString();
                    p.City = dataRow["City"].ToString();
                    p.State = dataRow["State"].ToString();
                    p.Zip = dataRow["Zip"].ToString();
                    p.PhoneNumber = dataRow["Phone"].ToString();
                    p.LeaveMessage = Convert.ToBoolean(dataRow["PhoneContactFlag"].ToString());
                    p.ChurchName = dataRow["ChurchHomeName"].ToString();
                    p.DateOfBirth = Convert.ToDateTime(dataRow["BirthDate"]);
                    p.Opinion = dataRow["Opinion"].ToString();
                    p.ChurchHome = Convert.ToBoolean(dataRow["ChurchHomeFlag"].ToString());
                    p.ChurchName = dataRow["ChurchHomeName"].ToString();
                    p.PersonID = Convert.ToInt32(dataRow["PersonID"].ToString());
                    //p.Opinion = data//.ToShortDateString();
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






            var frmPerson = new Person(p, this);
            frmPerson.Show();


            //try
            //{
            //    if (this.ValidateUpdate())
            //    {
            //        ClubMemberModel clubMemberModel = new ClubMemberModel()
            //        {
            //            Id = this.memberId,
            //            //Name = txt2Name.Text.Trim(),
            //            //DateOfBirth = dt2DateOfBirth.Value,
            //            //Occupation = (Occupation)cmb2Occupation.SelectedValue,
            //           // HealthStatus = (HealthStatus)cmb2HealthStatus.SelectedValue,
            //            //MaritalStatus = (MaritalStatus)cmb2MaritalStatus.SelectedValue,
            //            //Salary = txt2Salary.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txt2Salary.Text),
            //            //NumberOfChildren = txt2NoOfChildren.Text.Trim() == string.Empty ? 0 : Convert.ToInt16(txt2NoOfChildren.Text)
            //        };

            //        var flag = this.clubMemberService.UpdateClubMember(clubMemberModel);

            //        if (flag)
            //        {
            //            DataTable data = this.clubMemberService.GetAllClubMembers();
            //            this.LoadDataGridView(data);

            //            MessageBox.Show(
            //                Resources.Update_Successful_Message,
            //                Resources.Update_Successful_Message_Title,
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Information);                        
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(
            //            this.errorMessage,
            //            Resources.Registration_Error_Message_Title,
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
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
            //// TODO: This line of code loads data into the 'smallBlessingsDataSet1.Dependents' table. You can move, or remove it, as needed.
            //this.dependentsTableAdapter1.Fill(this.smallBlessingsDataSet1.Dependents);
            //// TODO: This line of code loads data into the 'smallBlessingsDataSet.Dependents' table. You can move, or remove it, as needed.
            //this.dependentsTableAdapter.Fill(this.smallBlessingsDataSet.Dependents);




        }

        private void dataGridViewDependents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewMembers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbOperand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dataGridViewDependents.Rows[this.rowIndex].IsNewRow)
            {
                this.dataGridViewDependents.Rows.RemoveAt(this.rowIndex);
            }
        }

        private static string GetTextFromDataTable(DataTable dataTable)
        {
            var stringBuilder = new StringBuilder();
            //stringBuilder.AppendLine(string.Join("\t\t", dataTable.Columns.Cast<DataColumn>().Select(arg => arg.ColumnName)));
            foreach (DataRow dataRow in dataTable.Rows)
                stringBuilder.AppendLine(string.Join("\t\t", dataRow.ItemArray.Select(arg => arg.ToString())));
            return stringBuilder.ToString();
        }

        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Get file name.
            string name = saveFileDialog.FileName;
            // Write to the file name selected.
            StringBuilder sb = new StringBuilder();
            try
            {
                //var table = (DataTable)dataGridViewMembers.DataSource;
                DataTable table = this.clubMemberService.GetAllClubMembers();

                //List<string> str = new List<string>();

                //foreach(var column in table.Columns)
                //{
                //    str.Add(column.ToString());
                //    //string.Format("{0,-15} | {0,-3} | {0,-15}", columns[1].ToString(), columns[2].ToString(), columns[3].ToString())
                //}

                //sb.AppendLine(string.Join("", string.Format("{0,-15} | {0,-3} | {0,-15}", str[1].ToString(), str[2].ToString(), str[3].ToString())));

                var columns = table.Columns
                   .Cast<DataColumn>()
                   .Select(x => x.ColumnName)
                   .ToList();

                foreach (DataColumn column in table.Columns)
                {
                    if (column.ToString() == "FirstName")                    
                        sb.Append(string.Format("{0,-18}",column.ToString()));
                        //sb.Append(string.Format("{0,-15}",column.ToString()));
                    else if (column.ToString() == "MI")
                        sb.Append(string.Format("{0,-6}", column.ToString()));
                    else if (column.ToString() == "LastName")
                        sb.Append(string.Format("{0,-31}", column.ToString()));
                    else if (column.ToString() == "Address")
                        sb.Append(string.Format("{0,-52}", column.ToString()));
                    else if (column.ToString() == "City")
                        sb.Append(string.Format("{0,-36}", column.ToString()));
                    else if (column.ToString() == "State")
                        sb.Append(string.Format("{0,-16}", column.ToString()));
                    else if (column.ToString() == "Zip")
                        sb.Append(string.Format("{0,-7}", column.ToString()));
                    else if (column.ToString() == "Phone")
                        sb.Append(string.Format("{0,-16}", column.ToString()));
                    else if (column.ToString() == "ChurchHomeName")
                        sb.Append(string.Format("{0,-31}", column.ToString()));
                    else if (column.ToString() == "BirthDate")
                        sb.Append(string.Format("{0,-15}", column.ToString()));

                }
                
                //string s = string.Format("{0,-15} | {1,-3} | {0,-15}", columns[1].ToString(), columns[2].ToString(), columns[3].ToString());
                //sb.AppendLine(string.Format("{0,-15} | {0,-3} | {0,-15}", columns.ElementAt(1).ToString(), columns.ElementAt(2).ToString(), columns.ElementAt(3).ToString()));

                sb.AppendLine("");

                var rows = table.Rows.Cast<DataRow>().Select(x => x.ItemArray).AsEnumerable().ToList();

                //foreach (DataRow dataRow in table.Rows)
                  //  sb.AppendLine(string.Format("{0,-15} | {0,-3} | {0,-15}", dataRow.ItemArray[1].ToString(), dataRow.ItemArray[2].ToString(), dataRow.ItemArray[3].ToString()));
                //File.WriteAllText(name, sb.ToString());
                                                                                
                foreach (DataRow row in table.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());

                    object[] itemArray = row.ItemArray;
                    string firstName = itemArray[1].ToString();
                    string middleInit = itemArray[2].ToString();
                    string lastName = itemArray[3].ToString();

                    //if (itemArray[1].ToString() == "FirstName")
                        sb.Append(string.Format("{0,-17}", itemArray[1].ToString()));
                    //else if (column.ToString() == "MI")
                        sb.Append(string.Format("|{0,-5}", itemArray[2].ToString()));
                    //else if (column.ToString() == "LastName")
                        sb.Append(string.Format("|{0,-30}", itemArray[3].ToString()));
                    //else if (column.ToString() == "Address")
                        sb.Append(string.Format("|{0,-51}", itemArray[4].ToString()));
                    //else if (column.ToString() == "City")
                        sb.Append(string.Format("|{0,-35}", itemArray[5].ToString()));
                    //else if (column.ToString() == "State")
                        sb.Append(string.Format("|{0,-15}", itemArray[6].ToString()));
                    //else if (column.ToString() == "Zip")
                        sb.Append(string.Format("|{0,-6}", itemArray[7].ToString()));
                    //else if (column.ToString() == "Phone")
                        sb.Append(string.Format("|{0,-15}", itemArray[8].ToString()));
                    //else if (column.ToString() == "ChurchHomeName")
                        sb.Append(string.Format("|{0,-30}", itemArray[9].ToString()));
                    //else if (column.ToString() == "BirthDate")
                        sb.Append(string.Format("|{0,-15}", itemArray[10].ToString().Substring(0,10)));
                        sb.AppendLine("");
                    //string s = string.Format("{0,-15} | {1,-3} | {0,-15}", itemArray[1].ToString(), itemArray[2].ToString(), itemArray[3].ToString());
                    //sb.AppendLine(string.Format("{0,-15} | {0,-3} | {0,-15}", firstName, middleInit, lastName));

                    //sb.AppendLine(string.Join("\t\t", row.ItemArray.Select(arg => arg.ToString())));
                    //sb.AppendLine(string.Format("|{0,5}|{1,5}|{2,5}", string.Join(",",fields)));
                    //sb.AppendLine(string.Join(",", fields));
                    //sb.AppendLine(string.Format("{0,20}", fields));
                }
                //foreach (DataRow row in table.Rows)
                //{
                //    IEnumerable<string> fields = row.ItemArray.Select(field => string.Format("{0,50}", field.ToString()));
                //    sb.AppendLine(string.Join("||", fields));
                //    //sb.AppendLine(string.Join(",", fields));
                //    //sb.AppendLine(string.Format("{0,20}", fields));
                //}

                // ... You can write the text from a TextBox instead of a string literal.
                File.WriteAllText(name, sb.ToString());
                //File.WriteAllText(name, text);

                MessageBox.Show(
                            Resources.Export_Success_Message,
                            Resources.Export_Success_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }


        }
    }
}
