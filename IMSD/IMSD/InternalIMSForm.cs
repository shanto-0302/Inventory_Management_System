using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMSD.EmpService;
using IMSD.ProService;
using IMSD.DUtilityService;
using IMSD.CusService;
using System.Data.SqlClient;
using IMSD.AService;
using IMSD.PurService;
using IMSD.ReportService;
using System.Text.RegularExpressions;
using System.IO;
using System;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace IMSD
{
    public partial class InternalIMSForm : Form
    {
        private class Data
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        public InternalIMSForm()
        {
            InitializeComponent();
        }

        EmployeeService employeeService = new EmployeeService();
        ProductService pService = new ProductService();
        DataUtilityService dataUtilityService = new DataUtilityService();
        CustomerService cusService = new CustomerService();
        AuthenticationService authService = new AuthenticationService();
        PurchaseService purchaseService = new PurchaseService();
        ReportingService reportingService = new ReportingService();
        private void EmployeeCreate_Click(object sender, EventArgs e)
        {
            string emp_name, emp_email,emp_password,emp_phone;
            emp_name = empNameText.Text;
            emp_email = emailText.Text;
            emp_password = passwordText.Text;
            emp_phone = contactText.Text;
            if (!dataUtilityService.checkEmpty(emp_name) && !dataUtilityService.checkEmpty(emp_email) && !dataUtilityService.checkEmpty(emp_password) && !dataUtilityService.checkEmpty(emp_phone))
            {
                bool msg = employeeService.CreateEmployee(emp_name, emp_email, emp_password, emp_phone);
                if (msg)
                {
                    empNameText.Text = "";
                    emailText.Text = "";
                    passwordText.Text = "";
                    contactText.Text = "";
                    // msgLbl.ForeColor = System.Drawing.Color.Green;
                    //msgLbl.Text = "Employee Information Successfully Saved";
                    MessageBox.Show("Employee Information Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //msgLbl.ForeColor = System.Drawing.Color.Red;
                    //msgLbl.Text = "Provided Email Already Exist";
                    MessageBox.Show("Provided Email Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                msgLbl.Visible = true;
            }
            else
            {
                MessageBox.Show("Please fill all the ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        DataGridViewLinkColumn EmployeeEditlink = new DataGridViewLinkColumn();
        DataGridViewLinkColumn EmployeeDeletelink = new DataGridViewLinkColumn();
        DataGridView myEployeeGrid = new DataGridView();
           
        private void EmployeeListTabPage_Click()
        {
            DataSet ds=   employeeService.GetAllEmployee();
            myEployeeGrid.Width = 510;
         
            myEployeeGrid.DataSource = ds.Tables[0];
            myEployeeGrid.Location = new System.Drawing.Point(100, 100);
            

            EmployeeListTabPage.Controls.Add(myEployeeGrid);


         /*   if (EmployeegridGernearteCount == 0)
            {
                EmployeeEditlink.UseColumnTextForLinkValue = true;
                EmployeeEditlink.HeaderText = "Edit";
                EmployeeEditlink.DataPropertyName = "lnkColumn";
                EmployeeEditlink.LinkBehavior = LinkBehavior.SystemDefault;
                EmployeeEditlink.Text = "Edit";
                myEployeeGrid.Columns.Add(EmployeeEditlink);

                EmployeeDeletelink.UseColumnTextForLinkValue = true;
                EmployeeDeletelink.HeaderText = "Delete";
                EmployeeDeletelink.DataPropertyName = "lnkColumn";
                EmployeeDeletelink.LinkBehavior = LinkBehavior.SystemDefault;
                EmployeeDeletelink.Text = "Delete";
                myEployeeGrid.Columns.Add(EmployeeDeletelink);
                EmployeeListTabPage.Controls.Add(myEployeeGrid);
                myEployeeGrid.CellClick += new DataGridViewCellEventHandler(myEployeeGrid_CellContentClick);
                EmployeegridGernearteCount++;
            }*/

        }
       /* private void myEployeeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String empId = Convert.ToString(myEployeeGrid.Rows[e.RowIndex].Cells["emp_id"].Value);

            if (!duservice.checkEmpty(empId))
            {
                if (e.ColumnIndex == 5)
                {
                    bool status = employeeService.DeleteEmployeeById(empId);
                    if (status)
                    {
                        MessageBox.Show("Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EmployeeListTabPage_Click();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (e.ColumnIndex == 4)
                {
                    //productId = Convert.ToString(ProductListGrid.Rows[e.RowIndex].Cells["Id"].Value);
                    EditProductForm editProductControl = new EditProductForm(CatId, productId);
                    editProductControl.ShowDialog();
                    EmployeeListTabPage_Click();
                }
            }

        }
        */
        DataGridView ProductCatGrid = new DataGridView();
        DataGridViewLinkColumn CategoryEditlink = new DataGridViewLinkColumn();
        DataGridViewLinkColumn CategoryDeletelink = new DataGridViewLinkColumn();
        DataGridViewLinkColumn ProductEditlink = new DataGridViewLinkColumn();
        DataGridViewLinkColumn ProductDeletelink = new DataGridViewLinkColumn();
        int gridGernearteCount = 0;

        private void ProductCategorytabPage_Click()
        {
            DataSet ds = pService.GetCategory();
            DataSet newDs = ds;

            DataSet dsCount = pService.GetNumberOfPoductIncategory();
            newDs.Tables[0].Columns.Add("Product", typeof(int));
            int i = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                foreach (DataRow countRow in dsCount.Tables[0].Rows)
                {
                    if(row[0].ToString().Equals(countRow[0].ToString())){
                        newDs.Tables[0].Rows[i][2] = countRow[1];
                    }
                }
                i= i+1;
            }


            ProductCatGrid.Width = 550;
            ProductCatGrid.DataSource = newDs.Tables[0];
            ProductCatGrid.Location = new System.Drawing.Point(100, 100);

            if (gridGernearteCount == 0)
            {
                CategoryEditlink.UseColumnTextForLinkValue = true;
                CategoryEditlink.HeaderText = "Edit";
                CategoryEditlink.DataPropertyName = "lnkColumn";
                CategoryEditlink.LinkBehavior = LinkBehavior.SystemDefault; 
                CategoryEditlink.Text = "Edit";
                ProductCatGrid.Columns.Add(CategoryEditlink);

                CategoryDeletelink.UseColumnTextForLinkValue = true;
                CategoryDeletelink.HeaderText = "Delete";
                CategoryDeletelink.DataPropertyName = "lnkColumn";
                CategoryDeletelink.LinkBehavior = LinkBehavior.SystemDefault;
                CategoryDeletelink.Text = "Delete";
                ProductCatGrid.Columns.Add(CategoryDeletelink);
                ProductCategoryTabPage.Controls.Add(ProductCatGrid);
                ProductCatGrid.CellClick += new DataGridViewCellEventHandler(ProductCatGrid_CellContentClick);
                gridGernearteCount++;
            }
        }

        
        private void ProductCatGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String productId = ""; 
            try
            {
                productId = Convert.ToString(ProductCatGrid.Rows[e.RowIndex].Cells["Id"].Value);

            }
            catch
            { 
            }
            if (!dataUtilityService.checkEmpty(productId))
            {
                if (e.ColumnIndex == 1)
                {
                    pService.DeleteCategory(productId);
                }
                else if (e.ColumnIndex == 0)
                {
                    EditCategoryForm editControl = new EditCategoryForm(productId);
                    editControl.ShowDialog();
                }
                ProductCategorytabPage_Click();
            }
        }
     
        private void AddCategory_Click(object sender, EventArgs e)
        {
            CategoryAddForm catAdd = new CategoryAddForm();
            catAdd.ShowDialog();
            ProductCategorytabPage_Click();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            String productName, scale = "Kg", quantity, catIdStr, priceStr;
            int catId;
            float price;

            catIdStr = CategoryComboBox.SelectedValue.ToString();
            productName = ProductTxt.Text;
            priceStr = Pricetxt.Text;
           
            quantity = quantityUpDown.Value.ToString();
            try
            {
                scale = ScaleComboBox.SelectedValue.ToString();
            }
            catch
            {

            }
            bool prodAdded;
            if (!dataUtilityService.checkEmpty(productName) && !dataUtilityService.checkEmpty(catIdStr) && !dataUtilityService.checkEmpty(priceStr))
            {
                catId = Convert.ToInt32(CategoryComboBox.SelectedValue);
                price = (float)Convert.ToDouble(priceStr);

                prodAdded = pService.AddProduct(catId, productName, price, quantity, scale, imgLoc);
                
                if (prodAdded)
                {
                    ProductTxt.Text = "";
                    Pricetxt.Text = "0";
                    ScaleComboBox.SelectedValue = "Kg";
                    quantityUpDown.Value = 1;
                    //ProductPictureBox.Image =null;
                    Graphics graphic = Graphics.FromImage(ProductPictureBox.Image);
                    graphic.Clear(System.Drawing.Color.White);
                    ProductPictureBox.ImageLocation = "";
                    MessageBox.Show("Product Successfully Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Product failed to add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
            
        }

        private void cmbTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Category_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        
        private void ProductCreatePageTab_Click()
        {
            DataSet ds = new DataSet();
            ds = pService.GetCategory();
            CategoryComboBox.DataSource = ds.Tables[0];
            CategoryComboBox.DisplayMember = "CategoryName";
            CategoryComboBox.ValueMember = "id";


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

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            IMSForm externalIMS = new IMSForm();
            externalIMS.ShowDialog();
        }

        private void TabPage_Changed(object sender, EventArgs e)
        {
            if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["HomeTabPage"]))
            {
                
            }
            else if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["ProductCategoryTabPage"]))
            {
                ProductCategorytabPage_Click();
            }
            else if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["ProductTabPage"]))
            {
                ProductCreatePageTab_Click();
            }
            else if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["ProductListTabPage"]))
            {
                ProductListPage_Click();   
            }
            else if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["CreateEmployeeTabPage"]))
            {

            }
            else if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["EmployeeListTabPage"]))
            {
                EmployeeListTabPage_Click();
            }
            else if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["ChangePasswordTabPage"]))
            {

            }
            else if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["PurchaseTabPage"]))
            {
                PurchaseTabPage_Click();
            }
            else if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["CreateCustomerTabPage"]))
            {
                CreateCustomerTabPage_Click();
            }
            else if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["CustomerListTabPage"]))
            {
                ShowCustomerList();
            }
            else if (InternalTabControl.SelectedTab.Equals(InternalTabControl.TabPages["SaleListTabPage"]))
            {
                ShowSellList();
            }
        }

        private void PurchaseTabPage_Click()
        {
            ProductNameComboBox.Enabled = true;
            ProductQuantityNumericUpDown.Enabled = true;
            ScaleNameComboBox.Enabled = true;
            ProductPriceTextBox.Enabled = true;
            CustomerComboBox.Enabled = true;
            CashMemoButton.Visible = false;
            PurchaseBackBtn.Visible = false;

            DataSet roductListDs = new DataSet();
            roductListDs = pService.GetProductList();
            ProductNameComboBox.DataSource = roductListDs.Tables[0];
            ProductNameComboBox.DisplayMember = "ProductName";
            ProductNameComboBox.ValueMember = "ProductId";


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

            ScaleNameComboBox.DataSource = dsScale.Tables[0];
            ScaleNameComboBox.DisplayMember = "Name";
            ScaleNameComboBox.ValueMember = "Value"; 


            //Customer All
            DataSet customerDs = new DataSet();
            customerDs = cusService.GetAllCustomer();

            CustomerComboBox.DataSource = customerDs.Tables[0];
            CustomerComboBox.DisplayMember = "CustomerName";
            CustomerComboBox.ValueMember = "CustomerId";

        }

        private void CreateCustomerTabPage_Click()
        {
            DataTable customerStatusTable = new DataTable("CustomerStatus");

            customerStatusTable.Columns.Add("Name", typeof(string));
            customerStatusTable.Columns.Add("Value", typeof(string));

            customerStatusTable.Rows.Add(new object[] { "Normal", "Normal", });
            customerStatusTable.Rows.Add(new object[] { "Aluminium", "Aluminium", });
            customerStatusTable.Rows.Add(new object[] { "Silver", "Silver", });
            customerStatusTable.Rows.Add(new object[] { "Gold", "Gold", });
            customerStatusTable.Rows.Add(new object[] { "Platinum", "Platinum", });
            customerStatusTable.Rows.Add(new object[] { "Diamond", "Diamond", });

            customerStatusTable.AcceptChanges();
            DataSet dsCustomerStatus = new DataSet();
            dsCustomerStatus.Tables.Add(customerStatusTable);
            dsCustomerStatus.AcceptChanges();

            CustomerStatusComboBox.DataSource = dsCustomerStatus.Tables[0];
            CustomerStatusComboBox.DisplayMember = "Name";
            CustomerStatusComboBox.ValueMember = "Value";
        }

        private void ProductSellButton_Click(object sender, EventArgs e)
        {
            String ProductId = ProductNameComboBox.SelectedValue.ToString();
            String QuantityStr = ProductQuantityNumericUpDown.Value.ToString();
            String ProductScale = ScaleNameComboBox.SelectedValue.ToString();
            String ProductPriceStr = ProductPriceTextBox.Text;
            String CustomerId = CustomerComboBox.SelectedValue.ToString();
            bool resultSave = false;
            bool resultCustomerUpdate = false;
            bool resultProductUpdate = false;
            if (!dataUtilityService.checkEmpty(ProductId) && !dataUtilityService.checkEmpty(QuantityStr) && !dataUtilityService.checkEmpty(ProductScale) && !dataUtilityService.checkEmpty(ProductPriceStr) && !dataUtilityService.checkEmpty(CustomerId))
            {
                int quantity = Convert.ToInt32(QuantityStr);
                float ProductPrice = (float)Convert.ToDouble(ProductPriceStr);
                float totalPrice = ProductPrice * quantity;
                resultSave = purchaseService.DoPurchase(ProductId, quantity, ProductScale, ProductPriceStr, CustomerId);
                if (resultSave)
                {
                    resultCustomerUpdate = purchaseService.UpdateCustomerPurchaseAmountById(CustomerId, totalPrice);
                    resultProductUpdate = purchaseService.UpdateProductQuantityById(ProductId, quantity);

                    if (resultSave && resultCustomerUpdate && resultProductUpdate)
                    {

                        ProductNameComboBox.Enabled = false;
                        ProductQuantityNumericUpDown.Enabled = false;
                        ScaleNameComboBox.Enabled = false;
                        ProductPriceTextBox.Enabled = false;
                        CustomerComboBox.Enabled = false;

                        saleMsgLbl.ForeColor = System.Drawing.Color.Green;
                        saleMsgLbl.Text = "Click on Cash Memo to get Cash Memo.";
                        MessageBox.Show("Product successfully sold.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProductSellButton.Visible = false;
                        PurchaseBackBtn.Visible = true;
                        saleMsgLbl.Visible = true;
                        CashMemoButton.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show("Purchase failed to Save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else{
                        MessageBox.Show("Requested products are not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Some fields are empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //raju start
        private void CreateCashMemoButton_Click(object sender, EventArgs e)
        {

            String ProductId = ProductNameComboBox.SelectedValue.ToString();
            String QuantityStr = ProductQuantityNumericUpDown.Value.ToString();
            String ProductScale = ScaleNameComboBox.SelectedValue.ToString();
            String ProductPriceStr = ProductPriceTextBox.Text;
            String CustomerId = CustomerComboBox.SelectedValue.ToString();

            //Customer name by Id
            DataSet customerDS = cusService.GetCustomerById(CustomerId);
            String CustomerName = customerDS.Tables[0].Rows[0][1].ToString();


            //Product name by Id

            String ProductName = pService.GetProductNameById(ProductId);

            String DateToday = DateTime.Now.ToString("yyyyMMddHHmms"); ;
            String FileName = "CashMemo" + CustomerId + ProductId + DateToday+".pdf";

            String outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), FileName);

            reportingService.GetCashMemo(ProductName, QuantityStr, ProductScale, ProductPriceStr, CustomerName, outputFile);

            Process.Start(outputFile);

            ProductQuantityNumericUpDown.Value = 1;
            ScaleNameComboBox.SelectedValue = "Kg";
            ProductPriceTextBox.Text = "0";

            ProductNameComboBox.Enabled = true;
            ProductQuantityNumericUpDown.Enabled = true;
            ScaleNameComboBox.Enabled = true;
            ProductPriceTextBox.Enabled = true;
            CustomerComboBox.Enabled = true;
            CashMemoButton.Visible = false;
            PurchaseBackBtn.Visible = false;
            ProductSellButton.Visible = true;
        }

        
        //raju end
        private void CreateCustomerBtn_Click(object sender, EventArgs e)
        {
            if (EmailFlag && mobileLength)
            {
                String customerName = CustomerNameTextBox.Text;
                String customerAddress = CustomerAddressTextBox.Text;
                String customerContact = CustomerContactTextBox.Text;
                String customerEmail = CustomerEmailTextBox.Text;
                String customerStatus = CustomerStatusComboBox.SelectedValue.ToString();
                bool createMsg;
                if (!dataUtilityService.checkEmpty(customerName) && !dataUtilityService.checkEmpty(customerEmail) && !dataUtilityService.checkEmpty(customerStatus))
                {
                    createMsg = cusService.AddCustomer(customerName, customerAddress, customerContact, customerEmail, customerStatus);

                    if (createMsg)
                    {
                        CustomerNameTextBox.Text = "";
                        CustomerAddressTextBox.Text = "";
                        CustomerContactTextBox.Text = "";
                        CustomerEmailTextBox.Text = "";
                        CustomerStatusComboBox.SelectedValue = "Normal";
                        //EmployeeMsgLbl.Text = "Customer Successfully Added.";
                        //EmployeeMsgLbl.ForeColor = System.Drawing.Color.Green;
                        //EmployeeMsgLbl.Visible = true;
                        MessageBox.Show("Customer Successfully Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                       // EmployeeMsgLbl.Text = "Customer failed to add.";
                        //EmployeeMsgLbl.ForeColor = System.Drawing.Color.Red;
                        //EmployeeMsgLbl.Visible = true;
                        MessageBox.Show("Customer failed to add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

        private void CustomerStatus_Keypress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //Shanto

        private void confirmPassword_KeyUp(object sender, KeyEventArgs e)
        {

        }
        public String userEmail;

        public void userEmail_Save(String mail)
        {
            userEmail = mail;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            String email = userEmail;
            String newPassword = newPasswordTxt.Text;
            String oldPassword = oldPasswordTxt.Text;
            if (!oldPassword.Equals(""))
            {
                bool ChangeStatus = authService.ChangePassword(userEmail, newPassword);
                if (ChangeStatus)
                {
                    MessageBox.Show("Password successfully changed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newPasswordTxt.Text = "";
                    oldPasswordTxt.Text = "";
                    confirmPasswordTxt.Text = "";
                }
                else
                {
                    MessageBox.Show("Some errors occur during password change.", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                oldPasswordTxt.BackColor = System.Drawing.Color.Red;
            }
        }

        private void confirmPasswordTxt_Leave(object sender, EventArgs e)
        {
            String newPassword = newPasswordTxt.Text;
            String confirsmPassword = confirmPasswordTxt.Text;
            if (!newPassword.Equals(confirsmPassword))
            {
                MessageBox.Show("New password and Confirm Password are not matched", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Shanto, Date Bugggggggggggggg
                confirmPasswordTxt.Text = "";
            }

        }

        private void oldPasswordTxt_Leave(object sender, EventArgs e)
        {
            AuthenticationService authService = new AuthenticationService();
            String oldPassword = oldPasswordTxt.Text;
            bool oldPasswordCheck = authService.OldPasswordCheck(userEmail, oldPassword);

            if (!oldPasswordCheck)
            {
                MessageBox.Show("Old password is incorrect", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oldPasswordTxt.Text = "";
            }

            //Shanto, Date Bugggggggggggggg
            else
            {
                oldPasswordTxt.BackColor = System.Drawing.Color.White;
            }
        }


        //Shanto
        int gridProductGernearteCount = 0;
        DataGridView ProductListGrid = new DataGridView();
        private void ProductListPage_Click()
        {
            DataSet ds = pService.GetProductList();
            ProductListGrid.Width = 800;
            ProductListGrid.Height = 300;
            ProductListGrid.RowTemplate.Height = 80;

            ProductListGrid.DataSource = ds.Tables[0];
            ProductListGrid.Location = new System.Drawing.Point(50,10);

            if (gridProductGernearteCount == 0)
            {
                ProductEditlink.UseColumnTextForLinkValue = true;
                ProductEditlink.HeaderText = "Edit";
                ProductEditlink.DataPropertyName = "lnkColumn";
                ProductEditlink.LinkBehavior = LinkBehavior.SystemDefault; 
                ProductEditlink.Text = "Edit";
                ProductListGrid.Columns.Add(ProductEditlink);

                ProductDeletelink.UseColumnTextForLinkValue = true;
                ProductDeletelink.HeaderText = "Delete";
                ProductDeletelink.DataPropertyName = "lnkColumn";
                ProductDeletelink.LinkBehavior = LinkBehavior.SystemDefault;
                ProductDeletelink.Text = "Delete";
                ProductListGrid.Columns.Add(ProductDeletelink);
                ProductListTabPage.Controls.Add(ProductListGrid);
                ProductListGrid.CellClick += new DataGridViewCellEventHandler(ProductListGrid_CellContentClick);
                gridProductGernearteCount++;
            }
        }

        //Shanto
        public static string productId;
        public static string CatId;
        private void ProductListGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            String productId = "";
            String CatId = "";
            try
            {
                CatId = Convert.ToString(ProductListGrid.Rows[e.RowIndex].Cells["Catid"].Value);
                productId = Convert.ToString(ProductListGrid.Rows[e.RowIndex].Cells["ProductId"].Value);
            }
            catch
            {

            }
            if (!dataUtilityService.checkEmpty(CatId) && !dataUtilityService.checkEmpty(productId))
            {
                if (e.ColumnIndex == 1)
                {
                    bool status= pService.DeleteOnlyProduct(productId, CatId);
                    if (status)
                    {
                        MessageBox.Show("Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProductListPage_Click();
                    }
                    else {
                        MessageBox.Show("Fail to Delete", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (e.ColumnIndex == 0)
                {
                    //productId = Convert.ToString(ProductListGrid.Rows[e.RowIndex].Cells["Id"].Value);
                    EditProductForm editProductControl = new EditProductForm(CatId, productId);
                    editProductControl.ShowDialog();
                    ProductListPage_Click();
                }

                else if(e.ColumnIndex==6){
                    ImageViewForm imageView = new ImageViewForm(CatId, productId);
                    imageView.ShowDialog();
                }

            }
        }

        private void ProductNameComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ScaleNameComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CustomerNameComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void PurchaseBackBtn_Click(object sender, EventArgs e)
        {
            ProductQuantityNumericUpDown.Value = 1;
            ScaleNameComboBox.SelectedValue = "Kg";
            ProductPriceTextBox.Text = "0";

            saleMsgLbl.Visible = false;
            ProductNameComboBox.Enabled = true;
            ProductQuantityNumericUpDown.Enabled = true;
            ScaleNameComboBox.Enabled = true;
            ProductPriceTextBox.Enabled = true;
            CustomerComboBox.Enabled = true;
            CashMemoButton.Visible = false;
            PurchaseBackBtn.Visible = false;
            ProductSellButton.Visible = true;
        }


        DataGridViewLinkColumn SellDeletelink = new DataGridViewLinkColumn();
        DataGridView SellListGrid = new DataGridView();
        int gridSellGernearteCount = 0;
        PurchaseService SaleService = new PurchaseService();
        private void ShowSellList()
        {

            DataSet ds = SaleService.GetPurchase();
            SellListGrid.Width = 900;
            SellListGrid.Height = 250;
            SellListGrid.DataSource = ds.Tables[0];
            SellListGrid.Location = new System.Drawing.Point(20, 50);

            if (gridSellGernearteCount == 0)
            {
                SellDeletelink.UseColumnTextForLinkValue = true;
                SellDeletelink.HeaderText = "Delete";
                SellDeletelink.DataPropertyName = "lnkColumn";
                SellDeletelink.LinkBehavior = LinkBehavior.SystemDefault;
                SellDeletelink.Text = "Delete";
                SellListGrid.Columns.Add(SellDeletelink);
                SaleListTabPage.Controls.Add(SellListGrid);
                SellListGrid.CellClick += new DataGridViewCellEventHandler(SaleListGrid_CellContentClick);
                gridSellGernearteCount++;
            }
        }

        //PurchaseService purService = new PurchaseService();
        //public static string CatId;
        private void SaleListGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String purchase_id = "";

            try
            {
                purchase_id = Convert.ToString(SellListGrid.Rows[e.RowIndex].Cells["Id"].Value);
            }
            catch
            {

            }
            if (!dataUtilityService.checkEmpty(purchase_id))
            {
                if (e.ColumnIndex == 0)
                {
                    bool status = SaleService.DeleteSaleById(purchase_id);
                    if (status)
                    {
                        MessageBox.Show("Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Fail to Delete", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ShowSellList();
            }
        }




        //Shanto, V3

        DataGridViewLinkColumn CustomerEditlink = new DataGridViewLinkColumn();
        DataGridViewLinkColumn CustomerDeletelink = new DataGridViewLinkColumn();
        DataGridView CustomerListGrid = new DataGridView();
        int gridCustomerGernearteCount = 0;
        //Shanto, V3
        CustomerService custService = new CustomerService();

        private void ShowCustomerList()
        {
            DataSet ds = custService.GetCustomerList();
            CustomerListGrid.Width = 900;
            CustomerListGrid.Height = 250;
            CustomerListGrid.DataSource = ds.Tables[0];
            CustomerListGrid.Location = new System.Drawing.Point(20, 50);

            if (gridCustomerGernearteCount == 0)
            {
                CustomerEditlink.UseColumnTextForLinkValue = true;
                CustomerEditlink.HeaderText = "Edit";
                CustomerEditlink.DataPropertyName = "lnkColumn";
                CustomerEditlink.LinkBehavior = LinkBehavior.SystemDefault;
                CustomerEditlink.Text = "Edit";
                CustomerListGrid.Columns.Add(CustomerEditlink);

                CustomerDeletelink.UseColumnTextForLinkValue = true;
                CustomerDeletelink.HeaderText = "Delete";
                CustomerDeletelink.DataPropertyName = "lnkColumn";
                CustomerDeletelink.LinkBehavior = LinkBehavior.SystemDefault;
                CustomerDeletelink.Text = "Delete";
                CustomerListGrid.Columns.Add(CustomerDeletelink);
                CustomerListTabPage.Controls.Add(CustomerListGrid);
                CustomerListGrid.CellClick += new DataGridViewCellEventHandler(CustomerListGrid_CellContentClick);
                gridCustomerGernearteCount++;
            }
        }




        CustomerService cService = new CustomerService();
        //public static string CatId;
        private void CustomerListGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String cus_Id = "";

            try
            {
                cus_Id = Convert.ToString(CustomerListGrid.Rows[e.RowIndex].Cells["Id"].Value);
            }
            catch
            {

            }
            if (!dataUtilityService.checkEmpty(cus_Id))
            {
                if (e.ColumnIndex == 1)
                {
                    bool status = cService.DeleteCustomerById(cus_Id);
                    if (status)
                    {
                        MessageBox.Show("Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Fail to Delete", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (e.ColumnIndex == 0)
                {
                    EditCustomerForm editCustomerControl = new EditCustomerForm(cus_Id);
                    editCustomerControl.ShowDialog();
                }
                ShowCustomerList();
            }
        }

        bool EmailFlag = true;
        private void isValidEmail(object sender, EventArgs e)
        {
             String CustomerEmail="";
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                CustomerEmail = CustomerEmailTextBox.Text;
                Regex re = new Regex(strRegex);
                if (re.IsMatch(CustomerEmail))
                {
                    CustomerEmailTextBox.BackColor = System.Drawing.Color.White;
                    EmailFlag = true;
                }
                else
                {
                    CustomerEmailTextBox.BackColor = System.Drawing.Color.Red;
                    EmailFlag = false;
                }
            }

        String employeeEmail = "";
        bool CustomerEmailFlag = true;
        private void isEmailValid(object sender, EventArgs e)
        {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                employeeEmail = emailText.Text;
                Regex re = new Regex(strRegex);
                if (re.IsMatch(employeeEmail))
                {
                    emailText.BackColor = System.Drawing.Color.White;
                    CustomerEmailFlag = true;
                }
                else
                {
                    emailText.BackColor = System.Drawing.Color.Red;
                    CustomerEmailFlag = false;
                }
        }

        ///Bugggggggggggggggg Shanto Start

        private void Pricetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumberCheck(e);
        }

        private void ProductPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = NumberCheck(e);

        }
        public bool NumberCheck(KeyPressEventArgs e)
        {
            bool NotNumber = false;
            if (!(Char.IsNumber(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                NotNumber = true;
            }
            else
                NotNumber = false;
            return NotNumber;
        }

        private void CustomerContactTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumberCheck(e);
        }
        bool mobileLength = true;
        private void CustomerContactTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            String contact = CustomerContactTextBox.Text;

            if (contact.Length > 11)
            {
                mobileLength = false;
                CustomerContactTextBox.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                mobileLength = true;
                CustomerContactTextBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void contactText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumberCheck(e);
        }

        private void contactText_KeyUp(object sender, KeyEventArgs e)
        {
            String contact = contactText.Text;

            if (contact.Length > 11)
            {
                mobileLength = false;
                contactText.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                mobileLength = true;
                contactText.BackColor = System.Drawing.Color.White;
            }
        }

        private void ProductPriceTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumberCheck(e);
        }
                string imgLoc = "";  
        private void Browse_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files(*.*)|*.*";
            dlg.Title = "Select Product Image";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                imgLoc = dlg.FileName.ToString();
                //ProductPictureBox.ImageLocation = imgLoc;
                byte[] img = dataUtilityService.GetImageFromBrowse(imgLoc);
                byte[] newBitmapData = dataUtilityService.Resize(img, 397, 245);

                System.Drawing.Bitmap bitmapImg;
                using (MemoryStream ms = new MemoryStream(newBitmapData))
                {
                    bitmapImg = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(ms);
                }

                ProductPictureBox.Image = bitmapImg;
            }
        }
    }
}

