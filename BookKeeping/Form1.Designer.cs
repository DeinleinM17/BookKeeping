namespace BookKeeping
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            btnEmail = new Button();
            btnViewCalendar = new Button();
            btnEditProf = new Button();
            btnAddLead = new Button();
            label1 = new Label();
            listBoxAppointments = new ListBox();
            btnHelp = new Button();
            label2 = new Label();
            comboBoxMetrics = new ComboBox();
            groupBox1 = new GroupBox();
            txtRescheduleRate = new TextBox();
            txtClosedRate = new TextBox();
            txtShowRate = new TextBox();
            txtSetRate = new TextBox();
            txtDownPayments = new TextBox();
            txtRescheduled = new TextBox();
            txtClosed = new TextBox();
            txtShowed = new TextBox();
            txtSet = new TextBox();
            txtLeads = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnComparison = new Button();
            btnExport = new Button();
            btnRefresh = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(662, 401);
            button1.Name = "button1";
            button1.Size = new Size(126, 37);
            button1.TabIndex = 10;
            button1.Text = "E&xit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnEmail
            // 
            btnEmail.Location = new Point(662, 181);
            btnEmail.Name = "btnEmail";
            btnEmail.Size = new Size(125, 37);
            btnEmail.TabIndex = 6;
            btnEmail.Text = "Email Group";
            btnEmail.UseVisualStyleBackColor = true;
            btnEmail.Click += btnEmail_Click;
            // 
            // btnViewCalendar
            // 
            btnViewCalendar.Location = new Point(663, 138);
            btnViewCalendar.Name = "btnViewCalendar";
            btnViewCalendar.Size = new Size(125, 37);
            btnViewCalendar.TabIndex = 5;
            btnViewCalendar.Text = "View Calendar";
            btnViewCalendar.UseVisualStyleBackColor = true;
            btnViewCalendar.Click += btnViewCalendar_Click;
            // 
            // btnEditProf
            // 
            btnEditProf.Location = new Point(663, 95);
            btnEditProf.Name = "btnEditProf";
            btnEditProf.Size = new Size(125, 37);
            btnEditProf.TabIndex = 4;
            btnEditProf.Text = "Edit Profile";
            btnEditProf.UseVisualStyleBackColor = true;
            btnEditProf.Click += btnEditProf_Click;
            // 
            // btnAddLead
            // 
            btnAddLead.Location = new Point(663, 52);
            btnAddLead.Name = "btnAddLead";
            btnAddLead.Size = new Size(125, 37);
            btnAddLead.TabIndex = 3;
            btnAddLead.Text = "Add Lead";
            btnAddLead.UseVisualStyleBackColor = true;
            btnAddLead.Click += btnAddLead_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(176, 20);
            label1.TabIndex = 0;
            label1.Text = "Upcoming Appointments";
            // 
            // listBoxAppointments
            // 
            listBoxAppointments.FormattingEnabled = true;
            listBoxAppointments.HorizontalScrollbar = true;
            listBoxAppointments.Location = new Point(12, 32);
            listBoxAppointments.Name = "listBoxAppointments";
            listBoxAppointments.Size = new Size(176, 404);
            listBoxAppointments.TabIndex = 7;
            listBoxAppointments.TabStop = false;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(663, 9);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(125, 37);
            btnHelp.TabIndex = 2;
            btnHelp.Text = "Help";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(6, 20);
            label2.Name = "label2";
            label2.Size = new Size(178, 23);
            label2.TabIndex = 9;
            label2.Text = "Metrics From the Last:";
            // 
            // comboBoxMetrics
            // 
            comboBoxMetrics.FormattingEnabled = true;
            comboBoxMetrics.Location = new Point(199, 20);
            comboBoxMetrics.Name = "comboBoxMetrics";
            comboBoxMetrics.Size = new Size(245, 28);
            comboBoxMetrics.TabIndex = 1;
            comboBoxMetrics.SelectedIndexChanged += comboBoxMetrics_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtRescheduleRate);
            groupBox1.Controls.Add(txtClosedRate);
            groupBox1.Controls.Add(txtShowRate);
            groupBox1.Controls.Add(txtSetRate);
            groupBox1.Controls.Add(txtDownPayments);
            groupBox1.Controls.Add(txtRescheduled);
            groupBox1.Controls.Add(txtClosed);
            groupBox1.Controls.Add(txtShowed);
            groupBox1.Controls.Add(txtSet);
            groupBox1.Controls.Add(txtLeads);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(comboBoxMetrics);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(194, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(462, 429);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            // 
            // txtRescheduleRate
            // 
            txtRescheduleRate.Location = new Point(148, 372);
            txtRescheduleRate.Name = "txtRescheduleRate";
            txtRescheduleRate.Size = new Size(74, 27);
            txtRescheduleRate.TabIndex = 26;
            txtRescheduleRate.TabStop = false;
            // 
            // txtClosedRate
            // 
            txtClosedRate.Location = new Point(148, 339);
            txtClosedRate.Name = "txtClosedRate";
            txtClosedRate.Size = new Size(74, 27);
            txtClosedRate.TabIndex = 25;
            txtClosedRate.TabStop = false;
            // 
            // txtShowRate
            // 
            txtShowRate.Location = new Point(148, 306);
            txtShowRate.Name = "txtShowRate";
            txtShowRate.Size = new Size(74, 27);
            txtShowRate.TabIndex = 24;
            txtShowRate.TabStop = false;
            // 
            // txtSetRate
            // 
            txtSetRate.Location = new Point(148, 273);
            txtSetRate.Name = "txtSetRate";
            txtSetRate.Size = new Size(74, 27);
            txtSetRate.TabIndex = 23;
            txtSetRate.TabStop = false;
            // 
            // txtDownPayments
            // 
            txtDownPayments.Location = new Point(148, 217);
            txtDownPayments.Name = "txtDownPayments";
            txtDownPayments.Size = new Size(74, 27);
            txtDownPayments.TabIndex = 22;
            txtDownPayments.TabStop = false;
            // 
            // txtRescheduled
            // 
            txtRescheduled.Location = new Point(148, 184);
            txtRescheduled.Name = "txtRescheduled";
            txtRescheduled.Size = new Size(74, 27);
            txtRescheduled.TabIndex = 21;
            txtRescheduled.TabStop = false;
            // 
            // txtClosed
            // 
            txtClosed.Location = new Point(148, 151);
            txtClosed.Name = "txtClosed";
            txtClosed.Size = new Size(74, 27);
            txtClosed.TabIndex = 20;
            txtClosed.TabStop = false;
            // 
            // txtShowed
            // 
            txtShowed.Location = new Point(148, 118);
            txtShowed.Name = "txtShowed";
            txtShowed.Size = new Size(74, 27);
            txtShowed.TabIndex = 19;
            txtShowed.TabStop = false;
            // 
            // txtSet
            // 
            txtSet.Location = new Point(148, 85);
            txtSet.Name = "txtSet";
            txtSet.Size = new Size(74, 27);
            txtSet.TabIndex = 18;
            txtSet.TabStop = false;
            // 
            // txtLeads
            // 
            txtLeads.Location = new Point(148, 52);
            txtLeads.Name = "txtLeads";
            txtLeads.Size = new Size(74, 27);
            txtLeads.TabIndex = 12;
            txtLeads.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(75, 276);
            label9.Name = "label9";
            label9.Size = new Size(67, 20);
            label9.TabIndex = 12;
            label9.Text = "Set Rate:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(60, 309);
            label10.Name = "label10";
            label10.Size = new Size(82, 20);
            label10.TabIndex = 13;
            label10.Text = "Show Rate:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(51, 342);
            label11.Name = "label11";
            label11.Size = new Size(91, 20);
            label11.TabIndex = 14;
            label11.Text = "Closed Rate:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(21, 375);
            label12.Name = "label12";
            label12.Size = new Size(121, 20);
            label12.TabIndex = 15;
            label12.Text = "Reschedule Rate:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(92, 55);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 12;
            label3.Text = "Leads:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 187);
            label4.Name = "label4";
            label4.Size = new Size(136, 20);
            label4.TabIndex = 13;
            label4.Text = "Appt. Rescheduled:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 220);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 14;
            label5.Text = "Down Payments:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 154);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 15;
            label6.Text = "Appt. Closed:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(69, 88);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 16;
            label7.Text = "Appt. Set:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(37, 121);
            label8.Name = "label8";
            label8.Size = new Size(105, 20);
            label8.TabIndex = 17;
            label8.Text = "Appt. Showed:";
            // 
            // btnComparison
            // 
            btnComparison.Location = new Point(663, 224);
            btnComparison.Name = "btnComparison";
            btnComparison.Size = new Size(125, 37);
            btnComparison.TabIndex = 7;
            btnComparison.Text = "Comparison";
            btnComparison.UseVisualStyleBackColor = true;
            btnComparison.Click += btnComparison_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(663, 309);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(125, 37);
            btnExport.TabIndex = 8;
            btnExport.Text = "Export to CSV";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(663, 352);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(125, 37);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // button2
            // 
            button2.Location = new Point(663, 267);
            button2.Name = "button2";
            button2.Size = new Size(125, 37);
            button2.TabIndex = 12;
            button2.Text = "Import to CSV";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(btnRefresh);
            Controls.Add(btnExport);
            Controls.Add(btnComparison);
            Controls.Add(btnHelp);
            Controls.Add(listBoxAppointments);
            Controls.Add(label1);
            Controls.Add(btnAddLead);
            Controls.Add(btnEditProf);
            Controls.Add(btnViewCalendar);
            Controls.Add(btnEmail);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Bookkeeping";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnEmail;
        private Button btnViewCalendar;
        private Button btnEditProf;
        private Button btnAddLead;
        private Label label1;
        private ListBox listBoxAppointments;
        private Button btnHelp;
        private Label label2;
        private ComboBox comboBoxMetrics;
        private GroupBox groupBox1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label3;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox txtRescheduleRate;
        private TextBox txtClosedRate;
        private TextBox txtShowRate;
        private TextBox txtSetRate;
        private TextBox txtDownPayments;
        private TextBox txtRescheduled;
        private TextBox txtClosed;
        private TextBox txtShowed;
        private TextBox txtSet;
        private TextBox txtLeads;
        private Button btnComparison;
        private Button btnExport;
        private Button btnRefresh;
        private Button button2;
    }
}
