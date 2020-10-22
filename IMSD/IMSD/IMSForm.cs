using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMSD.AService;
using IMSD.EmpService;

namespace IMSD
{
    public partial class IMSForm : Form
    {
        public IMSForm()
        {
            InitializeComponent();
        }
        AuthenticationService authenticationService = new AuthenticationService();
        EmployeeService empService = new EmployeeService();

        private void Login_Click(object sender, EventArgs e)
        {
            string email;
            string password;
            email = Emailtxt.Text;
            password = Password.Text;
            bool logedIn =false;
            try
            {
                logedIn = authenticationService.Login(email, password);

                if (logedIn)
                {
                    this.Hide();
                    InternalIMSForm internalIMS = new InternalIMSForm();
                    TabControl tbControl = (TabControl)internalIMS.Controls["InternalTabControl"];//.Visible = false;
                    TabPage homePage = tbControl.TabPages[0];

                    DataSet userInfo = empService.GetSingleEmployee(email);

                    String textMsg = "Welcome, " + userInfo.Tables[0].Rows[0][0].ToString() + ". Email: " + userInfo.Tables[0].Rows[0][1].ToString();
                    Label successLbl = new Label();
                    String userEmail = userInfo.Tables[0].Rows[0][1].ToString();
                    internalIMS.userEmail_Save(userEmail);
                    successLbl.Text = textMsg;
                    successLbl.Font = new System.Drawing.Font("", 18);
                    successLbl.ForeColor = Color.Green;
                    successLbl.Width = 340;
                    successLbl.Height = 400;
                    successLbl.Location = new System.Drawing.Point(285, 200);

                    homePage.Controls.Add(successLbl);

                    internalIMS.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Invalid username or password.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Password.Text = "";
                    //loginMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect remote server", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password.Text = "";
            }
        }  
    }
}
