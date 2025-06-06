// Matt Deinlein[mattdeinlein@gmail.com]
// @version: 1.0 06.06.2025
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;          
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using BookKeeping;
using System.Diagnostics;
using static BookKeeping.ComparisonForm;

namespace BookKeeping
{
    public class DatabaseHelper
    {
        // Private field for connectionString
        private string connectionString;

        // Public read-only property for the connection string
        public string ConnectionString
        {
            get
            {
                // Dynamically build the connection string every time it is accessed
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string databaseFolder = Path.Combine(appDataPath, "BookKeeping");
                Directory.CreateDirectory(databaseFolder); // Ensure the folder exists
                string databasePath = Path.Combine(databaseFolder, "JimmyDB.db");


                // Build and return the connection string
                return $"Data Source={databasePath};Version=3;";
            }
        }
        // Constructor to initialize the database and create tables if they don't exist
        public DatabaseHelper()
        {
            connectionString = ConnectionString;
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(connection);

                // Check if the Leads table exists and add the new columns if needed
                command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Leads (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT,
                Phone TEXT,
                Email TEXT,
                AppointmentDate TEXT,  
                ClientType TEXT,
                CreatedTime DATETIME,
                downPayment REAL DEFAULT 0,
                Notes TEXT)" ;      

                command.ExecuteNonQuery();

                // If the AppointmentDate column does not exist, alter the table
                command.CommandText = @"
            SELECT COUNT(*) FROM pragma_table_info('Leads') WHERE name = 'AppointmentDate'";
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 0)
                {
                    command.CommandText = "ALTER TABLE Leads ADD COLUMN AppointmentDate TEXT";
                    command.ExecuteNonQuery();
                }
                // Check if the 'ClientType' column exists
                command.CommandText = @"SELECT COUNT(*) FROM pragma_table_info('Leads') WHERE name = 'ClientType'";
                int clientTypeCount = Convert.ToInt32(command.ExecuteScalar());

                // If the 'ClientType' column does not exist, alter the table
                if (clientTypeCount == 0)
                {
                    command.CommandText = "ALTER TABLE Leads ADD COLUMN ClientType TEXT";
                    command.ExecuteNonQuery();
                }
                // Check if the 'downPayment' column exists
                command.CommandText = @"SELECT COUNT(*) FROM pragma_table_info('Leads') WHERE LOWER(name) = 'downpayment'";
                int downPaymentCount = Convert.ToInt32(command.ExecuteScalar());

                // If the 'downPayment' column does not exist, alter the table
                if (downPaymentCount == 0)
                {
                    command.CommandText = "ALTER TABLE Leads ADD COLUMN downPayment REAL DEFAULT 0;";
                    command.ExecuteNonQuery();
                }
                // Check if the 'Notes' column exists
                command.CommandText = @"SELECT COUNT(*) FROM pragma_table_info('Leads') WHERE name = 'Notes'";
                int notesCount = Convert.ToInt32(command.ExecuteScalar());

