using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace IMSWebservice
{
    /// <summary>
    /// Summary description for ProductService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductService : System.Web.Services.WebService
    {

        DBConnectionUtilityService ConnectionutilityService = new DBConnectionUtilityService();
        DataUtilityService dataUtilityService = new DataUtilityService();

        [WebMethod]
        public bool AddCategory(String Catname)
        {
            bool catAdd = false;
            SqlConnection con = ConnectionutilityService.Connect();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO ProductCategory (CategoryName) VALUES (@cat_name)"))
            {
                cmd.Parameters.AddWithValue("@cat_name", Catname);
                cmd.Connection = con;
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    catAdd = true;
                }
                catch
                {
                    catAdd = false;
                }
                con.Close();
            }
            return catAdd;
            //return "Hello World";
        }
        [WebMethod]
        public DataSet GetCategory()
        {
            SqlConnection con = ConnectionutilityService.Connect();
            
            using (SqlCommand cmd = new SqlCommand("SELECT * from ProductCategory" ))
            {
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable myTable = new DataTable("CategoryTable");

                myTable.Columns.Add("Id", typeof(int));
                myTable.Columns.Add("CategoryName", typeof(string));   

                while (reader.Read())
                {
                    myTable.Rows.Add(new object[] 
                    { 
                      reader["CategoryId"], reader["CategoryName"].ToString(),});
                }
                myTable.AcceptChanges();
                DataSet ds = new DataSet();
                ds.Tables.Add(myTable);
                ds.AcceptChanges();

                con.Close();
                return ds;
            }
            
        }


        [WebMethod]
        public bool AddProduct(int CatId, String ProductName, float Price, String Quantity, String qScale, String imgLoc)
        {
            bool prodAdd = false;
            SqlConnection con = ConnectionutilityService.Connect();

            byte[] img = dataUtilityService.GetImageFromBrowse(imgLoc);
            
            /*try
            {
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
            }
            catch (Exception e)
            {
            }*/
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Product (CategoryId, ProductName, Price, Quantity, QScale, Image, ImageUrl) VALUES (@CatId, @ProductName, @Price, @Quantity, @QScale, @img, @ImageUrl )"))
            {
                cmd.Parameters.AddWithValue("@CatId", CatId);
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@QScale", qScale);
                cmd.Parameters.AddWithValue("@img", img);
                cmd.Parameters.AddWithValue("@ImageUrl", imgLoc);
                

                cmd.Connection = con;
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    prodAdd = true;
                }
                catch
                {
                    prodAdd = false;
                }
                con.Close();
            }
            return prodAdd;
        }




        [WebMethod]
        public void DeleteProduct(String id) {
           
            SqlConnection con = ConnectionutilityService.Connect();
            int idI = Convert.ToInt32(id);
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Product where CategoryId =@CategoryId"))
            {
                // con.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@CategoryId", idI);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();

                //ds=  GetCategory();
            }
            con.Close();

        }

        [WebMethod]
        public void DeleteCategory(String id)
        { 
            SqlConnection con = ConnectionutilityService.Connect();
            
            int idI = Convert.ToInt32(id);
            using (SqlCommand cmd = new SqlCommand("DELETE FROM ProductCategory where CategoryId =@CategoryId"))
            {
                DeleteProduct(id);
               // con.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@CategoryId", idI);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();

              //ds=  GetCategory();
            }
            con.Close();
        }

        [WebMethod]
        public DataSet getOneCategoryInfo(String id) 
        {
            SqlConnection con = ConnectionutilityService.Connect();
            int idI = Convert.ToInt32(id);
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM ProductCategory where CategoryId =@CategoryId"))
            {
                cmd.Parameters.AddWithValue("@CategoryId", idI);
                cmd.Connection = con;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable myTable = new DataTable("CategoryTable");

                myTable.Columns.Add("id", typeof(int));
                myTable.Columns.Add("CategoryName", typeof(string));

                while (reader.Read())
                {
                    myTable.Rows.Add(new object[] {reader["CategoryId"], reader["CategoryName"].ToString(),});
                }
                myTable.AcceptChanges();
                DataSet ds = new DataSet();
                ds.Tables.Add(myTable);
                ds.AcceptChanges();

                con.Close();
                return ds;
            }
        }
        [WebMethod]
        public bool updateCategoryInfo(String id, String categoryName) {
            
            SqlConnection con = ConnectionutilityService.Connect();
            int idI = Convert.ToInt32(id);
            bool catAdd=false;
            using (SqlCommand cmd = new SqlCommand("UPDATE ProductCategory SET CategoryName=@CategoryName where CategoryId =@CategoryId"))
            {
                cmd.Parameters.AddWithValue("@CategoryId", idI);
                cmd.Parameters.AddWithValue("@categoryName", categoryName);
                cmd.Connection = con;
                con.Open();
                    try
                {
                    cmd.ExecuteNonQuery();
                    catAdd = true;
                }
                catch
                {
                    catAdd = false;
                }
                con.Close();
            }
            return catAdd;
        }
        [WebMethod]
        public DataSet GetNumberOfPoductIncategory()
        {
           
            SqlConnection con = ConnectionutilityService.Connect();
            
            SqlDataReader reader;
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand("SELECT CategoryId, COUNT(CategoryId) AS Count FROM Product GROUP BY CategoryId"))
            {
                cmd.Connection = con;
                con.Open();
                reader = cmd.ExecuteReader();
                DataTable myTable = new DataTable("CategoryTable");

                myTable.Columns.Add("CategoryId", typeof(int));
                myTable.Columns.Add("NumberOfProduct", typeof(string));

                while (reader.Read())
                {
                    myTable.Rows.Add(new object[] { reader["CategoryId"], reader["Count"].ToString(), });
                }
                myTable.AcceptChanges();
                
                ds.Tables.Add(myTable);
                ds.AcceptChanges();

                con.Close();
            }
            return ds;
        }


        //shanto

        [WebMethod]
        public DataSet GetProductList()
        {
            SqlConnection con = ConnectionutilityService.Connect();
            //ORDER BY CategoryId ASC
            using (SqlCommand cmd = new SqlCommand("SELECT * from Product, ProductCategory Where Product.CategoryId=ProductCategory.CategoryId"))
            {
                //cmd.Parameters.AddWithValue("@cat_name", Catname);
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable myProductTable = new DataTable("ProductTable");

                myProductTable.Columns.Add("Catid", typeof(int));
                myProductTable.Columns.Add("CategoryName", typeof(string));
                myProductTable.Columns.Add("ProductId", typeof(int));
                myProductTable.Columns.Add("ProductName", typeof(string));
                myProductTable.Columns.Add("Image", typeof(byte[]));
                myProductTable.Columns.Add("Price", typeof(float));
                myProductTable.Columns.Add("Quantity", typeof(int));
                myProductTable.Columns.Add("Scale", typeof(string));

                Bitmap image = new Bitmap(80, 80);

                MemoryStream memoryStream = new MemoryStream();
                byte[] newBitmapData;

                using (memoryStream)
                {
                    image.Save(memoryStream, ImageFormat.Jpeg);
                    newBitmapData = memoryStream.ToArray();
                }

                while (reader.Read())
                {
                    if (!dataUtilityService.checkEmpty(reader["Image"].ToString()))
                    {
                        newBitmapData = (byte[])reader["Image"];
                        newBitmapData = dataUtilityService.Resize(newBitmapData, 100, 100);
                    }
                    myProductTable.Rows.Add(new object[] 
                    { 

                      reader["CategoryId"], reader["CategoryName"].ToString(), reader["Id"],  reader["ProductName"].ToString(), newBitmapData, reader["Price"], reader["Quantity"], reader["QScale"].ToString(),});
                }
                myProductTable.AcceptChanges();
                DataSet ds = new DataSet();
                ds.Tables.Add(myProductTable);
                ds.AcceptChanges();

                con.Close();
                return ds;

            }

        }

        


        [WebMethod]
        public bool DeleteOnlyProduct(String PId, String CatId)
        {
            SqlConnection con = ConnectionutilityService.Connect();
            int CatidI = Convert.ToInt32(CatId);
            int PidI = Convert.ToInt32(PId);
            bool statusDelete = false;
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Product where CategoryId =@CategoryId AND id=@Id"))
            {
                // con.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@CategoryId", CatidI);
                cmd.Parameters.AddWithValue("@Id", PidI);
                cmd.Connection = con;
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    statusDelete = true;
                }
                catch
                {
                    statusDelete = false;
                }
                //ds=  GetCategory();
            }
            con.Close();
            return statusDelete;

        }


        [WebMethod]
        public DataSet getOneProductInfo(String CatId, String ProductId)
        {
            SqlConnection con = ConnectionutilityService.Connect();
            int CId = Convert.ToInt32(CatId);
            int PId = Convert.ToInt32(ProductId);

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product where CategoryId =@CategoryId AND Id=@Id"))
            {
                cmd.Parameters.AddWithValue("@CategoryId", CId);
                cmd.Parameters.AddWithValue("@Id", PId);
                cmd.Connection = con;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable myTable = new DataTable("ProductTable");

                myTable.Columns.Add("Id", typeof(int));
                myTable.Columns.Add("CategoryId", typeof(int));
                myTable.Columns.Add("ProductName", typeof(string));
                myTable.Columns.Add("Price", typeof(float));
                myTable.Columns.Add("Quantity", typeof(int));
                myTable.Columns.Add("Scale", typeof(string));
                myTable.Columns.Add("Image", typeof(byte[]));

                Bitmap image = new Bitmap(50, 50);

                MemoryStream memoryStream = new MemoryStream();
                byte[] bitmapData;

                using (memoryStream)
                {
                    image.Save(memoryStream, ImageFormat.Bmp);
                    bitmapData = memoryStream.ToArray();
                }


                while (reader.Read())
                {
                    if (!dataUtilityService.checkEmpty(reader["Image"].ToString()))
                    {
                        bitmapData = (byte[])reader["Image"];
                    }
                    myTable.Rows.Add(new object[] 
                    { 
                      reader["Id"],reader["CategoryId"], reader["ProductName"].ToString(),reader["Price"],reader["Quantity"],reader["QScale"],bitmapData,});
                }
                myTable.AcceptChanges();
                DataSet ds = new DataSet();
                ds.Tables.Add(myTable);
                ds.AcceptChanges();

                con.Close();
                return ds;




            }
        }

        [WebMethod]
        public bool updateProductInfo(String CatId, String ProductId, String ProductName, String price, String quantity, String scale, String imgLoc)
        {
            SqlConnection con = ConnectionutilityService.Connect();

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

            int CId = Convert.ToInt32(CatId);
            int PId = Convert.ToInt32(ProductId);
            double PriceD = Convert.ToDouble(price);
            int quantityI = Convert.ToInt32(quantity);
            bool pUpdate = false;
            using (SqlCommand cmd = new SqlCommand("UPDATE Product SET ProductName=@ProductName, Price=@Price, Quantity=@Quantity, QScale=@QScale, Image= @img  where CategoryId =@CategoryId AND Id=@Id"))
            {
                cmd.Parameters.AddWithValue("@CategoryId", CId);
                cmd.Parameters.AddWithValue("@Id", PId);
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@Price", PriceD);
                cmd.Parameters.AddWithValue("@Quantity", quantityI);
                cmd.Parameters.AddWithValue("@QScale", scale);
                cmd.Parameters.AddWithValue("@img", img);
                cmd.Connection = con;
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    pUpdate = true;
                }
                catch
                {
                    pUpdate = false;
                }
                con.Close();
            }
            return pUpdate;
        }

        [WebMethod]
        public String GetProductQuantityById(String ProductId)
        {
            SqlConnection con = ConnectionutilityService.Connect();
            int PId = Convert.ToInt32(ProductId);

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product where Id=@Id"))
            {
                cmd.Parameters.AddWithValue("@Id", PId);
                cmd.Connection = con;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                String quantity =null;
                while (reader.Read())
                {
                      quantity = reader["Quantity"].ToString();
                }
                
                con.Close();
                return quantity;
            }
        }

        [WebMethod]
        public String GetProductNameById(String ProductId)
        {
            SqlConnection con = ConnectionutilityService.Connect();
            int PId = Convert.ToInt32(ProductId);

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product where Id=@Id"))
            {
                cmd.Parameters.AddWithValue("@Id", PId);
                cmd.Connection = con;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                String ProductName = "";
                while (reader.Read())
                {
                    ProductName = reader["ProductName"].ToString();
                }

                con.Close();
                return ProductName;
            }
        }

        [WebMethod]
        public String GetProductImageurlById(String ProductId)
        {
            SqlConnection con = ConnectionutilityService.Connect();
            int PId = Convert.ToInt32(ProductId);

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product where Id=@Id"))
            {
                cmd.Parameters.AddWithValue("@Id", PId);
                cmd.Connection = con;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                String ImageUrl = "";
                while (reader.Read())
                {
                    ImageUrl = reader["ImageUrl"].ToString();
                }

                con.Close();
                return ImageUrl;
            }
        }

    }
}