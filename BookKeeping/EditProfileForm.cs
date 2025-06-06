// Matt Deinlein[mattdeinlein@gmail.com]
// @version: 1.0 06.06.2025
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BookKeeping
{
    public partial class EditProfileForm : Form
    {
        private DatabaseHelper dbHelper; 
        private int Id; 
        private Form1 mainForm;
        public EditProfileForm(int Id, Form1 mainForm)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            this.Id = Id;

            // Set the DateTimePicker to show both date and time, including seconds
            dateTimePickerAppointmentDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerAppointmentDate.CustomFormat = "yyyy-MM-dd HH:mm:ss"; 

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 

            LoadUserData(); 
            LoadLeads(); 
            LoadClientTypes();
            this.mainForm = mainForm;
        }

        private void LoadClientTypes()
        {
            comboBoxClientType.Items.Add("Lead");
            comboBoxClientType.Items.Add("Set");
            comboBoxClientType.Items.Add("Showed");
            comboBoxClientType.Items.Add("Rescheduled");
            comboBoxClientType.Items.Add("Closed");
        }

        public void LoadLeads()
        {
            DataTable leadsTable = dbHelper.GetLeadsDataTable();
            dataGridView1.DataSource = leadsTable;

            // Ensure DownPayment column is displayed
            if (!dataGridView1.Columns.Contains("DownPayment"))
            {
                dataGridView1.Columns.Add("DownPayment", "Down Payment");
            }

            AddEditDeleteColumns();
        }


        private void AddEditDeleteColumns()
        {
            dataGridView1.Columns.Clear(); 

            // Create Edit button column
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "btnEdit"
            };

            // Create Delete button column
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Name = "btnDelete"
            };

            // Add both button columns to the DataGridView
            dataGridView1.Columns.Add(editButtonColumn);
            dataGridView1.Columns.Add(deleteButtonColumn);
        }

        private void EditProfileForm_Load(object sender, EventArgs e)
        {
            LoadUserData(); 
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower(); 
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                using (var connection = new SQLiteConnection(dbHelper.ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT Id, Name, Phone, Email FROM Leads WHERE Name LIKE @searchTerm";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); // Wildcards for partial match
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable; // Update DataGridView with search results
                        }
                    }
                }
            }
            else
            {
                LoadUserData(); // Reload all data if the search term is empty
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnEdit"].Index && e.RowIndex >= 0)
            {
                int selectedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                EditProfileForm editProfileForm = new EditProfileForm(selectedId, this.mainForm);
                if (editProfileForm.ShowDialog() == DialogResult.OK)
                {
                    LoadLeads(); // Reload the DataGridView with updated data
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["btnDelete"].Index && e.RowIndex >= 0)
            {
                int selectedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                var confirmResult = MessageBox.Show("Are you sure to delete this profile?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    dbHelper.DeleteLead(selectedId); // Implement this method in dbHelper
                    LoadLeads();
                }
            }
        }

        private void LoadUserData()
        {
            using (var connection = new SQLiteConnection(dbHelper.ConnectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Name, Phone, Email, AppointmentDate, ClientType, DownPayment, Notes FROM Leads WHERE Id = @Id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["Name"].ToString();
                            txtPhone.Text = reader["Phone"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            rtbNotes.Text = reader["Notes"].ToString();

                            if (reader["AppointmentDate"] != DBNull.Value && DateTime.TryParse(reader["AppointmentDate"].ToString(), out DateTime appointmentDate))
                            {
                                dateTimePickerAppointmentDate.Value = appointmentDate;
                            }
                            else
                            {
                                dateTimePickerAppointmentDate.Value = DateTime.Now;
                                dateTimePickerAppointmentDate.CustomFormat = " ";
                            }

                            comboBoxClientType.SelectedItem = reader["ClientType"].ToString();

                            // Load Down Payment (ensure safe conversion)
                            txtDownPayment.Text = reader["DownPayment"] != DBNull.Value ? reader["DownPayment"].ToString() : "0";
                        }
                    }
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string updatedName = txtName.Text;
            string updatedPhone = txtPhone.Text;
            string updatedEmail = txtEmail.Text;
            DateTime updatedAppointmentDate = dateTimePickerAppointmentDate.Value;
            string updatedClientType = comboBoxClientType.SelectedItem?.ToString();
            decimal updatedDownPayment = decimal.TryParse(txtDownPayment.Text, out decimal dp) ? dp : 0;
            string updatedNotes = rtbNotes.Text.Trim();

            if (!decimal.TryParse(txtDownPayment.Text, out updatedDownPayment))
            {
                MessageBox.Show("Please enter a valid numeric value for Down Payment.");
                return;
            }

            // Update the user information in the database
            dbHelper.UpdateUser(Id, updatedName, updatedPhone, updatedEmail, updatedAppointmentDate, updatedClientType, updatedDownPayment, updatedNotes);

            MessageBox.Show("User details updated successfully.");
            LoadLeads(); 
            Form parentForm = this.Owner;

            
            this.Close();

            // Reopen the form
            if (parentForm != null)
            {
                // If this form has a parent, show this form as a dialog again
                EditProfileForm editProfileForm = new EditProfileForm(this.Id, this.mainForm);
                editProfileForm.ShowDialog(parentForm);
            }
            else
            {
                // If there's no parent, show as a standalone form
                EditProfileForm editProfileForm = new EditProfileForm(this.Id, this.mainForm);
                editProfileForm.Show();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
