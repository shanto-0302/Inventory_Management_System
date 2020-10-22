using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMSD.ProService;
using IMSD.DUtilityService;

namespace IMSD
{
    public partial class CategoryAddForm : Form
    {
        public CategoryAddForm()
        {
            InitializeComponent();
        }
        ProductService pService = new ProductService();
        
        private void add_Click(object sender, EventArgs e)
        {
            String categoryName= categoryNameTxt.Text;
            DataUtilityService dservice = new DataUtilityService();
            if (!dservice.checkEmpty(categoryName))
            {
               bool flagAdded= pService.AddCategory(categoryName);
               if (flagAdded)
               {
                 //  msglabel.Text = "Category Successfully Added";
                   categoryNameTxt.Text = "";
                  // msglabel.ForeColor = Color.Green;
                  // msglabel.Visible = true;
                   MessageBox.Show("Category Successfully Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

               }
               else {
                 //  msglabel.Text = "Category failed to add";
                 //  msglabel.ForeColor = Color.Red;
                 //  msglabel.Visible = true;
                   MessageBox.Show("Category failed to add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

               }
            }
            else {
               // msglabel.Text = "Empty category cannot be added";
               // msglabel.ForeColor = Color.Red;
               // msglabel.Visible = true;
                MessageBox.Show("Empty category cannot be added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
