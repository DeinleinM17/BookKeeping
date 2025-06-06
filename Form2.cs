// Matt Deinlein[mattdeinlein@gmail.com]
// @version: 1.0 06.06.2025
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;

namespace BookKeeping
{
    public partial class CalendarForm : Form
    {
        private DatabaseHelper dbHelper;
        private List<DateTime> appointmentDates;  // Store dates (only) with appointments for highlighting
        private Dictionary<DateTime, List<string>> appointmentsByDate; // Map date to appointments with time

        public CalendarForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            appointmentDates = new List<DateTime>();
            appointmentsByDate = new Dictionary<DateTime, List<string>>();

            // Load appointments from the database and store them
            LoadAppointments();

            // Handle the DateChanged event to display appointments when a date is clicked
            monthCalendar1.DateChanged += MonthCalendar1_DateChanged;

            // Highlight the dates with appointments
            HighlightAppointmentDates();
        }

        // Load appointments from the Leads table
        private void LoadAppointments()
        {
            appointmentsByDate.Clear();  // Clear existing data
            appointmentDates.Clear();    // Clear existing dates

            using (var connection = new SQLiteConnection(dbHelper.ConnectionString))
            {
                connection.Open();

                // Query to retrieve all appointments individually
                string sql = "SELECT AppointmentDate, Name, Phone, Email, Notes FROM Leads WHERE AppointmentDate IS NOT NULL";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dateString = reader["AppointmentDate"].ToString();
                            DateTime appointmentDate;

                            // Parse both date and time from AppointmentDate, including seconds
                            if (DateTime.TryParseExact(dateString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out appointmentDate))
                            {
                                // Create an appointment detail including time
                                string appointmentDetails = $"Time: {appointmentDate:HH:mm:ss} - Name: {reader["Name"]}, Phone: {reader["Phone"]}, Email: {reader["Email"]}, Notes: {reader["Notes"]}";

                                // Use the date part for the dictionary key (date-only)
                                DateTime dateOnly = appointmentDate.Date;  // Ignore time for grouping by date

                                if (!appointmentsByDate.ContainsKey(dateOnly))
                                {
                                    appointmentsByDate[dateOnly] = new List<string>();
                                    appointmentDates.Add(dateOnly);  // Add only the date part for highlighting
                                }

                                // Add the appointment to the list for this date
                                appointmentsByDate[dateOnly].Add(appointmentDetails);
                            }
                        }
                    }
                }
            }

            // Debugging output: print the number of appointments loaded
            Console.WriteLine($"Total appointments loaded: {appointmentsByDate.Count}");
            foreach (var date in appointmentsByDate)
            {
                Console.WriteLine($"Date: {date.Key.ToShortDateString()} - Appointments: {date.Value.Count}");
            }
        }

        // Display appointments when a date is selected
        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start.Date;  // Use the date-only part to find appointments for that day

            // Clear existing text in the TextBox
            txtAppointments.Clear();

            // Filter the appointments for the selected date
            var appointmentsForSelectedDate = appointmentsByDate
                .Where(kvp => kvp.Key == selectedDate)
                .SelectMany(kvp => kvp.Value)  // Flatten the list of appointments for the selected date
                .ToList();

            // Debugging output: print the appointments for the selected date
            Console.WriteLine($"Appointments for {selectedDate.ToShortDateString()}: {appointmentsForSelectedDate.Count}");

            // Display the appointments for the selected date
            if (appointmentsForSelectedDate.Count > 0)
            {
                txtAppointments.Text = $"{appointmentsForSelectedDate.Count} Appointment(s) on {selectedDate.ToShortDateString()}:" + Environment.NewLine + Environment.NewLine
                    + string.Join(Environment.NewLine, appointmentsForSelectedDate);
            }
            else
            {
                txtAppointments.Text = $"No appointments on {selectedDate.ToShortDateString()}.\n";
            }
        }



        // Highlight dates with appointments
        private void HighlightAppointmentDates()
        {
            monthCalendar1.RemoveAllBoldedDates();

            // Highlight all dates that have appointments
            foreach (var date in appointmentDates)
            {
                monthCalendar1.AddBoldedDate(date);
            }

            // Refresh the calendar to apply bolded dates
            monthCalendar1.UpdateBoldedDates();
        }




    }
}
