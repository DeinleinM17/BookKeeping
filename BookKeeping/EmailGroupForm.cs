// Matt Deinlein[mattdeinlein@gmail.com]
// @version: 1.0 06.06.2025
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;

namespace BookKeeping
{
    public partial class EmailGroupForm : Form
    {
        private DatabaseHelper dbHelper;
        private string senderEmail = "Fake Email";  // Replace with your sender email
        private string senderPassword = "Fake Password"; // Replace with your email password
        private List<string> attachedImages = new List<string>(); 

        public EmailGroupForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            InitializeComboBox();  
        }

        private void InitializeComboBox()
        {
            comboBoxType.Items.AddRange(new string[] { "Lead", "Set", "Showed", "Rescheduled", "Closed" });
            comboBoxType.SelectedIndex = 0;  // Set default selection to "Lead"
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string selectedType = comboBoxType.SelectedItem.ToString();
            string messageBody = richTextBoxMessageBody.Text;
            string emailSubject = txtSubject.Text; 

            // Get the emails based on the selected client type
            List<string> emailList = GetEmailsByClientType(selectedType);

            if (emailList.Count == 0)
            {
                MessageBox.Show("No emails found for the selected client type.");
                return;
            }

            // Send the email to each address
            foreach (string email in emailList)
            {
                try
                {
                    SendEmail(email, emailSubject, messageBody, attachedImages);  // Pass the list of image paths
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to send email to {email}: {ex.Message}");
                }
            }

            // Display a success message after sending all emails
            MessageBox.Show("Emails sent successfully!");
        }

        // Method to retrieve emails based on the selected client type
        private List<string> GetEmailsByClientType(string clientType)
        {
            List<string> emails = new List<string>();

            using (var connection = new SQLiteConnection(dbHelper.ConnectionString))
            {
                connection.Open();

                // SQL query to retrieve emails based on the selected client type
                string sql = "SELECT Email FROM Leads WHERE ClientType = @ClientType";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ClientType", clientType);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string email = reader["Email"].ToString();
                            if (!string.IsNullOrEmpty(email))
                            {
                                emails.Add(email);
                            }
                        }
                    }
                }
            }

            return emails;
        }

        // Method to send an email with dynamic subject and image attachments
        private void SendEmail(string recipientEmail, string subject, string messageBody, List<string> attachments)
        {
            using (var client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;  // Use the appropriate SMTP port (587 for TLS)
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = subject,  // Set the subject dynamically
                    Body = messageBody,
                    IsBodyHtml = false  // Set to true if you want to send HTML emails
                };
                mailMessage.To.Add(recipientEmail);

                // Attach each image file
                foreach (string filePath in attachments)
                {
                    if (File.Exists(filePath))
                    {
                        Attachment attachment = new Attachment(filePath);
                        mailMessage.Attachments.Add(attachment);
                    }
                    else
                    {
                        MessageBox.Show($"File not found: {filePath}");
                    }
                }

                client.Send(mailMessage);
            }
        }

        // Method to attach images
        private void btnAttachImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Add each selected file path to the list
                    attachedImages.AddRange(openFileDialog.FileNames);
                    MessageBox.Show($"{openFileDialog.FileNames.Length} images attached.");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
