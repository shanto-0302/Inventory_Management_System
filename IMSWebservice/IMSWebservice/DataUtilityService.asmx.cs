using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
namespace IMSWebservice
{
    /// <summary>
    /// Summary description for UtilityService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataUtilityService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool checkEmpty(String val)
        {
            bool emptyMsg = false;
            if (val.Equals(null) || val.Equals("") || val.Equals(" "))
            {
                emptyMsg = true;
            }
            return emptyMsg;
        }

        [WebMethod]
        public DateTime GetCurrentDateTime()
        {
            DateTime currentDateTime = DateTime.Now; ;

            return currentDateTime;
        }

        [WebMethod]
        public Byte[] Resize(Byte[] image, int width, int height)
        {
            using (var stream = new System.IO.MemoryStream(image))
            {
                var img = Image.FromStream(stream);
                var thumbnail = img.GetThumbnailImage(width, height, () => false, IntPtr.Zero);

                using (var thumbStream = new System.IO.MemoryStream())
                {
                    thumbnail.Save(thumbStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return thumbStream.GetBuffer();
                }
            }
        }


        [WebMethod]
        public Byte[] GetImageFromBrowse(String imgLoc)
        {
            byte[] img = null;
            try
            {
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
            }
            catch (Exception e)
            {
            }
            return img;
        }
        [WebMethod]
        public Bitmap ConvertByteArrayToBitmap(byte[] imgByteArray)
        {
            Bitmap img;
            using (MemoryStream ms = new MemoryStream(imgByteArray))
            {
                img = (Bitmap)Image.FromStream(ms);
            }
            return img;
        }

        [WebMethod]
        public byte[] ConvertBitmapToByteArray(Bitmap bitmapImg)
        {
            byte[] imgByteArry = null;
            MemoryStream memoryStream = new MemoryStream();

            using (memoryStream)
            {
                bitmapImg.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                imgByteArry = memoryStream.ToArray();
            }
            return imgByteArry;
        }

    }
}
