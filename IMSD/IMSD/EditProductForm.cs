using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMSD.ProService;
using System.IO;
using System.Drawing.Imaging;

namespace IMSD
{
    public partial class EditProductForm : Form
    {
        ProductService pService = new ProductService();
        public EditProductForm(String catId, String ProductId)
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            ds = pService.getOneProductInfo(catId, ProductId);

            CategoryIdTxt.Text = ds.Tables[0].Rows[0][1].ToString();
            ProductIdTxt.Text = ds.Tables[0].Rows[0][0].ToString();
            ProductName.Text = ds.Tables[0].Rows[0][2].ToString();
            PriceTxt.Text = ds.Tables[0].Rows[0][3].ToString();
            QuantityTxt.Text = ds.Tables[0].Rows[0][4].ToString();
            String scale = ds.Tables[0].Rows[0][5].ToString();

            byte[] bitmapData;
            /*Bitmap image = new Bitmap(50, 50);
            MemoryStream memoryStream = new MemoryStream();

            using (memoryStream)
            {
                image.Save(memoryStream, ImageFormat.Bmp);
                bitmapData = memoryStream.ToArray();
            }*/
            bitmapData = (byte[]) ds.Tables[0].Rows[0][6];
            Bitmap img;
            using (MemoryStream ms = new MemoryStream(bitmapData))
            {
                img = (Bitmap)Image.FromStream(ms);
            }
            EditpictureBox.Image = img;
            EditpictureBox.ImageLocation = pService.GetProductImageurlById(ProductId);


            DataTable myTable = new DataTable("Scale");

            myTable.Columns.Add("Name", typeof(string));
            myTable.Columns.Add("Value", typeof(string));

            myTable.Rows.Add(new object[] { "Kg", "Kg", });
            myTable.Rows.Add(new object[] { "Litre", "Litre", });
            myTable.Rows.Add(new object[] { "Piece", "Piece", });
            myTable.Rows.Add(new object[] { "Pair", "Pair", });
            myTable.Rows.Add(new object[] { "Dozen", "Dozen", });

            myTable.AcceptChanges();
            DataSet dsScale = new DataSet();
            dsScale.Tables.Add(myTable);
            dsScale.AcceptChanges();

            ScaleComboBox.DataSource = dsScale.Tables[0];
            ScaleComboBox.DisplayMember = "Name";
            ScaleComboBox.ValueMember = "Value";
            ScaleComboBox.SelectedValue = scale;
        }

        private void ProductEditbtn_Click(object sender, EventArgs e)
        {
            String catId = CategoryIdTxt.Text;
            String pId = ProductIdTxt.Text;
            String productName = ProductName.Text;
            String price = PriceTxt.Text;
            String quantity = QuantityTxt.Text;
            String scale = ScaleComboBox.SelectedValue.ToString();

            imgLoc = EditpictureBox.ImageLocation;
            bool status = pService.updateProductInfo(catId, pId, productName, price, quantity, scale, imgLoc);

            if (status)
            {
                this.Hide();
                MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { 
                MessageBox.Show("Failed to update product information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditProductScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        //Buggggggggggggggggggggg
        private void PriceTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void QuantityTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }
        string imgLoc = "";
        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files(*.*)|*.*";
            dlg.Title = "Select Product Image";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                imgLoc = dlg.FileName.ToString();
                EditpictureBox.ImageLocation = imgLoc;
            }
        }
    }
}
