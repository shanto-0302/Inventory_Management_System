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
    /// Summary description for CustomerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustomerService : System.Web.Services.WebService
    {

        DBConnectionUtilityService ConnectionUtilityService = new DBConnectionUtilityService();
        DataUtilityService dataUtilityService = new DataUtilityService();

        [WebMethod]
        public bool AddCustomer(String customerName, String customerAddress, String customerContact, String customerEmail, String customerStatus)
        {
            SqlConnection con = ConnectionUtilityService.Connect();
            bool msg = false;
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Customer (cus_name, cus_address, cus_contact, cus_email, cus_status) VALUES (@cus_name, @cus_address, @cus_contact, @cus_email, @cus_status)"))
            {
                cmd.Parameters.AddWithValue("@cus_name", customerName);
                cmd.Parameters.AddWithValue("@cus_address", customerAddress);
                cmd.Parameters.AddWithValue("@cus_contact", customerContact);
                cmd.Parameters.AddWithValue("@cus_email", customerEmail);
                cmd.Parameters.AddWithValue("@cus_status", customerStatus);

                cmd.Connection = con;
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    msg = true;
                }
                catch
                {
                    msg = false;
                }
                con.Close();
            }
            return msg;

        }

        [WebMethod]
        public DataSet GetAllCustomer()
        {
                SqlConnection con = ConnectionUtilityService.Connect();
                using (SqlCommand cmd = new SqlCommand("SELECT * from Customer ORDER BY cus_name ASC"))
                {
                    cmd.Connection = con;
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable myTable = new DataTable("EmployeeInfo");

                    myTable.Columns.Add("CustomerId", typeof(int));
                    myTable.Columns.Add("CustomerName", typeof(string));
                    myTable.Columns.Add("CustomerAddress", typeof(string));
                    myTable.Columns.Add("CustomerContact", typeof(string));
                    myTable.Columns.Add("CustomerEmail", typeof(string));
                    myTable.Columns.Add("CustomerTotalPurchase", typeof(float));
                    myTable.Columns.Add("CustomerStatus", typeof(string));

                    while (reader.Read())
                    {
                        myTable.Rows.Add(new object[] 

                    { 
                      reader["cus_id"], reader["cus_name"].ToString(), reader["cus_address"].ToString(), reader["cus_email"].ToString(), reader["cus_contact"].ToString(), reader["cus_total_purchase"], reader["cus_status"].ToString(),});
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
        public float GetCustomerPurchaseAmountById(String CusId)
        {
            SqlConnection con = ConnectionUtilityService.Connect();
            int CustomerId = Convert.ToInt32(CusId);

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customer where cus_id=@cus_id"))
            {
                cmd.Parameters.AddWithValue("@cus_id", CustomerId);
                cmd.Connection = con;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                float purchaseAmount = 0;
                while (reader.Read())
                {
                    if (!dataUtilityService.checkEmpty(reader["cus_total_purchase"].ToString()))
                    {
                        purchaseAmount = (float)Convert.ToDouble(reader["cus_total_purchase"]);
                    }
                    else{
                        purchaseAmount = 0;
                    }
                    
                }

                con.Close();
                return purchaseAmount;
            }
        }

        //Shanto, Date
        [WebMethod]
        public DataSet GetCustomerList()
        {
            SqlConnection con = ConnectionUtilityService.Connect();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customer"))
            {
                //cmd.Parameters.AddWithValue("@cus_id", Cus_Id);
                cmd.Connection = con;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable myCustomerTable = new DataTable("CustomerTable");

                myCustomerTable.Columns.Add("Id", typeof(int));
                myCustomerTable.Columns.Add("Name", typeof(string));
                myCustomerTable.Columns.Add("Address", typeof(string));
                myCustomerTable.Columns.Add("Contact", typeof(string));
                myCustomerTable.Columns.Add("Email", typeof(string));
                myCustomerTable.Columns.Add("Total Purchase", typeof(string));
                myCustomerTable.Columns.Add("Status", typeof(string));

                while (reader.Read())
                {
                    myCustomerTable.Rows.Add(new object[] 
                    { 
                      reader["cus_id"],reader["cus_name"].ToString(), reader["cus_address"].ToString(),reader["cus_contact"].ToString(),reader["cus_email"].ToString(), reader["cus_total_purchase"], reader["cus_status"].ToString(),});
                }
                myCustomerTable.AcceptChanges();
                DataSet ds = new DataSet();
                ds.Tables.Add(myCustomerTable);
                ds.AcceptChanges();
                con.Close();
                return ds;
            }
        }

        [WebMethod]
        public bool DeleteCustomerById(String id)
        {
            bool DeleteStatus = false;
            SqlConnection con = ConnectionUtilityService.Connect();
            int idI = Convert.ToInt32(id);
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Customer where cus_Id =@cus_Id"))
            {
                cmd.Parameters.AddWithValue("@cus_Id", idI);
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

        [WebMethod]
        public DataSet GetCustomerById(String id)
        {
            bool GetStatus = false;
            SqlConnection con = ConnectionUtilityService.Connect();
            int cus_id = Convert.ToInt32(id);
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customer where cus_id = @cus_id"))
            {
                cmd.Parameters.AddWithValue("@cus_id", cus_id);
                cmd.Connection = con;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable myTable = new DataTable("CustomerTable");

                myTable.Columns.Add("cus_id", typeof(int));
                myTable.Columns.Add("cus_name", typeof(string));
                myTable.Columns.Add("cus_address", typeof(string));
                myTable.Columns.Add("cus_contact", typeof(string));
                myTable.Columns.Add("cus_email", typeof(string));
                myTable.Columns.Add("cus_status", typeof(string));

                while (reader.Read())
                {
                    myTable.Rows.Add(new object[] { reader["cus_Id"], reader["cus_name"].ToString(), reader["cus_address"].ToString(), reader["cus_contact"].ToString(), reader["cus_email"].ToString(), reader["cus_status"].ToString(), });
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
        public bool updateCustomerInformation(String CId, String customerName, String CustomerAddress, String CustomerContact, String CustomerEmail, String scale)
        {
            DBConnectionUtilityService ConnectionutilityService = new DBConnectionUtilityService();
            SqlConnection con = ConnectionutilityService.Connect();
            int id = Convert.ToInt32(CId);
            bool pUpdate = false;
            using (SqlCommand cmd = new SqlCommand("UPDATE Customer SET cus_name=@cus_name, cus_address=@cus_address, cus_contact=@cus_contact, cus_email=@cus_email, cus_status=@cus_status where cus_id=@cus_id"))
            {
                cmd.Parameters.AddWithValue("@cus_id", id);
                cmd.Parameters.AddWithValue("@cus_name", customerName);
                cmd.Parameters.AddWithValue("@cus_address", CustomerAddress);
                cmd.Parameters.AddWithValue("@cus_contact", CustomerContact);
                cmd.Parameters.AddWithValue("@cus_email", CustomerEmail);
                cmd.Parameters.AddWithValue("@cus_status", scale);
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

    }
}
