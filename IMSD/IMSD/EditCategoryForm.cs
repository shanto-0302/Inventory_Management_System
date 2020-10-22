using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMSD.ProService;

namespace IMSD
{
    public partial class EditCategoryForm : Form
    {
        ProductService pService = new ProductService();
        InternalIMSForm iImsForm = new InternalIMSForm();
        public EditCategoryForm(String productId)
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            ds = pService.getOneCategoryInfo(productId);

            CategoryName.Text= ds.Tables[0].Rows[0][1].ToString();
            CategoryId.Text = ds.Tables[0].Rows[0][0].ToString();
            //CategoryComboBox.DisplayMember = "CategoryName";
            //CategoryComboBox.ValueMember = "id";
        }
        private void submit_Click(object sender, EventArgs e)
        {
            String categoryName = CategoryName.Text;
            String id = CategoryId.Text;
            bool status = pService.updateCategoryInfo(id, categoryName);
            if (status)
            {
                this.Hide();
            }
        }
    }
}
