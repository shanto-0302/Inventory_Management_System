namespace IMSD
{
    partial class ImageViewForm
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
            this.ImageViewPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageViewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageViewPictureBox
            // 
            this.ImageViewPictureBox.Location = new System.Drawing.Point(35, 42);
            this.ImageViewPictureBox.Name = "ImageViewPictureBox";
            this.ImageViewPictureBox.Size = new System.Drawing.Size(518, 362);
            this.ImageViewPictureBox.TabIndex = 0;
            this.ImageViewPictureBox.TabStop = false;
            // 
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 438);
            this.Controls.Add(this.ImageViewPictureBox);
            this.Name = "ImageView";
            this.Text = "ImageView";
            ((System.ComponentModel.ISupportInitialize)(this.ImageViewPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ImageViewPictureBox;
    }
}