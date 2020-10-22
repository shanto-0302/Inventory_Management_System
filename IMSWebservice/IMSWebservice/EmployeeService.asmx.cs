using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace IMSWebservice
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {

        DBConnectionUtilityService ConnectionutilityService = new DBConnectionUtilityService();
          
        [WebMethod]
        public bool CreateEmployee(String employeeName, String employeeEmail, String employeePassword, String employeeContact)
        {
                SqlConnection con= ConnectionutilityService.Connect();
                bool msg = false;
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Employee (emp_name, emp_email, emp_password, emp_contactNo) VALUES (@emp_name, @emp_email, @emp_password, @emp_contactNo)"))
                {
                    cmd.Parameters.AddWithValue("@emp_name", employeeName);
                    cmd.Parameters.AddWithValue("@emp_email", employeeEmail);
                    cmd.Parameters.AddWithValue("@emp_password", employeePassword);
                    cmd.Parameters.AddWithValue("@emp_contactNo", employeeContact);
                    cmd.Connection = con;
                    con.Open();
                    try
                    {
                         cmd.ExecuteNonQuery();
                         msg = true;
                    }
                    catch{
                        msg = false;
                    }
                    con.Close();
                }
            return msg;
        }

        [WebMethod]
        public DataSet GetAllEmployee()
        {
                SqlConnection con = ConnectionutilityService.Connect();
                using (SqlCommand cmd = new SqlCommand("SELECT * from Employee"))
                {
                    cmd.Connection = con;
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable myTable = new DataTable("EmployeeInfo");

                    myTable.Columns.Add("Employee Id", typeof(int));
                    myTable.Columns.Add("Employee Name", typeof(string));
                    myTable.Columns.Add("Employee Email", typeof(string));
                    myTable.Columns.Add("Employee Contact", typeof(string));


                    while (reader.Read())
                    {
                        myTable.Rows.Add(new object[] 

                    { 
                      reader["emp_id"], reader["emp_name"].ToString(), reader["emp_email"].ToString(), reader["emp_contactNo"].ToString(),});
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
        public DataSet GetSingleEmployee(String UserEmail)
        {
            SqlConnection con = ConnectionutilityService.Connect();

            using (SqlCommand cmd = new SqlCommand("SELECT emp_name, emp_email, emp_contactNo from Employee where emp_email= @emp_email"))
            {

                cmd.Parameters.AddWithValue("@emp_email", UserEmail);
               
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable myTable = new DataTable("UserInfo");

                myTable.Columns.Add("emp_name", typeof(string));
                myTable.Columns.Add("emp_email", typeof(string));
                myTable.Columns.Add("emp_contact", typeof(string));


                while (reader.Read())
                {
                    myTable.Rows.Add(new object[] { reader["emp_name"].ToString(), reader["emp_email"].ToString(), reader["emp_contactNo"].ToString(), });
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
        public bool DeleteEmployeeById(String eId)
        {
            SqlConnection con = ConnectionutilityService.Connect();
            int eIdI = Convert.ToInt32(eId); 
            bool statusDelete = false;
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Employee where emp_id=@emp_id"))
            {
                // con.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@emp_id", eIdI);
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

       
    }
}
