using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMSD.CusService;
using System.Text.RegularExpressions;

namespace IMSD
{
    public partial class EditCustomerForm : Form
    {
        CustomerService cusService = new CustomerService();
        public EditCustomerForm(String empId)
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            ds = cusService.GetCustomerById(empId);

            CustomerIdTextBox.Text = ds.Tables[0].Rows[0][0].ToString();
            CustomerNameTextBox.Text = ds.Tables[0].Rows[0][1].ToString();
            CustomerAddressTextBox.Text = ds.Tables[0].Rows[0][3].ToString();
            CustomerContactTextBox.Text = ds.Tables[0].Rows[0][2].ToString();
            CustomerEmailTextBox.Text = ds.Tables[0].Rows[0][4].ToString();
            comboBox1.Text = ds.Tables[0].Rows[0][5].ToString();
            String scale = ds.Tables[0].Rows[0][5].ToString();

            DataTable myTable = new DataTable("Scale");

            myTable.Columns.Add("Name", typeof(string));
            myTable.Columns.Add("Value", typeof(string));
            myTable.Rows.Add(new object[] { "Silver", "Silver", });
            myTable.Rows.Add(new object[] { "Gold", "Gold", });

            myTable.Rows.Add(new object[] { "Normal", "Normal", });
            myTable.Rows.Add(new object[] { "Aluminium", "Aluminium", });
            myTable.Rows.Add(new object[] { "Silver", "Silver", });
            myTable.Rows.Add(new object[] { "Gold", "Gold", });
            myTable.Rows.Add(new object[] { "Platinum", "Platinum", });
            myTable.Rows.Add(new object[] { "Diamond", "Diamond", });

            myTable.AcceptChanges();
            DataSet dsScale = new DataSet();
            dsScale.Tables.Add(myTable);
            dsScale.AcceptChanges();

            comboBox1.DataSource = dsScale.Tables[0];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Value";
            comboBox1.SelectedValue = scale;
        }

        String CustomerEmail = "";
        private void CustomerEditSaveBtn_Click(object sender, EventArgs e)
        {
            if (EmailFlag && mobileLength)
            {
                String CId = CustomerIdTextBox.Text;
                String customerName = CustomerNameTextBox.Text;
                String CustomerAddress = CustomerAddressTextBox.Text;
                String CustomerContact = CustomerContactTextBox.Text;
                CustomerEmail = CustomerEmailTextBox.Text;
                String scale = comboBox1.SelectedValue.ToString();
                bool status = cusService.updateCustomerInformation(CId, customerName, CustomerAddress, CustomerContact, CustomerEmail, scale);
                if (status)
                {
                    this.Hide();
                    MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ///Buggggggggggg
            else if (!EmailFlag && !mobileLength)
            {
                MessageBox.Show("Invalid Email and Mobile", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!EmailFlag)
            {
                MessageBox.Show("Invalid Email Address", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!mobileLength)
            {
                MessageBox.Show("Invalid Mobile Number", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool EmailFlag = true;
       
            private void isEmailValid(object sender, EventArgs e)
                {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                CustomerEmail = CustomerEmailTextBox.Text;
                Regex re = new Regex(strRegex);
                if (re.IsMatch(CustomerEmail))
                {
                    CustomerEmailTextBox.BackColor = Color.White;
                    EmailFlag = true;
                }
                else
                {
                    CustomerEmailTextBox.BackColor = Color.Red;
                    EmailFlag = false;
                }
            }

            //Buggggggggggggggggggggggg
            private void CustomerContactTextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!(Char.IsNumber(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                {
                    e.Handled = true;
                }
            }
            bool mobileLength = true;
            private void CustomerContactTextBox_KeyUp(object sender, KeyEventArgs e)
            {
                String contact = CustomerContactTextBox.Text;

                if (contact.Length > 11)
                {
                    mobileLength = false;
                    CustomerContactTextBox.BackColor = Color.Red;
                }
                else
                {
                    mobileLength = true;
                    CustomerContactTextBox.BackColor = Color.White;
                }
            }

            private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                e.Handled = true;
            }

        }
}
