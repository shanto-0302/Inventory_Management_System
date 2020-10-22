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
using IMSD.DUtilityService;

namespace IMSD
{
    public partial class ImageViewForm : Form
    {
        DataUtilityService dataUtilityService = new DataUtilityService();
            
        ProductService pService = new ProductService();

        public ImageViewForm(String catId, String ProductId)
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            ds = pService.getOneProductInfo(catId, ProductId);

            byte[] bitmapData;
           /* System.Drawing.Bitmap image = new System.Drawing.Bitmap(50, 50);
            MemoryStream memoryStream = new MemoryStream();

            using (memoryStream)
            {
                image.Save(memoryStream, ImageFormat.Bmp);
                bitmapData = memoryStream.ToArray();
            }*/
            bitmapData = (byte[])ds.Tables[0].Rows[0][6];
            byte[] newBitmapData = dataUtilityService.Resize(bitmapData, 518, 362);
            
            System.Drawing.Bitmap img;

            using (MemoryStream ms = new MemoryStream(newBitmapData))
            {
                img = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(ms);
            }

            ImageViewPictureBox.Image = img;
            
        }
    }
}
