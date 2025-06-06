namespace BookKeeping
{
    partial class EditProfileForm
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
            btnCancel = new Button();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            btnSave = new Button();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            txtSearch = new TextBox();
            label4 = new Label();
            label5 = new Label();
            comboBoxClientType = new ComboBox();
            dateTimePickerAppointmentDate = new DateTimePicker();
            btnRefresh = new Button();
            txtDownPayment = new TextBox();
            lblPayment = new Label();
            rtbNotes = new RichTextBox();
            lblNotes = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(110, 472);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(68, 28);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(86, 13);
            txtName.Name = "txtName";
            txtName.Size = new Size(220, 27);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(63, 28);
            label2.TabIndex = 3;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 48);
            label3.Name = "label3";
            label3.Size = new Size(71, 28);
            label3.TabIndex = 4;
            label3.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(86, 52);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(220, 27);
            txtPhone.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(86, 89);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 27);
            txtEmail.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(10, 472);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "S&ave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(12, 438);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "&Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(312, 9);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(718, 502);
            dataGridView1.TabIndex = 10;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 405);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(294, 27);
            txtSearch.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 127);
            label4.Name = "label4";
            label4.Size = new Size(133, 28);
            label4.TabIndex = 11;
            label4.Text = "Appointment:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(12, 171);
            label5.Name = "label5";
            label5.Size = new Size(57, 28);
            label5.TabIndex = 13;
            label5.Text = "Type:";
            // 
            // comboBoxClientType
            // 
            comboBoxClientType.FormattingEnabled = true;
            comboBoxClientType.Location = new Point(86, 171);
            comboBoxClientType.Name = "comboBoxClientType";
            comboBoxClientType.Size = new Size(220, 28);
            comboBoxClientType.TabIndex = 5;
            // 
            // dateTimePickerAppointmentDate
            // 
            dateTimePickerAppointmentDate.Location = new Point(151, 129);
            dateTimePickerAppointmentDate.Name = "dateTimePickerAppointmentDate";
            dateTimePickerAppointmentDate.Size = new Size(155, 27);
            dateTimePickerAppointmentDate.TabIndex = 4;
            dateTimePickerAppointmentDate.Value = new DateTime(2024, 10, 23, 3, 9, 15, 0);
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(210, 472);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "&Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtDownPayment
            // 
            txtDownPayment.Location = new Point(165, 213);
            txtDownPayment.Name = "txtDownPayment";
            txtDownPayment.Size = new Size(141, 27);
            txtDownPayment.TabIndex = 15;
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Font = new Font("Segoe UI", 12F);
            lblPayment.Location = new Point(12, 213);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(147, 28);
            lblPayment.TabIndex = 16;
            lblPayment.Text = "Down Payment:";
            // 
            // rtbNotes
            // 
            rtbNotes.Location = new Point(12, 277);
            rtbNotes.Name = "rtbNotes";
            rtbNotes.Size = new Size(294, 112);
            rtbNotes.TabIndex = 17;
            rtbNotes.Text = "";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 12F);
            lblNotes.Location = new Point(12, 246);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(68, 28);
            lblNotes.TabIndex = 18;
            lblNotes.Text = "Notes:";
            // 
            // EditProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 513);
            Controls.Add(lblNotes);
            Controls.Add(rtbNotes);
            Controls.Add(txtDownPayment);
            Controls.Add(lblPayment);
            Controls.Add(btnRefresh);
            Controls.Add(dateTimePickerAppointmentDate);
            Controls.Add(comboBoxClientType);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtSearch);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Name = "EditProfileForm";
            Text = "EditProfileForm";
            Load += EditProfileForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private Label label3;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private Button btnSave;
        private Button btnSearch;
        private DataGridView dataGridView1;
        private TextBox txtSearch;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxClientType;
        private DateTimePicker dateTimePickerAppointmentDate;
        private Button btnRefresh;
        private TextBox txtDownPayment;
        private Label lblPayment;
        private RichTextBox rtbNotes;
        private Label lblNotes;
    }
}