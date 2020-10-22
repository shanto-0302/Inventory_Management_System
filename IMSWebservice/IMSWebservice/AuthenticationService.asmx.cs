using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace IMSWebservice
{
    /// <summary>
    /// Summary description for AuthenticationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AuthenticationService : System.Web.Services.WebService
    {

        DBConnectionUtilityService ConnectionutilityService = new DBConnectionUtilityService();
        [WebMethod]
        public bool Login(String email, String password)
        {
            SqlConnection con = ConnectionutilityService.Connect();

            using (SqlCommand cmd = new SqlCommand("SELECT emp_name, emp_email, emp_password from Employee where emp_email= @emp_email and emp_password = @emp_password"))
            {

                cmd.Parameters.AddWithValue("@emp_email", email);
                cmd.Parameters.AddWithValue("@emp_password", password);
                cmd.Connection = con;
                con.Open();

                bool msg = false;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    
                    msg = true;

                }

                else
                {
                    msg = false;
                }

                return msg;
            }
        }
        [WebMethod]
        public bool ChangePassword(String Useremail, String password)
        {
            bool changeStatus = false;
            SqlConnection con = ConnectionutilityService.Connect();
            using (SqlCommand cmd = new SqlCommand("UPDATE Employee SET emp_password=@emp_password where emp_email =@emp_email"))
            {
                cmd.Parameters.AddWithValue("@emp_password", password);
                cmd.Parameters.AddWithValue("@emp_email", Useremail);
                cmd.Connection = con;
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    changeStatus = true;
                }
                catch
                {
                    changeStatus = false;
                }
                con.Close();
            }
            return changeStatus;
        }

        [WebMethod]
        public bool OldPasswordCheck(String UserEmail, String OldPassword)
        {
            bool PasswordMatch = false;
            SqlConnection con = ConnectionutilityService.Connect();
            using (SqlCommand cmd = new SqlCommand("Select * From Employee Where emp_password=@emp_password AND emp_email =@emp_email"))
            {
                cmd.Parameters.AddWithValue("@emp_password", OldPassword);
                cmd.Parameters.AddWithValue("@emp_email", UserEmail);
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    PasswordMatch = true;
                }

                else
                {
                    PasswordMatch = false;
                }

                return PasswordMatch;
            }
        }
    }
}
