namespace BookKeeping
{
    partial class AddLeadForm
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
            label1 = new Label();
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            label2 = new Label();
            textBoxPhone = new TextBox();
            label3 = new Label();
            buttonSave = new Button();
            btnExit = new Button();
            label4 = new Label();
            label5 = new Label();
            comboBoxClientType = new ComboBox();
            dateTimePickerAppointmentDate = new DateTimePicker();
            txtPayment = new TextBox();
            lblPayment = new Label();
            rtbNotes = new RichTextBox();
            lblNotes = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(68, 28);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(102, 10);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(355, 27);
            textBoxName.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(102, 112);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(355, 27);
            textBoxEmail.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 111);
            label2.Name = "label2";
            label2.Size = new Size(71, 28);
            label2.TabIndex = 2;
            label2.Text = "E-mail:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(102, 61);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(355, 27);
            textBoxPhone.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 58);
            label3.Name = "label3";
            label3.Size = new Size(71, 28);
            label3.TabIndex = 4;
            label3.Text = "Phone:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 307);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(107, 36);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "&Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(352, 307);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(105, 36);
            btnExit.TabIndex = 7;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 157);
            label4.Name = "label4";
            label4.Size = new Size(133, 28);
            label4.TabIndex = 9;
            label4.Text = "Appointment:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(12, 210);
            label5.Name = "label5";
            label5.Size = new Size(57, 28);
            label5.TabIndex = 8;
            label5.Text = "Type:";
            // 
            // comboBoxClientType
            // 
            comboBoxClientType.FormattingEnabled = true;
            comboBoxClientType.Location = new Point(102, 210);
            comboBoxClientType.Name = "comboBoxClientType";
            comboBoxClientType.Size = new Size(355, 28);
            comboBoxClientType.TabIndex = 5;
            // 
            // dateTimePickerAppointmentDate
            // 
            dateTimePickerAppointmentDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerAppointmentDate.Location = new Point(151, 158);
            dateTimePickerAppointmentDate.Name = "dateTimePickerAppointmentDate";
            dateTimePickerAppointmentDate.Size = new Size(306, 27);
            dateTimePickerAppointmentDate.TabIndex = 4;
            // 
            // txtPayment
            // 
            txtPayment.Location = new Point(165, 263);
            txtPayment.Name = "txtPayment";
            txtPayment.Size = new Size(292, 27);
            txtPayment.TabIndex = 11;
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Font = new Font("Segoe UI", 12F);
            lblPayment.Location = new Point(12, 262);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(147, 28);
            lblPayment.TabIndex = 10;
            lblPayment.Text = "Down Payment:";
            // 
            // rtbNotes
            // 
            rtbNotes.Location = new Point(483, 41);
            rtbNotes.Name = "rtbNotes";
            rtbNotes.Size = new Size(532, 298);
            rtbNotes.TabIndex = 12;
            rtbNotes.Text = "";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 12F);
            lblNotes.Location = new Point(483, 10);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(68, 28);
            lblNotes.TabIndex = 13;
            lblNotes.Text = "Notes:";
            // 
            // AddLeadForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 351);
            Controls.Add(lblNotes);
            Controls.Add(rtbNotes);
            Controls.Add(txtPayment);
            Controls.Add(lblPayment);
            Controls.Add(dateTimePickerAppointmentDate);
            Controls.Add(comboBoxClientType);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(btnExit);
            Controls.Add(buttonSave);
            Controls.Add(textBoxPhone);
            Controls.Add(label3);
            Controls.Add(textBoxEmail);
            Controls.Add(label2);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Name = "AddLeadForm";
            Text = "Add Lead";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private Label label2;
        private TextBox textBoxPhone;
        private Label label3;
        private Button buttonSave;
        private Button btnExit;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxClientType;
        private DateTimePicker dateTimePickerAppointmentDate;
        private TextBox txtPayment;
        private Label lblPayment;
        private RichTextBox rtbNotes;
        private Label lblNotes;
    }
}