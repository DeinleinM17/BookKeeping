// Matt Deinlein[mattdeinlein@gmail.com]
// @version: 1.0 06.06.2025
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data;

namespace BookKeeping
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;
        public DataGridView dataGridView1;
        private EditProfileForm editProfileForm;
        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            this.Shown += Form1_Shown; // Attach the Shown event to refresh appointments
            LoadComboBoxMetrics();
            comboBoxMetrics.SelectionChangeCommitted += comboBoxMetrics_SelectedIndexChanged;
            UpdateAllCounts(); //
            this.editProfileForm = editProfileForm;
            dataGridView1 = new DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            listBoxAppointments.SelectedIndexChanged += listBoxAppointments_SelectedIndexChanged;


            // Add event listener for comboBoxMetrics
            comboBoxMetrics.SelectedIndexChanged += comboBoxMetrics_SelectedIndexChanged;

            // Optionally set default selected value
            comboBoxMetrics.SelectedItem = "Day"; 

        }
        private void OpenEditProfileForm(int userId)
        {
            // Pass Form1 instance to EditProfileForm
            editProfileForm = new EditProfileForm(userId, this);
            editProfileForm.ShowDialog();  // Show the EditProfileForm
        }
        // Event to clear and refill the ListBox after the form loads
        private void Form1_Shown(object sender, EventArgs e)
        {
            LoadAppointments(); // Ensures appointments load when the form is fully shown
            UpdateAllCounts();
            UpdateRates();
            UpdateTotalDownPayments();
        }
        public class AppointmentItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; }

            public AppointmentItem(int id, string displayText)
            {
                Id = id;
                DisplayText = displayText;
            }

            public override string ToString()
            {
                return DisplayText; // Ensures the ListBox displays only the formatted text
            }
        }

        private void LoadAppointments()
        {
            DateTime currentDate = DateTime.Now;
            DateTime oneWeekLater = currentDate.AddDays(7);

            listBoxAppointments.Items.Clear(); // Clear the ListBox before loading data

            try
            {
                using (var connection = new SQLiteConnection(dbHelper.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Id, Name, AppointmentDate FROM Leads WHERE AppointmentDate BETWEEN @StartDate AND @EndDate";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", currentDate);
                        command.Parameters.AddWithValue("@EndDate", oneWeekLater);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            var appointments = new List<Appointment>();

                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["Id"]); // Get the ID
                                DateTime appointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                                string name = reader["Name"].ToString();

                                appointments.Add(new Appointment
                                {
                                    Id = id,
                                    Name = name,
                                    AppointmentDate = appointmentDate
                                });
                            }

                            // Sort appointments by date
                            var sortedAppointments = appointments.OrderBy(a => a.AppointmentDate).ToList();

                            foreach (var appointment in sortedAppointments)
                            {
                                string formattedDate = appointment.AppointmentDate.ToString("yyyy-MM-dd");
                                string formattedTime = appointment.AppointmentDate.ToString("HH:mm");

                                string appointmentDetails = $"{appointment.Name} - {formattedDate} {formattedTime}";

                                if (appointment.AppointmentDate.Date == DateTime.Today)
                                {
                                    appointmentDetails = $"**TODAY** {appointmentDetails}";
                                }

                                // Store appointment in the ListBox with ID
                                listBoxAppointments.Items.Add(new AppointmentItem(appointment.Id, appointmentDetails));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }

        private void listBoxAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAppointments.SelectedItem is AppointmentItem selectedAppointment)
            {
                int selectedId = selectedAppointment.Id;

                // Open EditProfileForm with the selected ID
                EditProfileForm editForm = new EditProfileForm(selectedId, this);
                editForm.ShowDialog();
            }
        }

        private void btnAddLead_Click(object sender, EventArgs e)
        {
            AddLeadForm addLeadForm = new AddLeadForm(this);
            addLeadForm.ShowDialog();

            if (!string.IsNullOrEmpty(addLeadForm.NewId))
            {
                MessageBox.Show("New user was added with ID: " + addLeadForm.NewId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

        private void btnEditProf_Click(object sender, EventArgs e)
        {
            int userId = 1; 
            EditProfileForm editProfileForm = new EditProfileForm(userId, this);
            editProfileForm.ShowDialog();
        }

        private void btnViewCalendar_Click(object sender, EventArgs e)
        {
            CalendarForm calendarForm = new CalendarForm();
            calendarForm.ShowDialog();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            EmailGroupForm emailGroupForm = new EmailGroupForm();
            emailGroupForm.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            string fileName = Path.Combine(downloadsFolder, "LeadsExport.csv");
            ExportDatabaseToCSV(fileName);
        }

        private void ExportDatabaseToCSV(string filePath)
        {
            try
            {
                using (var connection = new SQLiteConnection(dbHelper.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Name, Phone, Email, AppointmentDate FROM Leads";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            StringBuilder csvContent = new StringBuilder();
                            csvContent.AppendLine("Name,Phone,Email,AppointmentDate");

                            while (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                string phone = reader["Phone"].ToString();
                                string email = reader["Email"].ToString();
                                string appointmentDate = reader["AppointmentDate"].ToString();

                                csvContent.AppendLine($"{name},{phone},{email},{appointmentDate}");
                            }

                            File.WriteAllText(filePath, csvContent.ToString());
                            MessageBox.Show($"Data exported successfully to: {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exporting the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Refreshing data...");

            UpdateAllCounts();  // Refreshes all lead status counts
            UpdateRates();      // Recalculates conversion rates
            LoadAppointments(); // Reloads the appointment list
            UpdateTotalDownPayments();

            MessageBox.Show("Data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        private void btnComparison_Click(object sender, EventArgs e)
        {
            ComparisonForm comparisonForm = new ComparisonForm();
            comparisonForm.ShowDialog();
        }

        public class Appointment
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime AppointmentDate { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateAllCounts();
            UpdateRates();
            UpdateTotalDownPayments();

        }

        public void UpdateMetricCount(string clientType, TextBox targetTextBox, bool countAllProfiles = false, bool excludeLead = false, bool includeShowedClosed = false)
        {
            string selectedMetric = comboBoxMetrics.SelectedItem?.ToString();
            Console.WriteLine($"Selected Metric: {selectedMetric}");

            string sqlQuery;
            DateTime dateLimit = DateTime.Now;

            if (countAllProfiles)
            {
                // Count all unique profiles
                sqlQuery = "SELECT COUNT(DISTINCT Id) FROM Leads WHERE DATETIME(CreatedTime) >= @DateLimit";
            }
            else if (excludeLead)
            {
                // Count all profiles excluding "Lead"
                sqlQuery = "SELECT COUNT(DISTINCT Id) FROM Leads WHERE ClientType != 'Lead' AND DATETIME(CreatedTime) >= @DateLimit";
            }
            else if (includeShowedClosed)
            {
                // Count profiles with "Showed" or "Closed"
                sqlQuery = "SELECT COUNT(DISTINCT Id) FROM Leads WHERE (ClientType = 'Showed' OR ClientType = 'Closed') AND DATETIME(CreatedTime) >= @DateLimit";
            }
            else
            {
                sqlQuery = "SELECT COUNT(*) FROM Leads WHERE ClientType = @ClientType AND DATETIME(CreatedTime) >= @DateLimit";
            }

            // Adjust timeframe based on selected metric
            if (selectedMetric == "Day")
                dateLimit = DateTime.Now.AddDays(-1);
            else if (selectedMetric == "Week")
                dateLimit = DateTime.Now.AddDays(-7);
            else if (selectedMetric == "Month")
                dateLimit = DateTime.Now.AddMonths(-1);
            else if (selectedMetric == "Year")
                dateLimit = DateTime.Now.AddYears(-1);
            else if (selectedMetric == "All-Time")
            {
                if (countAllProfiles)
                    sqlQuery = "SELECT COUNT(DISTINCT Id) FROM Leads";
                else if (excludeLead)
                    sqlQuery = "SELECT COUNT(DISTINCT Id) FROM Leads WHERE ClientType != 'Lead'";
                else if (includeShowedClosed)
                    sqlQuery = "SELECT COUNT(DISTINCT Id) FROM Leads WHERE (ClientType = 'Showed' OR ClientType = 'Closed')";
                else
                    sqlQuery = "SELECT COUNT(*) FROM Leads WHERE ClientType = @ClientType";
            }

            Console.WriteLine($"SQL Query: {sqlQuery}");
            Console.WriteLine($"Date Limit: {dateLimit}");

            using (var connection = new SQLiteConnection(dbHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sqlQuery, connection))
                {
                    if (!countAllProfiles && !excludeLead && !includeShowedClosed)
                        command.Parameters.AddWithValue("@ClientType", clientType);

                    if (selectedMetric != "All-Time")
                        command.Parameters.AddWithValue("@DateLimit", dateLimit.ToString("yyyy-MM-dd HH:mm:ss"));

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"Count for {clientType}: {count}");
                    targetTextBox.Text = count.ToString();
                }
            }
        }

        private void UpdateTotalDownPayments()
        {
            string selectedTimeSpan = comboBoxMetrics.SelectedItem?.ToString();
            decimal totalDownPayment = dbHelper.GetTotalDownPayments(selectedTimeSpan);

            txtDownPayments.Text = totalDownPayment.ToString("C"); // Format as currency
        }


        public void UpdateAllCounts()
        {
            UpdateMetricCount("Lead", txtLeads, true);
            UpdateMetricCount("Set", txtSet, false, true);
            UpdateMetricCount("Showed", txtShowed, false, false, true);
            UpdateMetricCount("Rescheduled", txtRescheduled);
            UpdateMetricCount("Closed", txtClosed);
        }

        private void LoadComboBoxMetrics()
        {
            comboBoxMetrics.Items.Clear();
            comboBoxMetrics.Items.Add("Day");
            comboBoxMetrics.Items.Add("Week");
            comboBoxMetrics.Items.Add("Month");
            comboBoxMetrics.Items.Add("Year");
            comboBoxMetrics.Items.Add("All-Time");
            comboBoxMetrics.SelectedIndex = 0;
        }
        private int GetCount(SQLiteConnection connection, string status, string clientType, DateTime dateLimit)
        {
            string sqlQuery = @"
        SELECT COUNT(DISTINCT ProfileId)
        FROM StatusHistory AS sh
        JOIN Leads AS l ON sh.ProfileId = l.ProfileId
        WHERE l.ClientType = @ClientType
        AND sh.Status = @Status
        AND sh.StatusChangedTime >= @DateLimit";

            using (var command = new SQLiteCommand(sqlQuery, connection))
            {
                command.Parameters.AddWithValue("@ClientType", clientType);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@DateLimit", dateLimit.ToString("yyyy-MM-dd HH:mm:ss"));

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public void UpdateRates()
        {
            // Get values from text boxes, default to 0 if empty or invalid
            int totalLeads = int.TryParse(txtLeads.Text, out int leads) ? leads : 0;
            int totalSet = int.TryParse(txtSet.Text, out int set) ? set : 0;
            int totalShow = int.TryParse(txtShowed.Text, out int show) ? show : 0;
            int totalClosed = int.TryParse(txtClosed.Text, out int closed) ? closed : 0;
            int totalRescheduled = int.TryParse(txtRescheduled.Text, out int rescheduled) ? rescheduled : 0;

            // Calculate rates (avoid division by zero)
            double setRate = totalLeads > 0 ? (double)totalSet / totalLeads * 100 : 0;
            double showRate = totalSet > 0 ? (double)totalShow / totalSet * 100 : 0;
            double closedRate = totalShow > 0 ? (double)totalClosed / totalShow * 100 : 0;
            double rescheduledRate = totalSet > 0 ? (double)totalRescheduled / totalSet * 100 : 0;

            // Update text boxes
            txtSetRate.Text = setRate.ToString("0.00") + "%";
            txtShowRate.Text = showRate.ToString("0.00") + "%";
            txtClosedRate.Text = closedRate.ToString("0.00") + "%";
            txtRescheduleRate.Text = rescheduledRate.ToString("0.00") + "%";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Select a CSV File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ImportCsvToDatabase(filePath);
                }
            }
        }
        private void ImportCsvToDatabase(string filePath)
        {
            try
            {
                var lines = System.IO.File.ReadAllLines(filePath);

                using (var connection = new SQLiteConnection(dbHelper.ConnectionString))
                {
                    connection.Open();

                    foreach (var line in lines.Skip(1)) // Skip the header row
                    {
                        var values = line.Split(',');

                        if (values.Length >= 6) 
                        {
                            string name = values[0].Trim();
                            string phone = values[1].Trim();
                            string email = values[2].Trim();
                            DateTime appointmentDate = DateTime.Parse(values[3].Trim());
                            string clientType = values[4].Trim();
                            decimal downPayment = decimal.TryParse(values[5].Trim(), out decimal dp) ? dp : 0;

                            string sql = "INSERT INTO Leads (Name, Phone, Email, AppointmentDate, ClientType, DownPayment) VALUES (@Name, @Phone, @Email, @AppointmentDate, @ClientType, @DownPayment)";

                            using (var command = new SQLiteCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@Name", name);
                                command.Parameters.AddWithValue("@Phone", phone);
                                command.Parameters.AddWithValue("@Email", email);
                                command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                                command.Parameters.AddWithValue("@ClientType", clientType);
                                command.Parameters.AddWithValue("@DownPayment", downPayment);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("CSV data imported successfully!");
                editProfileForm.LoadLeads(); // Refresh DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing CSV: {ex.Message}");
            }
        }


        private void comboBoxMetrics_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAllCounts();
            Console.WriteLine($"ComboBox changed to: {comboBoxMetrics.SelectedItem}");
            UpdateRates();
            UpdateTotalDownPayments();
        }
    }
}