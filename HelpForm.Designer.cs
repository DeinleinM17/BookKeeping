namespace BookKeeping
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            rtbGlossary = new RichTextBox();
            SuspendLayout();
            // 
            // rtbGlossary
            // 
            rtbGlossary.Location = new Point(0, 1);
            rtbGlossary.Name = "rtbGlossary";
            rtbGlossary.ReadOnly = true;
            rtbGlossary.Size = new Size(799, 446);
            rtbGlossary.TabIndex = 0;
            rtbGlossary.Text = resources.GetString("rtbGlossary.Text");
            // 
            // HelpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 398);
            Controls.Add(rtbGlossary);
            Name = "HelpForm";
            Text = "HelpForm";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbGlossary;
    }
}