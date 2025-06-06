namespace BookKeeping
{
    partial class EmailGroupForm
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
            richTextBoxMessageBody = new RichTextBox();
            comboBoxType = new ComboBox();
            btnSend = new Button();
            btnExit = new Button();
            label1 = new Label();
            txtSubject = new TextBox();
            btnAttachImage = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // richTextBoxMessageBody
            // 
            richTextBoxMessageBody.Location = new Point(12, 12);
            richTextBoxMessageBody.Name = "richTextBoxMessageBody";
            richTextBoxMessageBody.Size = new Size(603, 426);
            richTextBoxMessageBody.TabIndex = 0;
            richTextBoxMessageBody.Text = "";
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(621, 12);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(167, 28);
            comboBoxType.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(621, 374);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(167, 29);
            btnSend.TabIndex = 2;
            btnSend.Text = "&Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(621, 409);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(167, 29);
            btnExit.TabIndex = 3;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(621, 66);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 4;
            label1.Text = "Subject:";
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(621, 89);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(167, 27);
            txtSubject.TabIndex = 5;
            // 
            // btnAttachImage
            // 
            btnAttachImage.Location = new Point(621, 140);
            btnAttachImage.Name = "btnAttachImage";
            btnAttachImage.Size = new Size(167, 29);
            btnAttachImage.TabIndex = 6;
            btnAttachImage.Text = "&Attach Image";
            btnAttachImage.UseVisualStyleBackColor = true;
            btnAttachImage.Click += btnAttachImage_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.Multiselect = true;
            // 
            // EmailGroupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAttachImage);
            Controls.Add(txtSubject);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnSend);
            Controls.Add(comboBoxType);
            Controls.Add(richTextBoxMessageBody);
            Name = "EmailGroupForm";
            Text = "EmailGroupForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnAttachImage_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private RichTextBox richTextBoxMessageBody;
        private ComboBox comboBoxType;
        private Button btnSend;
        private Button btnExit;
        private Label label1;
        private TextBox txtSubject;
        private Button btnAttachImage;
        private OpenFileDialog openFileDialog1;
    }
}