                // If the 'Notes' column does not exist, alter the table
                if (notesCount == 0)
                {
                    command.CommandText = "ALTER TABLE Leads ADD COLUMN Notes TEXT";
                    command.ExecuteNonQuery();
                }
                // Create Appointments table
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Appointments (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                LeadId INTEGER,
                                Date TEXT,
                                Time TEXT,
                                Status TEXT,
                                FOREIGN KEY (LeadId) REFERENCES Leads(Id))";
                command.ExecuteNonQuery();
                string createStatusHistoryTable = @"
            CREATE TABLE IF NOT EXISTS StatusHistory (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                ProfileId INTEGER NOT NULL,
                Status TEXT NOT NULL,
                StatusChangedTime DATETIME NOT NULL,
                FOREIGN KEY(ProfileId) REFERENCES Leads(ProfileId)
            );
        ";
            }
        }
        public decimal GetTotalDownPayments(string timeSpan)
        {
            decimal total = 0;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string sql = "SELECT SUM(DownPayment) FROM Leads"; // Default query

                switch (timeSpan)
                {
                    case "Day":
                        sql += " WHERE DATE(AppointmentDate) = DATE('now')";
                        break;
                    case "Week":
                        sql += " WHERE DATE(AppointmentDate) BETWEEN DATE('now', 'weekday 0', '-6 days') AND DATE('now', 'weekday 0')";
                        break;
                    case "Month":
                        sql += " WHERE strftime('%Y-%m', AppointmentDate) = strftime('%Y-%m', 'now')";
                        break;
                    case "Year":
                        sql += " WHERE strftime('%Y', AppointmentDate) = strftime('%Y', 'now')";
                        break;
                }

                using (var command = new SQLiteCommand(sql, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        total = Convert.ToDecimal(result);
                    }
                }
            }
            return total;
        }

        public DataTable GetLeadsDataTable()
        {
            DataTable dataTable = new DataTable();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT * FROM Leads", connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable); // Fill the DataTable with the query results
                    }
                }
            }

            return dataTable;
        }
        // Add a new lead to the Leads table
        public int AddLead(string name, string phone, string email, string appointmentDate, string clientType, string createdTime, double downPayment, string notes)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Leads (Name, Phone, Email, AppointmentDate, ClientType, CreatedTime, downPayment, Notes) " +
                             "VALUES (@Name, @Phone, @Email, @AppointmentDate, @ClientType, @CreatedTime, @downPayment, @Notes); " +
                             "SELECT last_insert_rowid();";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@ClientType", clientType);
                    command.Parameters.AddWithValue("@CreatedTime", createdTime); // Add created time here
                    command.Parameters.AddWithValue("@downPayment", downPayment);
                    command.Parameters.AddWithValue("@Notes", notes);

                    int newId = Convert.ToInt32(command.ExecuteScalar());
                    return newId;
                }
            }
        }


        // Method to get the last user ID from the database
        private string GetLastId(SQLiteConnection connection)
        {
            string sql = "SELECT Id FROM Leads ORDER BY Id DESC LIMIT 1";
            using (var command = new SQLiteCommand(sql, connection))
            {
                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : null;
            }
        }

        // Method to generate the next user ID based on the last one
        private string GenerateNextId(string lastId)
        {
            if (string.IsNullOrEmpty(lastId))
            {
                return "TECT0001";  // If no users exist, start with TECT0001
            }

            // Extract the numeric part of the last ID
            string numericPart = lastId.Substring(4);  
            int nextNumber = int.Parse(numericPart) + 1;  

            // Pad the number with leading zeros to maintain the format TECTXXXX
            return "TECT" + nextNumber.ToString("D4");
        }
    

    // Add a new appointment to the Appointments table
    public void AddAppointment(int leadId, string date, string time, string status)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO Appointments (LeadId, Date, Time, Status) VALUES (@leadId, @date, @time, @status)";
                command.Parameters.AddWithValue("@leadId", leadId);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@time", time);
                command.Parameters.AddWithValue("@status", status);
                command.ExecuteNonQuery();
            }
        }

        // Retrieve all leads from the Leads table
        public SQLiteDataReader GetLeads()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM Leads", connection);
            return command.ExecuteReader();
        }

        // Retrieve all appointments from the Appointments table
        public SQLiteDataReader GetAppointments()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM Appointments", connection);
            return command.ExecuteReader();
        }

        // Update lead details (if needed)
        public void UpdateLead(int leadId, string name, string phone, string email)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(connection);
                command.CommandText = "UPDATE Leads SET Name = @name, Phone = @phone, Email = @Email WHERE Id = @id";
                command.Parameters.AddWithValue("@id", leadId);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteNonQuery();
            }
        }
        public User GetUserByDetails(string name, string phone, string email)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Leads WHERE Name = @Name OR Phone = @Phone OR Email = @Email";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Name = reader["Name"]?.ToString() ?? string.Empty,  // Handle potential null
                                Phone = reader["Phone"]?.ToString() ?? string.Empty,  // Handle potential null
                                Email = reader["Email"]?.ToString() ?? string.Empty   // Handle potential null
                            };
                        }
                    }
                }
            }
            return null; // Return null if no user was found
        }


        public void UpdateUser(int Id, string name, string phone, string email, DateTime appointmentDate, string clientType, decimal downPayment, string notes)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string sql = @"UPDATE Leads 
                       SET Name = @Name, 
                           Phone = @Phone, 
                           Email = @Email, 
                           AppointmentDate = @AppointmentDate, 
                           ClientType = @ClientType, 
                           DownPayment = @DownPayment ,
                           Notes = @Notes 
                       WHERE Id = @Id";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@ClientType", clientType);
                    command.Parameters.AddWithValue("@DownPayment", downPayment);
                    command.Parameters.AddWithValue("@Notes", notes);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void DeleteLead(int leadId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Leads WHERE Id = @Id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", leadId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<string> GetAppointmentsByDate(DateTime date)
        {
            List<string> appointments = new List<string>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = @"
            SELECT Name, Time, Status 
            FROM Appointments 
            JOIN Leads ON Appointments.LeadId = Leads.Id 
            WHERE Date = @Date";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd HH:mm"));
                    Debug.WriteLine($"Executing SQL: {sql} with Date: {date.ToString("yyyy-MM-dd HH:mm")}"); 

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string appointmentInfo = $"Name: {reader["Name"]}, Time: {reader["Time"]}, Status: {reader["Status"]}";
                            appointments.Add(appointmentInfo);
                            Debug.WriteLine($"Retrieved Appointment: {appointmentInfo}"); 
                        }
                    }
                }
            }

            if (appointments.Count == 0)
            {
                Debug.WriteLine("No appointments found for this date."); 
            }

            return appointments;
        }

        public DataTable GetAllAppointments()
        {
            DataTable appointmentsTable = new DataTable();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT Leads.Name, Appointments.Date, Appointments.Time, Appointments.Status " +
                             "FROM Appointments JOIN Leads ON Appointments.LeadId = Leads.Id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(appointmentsTable);
                    }
                }
            }

            return appointmentsTable;
        }
        public ClientMetrics GetMetrics(DateTime start, DateTime end)
        {
            var metrics = new ClientMetrics();

            int rawLeads = GetCount("Lead", start, end);
            int rawSet = GetCount("Set", start, end);
            int rawShowed = GetCount("Showed", start, end);
            int rawClosed = GetCount("Closed", start, end);
            int rawRescheduled = GetCount("Rescheduled", start, end);
            decimal downPaymentTotal = GetDownPaymentTotal(start, end);

            // Accumulate dependency-based counts
            int leadCount = rawLeads;
            int setCount = rawSet;
            int showedCount = rawShowed;
            int closedCount = rawClosed;
            int rescheduledCount = rawRescheduled;

            // Lead gets incremented by all dependent types
            leadCount += rawSet + rawShowed + rawClosed + rawRescheduled;

            // Set gets incremented by its dependents
            setCount += rawShowed + rawClosed + rawRescheduled;

            // Showed gets incremented by Closed
            showedCount += rawClosed;

            // Now populate metrics
            metrics.LeadCount = leadCount;
            metrics.SetCount = setCount;
            metrics.ShowedCount = showedCount;
            metrics.ClosedCount = rawClosed;
            metrics.RescheduledCount = rawRescheduled;
            metrics.DownPaymentTotal = downPaymentTotal;

            return metrics;
        }
        private int GetCount(string clientType, DateTime start, DateTime end)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Leads WHERE ClientType = @type AND CreatedTime BETWEEN @start AND @end";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@type", clientType);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private decimal GetDownPaymentTotal(DateTime start, DateTime end)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT SUM(DownPayment) FROM Leads WHERE CreatedTime BETWEEN @start AND @end";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }
        public User GetUserById(int Id) // Change parameter type to int
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Leads WHERE Id = @Id";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id); // Use int directly
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["Id"]), // Keep as string if you plan to store as text
                                Name = reader["Name"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                        }
                    }
                }
            }

            return null;  // User not found
        }

    }
}

