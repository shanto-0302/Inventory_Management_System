namespace IMSD
{
    partial class EditCategoryForm
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
            this.CategoryId = new System.Windows.Forms.TextBox();
            this.CategoryName = new System.Windows.Forms.TextBox();
            this.Level1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CategoryId
            // 
            this.CategoryId.Enabled = false;
            this.CategoryId.Location = new System.Drawing.Point(175, 76);
            this.CategoryId.Name = "CategoryId";
            this.CategoryId.Size = new System.Drawing.Size(133, 20);
            this.CategoryId.TabIndex = 0;
            // 
            // CategoryName
            // 
            this.CategoryName.Location = new System.Drawing.Point(175, 120);
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Size = new System.Drawing.Size(133, 20);
            this.CategoryName.TabIndex = 1;
            // 
            // Level1
            // 
            this.Level1.AutoSize = true;
            this.Level1.Location = new System.Drawing.Point(67, 123);
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(80, 13);
            this.Level1.TabIndex = 2;
            this.Level1.Text = "Category Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Category Id";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(194, 165);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 4;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 277);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Level1);
            this.Controls.Add(this.CategoryName);
            this.Controls.Add(this.CategoryId);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CategoryId;
        private System.Windows.Forms.TextBox CategoryName;
        private System.Windows.Forms.Label Level1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submit;
    }
}