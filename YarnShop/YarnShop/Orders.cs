using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YarnShop
{
    public partial class Orders : Form
    {
        List<Supplier> supplierList = new List<Supplier>();
        List<Customer> customerList = new List<Customer>();
        List<string> SupplierNameList = new List<string>();

        //defining variables that will be used throughout
        List<string> orderList = new List<string>();
        List<string> custDelStatus = new List<string>();
        List<string> supplierDelStatus = new List<string>();
        List<string> payStatus = new List<string>();
        bool filtersApplied;
        string currentCommand;

        List<OrderItem> currentOrderList = new List<OrderItem>();

        Customer currentCust = null;
        Supplier currentSupp = null;
        CustOrder currentCustOrder = null;
        Order currentSupplierOrder = null;
        OrderItem currentOrderItem = null;

        //used for finding row of information about product
        int index;
        int tempQuantity;

        // These variables are static so they can be accessed by the CustOrder class to create an invoice.
        public static int pageNum;
        public static float height = 30;
        public static int startIndex = 0;
        public static List<InvoiceLine> lines = new List<InvoiceLine>();

        string selectedDelStatus;
        string selectedPayStatus;
        bool editMode = false;
        bool returnMode = false;
        bool voidMode = false;
        bool supplierRefresh;
        PrintDialog printDlg = new PrintDialog();

        BindingSource bindingSourceItems = new BindingSource();
        // if order items are being viewed then events will occur differently e.g. when a cell in dgvOrders is clicked it will not be able to show order info

        // Make form draggable
        bool drag = false;
        Point dragCursor;
        Point dragForm;
        private void pbxBar_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = Location;
        }
        private void pbxBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point difference = Point.Subtract(Cursor.Position, new Size(dragCursor));
                Location = Point.Add(dragForm, new Size(difference));
            }
        }
        private void pbxBar_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to discard all changes?", "Discard Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
        public Orders(CustOrder custOrder,Order order)
        {
            InitializeComponent();
            updateCustomerList();
            updateSupplierList();
            currentCustOrder = custOrder;
            currentSupplierOrder = order;
        }
        
        private void FormOrders_Load(object sender, EventArgs e)
        {
            pnlProductInfo.Visible = false;

            custDelStatus.Add("Order Made");
            custDelStatus.Add("Ready To Collect");
            custDelStatus.Add("Collected");
            custDelStatus.Add("Voided");
            custDelStatus.Add("Returned");

            supplierDelStatus.Add("Order Made");
            supplierDelStatus.Add("Out For Delivery");
            supplierDelStatus.Add("Delivered");
            supplierDelStatus.Add("Voided");
            supplierDelStatus.Add("Returned");

            payStatus.Add("Cancelled");
            payStatus.Add("Paid");
            payStatus.Add("Partially Refunded");
            payStatus.Add("Refunded");
            payStatus.Add("Unpaid");

            clsbPayStatus_Supplier.DataSource = payStatus;

            if (currentCustOrder!=null || currentSupplierOrder != null) // If this form was opened from a notice, load the order directly
            {
                string command = "";
                if (currentCustOrder != null) // If this form was opened from a customer order notice
                {
                    command = "SELECT * FROM TableCustOrders";
                    rbtnCust.Checked = true;
                }
                if (currentSupplierOrder != null) // If this form was opened from a supplier order notice
                {
                    command = "SELECT * FROM TableSupplierOrders"; 
                    rbtnSuppliers.Checked = true;
                }
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = command;
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvOrders.DataSource = bindingSource;
                connection.Close();
                
                if(currentCustOrder != null)
                {
                    foreach (DataGridViewRow row in dgvOrders.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) == currentCustOrder.orderID)
                        {
                            dgvOrders.ClearSelection();
                            dgvOrders.CurrentCell = dgvOrders.Rows[row.Index].Cells[0];
                            dgvOrders[0, row.Index].Selected = true;
                        }
                    }
                    DataGridViewRow selectedRow = dgvOrders.CurrentRow;
                    displayCustomerOrderInfo(selectedRow);
                    lblPayStatus_Supplier.Text = "PAYMENT STATUS";
                    clsbPayStatus_Supplier.DataSource = null;
                    clsbPayStatus_Supplier.DataSource = payStatus;
                    clsbDelStatus.DataSource = null;
                    clsbDelStatus.DataSource = custDelStatus;
                    displayCustomerOrders();
                }
                if(currentSupplierOrder!= null)
                {
                    foreach (DataGridViewRow row in dgvOrders.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) == currentSupplierOrder.orderID)
                        {
                            dgvOrders.ClearSelection();
                            dgvOrders.CurrentCell = dgvOrders.Rows[row.Index].Cells[0];
                            dgvOrders[0, row.Index].Selected = true;
                        }
                    }
                    DataGridViewRow selectedRow = dgvOrders.CurrentRow;
                    displaySupplierOrderInfo(selectedRow);
                    lblPayStatus_Supplier.Text = "SUPPLIER";
                    clsbPayStatus_Supplier.DataSource = null;
                    clsbPayStatus_Supplier.DataSource = supplierList;
                    clsbPayStatus_Supplier.DisplayMember = "Suppliers";
                    clsbPayStatus_Supplier.ValueMember = "supplierName";
                    clsbDelStatus.DataSource = null;
                    clsbDelStatus.DataSource = supplierDelStatus;
                    displaySupplierOrders();
                }
                
            }
            else
            {
                refresh();
            }
            clearChecked(clsbStatus);
            clearChecked(clsbDelStatus);
            clearChecked(clsbPayStatus_Supplier);
            dtpColDateFilter.Checked = false;
            dtpExpDateFilter.Checked = false;
            dtpOrderDateFilter.Checked = false;

        }
        private double applyVoucher(double amount) // Apply voucher according to the membership of the customer of the current customer order
        {
            if (amount < 0)
            {
                return 0;
            }
            else
            {
                //reapplying the vouchers
                if (currentCustOrder.voucher == "GOLD")
                {
                    return Math.Round(amount * 0.85, 2);
                }
                if (currentCustOrder.voucher == "SILVER")
                {
                    return Math.Round(amount * 0.9, 2);
                }
                if (currentCustOrder.voucher == "BRONZE")
                {
                    return Math.Round(amount * 0.95, 2);
                }
                else
                {
                    return amount;
                }
            }
        }
        private void disableEditing()
        {
            editMode = false;
            btnAddSave.Text = "New Order";

            //textboxes are all read only when not in edit mode

            //hide all editable fields
            dtpColDate.Visible = false;
            dtpExpDeliveryDate.Visible = false;
            dtpOrderDate.Visible = false;
            cbxDelStatus.Visible = false;
            tbxOrderDate.Visible = true;
            tbxExpectedDelivery.Visible = true;
            tbxColDate.Visible = true;
            tbxDelStatus.Visible = true;
            rtbxOrderNotes.ReadOnly = true;
            rtbxOrderNotes.BorderStyle = BorderStyle.None;
            rtbxOrderNotes.BackColor = SystemColors.ControlLightLight;

            btnCancel.Visible = false;
            btnViewOrderItems.Visible = true;

            //filters are only usable when not editing
            pnlFilters.Visible = true;
            if (rbtnCust.Checked)
            {
                lblColDateFilter.Visible = true;
                dtpColDateFilter.Visible = true;
            }
            rbtnCust.Visible = true;
            rbtnSuppliers.Visible = true;

            btnAddSave.Text = "New";

        }
        private void enableEditing()
        {
            if(currentCustOrder != null)
            {
                if (currentCustOrder.deliveryStatus != "Voided" && currentCustOrder.deliveryStatus != "Returned" && currentCustOrder.deliveryStatus != "Collected")
                {
                    // When an order has been returned or voided, only order notes can be edited.
                    dtpColDate.Visible = true;
                    dtpExpDeliveryDate.Visible = true;
                    dtpOrderDate.Visible = true;
                    cbxDelStatus.Visible = true;
                    tbxOrderDate.Visible = false;
                    tbxExpectedDelivery.Visible = false;
                    tbxColDate.Visible = false;
                    tbxDelStatus.Visible = false;
                    cbxDelStatus.Items.Clear();
                    cbxDelStatus.Items.AddRange(new string[] { "Collected", "Ready To Collect", "Order Made"});
                    cbxDelStatus.Text = currentCustOrder.deliveryStatus;
                }

            }
            if(currentSupplierOrder != null)
            {
                if(currentSupplierOrder.deliveryStatus != "Voided" && currentSupplierOrder.deliveryStatus != "Returned" && currentSupplierOrder.deliveryStatus!="Delivered")
                {
                    dtpColDate.Visible = false;

                    tbxDelStatus.Visible = false;
                    tbxPayStatus.Visible = false;

                    dtpExpDeliveryDate.Visible = true;

                    tbxExpectedDelivery.BackColor = Color.White;
                    tbxDelStatus.BackColor = Color.White;
                    tbxColDate.BackColor = Color.White;

                    cbxDelStatus.Visible = true;

                    cbxDelStatus.Items.Clear();
                    cbxDelStatus.Items.AddRange(new string[] { "Delivered", "Out For Delivery", "Order Made" });
                    dtpColDate.Visible = false;
                    cbxDelStatus.Text = currentSupplierOrder.deliveryStatus;
                }
            }

            // Order notes are always editable.
            rtbxOrderNotes.ReadOnly = false;
            rtbxOrderNotes.BackColor = Color.White;
            rtbxOrderNotes.BorderStyle = BorderStyle.Fixed3D;

            btnCancel.Visible = true;
            btnViewOrderItems.Visible = false;

            //filters are only usable when not editing
            pnlFilters.Visible = false;
            lblColDateFilter.Visible = false;
            dtpColDateFilter.Visible = false;
            rbtnCust.Visible = false;
            rbtnSuppliers.Visible = false;

            btnAddSave.Text = "Save";
        }


        // REFRESHING INFORMATION SHOWN
        private void refresh()
        {
            disableEditing();
            if (supplierRefresh)
            {
                // ensures the checked change event is triggered incase the radio button isnt selected at all
                rbtnSuppliers.Checked = false;
                rbtnSuppliers.Checked = true;
            }
            else
            {
                rbtnCust.Checked = false;
                rbtnCust.Checked = true;
            }
            updateCustomerList();
        }
        private void tbxSearch_TextChanged(object sender, EventArgs e)// As the user types in the search bar, orders are searched for according to the input.
        {
            if (!filtersApplied)
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {

                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    if (rbtnCust.Checked)
                    {
                        cmd.CommandText = "SELECT TableCustOrders.* FROM (TableCustOrders INNER JOIN TableCustomers ON TableCustOrders.CustID = TableCustomers.CustID) WHERE TableCustomers.FirstName LIKE @in OR TableCustomers.Surname LIKE @in OR TableCustomers.EmailAddress LIKE @in;";

                    }
                    if (rbtnSuppliers.Checked)
                    {
                        cmd.CommandText = "SELECT TableSupplierOrders.* FROM (TableSupplierOrders INNER JOIN TableSuppliers ON TableSupplierOrders.SupplierID = TableSuppliers.SupplierID) WHERE TableSuppliers.SupplierName LIKE @in";

                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@in", "%" + tbxSearch.Text + "%");
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvOrders.DataSource = bindingSource;
                    }
                    connection.Close();
                }
                else
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    if (rbtnCust.Checked)
                    {
                        cmd.CommandText = "SELECT * FROM TableCustOrders";
                    }
                    if (rbtnSuppliers.Checked)
                    {
                        cmd.CommandText = "SELECT * FROM TableSupplierOrders";
                    }
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvOrders.DataSource = bindingSource;
                    }
                    connection.Close();
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    if (rbtnCust.Checked)
                    {
                        cmd.CommandText = currentCommand + " AND (TableCustomers.FirstName LIKE @in OR TableCustomers.Surname LIKE @in OR TableCustomers.EmailAddress LIKE @in)";
                    }
                    if (rbtnSuppliers.Checked)
                    {
                        cmd.CommandText = currentCommand + " AND (TableSuppliers.SupplierName LIKE @in OR TableSuppliers.EmailAddress LIKE @in)";

                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ord", DateTime.Parse(dtpOrderDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@exd", DateTime.Parse(dtpExpDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@col", DateTime.Parse(dtpColDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@in", "%" + tbxSearch.Text + "%");
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvOrders.DataSource = bindingSource;
                    }
                    connection.Close();

                }
                else
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = currentCommand;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ord", DateTime.Parse(dtpOrderDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@exd", DateTime.Parse(dtpExpDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@col", DateTime.Parse(dtpColDateFilter.Value.ToShortDateString()));
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvOrders.DataSource = bindingSource;
                    }
                    connection.Close();
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e) // Search for orders by customer name/email address or supplier name
        {
            if (!filtersApplied)
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {

                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    if (rbtnCust.Checked)
                    {
                        cmd.CommandText = "SELECT TableCustOrders.* FROM (TableCustOrders INNER JOIN TableCustomers ON TableCustOrders.CustID = TableCustomers.CustID) WHERE TableCustomers.FirstName LIKE @in OR TableCustomers.Surname LIKE @in OR TableCustomers.EmailAddress LIKE @in;";

                    }
                    if (rbtnSuppliers.Checked)
                    {
                        cmd.CommandText = "SELECT TableSupplierOrders.* FROM (TableSupplierOrders INNER JOIN TableSuppliers ON TableSupplierOrders.SupplierID = TableSuppliers.SupplierID) WHERE TableSuppliers.SupplierName LIKE @in";

                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@in", "%" + tbxSearch.Text + "%");
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvOrders.DataSource = bindingSource;
                    }
                    else
                    {
                        MessageBox.Show("No orders found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
                else
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    if (rbtnCust.Checked)
                    {
                        cmd.CommandText = "SELECT * FROM TableCustOrders";
                    }
                    if (rbtnSuppliers.Checked)
                    {
                        cmd.CommandText = "SELECT * FROM TableSupplierOrders";
                    }
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvOrders.DataSource = bindingSource;
                    }
                    else
                    {
                        MessageBox.Show("No orders found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    if (rbtnCust.Checked)
                    {
                        cmd.CommandText = currentCommand + " AND (TableCustomers.FirstName LIKE @in OR TableCustomers.Surname LIKE @in OR TableCustomers.EmailAddress LIKE @in)";
                    }
                    if (rbtnSuppliers.Checked)
                    {
                        cmd.CommandText = currentCommand + " AND TableSuppliers.SupplierName LIKE @in";

                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ord", DateTime.Parse(dtpOrderDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@exd", DateTime.Parse(dtpExpDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@col", DateTime.Parse(dtpColDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@in", "%" + tbxSearch.Text + "%");
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvOrders.DataSource = bindingSource;
                    }
                    else
                    {
                        MessageBox.Show("No orders found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();

                }
                else
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = currentCommand;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ord", DateTime.Parse(dtpOrderDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@exd", DateTime.Parse(dtpExpDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@col", DateTime.Parse(dtpColDateFilter.Value.ToShortDateString()));
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvOrders.DataSource = bindingSource;
                    }
                    else
                    {
                        MessageBox.Show("No orders found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
            }
        }
        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e) // Allows the user to click on each order and view all details of each order
        {
            //when you click one cell it obtains info from the cell and puts it in the separate textboxes to display the info
            index = e.RowIndex;
            editMode = false;
            if (index < 0)
            {
                //Index cannot be negative.
                index = 0;
            }
            if (dgvOrders.DataSource == bindingSourceItems) // When viewing order items
            {
                displayOrderItemInfo(dgvOrders.Rows[index]);
                numQuantity.Enabled = false;
            }
            else
            {
                disableEditing(); // Disable editing when user clicks on another order
                if (rbtnCust.Checked == true)
                {
                    displayCustomerOrderInfo(dgvOrders.Rows[index]);

                }
                if (rbtnSuppliers.Checked == true)
                {
                    displaySupplierOrderInfo(dgvOrders.Rows[index]);
                }
                else // this is when an order has been passed into the form by notices
                {
                    if(currentCustOrder != null)
                    {

                        displayCustomerOrderInfo(dgvOrders.Rows[index]);
                    }
                    if(currentSupplierOrder != null)
                    {
                        displaySupplierOrderInfo(dgvOrders.Rows[index]);

                    }
                }
            }
        }
        private void displayCustomerOrders() // Displays all fields for customer orders
        {
            tbxStarsEarned.Visible = true;
            lblStarsEarned.Visible = true;

            tbxPayStatus.Visible = true;
            lblPayStatus.Visible = true;
            pnlPaymentInfo.Location = new Point(180, 147);

            lblVoucherUsed.Visible = true;
            tbxVoucher.Visible = true;

            lblPayStatus_Supplier.Text = "PAYMENT STATUS";
            clsbPayStatus_Supplier.DataSource = null;
            clsbPayStatus_Supplier.DataSource = payStatus;

            clsbDelStatus.DataSource = null;
            clsbDelStatus.DataSource = custDelStatus;

            lblOrderNotes.Location = new Point(9, 205);
            rtbxOrderNotes.Location = new Point(11, 226);

            tbxColDate.Visible = true;
            lblCollectionDate.Visible = true;
            dtpColDateFilter.Visible = true;
            lblColDateFilter.Visible = true;

            lblID.Text = "Customer ID";
            lblName.Text = "Full Name";
            lblURL.Text = "Membership Type";

            supplierRefresh = false;
            if (editMode)
            {
                dtpColDate.Visible = true;
            }
            printInvoiceToolStripMenuItem.Visible = true;
        }
        private void updateCustomerList() // Refreshes the list of customers
        {
            //loads customers into a list of instances
            customerList.Clear();
            OleDbConnection conCustomers = new OleDbConnection();
            conCustomers.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmdCustomers = conCustomers.CreateCommand();
            OleDbDataReader readerCustomers;
            conCustomers.Open();
            cmdCustomers.CommandText = "SELECT * FROM TableCustomers WHERE MemType <> 'Deleted' AND MemType <> 'Guest'";
            cmdCustomers.Connection = conCustomers;
            readerCustomers = cmdCustomers.ExecuteReader();
            while (readerCustomers.Read())
            {
                //instantiates new customer every time the loop iterates
                customerList.Add(new Customer(Convert.ToInt32(readerCustomers[0]), Convert.ToString(readerCustomers[1]), Convert.ToString(readerCustomers[2]), Convert.ToString(readerCustomers[3]), Convert.ToString(readerCustomers[4]), Convert.ToString(readerCustomers[5]), Convert.ToInt32(readerCustomers[6]), Convert.ToInt32(readerCustomers[7])));
            }
            conCustomers.Close();
        }
        private void displayCustomerOrderInfo(DataGridViewRow selectedRow) // Displays all customer order details
        {
            // Loads all the information of the selected customer order into an object to be used to display all the order and customer information.
            currentCustOrder = new CustOrder(Convert.ToInt32(selectedRow.Cells[0].Value), Convert.ToInt32(selectedRow.Cells[1].Value), Convert.ToDateTime(selectedRow.Cells[2].Value), Convert.ToDateTime(selectedRow.Cells[3].Value), selectedRow.Cells[4].Value.ToString(), Convert.ToDouble(selectedRow.Cells[8].Value), Convert.ToDouble(selectedRow.Cells[9].Value), Convert.ToString(selectedRow.Cells[11].Value), Convert.ToDateTime(selectedRow.Cells[6].Value), selectedRow.Cells[5].Value.ToString(), Convert.ToInt32(selectedRow.Cells[7].Value), selectedRow.Cells[10].Value.ToString());
            currentOrderList = currentCustOrder.OrderItemList();
            tbxOrderID.Text = currentCustOrder.orderID.ToString();
            dtpOrderDate.Value = currentCustOrder.orderDate;
            tbxOrderDate.Text = currentCustOrder.orderDate.ToString("dd/MM/yyyy");
            dtpExpDeliveryDate.Value = currentCustOrder.deliveryDate;
            tbxExpectedDelivery.Text = currentCustOrder.deliveryDate.ToString("dd/MM/yyyy");
            tbxDelStatus.Text = currentCustOrder.deliveryStatus;
            selectedDelStatus = tbxDelStatus.Text;
            tbxStatus.Text = currentCustOrder.status;
            tbxPayStatus.Text = currentCustOrder.paymentStatus;
            selectedPayStatus = tbxPayStatus.Text;
            dtpColDate.Value = currentCustOrder.colDateEnd;
            tbxColDate.Text = currentCustOrder.colDateEnd.ToString("dd/MM/yyyy");
            tbxStarsEarned.Text = currentCustOrder.starsEarned.ToString();
            tbxSubtotal.Text = currentCustOrder.subtotalString();
            tbxTotal.Text = currentCustOrder.totalString();
            tbxVoucher.Text = currentCustOrder.voucher;
            rtbxOrderNotes.Text = currentCustOrder.orderNotes;

            currentCust = currentCustOrder.GetCustomerDetails;

            tbxID.Text = currentCust.id.ToString();
            tbxFullName.Text = currentCust.fullName;
            tbxPhoneNum.Text = currentCust.phoneNum;
            tbxEmailAdd.Text = currentCust.emailAddress;
            tbxURL.Text = currentCust.memType;

            if(currentCustOrder.deliveryStatus == "Voided" || currentCustOrder.deliveryStatus == "Returned")
            {
                // If the order is voided or returned, this status cannot be modified.
                voidToolStripMenuItem.Visible = false;
                returnOrderToolStripMenuItem.Visible = false;
            }
            else if (currentCustOrder.deliveryStatus == "Collected")
            {
                // The order can only be returned when it's been delivered.
                voidToolStripMenuItem.Visible = false;
                returnOrderToolStripMenuItem.Visible = true;
            }
            else
            {
                voidToolStripMenuItem.Visible = true;
                returnOrderToolStripMenuItem.Visible = false;
            }
        }
        private void displaySupplierOrders() // Displays all fields for supplier orders
        {
            //moving textboxes and labels so visually appealing
            tbxStarsEarned.Visible = false;
            lblStarsEarned.Visible = false;

            tbxColDate.Visible = false;
            lblCollectionDate.Visible = false;
            lblColDateFilter.Visible = false;
            dtpColDateFilter.Visible = false;

            tbxPayStatus.Visible = false;
            lblPayStatus.Visible = false;
            
            lblVoucherUsed.Visible = false;
            tbxVoucher.Visible = false;

            pnlPaymentInfo.Location = new Point(180, 99);
            lblPayStatus_Supplier.Text = "SUPPLIER";
            clsbPayStatus_Supplier.DataSource = null;
            clsbPayStatus_Supplier.DisplayMember = null;
            clsbPayStatus_Supplier.ValueMember = null;
            clsbPayStatus_Supplier.DataSource = supplierList;
            clsbPayStatus_Supplier.DisplayMember = "Suppliers";
            clsbPayStatus_Supplier.ValueMember = "supplierName";

            clsbDelStatus.DataSource = null;
            clsbDelStatus.DataSource = supplierDelStatus;

            lblOrderNotes.Location = lblCollectionDate.Location;
            rtbxOrderNotes.Location = tbxColDate.Location;
            rtbxOrderNotes.Text = "";

            lblID.Text = "Supplier ID";
            lblName.Text = "Supplier Name";
            lblURL.Text = "URL";

            supplierRefresh = true;
            printInvoiceToolStripMenuItem.Visible = false;
        }
        private void updateSupplierList() // Refreshes the list of suppliers
        {
            //loads suppliers into a list of instances
            OleDbConnection conSuppliers = new OleDbConnection();
            conSuppliers.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmdSuppliers = conSuppliers.CreateCommand();
            OleDbDataReader readerSuppliers;
            conSuppliers.Open();
            cmdSuppliers.CommandText = "SELECT * FROM TableSuppliers WHERE SupplierName <> 'Deleted' AND EmailAddress <> 'Deleted'";
            cmdSuppliers.Connection = conSuppliers;
            readerSuppliers = cmdSuppliers.ExecuteReader();
            while (readerSuppliers.Read())
            {
                //instantiates new supplier every time the loop iterates
                supplierList.Add(new Supplier(Convert.ToInt32(readerSuppliers[0]), Convert.ToString(readerSuppliers[1]), Convert.ToString(readerSuppliers[2]), Convert.ToString(readerSuppliers[3]), Convert.ToString(readerSuppliers[4]), Convert.ToString(readerSuppliers[5]), Convert.ToString(readerSuppliers[6])));
            }
            conSuppliers.Close();

            foreach (Supplier sup in supplierList)
            {
                SupplierNameList.Add(sup.supplierName);
            }
        }
        private void displaySupplierOrderInfo(DataGridViewRow selectedRow) // Displays all supplier order details
        {
            // Loads all the information of the selected supplier order into an object to be used to display all the order and supplier information.
            currentSupplierOrder = new Order(Convert.ToInt32(selectedRow.Cells[0].Value), Convert.ToInt32(selectedRow.Cells[1].Value), Convert.ToDateTime(selectedRow.Cells[2].Value), Convert.ToDateTime(selectedRow.Cells[3].Value), selectedRow.Cells[4].Value.ToString(), Convert.ToDouble(selectedRow.Cells[5].Value), Convert.ToDouble(selectedRow.Cells[6].Value), selectedRow.Cells[7].Value.ToString());
            tbxOrderID.Text = currentSupplierOrder.orderID.ToString();
            dtpOrderDate.Value = currentSupplierOrder.orderDate;
            tbxOrderDate.Text = currentSupplierOrder.orderDate.ToString("dd/MM/yyyy");
            dtpExpDeliveryDate.Value = currentSupplierOrder.deliveryDate;
            tbxExpectedDelivery.Text = currentSupplierOrder.deliveryDate.ToString("dd/MM/yyyy");
            tbxDelStatus.Text = currentSupplierOrder.deliveryStatus;
            selectedDelStatus = tbxDelStatus.Text;
            tbxStatus.Text = currentSupplierOrder.status;
            tbxSubtotal.Text = currentSupplierOrder.subtotalString();
            tbxTotal.Text = currentSupplierOrder.totalString();
            rtbxOrderNotes.Text = currentSupplierOrder.orderNotes;

            currentSupp = currentSupplierOrder.GetSupplierDetails();

            tbxID.Text = currentSupp.id.ToString();
            tbxFullName.Text = currentSupp.supplierName;
            tbxPhoneNum.Text = currentSupp.phoneNum;
            tbxEmailAdd.Text = currentSupp.emailAddress;
            tbxURL.Text = currentSupp.url;

            if (currentSupplierOrder.deliveryStatus == "Voided" || currentSupplierOrder.deliveryStatus == "Returned")
            {
                voidToolStripMenuItem.Visible = false;
                returnOrderToolStripMenuItem.Visible = false;
            }
            else if(currentSupplierOrder.deliveryStatus == "Delivered")
            {
                voidToolStripMenuItem.Visible = false;
                returnOrderToolStripMenuItem.Visible = true;
            }
            else
            {
                voidToolStripMenuItem.Visible = true;
                returnOrderToolStripMenuItem.Visible = false;
            }
        }
        private void btnViewOrderItems_Click(object sender, EventArgs e) // Switches between order details and details of the products in the order
        {
            switchPanels();
        }
        private void switchPanels() // Switch between viewing order information and viewing order items
        {
            if (dgvOrders.DataSource != bindingSourceItems)
            {
                rbtnCust.Visible = false;
                rbtnSuppliers.Visible = false;
                pnlFilters.Visible = false;
                editToolStripMenuItem.Visible = false;
                voidToolStripMenuItem.Text = "Void Item";
                returnOrderToolStripMenuItem.Text = "Return Item";
                printInvoiceToolStripMenuItem.Visible = false;

                pnlProductInfo.Visible = true;
                pnlOrderInfo.Visible = false;
                lblOrderInfo.Text = "Product Info";

                btnViewOrderItems.Text = "View Order Info";

                refreshOrderItemsDGV();
                displayOrderItemInfo((dgvOrders.Rows[0]));
            }
            else
            {
                rbtnCust.Visible = true;
                rbtnSuppliers.Visible = true;
                pnlFilters.Visible = true;
                editToolStripMenuItem.Text = "Edit";
                editToolStripMenuItem.Visible = true;
                voidToolStripMenuItem.Text = "Void Order";
                returnOrderToolStripMenuItem.Text = "Return Order";
                printInvoiceToolStripMenuItem.Visible = true;

                pnlProductInfo.Visible = false;
                pnlOrderInfo.Visible = true;
                lblOrderInfo.Text = "Order Info";

                btnViewOrderItems.Text = "View Order Items";

                if (rbtnCust.Checked)
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = "SELECT * FROM TableCustOrders";
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvOrders.DataSource = bindingSource;
                    connection.Close();

                }
                if (rbtnSuppliers.Checked)
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = "SELECT * FROM TableSupplierOrders";
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvOrders.DataSource = bindingSource;
                    connection.Close();
                }

                // so the order record is selected when the user switches back to the order view
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (tbxOrderID.Text == row.Cells[0].Value.ToString())
                    {
                        dgvOrders.ClearSelection();
                        row.Selected = true;
                    }
                }
            }
        }
        private void refreshOrderItemsDGV() // Shows all products in the order in the dgv.
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            if (rbtnCust.Checked)
            {
                currentOrderList = currentCustOrder.OrderItemList(); //refresh the list
                cmd.CommandText = "SELECT DISTINCT TableProducts.ProductID, TableProducts.ProductName, TableCustOrderItems.Quantity,TableCustOrderItems.QuantityVoided,TableCustOrderItems.QuantityReturned, TableProducts.BallWeightSize,TableProducts.Category,TableProducts.Colour,TableProducts.FibreMaterial,TableProducts.ProductType FROM (TableProducts INNER JOIN TableCustOrderItems ON TableProducts.ProductID = TableCustOrderItems.ProductID) INNER JOIN TableCustOrders ON TableCustOrderItems.OrderID = TableCustOrders.@oid;";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oid", currentCustOrder.orderID);

            }
            else
            {
                currentOrderList = currentSupplierOrder.OrderItemList(); //refresh the list
                cmd.CommandText = "SELECT DISTINCT TableProducts.ProductID, TableProducts.ProductName, TableSupplierOrderItems.Quantity,TableSupplierOrderItems.QuantityVoided,TableSupplierOrderItems.QuantityReturned, TableProducts.BallWeightSize,TableProducts.Category,TableProducts.Colour,TableProducts.FibreMaterial,TableProducts.ProductType FROM (TableProducts INNER JOIN TableSupplierOrderItems ON TableProducts.ProductID = TableSupplierOrderItems.ProductID) INNER JOIN TableSupplierOrders ON TableSupplierOrderItems.OrderID = TableSupplierOrders.@oid;";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oid", currentSupplierOrder.orderID);

            }
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            bindingSourceItems.DataSource = reader;
            dgvOrders.DataSource = bindingSourceItems;
            connection.Close();
            numQuantity.Enabled = false;
        }
        private void displayOrderItemInfo(DataGridViewRow selectedRow) // Display information of the product currently selected
        {
            foreach (OrderItem item in currentOrderList)
            {
                if (Convert.ToInt32(selectedRow.Cells[0].Value) == item.product.id)
                {
                    currentOrderItem = item;
                }
            }
            if (currentOrderItem != null)
            {
                tbxProductID.Text = currentOrderItem.product.id.ToString();
                tbxProductName.Text = currentOrderItem.product.name;
                tbxProductCost.Text = currentOrderItem.product.CostString;
                tbxStock.Text = currentOrderItem.product.stock.ToString();

                //this loop searches through the array of Suppliers and matches the selected product's supplier
                //  to the corresponding supplier in the array using their ID, then returns the supplier name to the textbox

                foreach (Supplier selectingSup in supplierList)
                {
                    if (selectingSup.id == currentOrderItem.product.supplierID)
                    {
                        tbxSupplier.Text = selectingSup.supplierName;
                    }
                }

                tbxType.Text = selectedRow.Cells[5].Value.ToString();
                tbxCategory.Text = selectedRow.Cells[6].Value.ToString();
                tbxColour.Text = selectedRow.Cells[7].Value.ToString();
                tbxFibre.Text = selectedRow.Cells[8].Value.ToString();
                numQuantity.Maximum = currentOrderItem.quantityRemaining;
                numQuantity.Value = numQuantity.Maximum;
                tbxQuantityVoided.Text = currentOrderItem.quantityVoided.ToString();
                tbxQuantityReturned.Text = currentOrderItem.quantityReturned.ToString();

                //changes the field names based on the type of product selected

                if (selectedRow.Cells[9].Value.ToString() == "y")
                {
                    lblType.Text = "Ball Weight";
                    lblCategory.Text = "Yarn Weight";
                    lblFibre.Text = "Fibre";
                }
                if (selectedRow.Cells[9].Value.ToString() == "a")
                {
                    lblType.Text = "Size";
                    lblCategory.Text = "Category";
                    lblFibre.Text = "Material";
                }
            }
        }

        // FILTERS
        private void rbtnCust_CheckedChanged(object sender, EventArgs e)
        {
            currentSupplierOrder = null;
            if (rbtnCust.Checked == true)
            {
                pnlFilters.Visible = true;
                if (pnlProductInfo.Visible)
                {
                    pnlFilters.Visible = false;
                    chbxOrderNotes.Enabled = true;
                    editToolStripMenuItem.Text = "Edit";
                    voidToolStripMenuItem.Text = "Void Order";
                    returnOrderToolStripMenuItem.Text = "Return Order";

                    pnlContactInfo.Enabled = true;
                    pnlProductInfo.Visible = false;
                    pnlOrderInfo.Visible = true;
                    lblOrderInfo.Text = "Order Info";

                    btnViewOrderItems.Text = "View Order Items";
                }

                lblPayStatus_Supplier.Text = "PAYMENT STATUS";
                clsbPayStatus_Supplier.DataSource = null;
                clsbPayStatus_Supplier.DataSource = payStatus;

                clsbDelStatus.DataSource = null;
                clsbDelStatus.DataSource = custDelStatus;

                clearChecked(clsbStatus);
                clearChecked(clsbDelStatus);
                clearChecked(clsbPayStatus_Supplier);
                dtpOrderDateFilter.Value = DateTime.Today;
                dtpExpDateFilter.Value = DateTime.Today;
                dtpColDateFilter.Value = DateTime.Today;

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableCustOrders";
                cmd.Parameters.Clear();
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvOrders.DataSource = bindingSource;
                connection.Close();
                filtersApplied = false;
                printInvoiceToolStripMenuItem.Visible = true;


                //ensures there is always something in the textboxes so null values don't appear when you edit another customer straight after
                displayCustomerOrderInfo(dgvOrders.Rows[0]);
                displayCustomerOrders();
            }
        }
        private void rbtnSuppliers_CheckedChanged(object sender, EventArgs e)
        {
            currentCustOrder = null;
            if (rbtnSuppliers.Checked == true)
            {
                pnlFilters.Visible = true;
                if (pnlProductInfo.Visible)
                {
                    pnlFilters.Visible = false;
                    chbxOrderNotes.Enabled = true;
                    editToolStripMenuItem.Text = "Edit";
                    voidToolStripMenuItem.Text = "Void Order";
                    returnOrderToolStripMenuItem.Text = "Return Order";

                    pnlContactInfo.Enabled = true;
                    pnlProductInfo.Visible = false;
                    pnlOrderInfo.Visible = true;
                    lblOrderInfo.Text = "Order Info";

                    btnViewOrderItems.Text = "View Order Items";
                }
                clearChecked(clsbStatus);
                clearChecked(clsbDelStatus);
                clearChecked(clsbPayStatus_Supplier);
                dtpOrderDateFilter.Value = DateTime.Today;
                dtpExpDateFilter.Value = DateTime.Today;
                dtpColDateFilter.Value = DateTime.Today;

                lblPayStatus_Supplier.Text = "SUPPLIER";
                clsbPayStatus_Supplier.DataSource = null;
                clsbPayStatus_Supplier.DataSource = supplierList;
                clsbPayStatus_Supplier.DisplayMember = "Suppliers";
                clsbPayStatus_Supplier.ValueMember = "supplierName";

                clsbDelStatus.DataSource = null;
                clsbDelStatus.DataSource = supplierDelStatus;

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableSupplierOrders";
                cmd.Parameters.Clear();
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvOrders.DataSource = bindingSource;
                connection.Close();
                filtersApplied = false;
                printInvoiceToolStripMenuItem.Visible = false;
                //ensures there is always something in the textboxes so null values don't appear when you edit another customer straight after
                displaySupplierOrderInfo(dgvOrders.Rows[0]);
                displaySupplierOrders();
            }
        }
        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            filtersApplied = false;
            if (clsbStatus.CheckedItems.Count == 0 && clsbDelStatus.CheckedItems.Count == 0 && clsbPayStatus_Supplier.CheckedItems.Count == 0 && !dtpOrderDateFilter.Checked && !dtpExpDateFilter.Checked && !dtpColDateFilter.Checked && !chbxOrderNotes.Checked)
            {
                // If none of the filters are selected, display all records. This condition is here to prevent the error that occurs since WHERE is still in the base command statement.
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                if (rbtnCust.Checked)
                {
                    cmd.CommandText = "SELECT * FROM TableCustOrders";
                }
                if (rbtnSuppliers.Checked)
                {
                    cmd.CommandText = "SELECT * FROM TableSupplierOrders";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ya", "a");
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvOrders.DataSource = bindingSource;
                connection.Close();
            }
            else
            {
                if (rbtnCust.Checked)
                {
                    string baseCommandText = "SELECT * FROM TableCustOrders WHERE";

                    string delStatusFilterCommand = " DeliveryStatus IN (";
                    string payStatusFilterCommand = " PaymentStatus IN (";

                    // Need these lists to store the selected items for each checked list box.
                    // Since a new list is created each time the user clicks the apply button, the list will be cleared each time.
                    List<string> selectedStatusFilters = new List<string>();
                    List<string> selectedDelStatusFilters = new List<string>();
                    List<string> selectedPayStatusFilters = new List<string>();

                    // Load all the checked filters into their corresponding lists
                    selectedStatusFilters = clsbStatus.CheckedItems.Cast<string>().ToList();
                    if (selectedStatusFilters.Count == 2)
                    {
                        // If both Archived and Open are selected, add all delivery statuses to the delivery status filters.
                        selectedDelStatusFilters.AddRange(clsbDelStatus.Items.Cast<string>().ToList());
                    }
                    else if (selectedStatusFilters.Contains("Archived"))
                    {
                        filtersApplied = true;
                        selectedDelStatusFilters.AddRange(new List<string> { "Collected", "Voided", "Returned" });
                    }
                    else if (selectedStatusFilters.Contains("Open"))
                    {
                        filtersApplied = true;
                        selectedDelStatusFilters.AddRange(new List<string> { "Order Made", "Ready To Collect"});
                    }

                    if(selectedDelStatusFilters.Count != 0 && selectedDelStatusFilters != clsbDelStatus.Items.Cast<string>().ToList())
                    {
                        filtersApplied = true;
                        // If filters have already been added as a result of any statuses being selected
                        // And archived and open have not both been selected resulting in all delivery statuses already being added
                        List<string> tempDelStatusFilters = clsbDelStatus.CheckedItems.Cast<string>().ToList();
                        foreach (string delStatusFilter in tempDelStatusFilters)
                        {
                            if (!selectedDelStatusFilters.Contains(delStatusFilter))
                            {
                                selectedDelStatusFilters.Add(delStatusFilter);
                            }
                        }
                    }
                    else if (selectedDelStatusFilters != selectedStatusFilters)
                    {
                        filtersApplied = true;
                        // If there is nothing in delivery status filters
                        selectedDelStatusFilters = clsbDelStatus.CheckedItems.Cast<string>().ToList();
                    }
                    selectedPayStatusFilters = clsbPayStatus_Supplier.CheckedItems.Cast<string>().ToList();

                    // Building the command string
                    if (selectedDelStatusFilters.Count != 0)
                    {
                        filtersApplied = true;
                        if (!baseCommandText.EndsWith("E"))
                        {
                            delStatusFilterCommand = " AND " + delStatusFilterCommand;
                        }
                        foreach (string delStatusFilter in selectedDelStatusFilters)
                        {
                            // If there isn't anything in the string so far, don't want it to start with a comma.
                            if (delStatusFilterCommand.EndsWith("("))
                            {
                                delStatusFilterCommand += "'" + delStatusFilter + "'";
                            }
                            // Add the checked filter to the command string.
                            else
                            {
                                delStatusFilterCommand += "," + "'" + delStatusFilter + "'";
                            }
                        }
                        delStatusFilterCommand += ")";
                        baseCommandText += delStatusFilterCommand;
                    }
                    if (selectedPayStatusFilters.Count != 0)
                    {
                        if (!baseCommandText.EndsWith("E"))
                        {
                            payStatusFilterCommand = " AND " + payStatusFilterCommand;
                        }
                        foreach (string payStatusFilter in selectedPayStatusFilters)
                        {
                            // If there isn't anything in the string so far, don't want it to start with a comma.
                            if (payStatusFilterCommand.EndsWith("("))
                            {
                                payStatusFilterCommand += "'" + payStatusFilter + "'";
                            }
                            // Add the checked filter to the command string.
                            else
                            {
                                payStatusFilterCommand += "," + "'" + payStatusFilter + "'";
                            }
                        }
                        payStatusFilterCommand += ")";
                        baseCommandText += payStatusFilterCommand;

                    }

                    // Commands need to end with a closing bracket- SQL syntax.

                    if (dtpOrderDateFilter.Checked)
                    {
                        filtersApplied = true;
                        if (!baseCommandText.EndsWith("E"))
                        {
                            baseCommandText += " AND OrderDate = @ord";
                        }
                        else
                        {
                            baseCommandText += " OrderDate = @ord";
                        }
                    }
                    if (dtpExpDateFilter.Checked)
                    {
                        filtersApplied = true;
                        if (!baseCommandText.EndsWith("E"))
                        {
                            baseCommandText += " AND DeliveryDate = @exd";
                        }
                        else
                        {
                            baseCommandText += " DeliveryDate = @exd";
                        }
                    }
                    if (dtpColDateFilter.Checked)
                    {
                        filtersApplied = true;
                        if (!baseCommandText.EndsWith("E"))
                        {
                            baseCommandText += " AND CollectionDateEnd = @col";
                        }
                        else
                        {
                            baseCommandText += " CollectionDateEnd = @col";
                        }
                    }
                    if (chbxOrderNotes.Checked)
                    {
                        filtersApplied = true;
                        if (!baseCommandText.EndsWith("E"))
                        {
                            baseCommandText += " AND OrderNotes IS NOT NULL";
                        }
                        else
                        {
                            baseCommandText += " OrderNotes IS NOT NULL";
                        }
                    }


                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = baseCommandText;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ord", DateTime.Parse(dtpOrderDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@exd", DateTime.Parse(dtpExpDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@col", DateTime.Parse(dtpColDateFilter.Value.ToShortDateString()));
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    if (reader.HasRows)
                    {
                        bindingSource.DataSource = reader;
                        dgvOrders.DataSource = bindingSource;
                        displayCustomerOrderInfo(dgvOrders.Rows[0]);
                    }
                    else
                    {
                        MessageBox.Show("No results found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
                if (rbtnSuppliers.Checked)
                {
                    string baseCommandText = "SELECT * FROM TableSupplierOrders WHERE";

                    string delStatusFilterCommand = " DeliveryStatus IN (";
                    string supplierFilterCommand = " SupplierID IN (";
                    //string orderDateFilterCommand = "";

                    // Need these lists to store the selected items for each checked list box.
                    // Since a new list is created each time the user clicks the apply button, the list will be cleared each time.
                    List<string> selectedStatusFilters = new List<string>();
                    List<string> selectedDelStatusFilters = new List<string>();
                    List<int> selectedSupplierFilters = new List<int>();

                    // Load all the checked filters into their corresponding lists
                    selectedStatusFilters = clsbStatus.CheckedItems.Cast<string>().ToList();
                    if (selectedStatusFilters.Count == 2)
                    {
                        // If both Archived and Open are selected, add all delivery statuses to the delivery status filters.
                        selectedDelStatusFilters.AddRange(clsbDelStatus.Items.Cast<string>().ToList());
                    }
                    else if (selectedStatusFilters.Contains("Archived"))
                    {
                        filtersApplied = true;
                        selectedDelStatusFilters.AddRange(new List<string> { "Delivered", "Voided", "Returned" });
                    }
                    else if(selectedStatusFilters.Contains("Open"))
                    {
                        filtersApplied = true;
                        selectedDelStatusFilters.AddRange(new List<string> { "Order Made", "Out For Delivery" });
                    }

                    if (selectedDelStatusFilters.Count != 0 && selectedDelStatusFilters != clsbDelStatus.Items.Cast<string>().ToList())
                    {
                        filtersApplied = true;
                        // If filters have already been added as a result of any statuses being selected
                        // And archived and open have not both been selected resulting in all delivery statuses already being added
                        List<string> tempDelStatusFilters = clsbDelStatus.CheckedItems.Cast<string>().ToList();
                        foreach (string delStatusFilter in tempDelStatusFilters)
                        {
                            if (!selectedDelStatusFilters.Contains(delStatusFilter))
                            {
                                selectedDelStatusFilters.Add(delStatusFilter);
                            }
                        }
                    }
                    else if (selectedDelStatusFilters != selectedStatusFilters)
                    {
                        filtersApplied = true;
                        // If there is nothing in delivery status filters
                        selectedDelStatusFilters = clsbDelStatus.CheckedItems.Cast<string>().ToList();
                    }

                    foreach (Supplier supplier in clsbPayStatus_Supplier.CheckedItems)
                    {
                        filtersApplied = true;
                        foreach (Supplier findSupplier in supplierList)
                        {
                            if (supplier == findSupplier)
                            {
                                selectedSupplierFilters.Add(supplier.id);
                            }
                        }
                    }
                    // Building the command string

                    if (selectedDelStatusFilters.Count != 0)
                    {
                        filtersApplied = true;
                        if (!baseCommandText.EndsWith("E"))
                        {
                            delStatusFilterCommand = " AND " + delStatusFilterCommand;
                        }
                        foreach (string delStatusFilter in selectedDelStatusFilters)
                        {
                            // If there isn't anything in the string so far, don't want it to start with a comma.
                            if (delStatusFilterCommand.EndsWith("("))
                            {
                                delStatusFilterCommand += "'" + delStatusFilter + "'";
                            }
                            // Add the checked filter to the command string.
                            else
                            {
                                delStatusFilterCommand += "," + "'" + delStatusFilter + "'";
                            }
                        }
                        delStatusFilterCommand += ")";
                        baseCommandText += delStatusFilterCommand;
                    }
                    if (selectedSupplierFilters.Count != 0)
                    {
                        filtersApplied = true;
                        if (!baseCommandText.EndsWith("E"))
                        {
                            supplierFilterCommand = " AND " + supplierFilterCommand;
                        }
                        foreach (int supplierFilter in selectedSupplierFilters)
                        {
                            // If there isn't anything in the string so far, don't want it to start with a comma.
                            if (supplierFilterCommand.EndsWith("("))
                            {
                                supplierFilterCommand += supplierFilter;
                            }
                            // Add the checked filter to the command string.
                            else
                            {
                                supplierFilterCommand += "," + supplierFilter;
                            }
                        }
                        supplierFilterCommand += ")";
                        baseCommandText += supplierFilterCommand;

                    }

                    // Commands need to end with a closing bracket- SQL syntax.

                    if (dtpOrderDateFilter.Checked)
                    {
                        filtersApplied = true;
                        if (!baseCommandText.EndsWith("E"))
                        {
                            baseCommandText += " AND OrderDate = @ord";
                        }
                        else
                        {
                            baseCommandText += " OrderDate = @ord";
                        }
                    }
                    if (dtpExpDateFilter.Checked)
                    {
                        filtersApplied = true;
                        if (!baseCommandText.EndsWith("E"))
                        {
                            baseCommandText += " AND DeliveryDate = @exd";
                        }
                        else
                        {
                            baseCommandText += " DeliveryDate = @exd";
                        }
                    }
                    if (chbxOrderNotes.Checked)
                    {
                        filtersApplied = true;
                        if (!baseCommandText.EndsWith("E"))
                        {
                            baseCommandText += " AND OrderNotes IS NOT NULL";
                        }
                        else
                        {
                            baseCommandText += " OrderNotes IS NOT NULL";
                        }
                    }

                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = baseCommandText;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ord", DateTime.Parse(dtpOrderDateFilter.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@exd", DateTime.Parse(dtpExpDateFilter.Value.ToShortDateString()));
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    if (reader.HasRows)
                    {
                        bindingSource.DataSource = reader;
                        dgvOrders.DataSource = bindingSource;
                        displaySupplierOrderInfo(dgvOrders.Rows[0]);
                        currentCommand = baseCommandText;
                    }
                    else
                    {
                        MessageBox.Show("No results found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }

            }

        }
        private void clearChecked(CheckedListBox clsbToClear)
        {
            for (int i = 0; i < clsbToClear.Items.Count; i++)
            {
                clsbToClear.SetSelected(i, false);
                clsbToClear.SetItemChecked(i, false);
            }
            clsbToClear.ClearSelected();
        }
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will clear all filters. Proceed?", "Clear All Filters", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                clearChecked(clsbStatus);
                clearChecked(clsbDelStatus);
                clearChecked(clsbPayStatus_Supplier);
                chbxOrderNotes.Checked = false;
                dtpOrderDateFilter.Value = DateTime.Today;
                dtpExpDateFilter.Value = DateTime.Today;
                dtpColDateFilter.Value = DateTime.Today;
                dtpOrderDateFilter.Checked = false;
                dtpExpDateFilter.Checked = false;
                dtpColDateFilter.Checked = false;

                if (rbtnCust.Checked)
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = "SELECT * FROM TableCustOrders";
                    cmd.Parameters.Clear();
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvOrders.DataSource = bindingSource;
                    connection.Close();
                }
                if (rbtnSuppliers.Checked)
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = "SELECT * FROM TableSupplierOrders";
                    cmd.Parameters.Clear();
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvOrders.DataSource = bindingSource;
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("No filters were deleted.", "Clear All Filters", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            filtersApplied = false;
        }

        // EDITING, VOIDING, RETURNING ORDERS
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.DataSource != bindingSourceItems) // When viewing order items and the quantity of an order item is to be edited.
            {
                //TO EDIT THE ORDER

                //changes the add button to a save button
                editMode = true;
                enableEditing();
            }
        }
        private void btnAddSave_Click(object sender, EventArgs e )
        {
            if (!editMode)
            {
                if (rbtnCust.Checked)
                {
                    NewCustOrder formMakeCustOrder = new NewCustOrder();
                    formMakeCustOrder.ShowDialog();
                }
                if (rbtnSuppliers.Checked)
                {
                    NewSupplierOrder formMakeSupplierOrder = new NewSupplierOrder(null);
                    formMakeSupplierOrder.ShowDialog();
                    supplierRefresh = true;
                }
                refresh();

            }
            else
            //EDITS PRODUCT IN DATABASE
            {
                if (rtbxOrderNotes.Text == "")
                {
                    rtbxOrderNotes.Text = " ";
                }
                if (dtpExpDeliveryDate.Value < dtpOrderDate.Value)
                {
                    MessageBox.Show("You cannot enter an expected delivery date that falls before the order date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpExpDeliveryDate.Value = dtpOrderDate.Value.AddDays(3);
                    dtpColDate.Value = dtpExpDeliveryDate.Value.AddDays(7);
                }
                else if (dtpColDate.Value < dtpOrderDate.Value)
                {
                    MessageBox.Show("You cannot enter a collection end date that falls before the order date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpColDate.Value = dtpExpDeliveryDate.Value.AddDays(7);
                }
                else if (dtpColDate.Value < dtpExpDeliveryDate.Value.AddDays(-7))
                {
                    MessageBox.Show("You cannot enter a collection end date that falls before the expected delivery date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpColDate.Value = dtpExpDeliveryDate.Value.AddDays(7);
                }
                else
                {
                    if (rbtnCust.Checked)
                    {
                        if(cbxDelStatus.Text == "Ready To Collect" && currentCustOrder.deliveryStatus != cbxDelStatus.Text && dtpExpDeliveryDate.Value == currentCustOrder.deliveryDate)
                        {
                            // If the order's delivery status has been changed to 'Ready to Collect'
                            // If the delivery date has not been changed by the user
                            // Set the delivery date to the day that it became ready for collection and the collection date end for a week after
                            dtpExpDeliveryDate.Value = DateTime.Today;
                            dtpColDate.Value = dtpExpDeliveryDate.Value.AddDays(7);
                        }
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        connection.Open();
                        cmd.CommandText = "UPDATE TableCustOrders SET OrderDate = @od, DeliveryDate = @dda, DeliveryStatus = @dsa, PaymentStatus = @psa, CollectionDateEnd = @col,OrderNotes = @ordn WHERE CustOrderID = @orid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@od", Convert.ToString(dtpOrderDate.Value));
                        cmd.Parameters.AddWithValue("@dda", Convert.ToString(dtpExpDeliveryDate.Value));
                        cmd.Parameters.AddWithValue("@dsa", cbxDelStatus.Text);
                        cmd.Parameters.AddWithValue("@psa", tbxPayStatus.Text);
                        cmd.Parameters.AddWithValue("@col", Convert.ToString(dtpColDate.Value));
                        cmd.Parameters.AddWithValue("@ordn", rtbxOrderNotes.Text);
                        cmd.Parameters.AddWithValue("@orid", currentCustOrder.orderID);
                        cmd.Connection = connection;
                        int status = cmd.ExecuteNonQuery();
                        connection.Close();
                        supplierRefresh = false;
                    }
                    if (rbtnSuppliers.Checked)
                    {

                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        connection.Open();
                        cmd.CommandText = "UPDATE TableSupplierOrders SET OrderDate = @od, DeliveryDate = @dda, DeliveryStatus = @dsa, OrderNotes = @ordn WHERE SupplierOrderID = @orid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@od", dtpOrderDate.Value.ToString());
                        cmd.Parameters.AddWithValue("@dda", dtpExpDeliveryDate.Value.ToString());
                        cmd.Parameters.AddWithValue("@dsa", cbxDelStatus.Text);
                        cmd.Parameters.AddWithValue("@ordn", rtbxOrderNotes.Text);
                        cmd.Parameters.AddWithValue("@orid", currentSupplierOrder.orderID);
                        cmd.Connection = connection;
                        int status = cmd.ExecuteNonQuery();
                        connection.Close();
                        
                        if(cbxDelStatus.Text == "Delivered" && (cbxDelStatus.Text != currentSupplierOrder.deliveryStatus))
                        {
                            // If the delivery status has been changed to 'Delivered' and it wasn't this previously, then stock can be updated.
                            foreach (OrderItem item in currentOrderList)
                            {
                                updateInventory(item.quantityRemaining, item.product.id); // quantity remaining is used incase any products were voided before delivery
                            }

                        }
                        supplierRefresh = true;
                    }

                    editMode = false;
                    MessageBox.Show("Order edited successfully.", "Order Edited", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
            }
        }
        private void updateInventory(int quantityChange, int productID) // Update stock
        {
            // Updates inventory stock.
            OleDbConnection conUpdateStock = new OleDbConnection();
            conUpdateStock.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
            OleDbCommand cmdUpdateStock = conUpdateStock.CreateCommand();
            conUpdateStock.Open();
            cmdUpdateStock.CommandText = "UPDATE TableProducts SET Stock = Stock + @sto WHERE ProductID = @prid";
            cmdUpdateStock.Parameters.Clear();
            cmdUpdateStock.Parameters.AddWithValue("@sto", quantityChange); // If the stock change is negative
            cmdUpdateStock.Parameters.AddWithValue("@prid", productID);
            cmdUpdateStock.Connection = conUpdateStock;
            int statusUpdateStock = cmdUpdateStock.ExecuteNonQuery();
            conUpdateStock.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                //ensures user does not accidentally delete product
                DialogResult result = MessageBox.Show("Are you sure you want to discard all changes?", "Discard Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    disableEditing();
                    if (rbtnCust.Checked)
                    {
                        displayCustomerOrderInfo(dgvOrders.Rows[index]);
                    }
                    if (rbtnSuppliers.Checked)
                    {
                        displaySupplierOrderInfo(dgvOrders.Rows[index]);
                    }
                }
                else
                {
                    MessageBox.Show("No changes discarded.", "Discard Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void updateMembershipDetails(int quantityChange, double productCost)
        {
            // Update membership details of the customer when voids/returns are made

            // Calculate the total cost change due to the quantity change and apply any vouchers.
            // The negative sign ensures the calculation reflects a decrease in quantity for returns
            double totalCostChange = -applyVoucher(-quantityChange * productCost);

            // Store the customer's original total stars before applying the change.
            int originalTotalStars = currentCust.totalStars;

            // Update the customer's total stars based on the total cost change.
            // £1 = 3 stars
            currentCust.SetTotalStars(currentCust.totalStars + Convert.ToInt32(totalCostChange * 3));

            // Change in voucher count based on the change in total stars
            // Customers earn 1 voucher for every 150 stars
            int voucherChange = (currentCust.totalStars - originalTotalStars) / 150;

            // This decreases the stars earned and may affect the customer's membership status
            if (quantityChange < 0)
            {
                // Ensure the customer does not have negative total stars
                // If total stars go below zero, adjust the membership type and restore stars accordingly.
                while (currentCust.totalStars < 0)
                {
                    // If the customer is Gold, downgrade to Silver and add 900 stars (the threshold for Gold)
                    if (currentCust.memType == "Gold")
                    {
                        currentCust.SetMemType("Silver");
                        currentCust.SetTotalStars(currentCust.totalStars + 900);

                        // Adjust the voucher count, ensuring it doesn't drop below zero
                        if (currentCust.voucherNum > 0)
                        {
                            currentCust.SetVoucherNum(currentCust.voucherNum + voucherChange - 1);
                        }
                    }
                    // If the customer is Silver, downgrade to Bronze and add 450 stars (the threshold for Silver)
                    else if (currentCust.memType == "Silver")
                    {
                        currentCust.SetMemType("Bronze");
                        currentCust.SetTotalStars(currentCust.totalStars + 450);

                        // Adjust the voucher count, ensuring it doesn't drop below zero.
                        if (currentCust.voucherNum > 0)
                        {
                            currentCust.SetVoucherNum(currentCust.voucherNum + voucherChange - 1);
                        }
                    }
                    // If the customer is already Bronze, set their total stars to zero
                    else
                    {
                        currentCust.SetTotalStars(0);
                    }
                }

                // Ensure the voucher count does not go below zero
                if (currentCust.voucherNum < 0)
                {
                    currentCust.SetVoucherNum(0);
                }
            }


            // Updating the total stars, membership type and vouchers of the customer in the database
            OleDbConnection conCust = new OleDbConnection();
            conCust.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
            OleDbCommand cmdCust = conCust.CreateCommand();
            conCust.Open();
            cmdCust.CommandText = "UPDATE TableCustomers SET MemType = @met,TotalStars = @sta, VoucherNum = @von WHERE CustID = @cid";
            cmdCust.Parameters.Clear();
            cmdCust.Parameters.AddWithValue("@met", currentCust.memType);
            cmdCust.Parameters.AddWithValue("@sta", currentCust.totalStars);
            cmdCust.Parameters.AddWithValue("@von", currentCust.voucherNum);
            cmdCust.Parameters.AddWithValue("@cid", currentCust.id);
            cmdCust.Connection = conCust;
            int status2 = cmdCust.ExecuteNonQuery();
            conCust.Close();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (voidMode)
            {
                int quantityVoided = currentOrderItem.quantityRemaining - (int)numQuantity.Value;
                if (quantityVoided != 0) // If the quantity hasn't been changed.
                {
                    // Checks how many products there are in the order. If there is only one, nothing will be updated as the user must delete the whole order for there to be 0 products in the order.
                    if (dgvOrders.Rows.Count == 1 && numQuantity.Value == 0)
                    {
                        //If there's only one product in the order, and the user has attempted to remove another product, the order will have no products.
                        //Therefore it will not allow the user to remove the product, the user must delete the whole order itself.
                        DialogResult result = MessageBox.Show("Voiding this product will result in a fully voided order. Continue?", "Void Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            voidReturnOrder();
                            switchPanels();
                        }
                        else
                        {
                            MessageBox.Show("No items/orders were voided.", "Void Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            numQuantity.Value = tempQuantity; //sets back to original quantity
                        }
                    }
                    else
                    {
                        //If there's more than one product in the order, the product is removed, stock is updated, total cost of order is updated, stars earned from the order is updated, total stars, membership type and voucher num of customer is updated
                        DialogResult result = MessageBox.Show("Do you want to permanently void this product?", "Void Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (rbtnCust.Checked)
                            {
                                updateInventory(quantityVoided, currentOrderItem.product.id);
                                updateMembershipDetails(-quantityVoided, currentOrderItem.product.cost);

                                double newTotal = Math.Round(currentCustOrder.total - (applyVoucher(currentOrderItem.product.cost) * quantityVoided), 2);
                                int newStarsEarned = Convert.ToInt32(newTotal * 3);

                                OleDbConnection conQuantity = new OleDbConnection();
                                conQuantity.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                                OleDbCommand cmdQuantity = conQuantity.CreateCommand();
                                conQuantity.Open();
                                cmdQuantity.CommandText = "UPDATE TableCustOrderItems SET QuantityVoided = QuantityVoided + @qu WHERE OrderID = @orid AND ProductID = @prid";
                                cmdQuantity.Parameters.Clear();
                                cmdQuantity.Parameters.AddWithValue("@qu", quantityVoided);
                                cmdQuantity.Parameters.AddWithValue("@orid", currentCustOrder.orderID);
                                cmdQuantity.Parameters.AddWithValue("@prid", currentOrderItem.product.id);
                                cmdQuantity.Connection = conQuantity;
                                int statusQuantity = cmdQuantity.ExecuteNonQuery();
                                conQuantity.Close();

                                OleDbConnection conVoid = new OleDbConnection();
                                conVoid.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                                OleDbCommand cmdVoid = conVoid.CreateCommand();
                                conVoid.Open();
                                cmdVoid.CommandText = "UPDATE TableCustOrders SET StarsEarned = @st, Total = @to WHERE CustOrderID = @orid";
                                cmdVoid.Parameters.Clear();
                                cmdVoid.Parameters.AddWithValue("@st", newStarsEarned);
                                cmdVoid.Parameters.AddWithValue("@to", newTotal);
                                cmdVoid.Parameters.AddWithValue("@orid", currentCustOrder.orderID); // copy to return
                                cmdVoid.Connection = conVoid;
                                int status1 = cmdVoid.ExecuteNonQuery();
                                conVoid.Close();
                            }
                            if (rbtnSuppliers.Checked)
                            {
                                double newTotal = Math.Round(currentSupplierOrder.total - (currentOrderItem.product.cost * quantityVoided), 2);

                                OleDbConnection conQuantity = new OleDbConnection();
                                conQuantity.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                                OleDbCommand cmdQuantity = conQuantity.CreateCommand();
                                conQuantity.Open();
                                cmdQuantity.CommandText = "UPDATE TableSupplierOrderItems SET QuantityVoided = QuantityVoided + @qu WHERE OrderID = @orid AND ProductID = @prid";
                                cmdQuantity.Parameters.Clear();
                                cmdQuantity.Parameters.AddWithValue("@qu", quantityVoided);
                                cmdQuantity.Parameters.AddWithValue("@orid", currentSupplierOrder.orderID);
                                cmdQuantity.Parameters.AddWithValue("@prid", currentOrderItem.product.id);
                                cmdQuantity.Connection = conQuantity;
                                int statusQuantity = cmdQuantity.ExecuteNonQuery();
                                conQuantity.Close();

                                OleDbConnection conVoid = new OleDbConnection();
                                conVoid.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                                OleDbCommand cmdVoid = conVoid.CreateCommand();
                                conVoid.Open();
                                cmdVoid.CommandText = "UPDATE TableSupplierOrders SET DeliveryStatus = 'Delivered', Total = @to WHERE SupplierOrderID = @orid";
                                cmdVoid.Parameters.Clear();
                                cmdVoid.Parameters.AddWithValue("@to", newTotal);
                                cmdVoid.Parameters.AddWithValue("@orid", currentSupplierOrder.orderID); // copy to return
                                cmdVoid.Connection = conVoid;
                                int status1 = cmdVoid.ExecuteNonQuery();
                                conVoid.Close();
                            }

                            refreshOrderItemsDGV();
                        }
                        else
                        {
                            MessageBox.Show("No items were voided.", "Void Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayOrderItemInfo((dgvOrders.Rows[0]));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No items were voided.", "Void Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayOrderItemInfo((dgvOrders.Rows[0]));
                }
                voidMode = false;
                tbxQuantityVoided.Text = Convert.ToString(Convert.ToInt32(tbxQuantityVoided.Text) + quantityVoided);
            }
            if (returnMode)
            {
                int quantityReturned = currentOrderItem.quantityRemaining - (int)numQuantity.Value;
                if (quantityReturned != 0) // If the quantity hasn't been changed.
                {
                    // Checks how many products there are in the order. If there is only one, nothing will be updated as the user must delete the whole order for there to be 0 products in the order.
                    if (dgvOrders.Rows.Count == 1)
                    {
                        //If there's only one product in the order, and the user has attempted to remove another product, the order will have no products.
                        //Therefore it will not allow the user to remove the product, the user must delete the whole order itself.
                        DialogResult result = MessageBox.Show("Returning this product will result in a fully returned order. Continue?", "Return Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            voidReturnOrder();
                            switchPanels();
                        }
                        else
                        {
                            MessageBox.Show("No items/orders were returned.", "Return Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            numQuantity.Value = tempQuantity; //sets back to original quantity
                        }
                    }
                    else
                    {
                        //If there's more than one product in the order, the product is removed, stock is updated, total cost of order is updated, stars earned from the order is updated, total stars, membership type and voucher num of customer is updated
                        DialogResult result = MessageBox.Show("Do you want to permanently return this product?", "Return Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (rbtnCust.Checked)
                            {
                                updateInventory(quantityReturned, currentOrderItem.product.id); // If a product is returned to the store, stock increases
                                updateMembershipDetails(-quantityReturned, currentOrderItem.product.cost);

                                double newTotal = Math.Round(currentCustOrder.total - (applyVoucher(currentOrderItem.product.cost) * quantityReturned), 2);
                                int newStarsEarned = Convert.ToInt32(newTotal * 3);
                                OleDbConnection conQuantity = new OleDbConnection();
                                conQuantity.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                                OleDbCommand cmdQuantity = conQuantity.CreateCommand();
                                conQuantity.Open();
                                cmdQuantity.CommandText = "UPDATE TableCustOrderItems SET QuantityReturned = QuantityReturned + @qu WHERE OrderID = @orid AND ProductID = @prid";
                                cmdQuantity.Parameters.Clear();
                                cmdQuantity.Parameters.AddWithValue("@qu", quantityReturned);
                                cmdQuantity.Parameters.AddWithValue("@orid", currentCustOrder.orderID);
                                cmdQuantity.Parameters.AddWithValue("@prid", currentOrderItem.product.id);
                                cmdQuantity.Connection = conQuantity;
                                int statusQuantity = cmdQuantity.ExecuteNonQuery();
                                conQuantity.Close();

                                OleDbConnection conReturn = new OleDbConnection();
                                conReturn.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                                OleDbCommand cmdReturn = conReturn.CreateCommand();
                                conReturn.Open();
                                cmdReturn.CommandText = "UPDATE TableCustOrders SET PaymentStatus = 'Partially Refunded', StarsEarned = @st, Total = @to WHERE CustOrderID = @orid";
                                cmdReturn.Parameters.Clear();
                                cmdReturn.Parameters.AddWithValue("@st", newStarsEarned);
                                cmdReturn.Parameters.AddWithValue("@to", newTotal);
                                cmdReturn.Parameters.AddWithValue("@orid", currentCustOrder.orderID);
                                cmdReturn.Connection = conReturn;
                                int status1 = cmdReturn.ExecuteNonQuery();
                                conReturn.Close();
                            }
                            if (rbtnSuppliers.Checked)
                            {
                                updateInventory(-quantityReturned, currentOrderItem.product.id); // If a product is returned to the supplier, stock decreases

                                double newTotal = Math.Round(currentSupplierOrder.total - (currentOrderItem.product.cost * quantityReturned), 2);
                                OleDbConnection conQuantity = new OleDbConnection();
                                conQuantity.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                                OleDbCommand cmdQuantity = conQuantity.CreateCommand();
                                conQuantity.Open();
                                cmdQuantity.CommandText = "UPDATE TableSupplierOrderItems SET QuantityReturned = QuantityReturned + @qu WHERE OrderID = @orid AND ProductID = @prid";
                                cmdQuantity.Parameters.Clear();
                                cmdQuantity.Parameters.AddWithValue("@qu", quantityReturned);
                                cmdQuantity.Parameters.AddWithValue("@orid", currentSupplierOrder.orderID);
                                cmdQuantity.Parameters.AddWithValue("@prid", currentOrderItem.product.id);
                                cmdQuantity.Connection = conQuantity;
                                int statusQuantity = cmdQuantity.ExecuteNonQuery();
                                conQuantity.Close();

                                OleDbConnection conReturn = new OleDbConnection();
                                conReturn.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                                OleDbCommand cmdReturn = conReturn.CreateCommand();
                                conReturn.Open();
                                cmdReturn.CommandText = "UPDATE TableSupplierOrders SET DeliveryStatus = 'Delivered', Total = @to WHERE SupplierOrderID = @orid";
                                cmdReturn.Parameters.Clear();
                                cmdReturn.Parameters.AddWithValue("@to", newTotal);
                                cmdReturn.Parameters.AddWithValue("@orid", currentSupplierOrder.orderID);
                                cmdReturn.Connection = conReturn;
                                int status1 = cmdReturn.ExecuteNonQuery();
                                conReturn.Close();
                            }
                            refreshOrderItemsDGV();
                        }
                        else
                        {
                            MessageBox.Show("No items were returned.", "Return Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayOrderItemInfo((dgvOrders.Rows[0]));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No items were returned.", "Return Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayOrderItemInfo((dgvOrders.Rows[0]));
                }
                returnMode = false;
                tbxQuantityReturned.Text = Convert.ToString(Convert.ToInt32(tbxQuantityReturned.Text) + quantityReturned);
            }

            refreshOrderItemsDGV();
            numQuantity.Enabled = false;
            btnApply.Visible = false;
        }
        private void voidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.DataSource == bindingSourceItems) // If the void button has been clicked on a specific order item
            {
                numQuantity.Enabled = true;
                numQuantity.Maximum = currentOrderItem.quantityRemaining; // prevents user from increasing the quantity, can only decrease
                btnApply.Visible = true;
                voidMode = true;
            }
            else
            {
                voidReturnOrder();
                refresh();
            }
        }
        private void voidReturnOrder()
        {
            if (rbtnCust.Checked)
            {
                // Voids/returns all order items and the entire order itself, and adjusts the membership information of the customer linked to the order.
                // This event occurs when the user has clicked "Void Order" or "Return Order" or when the user attempts to remove a product from an order resulting in there being no products left in the order.
                foreach (OrderItem item in currentOrderList)
                {
                    updateInventory(item.quantityRemaining, item.product.id);
                    updateMembershipDetails(-item.quantityRemaining, item.product.cost);
                }

                if (currentCustOrder.voucher != "N/A" && currentCustOrder.deliveryStatus != "Collected") // If the customer used a voucher and the order is being voided, the customer cannot get their voucher back if they are returning an order
                {
                    OleDbConnection con1 = new OleDbConnection();
                    con1.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                    OleDbCommand cmd1 = con1.CreateCommand();
                    con1.Open();
                    cmd1.CommandText = "UPDATE TableCustomers SET VoucherNum = VoucherNum + 1 WHERE CustID = @cid";
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.AddWithValue("@cid", currentCustOrder.id);
                    cmd1.Connection = con1;
                    int status2 = cmd1.ExecuteNonQuery();
                    con1.Close();
                }

                // Void/return all items in the order
                OleDbConnection conVoidReturnItems = new OleDbConnection();
                conVoidReturnItems.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                OleDbCommand cmdVoidReturnItems = conVoidReturnItems.CreateCommand();
                conVoidReturnItems.Open();
                if (currentCustOrder.deliveryStatus == "Collected") // If the order has been collected, then it is returned
                {
                    cmdVoidReturnItems.CommandText = "UPDATE TableCustOrderItems SET QuantityVoided = Quantity - QuantityReturned WHERE OrderID = @orid";
                }
                else
                {
                    cmdVoidReturnItems.CommandText = "UPDATE TableCustOrderItems SET QuantityReturned = Quantity - QuantityVoided WHERE OrderID = @orid";
                }
                cmdVoidReturnItems.Parameters.Clear();
                cmdVoidReturnItems.Parameters.AddWithValue("@orid", currentCustOrder.orderID);
                cmdVoidReturnItems.Connection = conVoidReturnItems;
                int status = cmdVoidReturnItems.ExecuteNonQuery();
                conVoidReturnItems.Close();

                // Void/return the order
                OleDbConnection conVoidReturn = new OleDbConnection();
                conVoidReturn.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                OleDbCommand cmdVoidReturn = conVoidReturn.CreateCommand();
                conVoidReturn.Open();
                if(currentCustOrder.deliveryStatus == "Collected") // If the order has been collected, then it is returned
                {
                    cmdVoidReturn.CommandText = "UPDATE TableCustOrders SET DeliveryStatus = 'Returned', PaymentStatus = 'Refunded' WHERE CustOrderID = @orid";
                }
                else //otherwise it is being voided
                {
                    cmdVoidReturn.CommandText = "UPDATE TableCustOrders SET DeliveryDate = OrderDate, DeliveryStatus = 'Voided', PaymentStatus = 'Cancelled', CollectionDateEnd = OrderDate, StarsEarned = 0, Total = 0 WHERE CustOrderID = @orid";

                }
                cmdVoidReturn.Parameters.Clear();
                cmdVoidReturn.Parameters.AddWithValue("@orid", currentCustOrder.orderID);
                cmdVoidReturn.Connection = conVoidReturn;
                int status1 = cmdVoidReturn.ExecuteNonQuery();
                conVoidReturn.Close();
            }
            if (rbtnSuppliers.Checked)
            {
                foreach (OrderItem item in currentOrderList)
                {
                    updateInventory(item.quantityRemaining, item.product.id);
                }

                // Void/return all items in the order
                OleDbConnection conVoidReturnItems = new OleDbConnection();
                conVoidReturnItems.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                OleDbCommand cmdVoidReturnItems = conVoidReturnItems.CreateCommand();
                conVoidReturnItems.Open();
                if(currentSupplierOrder.deliveryStatus == "Delivered") // If the order has been delivered, it will be returned
                {
                    cmdVoidReturnItems.CommandText = "UPDATE TableSupplierOrderItems SET QuantityReturned = Quantity - QuantityVoided WHERE OrderID = @orid";
                }
                else // If the order has not been delivered, it will be voided
                {
                    cmdVoidReturnItems.CommandText = "UPDATE TableSupplierOrderItems SET QuantityVoided = Quantity - QuantityReturned WHERE OrderID = @orid";
                }
                cmdVoidReturnItems.Parameters.Clear();
                cmdVoidReturnItems.Parameters.AddWithValue("@orid", currentSupplierOrder.orderID);
                cmdVoidReturnItems.Connection = conVoidReturnItems;
                int status = cmdVoidReturnItems.ExecuteNonQuery();
                conVoidReturnItems.Close();

                // Void/return the order
                OleDbConnection conVoidReturn = new OleDbConnection();
                conVoidReturn.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                OleDbCommand cmdVoidReturn = conVoidReturn.CreateCommand();
                conVoidReturn.Open(); 
                if (currentSupplierOrder.deliveryStatus == "Delivered") // If the order has been delivered, it will be returned
                {
                    cmdVoidReturn.CommandText = "UPDATE TableSupplierOrders SET DeliveryStatus = 'Returned' WHERE SupplierOrderID = @orid";
                }
                else // If the order has not been delivered, it will be voided
                {
                    cmdVoidReturn.CommandText = "UPDATE TableSupplierOrders SET DeliveryStatus = 'Voided' WHERE SupplierOrderID = @orid";
                }
                cmdVoidReturn.Parameters.Clear();
                cmdVoidReturn.Parameters.AddWithValue("@orid", currentSupplierOrder.orderID);
                cmdVoidReturn.Connection = conVoidReturn;
                int status1 = cmdVoidReturn.ExecuteNonQuery();
                conVoidReturn.Close();
            }
        }
        private void returnOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.DataSource == bindingSourceItems) // If the void button has been clicked on a specific order item
            {
                numQuantity.Enabled = true;
                numQuantity.Maximum = currentOrderItem.quantityRemaining; // prevents user from increasing the quantity, can only decrease
                btnApply.Visible = true;
                returnMode = true;
            }
            else
            {
                voidReturnOrder();
                refresh();
            }
        }
        private void dtpOrderDate_ValueChanged(object sender, EventArgs e)
        {
            // The order date can be a previous date, if a past order has not been recorded.
            // It cannot be later than the expected delivery date, but can be the same if all products in the order are already in store.
            // The collection end date will always be at least a week later than the order date, if the order date and expected delivery date are the same.

            if (editMode)
            {
                //Automatically changes both values so dtpExpDeliveryDate_ValueChanged does not return an error when initiated.
                dtpColDate.Value = dtpOrderDate.Value.AddDays(10);
                dtpExpDeliveryDate.Value = dtpOrderDate.Value.AddDays(3);
            }


        }
        private void dtpExpDeliveryDate_ValueChanged(object sender, EventArgs e)
        {
            // The expected delivery date cannot be earlier than the order date, or later than the collection end date.
            // If editing or adding, automatically set the collection end date to a week after the expected delivery date.
            // Does not change the order date.
            dtpColDate.Value = dtpExpDeliveryDate.Value.AddDays(7);

        }
        private void cbxDelStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (rbtnCust.Checked)
            {
                if (cbxDelStatus.SelectedItem.ToString() == "Collected")
                {
                    tbxStatus.Text = "Archived";
                    tbxPayStatus.Text = "Paid";
                }
                else
                {
                    tbxStatus.Text = "Open";
                    tbxPayStatus.Text = "Unpaid";
                }
            }
            if (rbtnSuppliers.Checked)
            {
                if (cbxDelStatus.SelectedItem.ToString() == "Delivered")
                {
                    tbxStatus.Text = "Archived";
                    tbxPayStatus.Text = "Paid";
                }
                else
                {
                    tbxStatus.Text = "Open";
                    tbxPayStatus.Text = "Unpaid";
                }
            }
        }
        private void rtbxOrderNotes_TextChanged(object sender, EventArgs e)
        {
            // Implements character length limit on order notes. It will show the user when the order notes' text length is reaching the limit of 255.
            if (rtbxOrderNotes.TextLength > 244)
            {
                lblCharLimit.Visible = true;
                lblCharLimit.Text = rtbxOrderNotes.TextLength + "/255";
            }
            else
            {
                lblCharLimit.Visible = false;
            }
        }

        // PRINTING INVOICES
        private void printInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // START GENERATING INVOICE

            lines.Clear(); // Ensures that an entirely new invoice is generated
            pageNum = 1; // Sets the page number to the first page
            startIndex = 0; // Sets the line start index to 0
            printInvoice.DocumentName = "Print Invoice";
            printDlg.Document = printInvoice;
            PaperSize pageSize = new PaperSize();
            pageSize.Width = 220; // Fixes the width of the invoice: this works with the printer used to print these invoices
            printInvoice.DefaultPageSettings.PaperSize = pageSize;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                printInvoice.Print();
            }
        }
        private void printInvoice_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool pdf = false;
            height = 30; // initialises the height every time a new page is created
            if (printDlg.PrinterSettings.PrinterName == "Microsoft Print to PDF")
            {
                pdf = true;
            }
            currentCustOrder.GenerateInvoice(e, pdf, lines);
        }
    }
}
