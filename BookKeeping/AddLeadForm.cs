using BookKeeping;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Text;
using System;
using Windows.Graphics;

// Matt Deinlein[mattdeinlein@gmail.com]
// @version: 1.0 06.06.2025

using System;
using System.Windows.Forms;

namespace BookKeeping
{
    public partial class AddLeadForm : Form
    {
        private DatabaseHelper dbHelper;
        public string NewId { get; private set; } // Store the new user's ID
        private Form1 mainForm;
        public AddLeadForm(Form1 mainForm)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadClientTypes(); // Load client types into the ComboBox
            this.mainForm = mainForm;
            dateTimePickerAppointmentDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerAppointmentDate.CustomFormat = "yyyy-MM-dd HH:mm:ss"; // 24-hour format
        }

        private void LoadClientTypes()
        {
            //Sets the Client Types
            comboBoxClientType.Items.Add("Lead");
            comboBoxClientType.Items.Add("Set");
            comboBoxClientType.Items.Add("Showed");
            comboBoxClientType.Items.Add("Rescheduled");
            comboBoxClientType.Items.Add("Closed");
        }
        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and control keys (backspace, delete)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string appointmentDate = dateTimePickerAppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string clientType = comboBoxClientType.SelectedItem?.ToString();
            string createdTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            double downPayment = double.TryParse(txtPayment.Text, out double payment) ? payment : 0;
            string notes = rtbNotes.Text.Trim(); 
            mainForm.UpdateAllCounts();  // Refreshes all lead status counts
            mainForm.UpdateRates();      // Recalculates conversion rates



            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone) &&
                !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(clientType))
            {
                int newId = dbHelper.AddLead(name, phone, email, appointmentDate, clientType, createdTime, downPayment, notes);
                MessageBox.Show("Lead added successfully with ID: " + newId);

                this.Close(); 
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
            this.Close(); 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
