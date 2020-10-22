namespace IMSD
{
    partial class EditCustomerForm
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
            this.CustomerIdLbl = new System.Windows.Forms.Label();
            this.CustomerNameLbl = new System.Windows.Forms.Label();
            this.CustomerAddressLbl = new System.Windows.Forms.Label();
            this.CustomerContactLbl = new System.Windows.Forms.Label();
            this.CustomerEmailLbl = new System.Windows.Forms.Label();
            this.CustomerStatusLbl = new System.Windows.Forms.Label();
            this.CustomerIdTextBox = new System.Windows.Forms.TextBox();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.CustomerAddressTextBox = new System.Windows.Forms.TextBox();
            this.CustomerContactTextBox = new System.Windows.Forms.TextBox();
            this.CustomerEmailTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CustomerEditSaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomerIdLbl
            // 
            this.CustomerIdLbl.AutoSize = true;
            this.CustomerIdLbl.Enabled = false;
            this.CustomerIdLbl.Location = new System.Drawing.Point(70, 61);
            this.CustomerIdLbl.Name = "CustomerIdLbl";
            this.CustomerIdLbl.Size = new System.Drawing.Size(63, 13);
            this.CustomerIdLbl.TabIndex = 0;
            this.CustomerIdLbl.Text = "Customer Id";
            // 
            // CustomerNameLbl
            // 
            this.CustomerNameLbl.AutoSize = true;
            this.CustomerNameLbl.Location = new System.Drawing.Point(70, 98);
            this.CustomerNameLbl.Name = "CustomerNameLbl";
            this.CustomerNameLbl.Size = new System.Drawing.Size(82, 13);
            this.CustomerNameLbl.TabIndex = 1;
            this.CustomerNameLbl.Text = "Customer Name";
            // 
            // CustomerAddressLbl
            // 
            this.CustomerAddressLbl.AutoSize = true;
            this.CustomerAddressLbl.Location = new System.Drawing.Point(70, 134);
            this.CustomerAddressLbl.Name = "CustomerAddressLbl";
            this.CustomerAddressLbl.Size = new System.Drawing.Size(92, 13);
            this.CustomerAddressLbl.TabIndex = 2;
            this.CustomerAddressLbl.Text = "Customer Address";
            // 
            // CustomerContactLbl
            // 
            this.CustomerContactLbl.AutoSize = true;
            this.CustomerContactLbl.Location = new System.Drawing.Point(71, 172);
            this.CustomerContactLbl.Name = "CustomerContactLbl";
            this.CustomerContactLbl.Size = new System.Drawing.Size(91, 13);
            this.CustomerContactLbl.TabIndex = 3;
            this.CustomerContactLbl.Text = "Customer Contact";
            // 
            // CustomerEmailLbl
            // 
            this.CustomerEmailLbl.AutoSize = true;
            this.CustomerEmailLbl.Location = new System.Drawing.Point(71, 214);
            this.CustomerEmailLbl.Name = "CustomerEmailLbl";
            this.CustomerEmailLbl.Size = new System.Drawing.Size(79, 13);
            this.CustomerEmailLbl.TabIndex = 4;
            this.CustomerEmailLbl.Text = "Customer Email";
            // 
            // CustomerStatusLbl
            // 
            this.CustomerStatusLbl.AutoSize = true;
            this.CustomerStatusLbl.Location = new System.Drawing.Point(71, 248);
            this.CustomerStatusLbl.Name = "CustomerStatusLbl";
            this.CustomerStatusLbl.Size = new System.Drawing.Size(84, 13);
            this.CustomerStatusLbl.TabIndex = 5;
            this.CustomerStatusLbl.Text = "Customer Status";
            // 
            // CustomerIdTextBox
            // 
            this.CustomerIdTextBox.Enabled = false;
            this.CustomerIdTextBox.Location = new System.Drawing.Point(226, 56);
            this.CustomerIdTextBox.Name = "CustomerIdTextBox";
            this.CustomerIdTextBox.Size = new System.Drawing.Size(159, 20);
            this.CustomerIdTextBox.TabIndex = 6;
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.Location = new System.Drawing.Point(225, 96);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.Size = new System.Drawing.Size(160, 20);
            this.CustomerNameTextBox.TabIndex = 7;
            // 
            // CustomerAddressTextBox
            // 
            this.CustomerAddressTextBox.Location = new System.Drawing.Point(226, 132);
            this.CustomerAddressTextBox.Name = "CustomerAddressTextBox";
            this.CustomerAddressTextBox.Size = new System.Drawing.Size(160, 20);
            this.CustomerAddressTextBox.TabIndex = 8;
            // 
            // CustomerContactTextBox
            // 
            this.CustomerContactTextBox.Location = new System.Drawing.Point(226, 171);
            this.CustomerContactTextBox.Name = "CustomerContactTextBox";
            this.CustomerContactTextBox.Size = new System.Drawing.Size(160, 20);
            this.CustomerContactTextBox.TabIndex = 9;
            this.CustomerContactTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomerContactTextBox_KeyPress);
            this.CustomerContactTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CustomerContactTextBox_KeyUp);
            // 
            // CustomerEmailTextBox
            // 
            this.CustomerEmailTextBox.Location = new System.Drawing.Point(226, 211);
            this.CustomerEmailTextBox.Name = "CustomerEmailTextBox";
            this.CustomerEmailTextBox.Size = new System.Drawing.Size(160, 20);
            this.CustomerEmailTextBox.TabIndex = 10;
            this.CustomerEmailTextBox.Leave += new System.EventHandler(this.isEmailValid);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(227, 247);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // CustomerEditSaveBtn
            // 
            this.CustomerEditSaveBtn.Location = new System.Drawing.Point(228, 301);
            this.CustomerEditSaveBtn.Name = "CustomerEditSaveBtn";
            this.CustomerEditSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.CustomerEditSaveBtn.TabIndex = 12;
            this.CustomerEditSaveBtn.Text = "Save";
            this.CustomerEditSaveBtn.UseVisualStyleBackColor = true;
            this.CustomerEditSaveBtn.Click += new System.EventHandler(this.CustomerEditSaveBtn_Click);
            // 
            // EditCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 359);
            this.Controls.Add(this.CustomerEditSaveBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.CustomerEmailTextBox);
            this.Controls.Add(this.CustomerContactTextBox);
            this.Controls.Add(this.CustomerAddressTextBox);
            this.Controls.Add(this.CustomerNameTextBox);
            this.Controls.Add(this.CustomerIdTextBox);
            this.Controls.Add(this.CustomerStatusLbl);
            this.Controls.Add(this.CustomerEmailLbl);
            this.Controls.Add(this.CustomerContactLbl);
            this.Controls.Add(this.CustomerAddressLbl);
            this.Controls.Add(this.CustomerNameLbl);
            this.Controls.Add(this.CustomerIdLbl);
            this.Name = "EditCustomerForm";
            this.Text = "CustomerEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CustomerIdLbl;
        private System.Windows.Forms.Label CustomerNameLbl;
        private System.Windows.Forms.Label CustomerAddressLbl;
        private System.Windows.Forms.Label CustomerContactLbl;
        private System.Windows.Forms.Label CustomerEmailLbl;
        private System.Windows.Forms.Label CustomerStatusLbl;
        private System.Windows.Forms.TextBox CustomerIdTextBox;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
        private System.Windows.Forms.TextBox CustomerAddressTextBox;
        private System.Windows.Forms.TextBox CustomerContactTextBox;
        private System.Windows.Forms.TextBox CustomerEmailTextBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button CustomerEditSaveBtn;
    }
}