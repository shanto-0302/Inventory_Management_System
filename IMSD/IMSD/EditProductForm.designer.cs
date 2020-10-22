namespace IMSD
{
    partial class EditProductForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CategoryIdTxt = new System.Windows.Forms.TextBox();
            this.ProductIdTxt = new System.Windows.Forms.TextBox();
            this.ProductName = new System.Windows.Forms.TextBox();
            this.PriceTxt = new System.Windows.Forms.TextBox();
            this.QuantityTxt = new System.Windows.Forms.TextBox();
            this.ProductEditbtn = new System.Windows.Forms.Button();
            this.ScaleComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EditpictureBox = new System.Windows.Forms.PictureBox();
            this.Browse = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EditpictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product Name";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(30, 165);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(31, 13);
            this.Price.TabIndex = 3;
            this.Price.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Quantity";
            // 
            // CategoryIdTxt
            // 
            this.CategoryIdTxt.Enabled = false;
            this.CategoryIdTxt.Location = new System.Drawing.Point(117, 47);
            this.CategoryIdTxt.Name = "CategoryIdTxt";
            this.CategoryIdTxt.Size = new System.Drawing.Size(129, 20);
            this.CategoryIdTxt.TabIndex = 5;
            // 
            // ProductIdTxt
            // 
            this.ProductIdTxt.Enabled = false;
            this.ProductIdTxt.Location = new System.Drawing.Point(116, 85);
            this.ProductIdTxt.Name = "ProductIdTxt";
            this.ProductIdTxt.Size = new System.Drawing.Size(130, 20);
            this.ProductIdTxt.TabIndex = 6;
            // 
            // ProductName
            // 
            this.ProductName.Location = new System.Drawing.Point(116, 121);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(130, 20);
            this.ProductName.TabIndex = 7;
            // 
            // PriceTxt
            // 
            this.PriceTxt.Location = new System.Drawing.Point(117, 159);
            this.PriceTxt.Name = "PriceTxt";
            this.PriceTxt.Size = new System.Drawing.Size(130, 20);
            this.PriceTxt.TabIndex = 8;
            this.PriceTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceTxt_KeyPress);
            // 
            // QuantityTxt
            // 
            this.QuantityTxt.Location = new System.Drawing.Point(118, 196);
            this.QuantityTxt.Name = "QuantityTxt";
            this.QuantityTxt.Size = new System.Drawing.Size(130, 20);
            this.QuantityTxt.TabIndex = 9;
            this.QuantityTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuantityTxt_KeyPress);
            // 
            // ProductEditbtn
            // 
            this.ProductEditbtn.Location = new System.Drawing.Point(154, 324);
            this.ProductEditbtn.Name = "ProductEditbtn";
            this.ProductEditbtn.Size = new System.Drawing.Size(75, 23);
            this.ProductEditbtn.TabIndex = 10;
            this.ProductEditbtn.Text = "Edit";
            this.ProductEditbtn.UseVisualStyleBackColor = true;
            this.ProductEditbtn.Click += new System.EventHandler(this.ProductEditbtn_Click);
            // 
            // ScaleComboBox
            // 
            this.ScaleComboBox.FormattingEnabled = true;
            this.ScaleComboBox.Location = new System.Drawing.Point(118, 236);
            this.ScaleComboBox.Name = "ScaleComboBox";
            this.ScaleComboBox.Size = new System.Drawing.Size(129, 21);
            this.ScaleComboBox.TabIndex = 11;
            this.ScaleComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditProductScale_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Scale";
            // 
            // EditpictureBox
            // 
            this.EditpictureBox.Location = new System.Drawing.Point(318, 42);
            this.EditpictureBox.Name = "EditpictureBox";
            this.EditpictureBox.Size = new System.Drawing.Size(319, 215);
            this.EditpictureBox.TabIndex = 13;
            this.EditpictureBox.TabStop = false;
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(150, 277);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(78, 27);
            this.Browse.TabIndex = 14;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Upload Image";
            // 
            // EditProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(649, 402);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.EditpictureBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ScaleComboBox);
            this.Controls.Add(this.ProductEditbtn);
            this.Controls.Add(this.QuantityTxt);
            this.Controls.Add(this.PriceTxt);
            this.Controls.Add(this.ProductName);
            this.Controls.Add(this.ProductIdTxt);
            this.Controls.Add(this.CategoryIdTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditProductForm";
            this.Text = "EditProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.EditpictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CategoryIdTxt;
        private System.Windows.Forms.TextBox ProductIdTxt;
        private System.Windows.Forms.TextBox ProductName;
        private System.Windows.Forms.TextBox PriceTxt;
        private System.Windows.Forms.TextBox QuantityTxt;
        private System.Windows.Forms.Button ProductEditbtn;
        private System.Windows.Forms.ComboBox ScaleComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox EditpictureBox;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Label label10;
    }
}