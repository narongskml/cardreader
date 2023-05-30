namespace ThaiIDCardTest
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
            cmbReader = new ComboBox();
            label1 = new Label();
            btRefreshReader = new Button();
            lblLibVersion = new Label();
            txtdata = new TextBox();
            picPhoto = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            SuspendLayout();
            // 
            // cmbReader
            // 
            cmbReader.FormattingEnabled = true;
            cmbReader.Location = new Point(130, 37);
            cmbReader.Name = "cmbReader";
            cmbReader.Size = new Size(447, 23);
            cmbReader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 40);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 1;
            label1.Text = "Select Reader:";
            // 
            // btRefreshReader
            // 
            btRefreshReader.Location = new Point(583, 25);
            btRefreshReader.Name = "btRefreshReader";
            btRefreshReader.Size = new Size(86, 44);
            btRefreshReader.TabIndex = 2;
            btRefreshReader.Text = "Refresh Reader";
            btRefreshReader.UseVisualStyleBackColor = true;
            btRefreshReader.Click += btRefreshReader_Click;
            // 
            // lblLibVersion
            // 
            lblLibVersion.AutoSize = true;
            lblLibVersion.Location = new Point(12, 503);
            lblLibVersion.Name = "lblLibVersion";
            lblLibVersion.Size = new Size(48, 15);
            lblLibVersion.TabIndex = 3;
            lblLibVersion.Text = "Version:";
            // 
            // txtdata
            // 
            txtdata.Location = new Point(130, 77);
            txtdata.Multiline = true;
            txtdata.Name = "txtdata";
            txtdata.Size = new Size(447, 389);
            txtdata.TabIndex = 4;
            // 
            // picPhoto
            // 
            picPhoto.Location = new Point(585, 77);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(147, 173);
            picPhoto.TabIndex = 5;
            picPhoto.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 527);
            Controls.Add(picPhoto);
            Controls.Add(txtdata);
            Controls.Add(lblLibVersion);
            Controls.Add(btRefreshReader);
            Controls.Add(label1);
            Controls.Add(cmbReader);
            Name = "Form1";
            Text = "Read Card ID Thai";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbReader;
        private Label label1;
        private Button btRefreshReader;
        private Label lblLibVersion;
        private TextBox txtdata;
        private PictureBox picPhoto;
    }
}