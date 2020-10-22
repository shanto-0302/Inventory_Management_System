namespace IMSD
{
    partial class CategoryAddForm
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
            this.categoryNameTxt = new System.Windows.Forms.TextBox();
            this.Category = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.msg = new System.Windows.Forms.Label();
            this.msglabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // categoryNameTxt
            // 
            this.categoryNameTxt.Location = new System.Drawing.Point(125, 72);
            this.categoryNameTxt.Name = "categoryNameTxt";
            this.categoryNameTxt.Size = new System.Drawing.Size(100, 20);
            this.categoryNameTxt.TabIndex = 0;
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(39, 76);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(49, 13);
            this.Category.TabIndex = 1;
            this.Category.Text = "Category";
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(52, 115);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 2;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.Location = new System.Drawing.Point(96, 29);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(0, 13);
            this.msg.TabIndex = 3;
            // 
            // msglabel
            // 
            this.msglabel.AutoSize = true;
            this.msglabel.Location = new System.Drawing.Point(39, 29);
            this.msglabel.Name = "msglabel";
            this.msglabel.Size = new System.Drawing.Size(26, 13);
            this.msglabel.TabIndex = 4;
            this.msglabel.Text = "msg";
            this.msglabel.Visible = false;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(159, 116);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // CategoryAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 188);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.msglabel);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.add);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.categoryNameTxt);
            this.Name = "CategoryAdd";
            this.Text = "Category Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox categoryNameTxt;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.Label msglabel;
        private System.Windows.Forms.Button exitButton;
    }
}