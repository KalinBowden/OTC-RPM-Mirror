﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using shipapp.Connections.HelperClasses;
using shipapp.Models;
using shipapp.Models.ModelData;
using shipapp.Connections.DataConnections;

namespace shipapp
{
    /// <summary>
    /// This class will allow the program to track and update table information
    /// Note 0: THe class keeps track of which table is active by testing the variable current table
    /// </summary>
    public partial class Manage : Form
    {
        // Class level variables
        private int currentTable = 0;
        private string message = "REST";
        private int role;
        private DataGridViewColumnHelper dgvch = new DataGridViewColumnHelper();
        private object objectToBeEditied;
        private BindingList<Faculty> faculties;
        private BindingList<Vendors> vendors;
        private BindingList<Carrier> carriers;
        private BindingList<BuildingClass> buildings;
        private BindingList<User> users;
        private char c = '\u2022';
        //Search Vars Uses
        private BindingSource bs = new BindingSource();
        public object ObjectToBeEditied { get => objectToBeEditied; set => objectToBeEditied = value; }
        public Manage()
        {
            InitializeComponent();
            dataGridView1.DataError += DataGridView1_DataError;
            dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
        }
        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // reset column values lost during sort
                if (currentTable == 1)
                {
                    dataGridView1.Columns["Level"].HeaderText = "Role";
                    for (int i = 0; i < DataConnectionClass.DataLists.UsersList.Count; i++)
                    {
                        long a = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                        User res = DataConnectionClass.DataLists.UsersList.FirstOrDefault(m => m.Id == a);
                        dataGridView1.Rows[i].Cells["note_count"].Value = res.Notes.Count.ToString();
                        dataGridView1.Rows[i].Cells["Level"].Value = res.Level.ToString();
                    }
                }
                else if (currentTable == 2)
                {

                }
                else if (currentTable == 3)
                {
                    for (int i = 0; i < DataConnectionClass.DataLists.FacultyList.Count; i++)
                    {
                        long a = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                        Faculty res = DataConnectionClass.DataLists.FacultyList.FirstOrDefault(m => m.Id == a);
                    }
                }
                else if (currentTable == 4)
                {

                }
                else if (currentTable == 5)
                {

                }
                else if (currentTable == 6)
                {

                }
                else
                {
                    throw new ArgumentOutOfRangeException("Current table value is out of range");
                }
            }
            catch (Exception)
            {
                //do nothing but quietly handle error
            }
        }
        /// <summary>
        /// used to hide data conversion errors even though they are resolved through the getStrings and toStrings methods
        /// </summary>
        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //
        }
        /// <summary>
        /// Close the Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Manage_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            SetRole();

            //
            if (role == 1)
            {
                // Do nothing
                pcBxDelete.Enabled = true;
                pcBxEdit.Enabled = true;
                pictureBox1.Enabled = true;
                pcBxPrint.Enabled = true;

                pcBxDelete.BackColor = Color.Transparent;
                pcBxEdit.BackColor = Color.Transparent;
                pictureBox1.BackColor = Color.Transparent;
                pcBxPrint.BackColor = Color.Transparent;

                btnVendors.BackColor = SystemColors.ButtonFace;
                btnVendors.Enabled = true;
                btnFaculty.BackColor = SystemColors.ButtonFace;
                btnFaculty.Enabled = true;
                btnBuildings.BackColor = SystemColors.ButtonFace;
                btnBuildings.Enabled = true;
                btnCarriers.BackColor = SystemColors.ButtonFace;
                btnCarriers.Enabled = true;
                btnOther.BackColor = SystemColors.ButtonFace;
                btnOther.Enabled = true;
            }
            else if (role == 2)
            {
                // Do nothing
                pcBxDelete.Enabled = false;
                pcBxDelete.BackColor = Color.LightPink;
                pcBxEdit.Enabled = true;
                pictureBox1.Enabled = true;
                pcBxPrint.Enabled = true;
                
                pcBxEdit.BackColor = Color.Transparent;
                pictureBox1.BackColor = Color.Transparent;
                pcBxPrint.BackColor = Color.Transparent;

                btnVendors.Enabled = true;
                btnFaculty.BackColor = SystemColors.ButtonFace;
                btnFaculty.Enabled = true;
                btnFaculty.BackColor = SystemColors.ButtonFace;
                btnBuildings.Enabled = true;
                btnFaculty.BackColor = SystemColors.ButtonFace;
                btnCarriers.Enabled = true;
                btnCarriers.BackColor = SystemColors.ButtonFace;
                btnOther.Enabled = true;
                btnFaculty.BackColor = SystemColors.ButtonFace;
            }
            else if (role == 3)
            {

                pcBxDelete.Enabled = false;
                pcBxEdit.Enabled = false;
                pictureBox1.Enabled = false;
                pcBxPrint.Enabled = false;

                pcBxDelete.BackColor = Color.LightPink;
                pcBxEdit.BackColor = Color.LightPink;
                pictureBox1.BackColor = Color.LightPink;
                pcBxPrint.BackColor = Color.LightPink;


                btnVendors.Enabled = true;
                btnFaculty.BackColor = SystemColors.ButtonFace;
                btnFaculty.Enabled = true;
                btnBuildings.BackColor = SystemColors.ButtonFace;
                btnBuildings.Enabled = true;
                btnCarriers.BackColor = SystemColors.ButtonFace;
                btnCarriers.Enabled = true;
                btnOther.Enabled = true;
                btnOther.BackColor = SystemColors.ButtonFace;
            }
            else if ( role == 0)
            {
                btnUsers.Enabled = true;
                btnUsers.BackColor = SystemColors.ButtonFace;
                btnVendors.Enabled = false;
                btnFaculty.BackColor = Color.LightPink;
                btnFaculty.Enabled = false;
                btnBuildings.BackColor = Color.LightPink;
                btnBuildings.Enabled = false;
                btnCarriers.BackColor = Color.LightPink;
                btnCarriers.Enabled = false;
                btnOther.Enabled = false;
                btnOther.BackColor = Color.LightPink;
            }
            btnUsers_Click_1(this, e);
        }
        #region Table Buttons
        /// <summary>
        /// Faculty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ClearBackColor();
            btnFaculty.BackColor = SystemColors.ButtonHighlight;
            currentTable = 3;
            lblSearch.Text = "";
            txtSearch.Text = "";
            DataConnectionClass.EmployeeConn.GetAllAfaculty(this);

            pictureBox1.Enabled = true;
            pictureBox1.BackColor = Color.Transparent;
            pcBxEdit.Enabled = true;
            pcBxEdit.BackColor = Color.Transparent;
            pcBxDelete.Enabled = true;
            pcBxDelete.BackColor = Color.Transparent;

            if (role == 2)
            {
                pictureBox1.Enabled = true;
                pictureBox1.Show();
            }
        }
        #endregion // When the user clicks one of these button they will assign the active table and fiil the grid with data.
        #region Grid Buttons
        /// <summary>
        /// Allow the application to know what table to add and
        /// bring the appropriate form to the front.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
                AddEntity(e);
        }
        #endregion
        private void btnUsers_Click_1(object sender, EventArgs e)
        {
            ClearBackColor();
            btnUsers.BackColor = SystemColors.ButtonHighlight;
            currentTable = 1;
            //TODO Fill list with query from Database
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            DataConnectionClass.UserConn.GetManyUsers(this);
            lblSearch.Text = "";
            txtSearch.Text = "";

            pictureBox1.Enabled = true;
            pictureBox1.BackColor = Color.Transparent;
            pcBxEdit.Enabled = true;
            pcBxEdit.BackColor = Color.Transparent;
            pcBxDelete.Enabled = true;
            pcBxDelete.BackColor = Color.Transparent;

            if (role == 2)
            {
                pictureBox1.Enabled = false;
                pictureBox1.BackColor = Color.Transparent;
            }

            //change header text for roles
            try
            {
                dataGridView1.Columns["Level"].HeaderText = "Role";
                
                //dgvch.AddCustomColumn(dataGridView1, "Note Count", "note_count", "", 10);
                int i = 0;
                // sets the value of the text to role title rather than the class namespace and name
                // see tostring override in roles to see how this was hanled, may need to change based on what we do for other classes
                for (i = 0; i < DataConnectionClass.DataLists.UsersList.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["Level"].Value = DataConnectionClass.DataLists.UsersList[i].Level.ToString();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                dataGridView1.Update();
            }
        }
        private void btnVendors_Click_1(object sender, EventArgs e)
        {
            ClearBackColor();
            btnVendors.BackColor = SystemColors.ButtonHighlight;
            currentTable = 2;
            //TODO Fill list with query from Database
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            DataConnectionClass.VendorConn.GetVendorList(this);
            lblSearch.Text = "";
            txtSearch.Text = "";
            if (role == 2)
            {
                pictureBox1.Enabled = false;
                pictureBox1.BackColor = Color.Transparent;
            }

            pictureBox1.Enabled = true;
            pictureBox1.BackColor = Color.Transparent;
            pcBxEdit.Enabled = true;
            pcBxEdit.BackColor = Color.Transparent;
            pcBxDelete.Enabled = true;
            pcBxDelete.BackColor = Color.Transparent;
        }
        private void btnBuildings_Click_1(object sender, EventArgs e)
        {
            ClearBackColor();
            btnBuildings.BackColor = SystemColors.ButtonHighlight;
            currentTable = 4;
            DataConnectionClass.buildingConn.GetBuildingList(this);
            lblSearch.Text = "";
            txtSearch.Text = "";
            if (role == 2)
            {
                pictureBox1.Enabled = false;
                pictureBox1.BackColor = Color.Transparent;
            }

            pictureBox1.Enabled = true;
            pictureBox1.BackColor = Color.Transparent;
            pcBxEdit.Enabled = true;
            pcBxEdit.BackColor = Color.Transparent;
            pcBxDelete.Enabled = true;
            pcBxDelete.BackColor = Color.Transparent;
        }
        private void btnCarriers_Click_1(object sender, EventArgs e)
        {
            ClearBackColor();
            btnCarriers.BackColor = SystemColors.ButtonHighlight;
            currentTable = 5;
            //TODO Fill list with query from Database
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            DataConnectionClass.CarrierConn.GetCarrierList(this);
            lblSearch.Text = "";
            txtSearch.Text = "";
            if (role == 2)
            {
                pictureBox1.Enabled = false;
                pictureBox1.BackColor = Color.Transparent;
            }

            pictureBox1.Enabled = true;
            pictureBox1.BackColor = Color.Transparent;
            pcBxEdit.Enabled = true;
            pcBxEdit.BackColor = Color.Transparent;
            pcBxDelete.Enabled = true;
            pcBxDelete.BackColor = Color.Transparent;
        }
        private void btnOther_Click_1(object sender, EventArgs e)
        {
            if (role == 2)
            {
                pictureBox1.Enabled = false;
                pictureBox1.BackColor = Color.Transparent;
            }
            lblSearch.Text = "";
            pictureBox1.Enabled = false;
            pictureBox1.BackColor = Color.LightPink;
            pcBxEdit.Enabled = false;
            pcBxEdit.BackColor = Color.LightPink;
            pcBxDelete.Enabled = false;
            pcBxDelete.BackColor = Color.LightPink;

            ClearBackColor();
            btnOther.BackColor = SystemColors.ButtonHighlight;
            currentTable = 6;
            DataConnectionClass.AuditLogConnClass.GetAuditLog(this);
        }
        /// <summary>
        /// Delete an object from the designated table
        /// </summary>
        public void DeleteEntity()
        {
            // Use the proper delete for the table
            if (currentTable == 1)
            {
                // Delete selected user
                User userToBeDeleted = DataConnectionClass.DataLists.UsersList.FirstOrDefault(uid => uid.Id == Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value));
                DataConnectionClass.UserConn.DeleteUser(userToBeDeleted);
                DataConnectionClass.AuditLogConnClass.AddRecordToAudit("deleted user " + userToBeDeleted.ToString());
                DataConnectionClass.UserConn.GetManyUsers(this);
            }
            else if (currentTable == 2)
            {
                // Delete selected vendor
                Vendors vendorToBeDeleted = DataConnectionClass.DataLists.Vendors.FirstOrDefault(vid => vid.VendorId == Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value));
                DataConnectionClass.VendorConn.DeleteVendor(vendorToBeDeleted);
                DataConnectionClass.AuditLogConnClass.AddRecordToAudit("deleted vendor " + vendorToBeDeleted.VendorName);
                DataConnectionClass.VendorConn.GetVendorList(this);
            }
            else if (currentTable == 3)
            {
                // Delete selected faculty
                Faculty facultyToBeDeleted = DataConnectionClass.DataLists.FacultyList.FirstOrDefault(fid => fid.Id == Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value));
                DataConnectionClass.EmployeeConn.DeleteFaculty(facultyToBeDeleted);
                DataConnectionClass.AuditLogConnClass.AddRecordToAudit("deleted faculty member " + facultyToBeDeleted.ToNormalNameString());
                DataConnectionClass.EmployeeConn.GetAllAfaculty(this);
            }
            else if (currentTable == 4)
            {
                // Delete selected building
                BuildingClass buildingToBeDeleted = DataConnectionClass.DataLists.BuildingNames.FirstOrDefault(bid => bid.BuildingId == Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value));
                DataConnectionClass.buildingConn.RemoveBuilding(buildingToBeDeleted);
                DataConnectionClass.AuditLogConnClass.AddRecordToAudit("deleted a building: " + buildingToBeDeleted.BuildingLongName);
                DataConnectionClass.buildingConn.GetBuildingList(this);
            }
            else if (currentTable == 5)
            {
                // Delete selected carrier
                Carrier carrierToBeDeleted = DataConnectionClass.DataLists.CarriersList.FirstOrDefault(cid => cid.CarrierId == Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value));
                DataConnectionClass.CarrierConn.DeleteCarrier(carrierToBeDeleted);
                DataConnectionClass.AuditLogConnClass.AddRecordToAudit("deleted carrier " + carrierToBeDeleted.CarrierName);
                DataConnectionClass.CarrierConn.GetCarrierList(this);
            }
            else if (currentTable == 6)
            {
                // TODO: 
                MessageBox.Show("This button does not yet have a function", "Uh-oh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else// Provide an error message if no table is selected
            {
                MessageBox.Show("You must select a table before you can delete an item.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// When this event fires, delete the currently selected entity from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcBxDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DeleteEntity();
            }
        }
        /// <summary>
        /// Send a user to the edit form then edit the user
        /// </summary>
        public void EditEntity()
        {
            // Set the message to edit
            message = "EDIT";

            // Edit the correct object
            if (currentTable == 1)
            {
                // Edit user object 
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    User userToBeEdited = DataConnectionClass.DataLists.UsersList.FirstOrDefault(uid => uid.Id == Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value));
                    AddUser addUser = new AddUser(message, userToBeEdited);
                    addUser.ShowDialog();
                    DataConnectionClass.UserConn.GetManyUsers(this);
                }
                else
                {
                    MessageBox.Show("Sorry, you must select the row to proceed.","Row to modify is null");
                }
            }
            else if (currentTable == 2)
            {
                // Edit vendor object
                Vendors vendorToBeEdited = DataConnectionClass.DataLists.Vendors.FirstOrDefault(vid => vid.VendorId == Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value));
                AddVendor addVendor = new AddVendor(message, vendorToBeEdited);
                addVendor.ShowDialog();
                DataConnectionClass.VendorConn.GetVendorList(this);
            }
            else if (currentTable == 3)
            {
                // Edit faculty object
                Faculty facultyToBeEdited = DataConnectionClass.DataLists.FacultyList.FirstOrDefault(fid => fid.Id == Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value));
                AddFaculty addFaculty = new AddFaculty(message, facultyToBeEdited);
                addFaculty.ShowDialog();
                DataConnectionClass.EmployeeConn.GetAllAfaculty(this);
            }
            else if (currentTable == 4)
            {
                // Edit building object
                BuildingClass buildingToBeEdited = DataConnectionClass.DataLists.BuildingNames.FirstOrDefault(bid => bid.BuildingId == Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value));
                AddBuilding addBuilding = new AddBuilding(message, buildingToBeEdited);
                addBuilding.ShowDialog();
                DataConnectionClass.buildingConn.GetBuildingList(this);
            }
            else if (currentTable == 5)
            {
                // Edit carrier object
                Carrier carrierToBeEdited = DataConnectionClass.DataLists.CarriersList.FirstOrDefault(cid => cid.CarrierId == Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value));
                AddCarrier addCarrier = new AddCarrier(message, carrierToBeEdited);
                addCarrier.ShowDialog();
                DataConnectionClass.CarrierConn.GetCarrierList(this);
            }
            else if (currentTable == 6)
            {
                // Edit other object
                MessageBox.Show("This table is not setup yet", "Uh-oh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Alert user that a table must be selected
                MessageBox.Show("Please select a table", "Uh-oh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            message = "REST";
        }
        /// <summary>
        /// When this button fires grab the correct entity and edit it to the DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcBxEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                EditEntity();
            }
        }
        public void SetRole()
        {
            if (DataConnectionClass.AuthenticatedUser.Level.Role_Title == "Administrator")
            {
                role = 1;
            }
            else if (DataConnectionClass.AuthenticatedUser.Level.Role_Title == "Dock Supervisor")
            {
                role = 2;
            }
            else if (DataConnectionClass.AuthenticatedUser.Level.Role_Title == "Supervisor")
            {
                role = 3;
            }
            else if (DataConnectionClass.AuthenticatedUser.Level.Role_Title == "User")
            {
                role = 4;
            }
            else
            {
                role = 0;
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SignOut();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            SignOut();
        }
        public void SignOut()
        {
            MessageBox.Show(DataConnectionClass.AuthenticatedUser.LastName + ", " + DataConnectionClass.AuthenticatedUser.FirstName + "\r\n" + DataConnectionClass.AuthenticatedUser.Level.Role_Title + "\r\n\r\nTo Logout exit to the Main Menu.");
        }
        /// <summary>
        /// Print the selected report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcBxPrint_Click(object sender, EventArgs e)
        {
            PrintReport();
        }
        /// <summary>
        /// Print the selected report
        /// </summary>
        public void PrintReport()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Print();
            }
        }
        /// <summary>
        /// Display a list of objects that match the text in the search bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }
        public void SearchData()
        {
            string lblTxt = lblSearch.Text;
            string sText = txtSearch.Text;
            if (String.IsNullOrWhiteSpace(sText) || String.IsNullOrWhiteSpace(lblTxt))
            {
                if (currentTable == 1)
                {
                    bs.DataSource = DataConnectionClass.DataLists.UsersList;
                }
                else if (currentTable == 2)
                {
                    bs.DataSource = DataConnectionClass.DataLists.Vendors;
                }
                else if (currentTable == 3)
                {
                    bs.DataSource = DataConnectionClass.DataLists.FacultyList;
                }
                else if (currentTable == 4)
                {
                    bs.DataSource = DataConnectionClass.DataLists.BuildingNames;
                }
                else if (currentTable == 5)
                {
                    bs.DataSource = DataConnectionClass.DataLists.CarriersList;
                }
                else if (currentTable == 6)
                {
                    bs.DataSource = DataConnectionClass.DataLists.AuditLog;
                }
                else
                {
                    return;
                }
            }
            if (currentTable == 1)
            {
                List<User> sList = new List<User>();
                SortableBindingList<User> fList = new SortableBindingList<User>();
                //users
                switch (lblTxt)
                {
                    case "FirstName":
                        sList = DataConnectionClass.DataLists.UsersList.Where(i => i.FirstName.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    case "LastName":
                        sList = DataConnectionClass.DataLists.UsersList.Where(i => i.LastName.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    case "Level":
                        sList = DataConnectionClass.DataLists.UsersList.Where(i => i.Level.Role_Title.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    case "UserName":
                        sList = DataConnectionClass.DataLists.UsersList.Where(i => i.Username.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    default:
                        bs.DataSource = DataConnectionClass.DataLists.UsersList;
                        break;
                }
            }
            else if (currentTable == 2)
            {
                List<Vendors> sList = new List<Vendors>();
                SortableBindingList<Vendors> fList = new SortableBindingList<Vendors>();
                //vendor
                switch (lblTxt)
                {
                    case "VendorName":
                        sList = DataConnectionClass.DataLists.Vendors.Where(i => i.VendorName.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    default:
                        bs.DataSource = DataConnectionClass.DataLists.Vendors;
                        break;
                }
            }
            else if (currentTable == 3)
            {
                List<Faculty> sList = new List<Faculty>();
                SortableBindingList<Faculty> fList = new SortableBindingList<Faculty>();
                //faculty
                switch (lblTxt)
                {
                    case "FirstName":
                        sList = DataConnectionClass.DataLists.FacultyList.Where(i => i.FirstName.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    case "LastName":
                        sList = DataConnectionClass.DataLists.FacultyList.Where(i => i.LastName.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    case "BuildingName":
                        sList = DataConnectionClass.DataLists.FacultyList.Where(i => i.Building_Name.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    case "RoomNumber":
                        sList = DataConnectionClass.DataLists.FacultyList.Where(i => i.RoomNumber.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    default:
                        bs.DataSource = DataConnectionClass.DataLists.FacultyList;
                        break;
                }
            }
            else if (currentTable == 4)
            {
                List<BuildingClass> sList = new List<BuildingClass>();
                SortableBindingList<BuildingClass> fList = new SortableBindingList<BuildingClass>();
                //building
                switch (lblTxt)
                {
                    case "BuildingLongName":
                        sList = DataConnectionClass.DataLists.BuildingNames.Where(i => i.BuildingLongName.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    case "BuildingShortName":
                        sList = DataConnectionClass.DataLists.BuildingNames.Where(i => i.BuildingShortName.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    default:
                        bs.DataSource = DataConnectionClass.DataLists.BuildingNames;
                        break;
                }
            }
            else if (currentTable == 5)
            {
                List<Carrier> sList = new List<Carrier>();
                SortableBindingList<Carrier> fList = new SortableBindingList<Carrier>();
                //carriers
                switch (lblTxt)
                {
                    case "CarrierName":
                        sList = DataConnectionClass.DataLists.CarriersList.Where(i => i.CarrierName.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    default:
                        bs.DataSource = DataConnectionClass.DataLists.CarriersList;
                        break;
                }
            }
            else if (currentTable == 6)
            {
                List<AuditItem> sList = new List<AuditItem>();
                SortableBindingList<AuditItem> fList = new SortableBindingList<AuditItem>();
                //history
                switch (lblTxt)
                {
                    case "Item":
                        sList = DataConnectionClass.DataLists.AuditLog.Where(i => i.Item.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    case "Date":
                        sList = DataConnectionClass.DataLists.AuditLog.Where(i => i.Date.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    case "Time":
                        sList = DataConnectionClass.DataLists.AuditLog.Where(i => i.Time.ToLower().IndexOf(sText.ToLower()) >= 0).ToList();
                        sList.ForEach(i => fList.Add(i));
                        bs.DataSource = sList;
                        break;
                    default:
                        bs.DataSource = DataConnectionClass.DataLists.AuditLog;
                        break;
                }
            }
            else
            {
                //invalid table
                return;
            }
            // -- -- Query database and return results
            dataGridView1.DataSource = bs;
        }
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("It worked: " + dataGridView1.SelectedCells[0].ColumnIndex + "\r\n" + dataGridView1.Columns[dataGridView1.SelectedCells[0].ColumnIndex].DataPropertyName);
            lblSearch.Text = dataGridView1.Columns[dataGridView1.SelectedCells[0].ColumnIndex].DataPropertyName;
        }
        public void Print()
        {
            if (currentTable == 1)
            {
                CreateLogList();
                PrintPreview printPreview = new PrintPreview(users, currentTable + 2, null);
                printPreview.ShowDialog();
            }
            else if (currentTable == 2)
            {
                CreateLogList();
                PrintPreview printPreview = new PrintPreview(vendors, currentTable + 2, null);
                printPreview.ShowDialog();
            }
            else if (currentTable == 3)
            {
                CreateLogList();
                PrintPreview printPreview = new PrintPreview(faculties, currentTable + 2, null);
                printPreview.ShowDialog();
            }
            else if (currentTable == 4)
            {
                CreateLogList();
                PrintPreview printPreview = new PrintPreview(buildings, currentTable + 2, null);
                printPreview.ShowDialog();
            }
            else if (currentTable == 5)
            {
                CreateLogList();
                PrintPreview printPreview = new PrintPreview(carriers, currentTable + 2, null);
                printPreview.ShowDialog();
            }
            else if (currentTable == 6)
            {
                //// TODO History
                //PrintPreview printPreview = new PrintPreview();
                //printPreview.ShowDialog();
            }
            else
            {
                MessageBox.Show("It seems something went wrong.\r\nPlease try again.", "Uh-oh!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// Fill a list with the selected items
        /// </summary>
        public void CreateLogList()
        {
            // Create new list object
            if (currentTable == 1)
            {
                users = new BindingList<User>();

                // Fill list with logs
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    // Convert packages to logs
                    users.Add((User)dataGridView1.SelectedRows[i].DataBoundItem);
                }
            }
            else if (currentTable == 2)
            {
                vendors = new BindingList<Vendors>();

                // Fill list with logs
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    // Convert packages to logs
                    vendors.Add((Vendors)dataGridView1.SelectedRows[i].DataBoundItem);
                }
            }
            else if (currentTable == 3)
            {
                faculties = new BindingList<Faculty>();

                // Fill list with logs
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    // Convert packages to logs
                    faculties.Add((Faculty)dataGridView1.SelectedRows[i].DataBoundItem);
                }
            }
            else if (currentTable == 4)
            {
                buildings = new BindingList<BuildingClass>();

                // Fill list with logs
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    // Convert packages to logs
                    buildings.Add((BuildingClass)dataGridView1.SelectedRows[i].DataBoundItem);
                }
            }
            else if (currentTable == 5)
            {
                carriers = new BindingList<Carrier>();

                // Fill list with logs
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    // Convert packages to logs
                    carriers.Add((Carrier)dataGridView1.SelectedRows[i].DataBoundItem);
                }
            }
            else if (currentTable == 6)
            {
                //// TODO History
                //list = new BindingList<Log>();

                // Fill list with logs
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    // Convert packages to logs
                    users.Add((User)dataGridView1.SelectedRows[i].DataBoundItem);
                }
            }
            else
            {
                MessageBox.Show("It seems something went wrong.\r\nTry again", "Uh-oh!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void AddEntity(EventArgs e)
        {
            message = "ADD";

            if (currentTable == 0)
            {
                MessageBox.Show("You must select a table before you can add an item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (currentTable == 1)
            {
                AddUser addUser = new AddUser(message);
                addUser.ShowDialog();
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                DataConnectionClass.UserConn.GetManyUsers(this);
                dataGridView1.Update();
            }
            else if (currentTable == 2)
            {
                AddVendor addVendor = new AddVendor(message);
                addVendor.ShowDialog();
                btnVendors_Click_1(this, e);
                DataConnectionClass.VendorConn.GetVendorList(this);
            }
            else if (currentTable == 3)
            {
                AddFaculty addFaculty = new AddFaculty(message);
                addFaculty.ShowDialog();
                DataConnectionClass.EmployeeConn.GetAllAfaculty(this);
            }
            else if (currentTable == 4)
            {
                AddBuilding addbuilding = new AddBuilding(message);
                DialogResult dr = addbuilding.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    addbuilding.Dispose();
                    GC.Collect();
                    btnBuildings_Click_1(this, e);
                    DataConnectionClass.buildingConn.GetBuildingList(this);
                }
            }
            else if (currentTable == 5)
            {
                AddCarrier addCarrier = new AddCarrier(message);
                addCarrier.ShowDialog();
                btnCarriers_Click_1(this, e);
                DataConnectionClass.CarrierConn.GetCarrierList(this);
            }
            else if (currentTable == 6)
            {
                MessageBox.Show("This button is not set to a existing table! Please select another table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Reset message
            message = "REST";
        }
        public string ValueToPassWord(String password)
        {
            
            for (int i = 0; i < password.Length; i++)
            {
                 password.ToCharArray()[i] = c;
            }

            return password;
        }
        public void ClearBackColor()
        {
            btnUsers.BackColor = SystemColors.ButtonFace;
            btnVendors.BackColor = SystemColors.ButtonFace;
            btnFaculty.BackColor = SystemColors.ButtonFace;
            btnCarriers.BackColor = SystemColors.ButtonFace;
            btnBuildings.BackColor = SystemColors.ButtonFace;
            btnOther.BackColor = SystemColors.ButtonFace;
        }
    }
}

