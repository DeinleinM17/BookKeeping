namespace BookKeeping
{
    partial class Profile
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
            lblNotes = new Label();
            rtbNotes = new RichTextBox();
            txtDownPayment = new TextBox();
            lblPayment = new Label();
            dateTimePickerAppointmentDate = new DateTimePicker();
            comboBoxClientType = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 12F);
            lblNotes.Location = new Point(385, 11);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(68, 28);
            lblNotes.TabIndex = 32;
            lblNotes.Text = "Notes:";
            // 
            // rtbNotes
            // 
            rtbNotes.Location = new Point(385, 42);
            rtbNotes.Name = "rtbNotes";
            rtbNotes.Size = new Size(403, 198);
            rtbNotes.TabIndex = 31;
            rtbNotes.Text = "";
            // 
            // txtDownPayment
            // 
            txtDownPayment.Location = new Point(160, 212);
            txtDownPayment.Name = "txtDownPayment";
            txtDownPayment.Size = new Size(219, 27);
            txtDownPayment.TabIndex = 29;
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Font = new Font("Segoe UI", 12F);
            lblPayment.Location = new Point(7, 212);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(147, 28);
            lblPayment.TabIndex = 30;
            lblPayment.Text = "Down Payment:";
            // 
            // dateTimePickerAppointmentDate
            // 
            dateTimePickerAppointmentDate.Location = new Point(146, 128);
            dateTimePickerAppointmentDate.Name = "dateTimePickerAppointmentDate";
            dateTimePickerAppointmentDate.Size = new Size(233, 27);
            dateTimePickerAppointmentDate.TabIndex = 24;
            dateTimePickerAppointmentDate.Value = new DateTime(2024, 10, 23, 3, 9, 15, 0);
            // 
            // comboBoxClientType
            // 
            comboBoxClientType.FormattingEnabled = true;
            comboBoxClientType.Location = new Point(81, 170);
            comboBoxClientType.Name = "comboBoxClientType";
            comboBoxClientType.Size = new Size(298, 28);
            comboBoxClientType.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(7, 170);
            label5.Name = "label5";
            label5.Size = new Size(57, 28);
            label5.TabIndex = 28;
            label5.Text = "Type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(7, 126);
            label4.Name = "label4";
            label4.Size = new Size(133, 28);
            label4.TabIndex = 27;
            label4.Text = "Appointment:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(81, 88);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(298, 27);
            txtEmail.TabIndex = 22;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(81, 51);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(298, 27);
            txtPhone.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(7, 47);
            label3.Name = "label3";
            label3.Size = new Size(71, 28);
            label3.TabIndex = 25;
            label3.Text = "Phone:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(7, 87);
            label2.Name = "label2";
            label2.Size = new Size(63, 28);
            label2.TabIndex = 23;
            label2.Text = "Email:";
            // 
            // txtName
            // 
            txtName.Location = new Point(81, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(298, 27);
            txtName.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(7, 8);
            label1.Name = "label1";
            label1.Size = new Size(68, 28);
            label1.TabIndex = 20;
            label1.Text = "Name:";
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 254);
            Controls.Add(lblNotes);
            Controls.Add(rtbNotes);
            Controls.Add(txtDownPayment);
            Controls.Add(lblPayment);
            Controls.Add(dateTimePickerAppointmentDate);
            Controls.Add(comboBoxClientType);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "Profile";
            Text = "Profile";
            UseWaitCursor = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNotes;
        private RichTextBox rtbNotes;
        private TextBox txtDownPayment;
        private Label lblPayment;
        private DateTimePicker dateTimePickerAppointmentDate;
        private ComboBox comboBoxClientType;
        private Label label5;
        private Label label4;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Label label3;
        private Label label2;
        private TextBox txtName;
        private Label label1;
    }
}