using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace IMSWebservice
{
    /// <summary>
    /// Summary description for PurchaseService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PurchaseService : System.Web.Services.WebService
    {

        DBConnectionUtilityService ConnectionUtilityService = new DBConnectionUtilityService();
        DataUtilityService dataUtilityService = new DataUtilityService();
        ProductService productService = new ProductService();
        CustomerService customerService = new CustomerService();

        [WebMethod]
        public bool DoPurchase(String PId, int Quantity, String Scale, String Price, String CId)
        {
            int ProductId = Convert.ToInt16(PId);
            float price = (float)Convert.ToDouble(Price);
            float totalPrice = price * Quantity;
            int CustomerId = Convert.ToInt16(CId);
            DateTime currentDateTime = dataUtilityService.GetCurrentDateTime();
            bool purchaseAdd = false;
            int PrevQuantity = Convert.ToInt32(productService.GetProductQuantityById(PId));
            int newQuantity = 0;
            newQuantity = PrevQuantity - Quantity;
            if (newQuantity >= 0)
            {
                SqlConnection con = ConnectionUtilityService.Connect();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Purchase (product_id, quantity, scale, total_price, cus_id, purchase_date) VALUES (@product_id, @quantity, @scale, @total_price, @cus_id, @purchase_date)"))
                {
                    cmd.Parameters.AddWithValue("@product_id", ProductId);
                    cmd.Parameters.AddWithValue("@quantity", Quantity);
                    cmd.Parameters.AddWithValue("@scale", Scale);
                    cmd.Parameters.AddWithValue("@total_price", totalPrice);
                    cmd.Parameters.AddWithValue("@cus_id", CustomerId);
                    cmd.Parameters.AddWithValue("@purchase_date", currentDateTime);

                    cmd.Connection = con;
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        purchaseAdd = true;
                    }
                    catch
                    {
                        purchaseAdd = false;
                    }
                    con.Close();
                }
            }
            else { 
            purchaseAdd = false;
            }
            return purchaseAdd;
        }

        [WebMethod]
        public bool UpdateProductQuantityById(String PId, int Quantity)
        {
            int PrevQuantity = Convert.ToInt32(productService.GetProductQuantityById(PId));
            int newQuantity = 0;
            bool updateQuantity = false;
            newQuantity = PrevQuantity - Quantity;
            if (newQuantity >= 0)
            {
               
                int ProductId = Convert.ToInt16(PId);

                SqlConnection con = ConnectionUtilityService.Connect();
                using (SqlCommand cmd = new SqlCommand("UPDATE Product SET Quantity=@quantity where Id =@product_id"))
                {
                    cmd.Parameters.AddWithValue("@product_id", ProductId);
                    cmd.Parameters.AddWithValue("@quantity", newQuantity);

                    cmd.Connection = con;
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        updateQuantity = true;
                    }
                    catch
                    {
                        updateQuantity = false;
                    }
                    con.Close();
                }
            }
            else {
                updateQuantity = false;
            } 
            return updateQuantity;
        }

        [WebMethod]
        public bool UpdateCustomerPurchaseAmountById(String CId, float Price)
        {
            int CustomerId = Convert.ToInt16(CId);
            float PrevPurchaseAmount = customerService.GetCustomerPurchaseAmountById(CId);

            float newPurchaseAmount = PrevPurchaseAmount + Price;

            bool updateCustomerPurchaseAmount = false;
            SqlConnection con = ConnectionUtilityService.Connect();

            using (SqlCommand cmd = new SqlCommand("UPDATE Customer SET cus_total_purchase=@cus_total_purchase where cus_id =@cus_id"))
            {
                cmd.Parameters.AddWithValue("@cus_id", CustomerId);
                cmd.Parameters.AddWithValue("@cus_total_purchase", newPurchaseAmount);

                cmd.Connection = con;
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    updateCustomerPurchaseAmount = true;
                }
                catch
                {
                    updateCustomerPurchaseAmount = false;
                }
                con.Close();
            }
            return updateCustomerPurchaseAmount;
        }




        [WebMethod]
        public DataSet GetPurchase()
        {
            SqlConnection con = ConnectionUtilityService.Connect();

            using (SqlCommand cmd = new SqlCommand("SELECT * from Purchase"))
            {
                //cmd.Parameters.AddWithValue("@cat_name", Catname);
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable myTable = new DataTable("PurchaseTable");

                myTable.Columns.Add("Id", typeof(int));
                myTable.Columns.Add("product_id", typeof(int));
                myTable.Columns.Add("quantity", typeof(string));

                myTable.Columns.Add("scale", typeof(string));
                myTable.Columns.Add("total_price", typeof(string));
                myTable.Columns.Add("cus_id", typeof(int));
                myTable.Columns.Add("purchase_date", typeof(string));


                while (reader.Read())
                {
                    myTable.Rows.Add(new object[] 

                    { 
                      reader["purchase_id"], reader["product_id"], reader["quantity"],reader["scale"].ToString(),reader["total_price"].ToString(),reader["cus_id"],reader["purchase_date"].ToString(),});
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
        public bool DeleteSaleById(String id)
        {
            bool DeleteStatus = false;
            SqlConnection con = ConnectionUtilityService.Connect();
            int idI = Convert.ToInt32(id);
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Purchase where purchase_id =@purchase_id"))
            {
                cmd.Parameters.AddWithValue("@purchase_id", idI);
                cmd.Connection = con;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    DeleteStatus = true;
                }
                catch
                {
                    DeleteStatus = false;
                }
            }
            con.Close();
            return DeleteStatus;
        }


    }
}
