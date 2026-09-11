using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public partial class Customers : Form
    {
        int index;
        Customer currentCust;
        bool editMode = false;
        List<string> memTypes = new List<string>();

        // Make form draggable
        bool drag = false;
        Point dragCursor;
        Point dragForm;

        public Customers()
        {
            Visible = false;
            InitializeComponent();
        }

        // CUSTOM DRAGGABLE FORM BORDER
        private void pbxBar_MouseDown(object sender, MouseEventArgs e) // Detects when the mouse is down and allows the user to drag
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = Location;
        }
        private void pbxBar_MouseMove(object sender, MouseEventArgs e) // Detects when the mouse is down and moving
        {
            if (drag)
            {
                Point difference = Point.Subtract(Cursor.Position, new Size(dragCursor));
                Location = Point.Add(dragForm, new Size(difference));
            }
        }
        private void pbxBar_MouseUp(object sender, MouseEventArgs e) // Detects when the mouse is not dragging the form
        {
            drag = false;
        }
        private void btnClose_Click(object sender, EventArgs e) // Closes the form
        {
            if (editMode)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to discard all changes?", "Discard Edits", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        // VIEW ALL CUSTOMER INFORMATION
        private void FormCustomers_Load(object sender, EventArgs e) 
        {
            refresh();
            Visible = true;
        }
        private void refresh() // Disables editing and displays all customers.
        {
            disableEditing();
            editMode = false;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = "SELECT * FROM TableCustomers WHERE MemType <> 'Guest' OR MemType <> 'Deleted'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = reader;
            dgvCustomers.DataSource = bindingSource;
            connection.Close();

            //ensures there is always something in the textboxes so null values don't appear when you edit another customer straight after
            refreshCustomerInfo(0);

        }
        private void tbxSearch_TextChanged(object sender, EventArgs e) // As the user types in the search bar, customers are searched for according to the input.
        {
            if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableCustomers WHERE (FirstName LIKE @qu OR Surname LIKE @qu OR EmailAddress LIKE @qu) AND (MemType <> 'Guest' OR MemType <> 'Deleted')";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@qu", "%" + tbxSearch.Text + "%");
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvCustomers.DataSource = bindingSource;
                    refreshCustomerInfo(0);
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
                cmd.CommandText = "SELECT * FROM TableCustomers WHERE MemType <> 'Guest' OR MemType <> 'Deleted'";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvCustomers.DataSource = bindingSource;
                connection.Close();
                refreshCustomerInfo(0);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e) // Search for the customer by name or email address
        {
            if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableCustomers WHERE (FirstName LIKE @qu OR Surname LIKE @qu OR EmailAddress LIKE @qu) AND (MemType <> 'Guest' OR MemType <> 'Deleted')";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@qu", "%"+tbxSearch.Text+"%");
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvCustomers.DataSource = bindingSource;
                    refreshCustomerInfo(0);
                }
                else
                {
                    MessageBox.Show("No customers found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cmd.CommandText = "SELECT * FROM TableCustomers WHERE MemType <> 'Guest' OR MemType <> 'Deleted'";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvCustomers.DataSource = bindingSource;
                connection.Close();
                refreshCustomerInfo(0);
            }
        }
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e) // Allows the user to click on each customer and view all details of each customer.
        {
            disableEditing(); // If the user clicks on another customer while editing, disable editing
            index = e.RowIndex;
            refreshCustomerInfo(index);
        }
        private void refreshCustomerInfo(int index)
        {
            if (index < 0) // Index cannot be negative
            {
                index = 0;
                dgvCustomers.ClearSelection();
                dgvCustomers.CurrentCell = dgvCustomers.Rows[0].Cells[0];
                dgvCustomers[0,0].Selected = true;
                dgvCustomers.FirstDisplayedScrollingRowIndex = 0;
                dgvCustomers.Focus();
            }
            DataGridViewRow selectedRow = dgvCustomers.Rows[index];
            currentCust = new Customer(Convert.ToInt32(selectedRow.Cells[0].Value), selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[2].Value.ToString(), selectedRow.Cells[3].Value.ToString(), selectedRow.Cells[4].Value.ToString(), selectedRow.Cells[5].Value.ToString(), Convert.ToInt32(selectedRow.Cells[6].Value), Convert.ToInt32(selectedRow.Cells[7].Value));
            tbxCustID.Text = currentCust.id.ToString();
            tbxForename.Text = currentCust.firstName;
            tbxSurname.Text = currentCust.lastName;
            tbxPhoneNum.Text = currentCust.phoneNum;
            tbxEmailAdd.Text = currentCust.emailAddress;
            cbxMemType.Text = currentCust.memType;
            tbxTotalStars.Text = currentCust.totalStars.ToString();
            tbxVouchers.Text = currentCust.voucherNum.ToString();
        }

        // ADDING, EDITING AND DELETING
        private void disableEditing()
        {
            editMode = false;
            btnAddSave.Text = "Add New Customer";
            tbxCustID.ReadOnly = true;
            tbxForename.ReadOnly = true;
            tbxSurname.ReadOnly = true;
            tbxEmailAdd.ReadOnly = true;
            tbxPhoneNum.ReadOnly = true;
            cbxMemType.Enabled = false;
            tbxTotalStars.ReadOnly = true;
            tbxVouchers.ReadOnly = true;
            btnCancel.Visible = false;
            tbxCustID.BackColor = SystemColors.ControlLightLight;
            tbxForename.BackColor = SystemColors.ControlLightLight;
            tbxSurname.BackColor = SystemColors.ControlLightLight;
            tbxEmailAdd.BackColor = SystemColors.ControlLightLight;
            tbxPhoneNum.BackColor = SystemColors.ControlLightLight;
            cbxMemType.BackColor = SystemColors.ControlLightLight;
            tbxTotalStars.BackColor = SystemColors.ControlLightLight;
            tbxVouchers.BackColor = SystemColors.ControlLightLight;
            tbxCustID.BorderStyle = BorderStyle.None;
            tbxForename.BorderStyle = BorderStyle.None;
            tbxSurname.BorderStyle = BorderStyle.None;
            tbxEmailAdd.BorderStyle = BorderStyle.None;
            tbxPhoneNum.BorderStyle = BorderStyle.None;
            cbxMemType.FlatStyle = FlatStyle.Flat;
            tbxTotalStars.BorderStyle = BorderStyle.None;
            tbxVouchers.BorderStyle = BorderStyle.None;
        }
        private void enableEditing()
        {
            tbxForename.BackColor = Color.White;
            tbxSurname.BackColor = Color.White;
            tbxEmailAdd.BackColor = Color.White;
            tbxPhoneNum.BackColor = Color.White;
            cbxMemType.BackColor = Color.White;
            tbxTotalStars.BackColor = Color.White;
            tbxVouchers.BackColor = Color.White;
            tbxForename.BorderStyle = BorderStyle.Fixed3D;
            tbxSurname.BorderStyle = BorderStyle.Fixed3D;
            tbxEmailAdd.BorderStyle = BorderStyle.Fixed3D;
            tbxPhoneNum.BorderStyle = BorderStyle.Fixed3D;
            cbxMemType.FlatStyle = FlatStyle.System;
            tbxTotalStars.BorderStyle = BorderStyle.Fixed3D;
            tbxVouchers.BorderStyle = BorderStyle.Fixed3D;
            tbxForename.ReadOnly = false;
            tbxSurname.ReadOnly = false;
            tbxEmailAdd.ReadOnly = false;
            tbxPhoneNum.ReadOnly = false;
            cbxMemType.Enabled = true;
            tbxTotalStars.ReadOnly = false;
            tbxVouchers.ReadOnly = false;
            btnCancel.Visible = true;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e) // Edit all customer details
        {
            //changes the add button to a save button
            editMode = true;
            enableEditing();
            btnAddSave.Text = "Save";
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) // Delete customer data from the system
        {
            if (dgvCustomers.SelectedRows != null)
            {
                //ensures user does not accidentally delete customer
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this customer?", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    bool openOrders = false;

                    // All orders made by the customer must have been collected, voided or returned before deleting their data
                    OleDbConnection con = new OleDbConnection();
                    con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = con.CreateCommand();
                    OleDbDataReader reader;
                    con.Open();
                    cmd.CommandText = "SELECT * FROM TableCustOrders WHERE CustID = @cid AND (DeliveryStatus = 'Order Made' OR DeliveryStatus = 'Ready To Collect')";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@cid", currentCust.id);
                    cmd.Connection = con;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        openOrders = true;
                    }
                    con.Close();
                    if (openOrders)
                    {
                        MessageBox.Show("Review all open orders before deleting customer data.", "Open Orders", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Deletes the customer from all events
                        OleDbConnection conEventAtt = new OleDbConnection();
                        conEventAtt.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmdEventAtt = conEventAtt.CreateCommand();
                        conEventAtt.Open();
                        cmdEventAtt.CommandText = "DELETE FROM TableEventAttendees WHERE CustID = @cid";
                        cmdEventAtt.Parameters.Clear();
                        cmdEventAtt.Parameters.AddWithValue("@cid", currentCust.id);
                        cmdEventAtt.Connection = conEventAtt;
                        int statusEventAtt = cmdEventAtt.ExecuteNonQuery();
                        conEventAtt.Close();

                        // Sets the customer record to a 'deleted state' to maintain referential integrity
                        OleDbConnection conCust = new OleDbConnection();
                        conCust.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmdCust = conCust.CreateCommand();
                        conCust.Open();
                        cmdCust.CommandText = "UPDATE TableCustomers SET FirstName = 'Deleted', Surname = 'Customer', PhoneNum = 'N/A', EmailAddress = 'N/A', MemType = 'Deleted', TotalStars = 0, VoucherNum = 0 WHERE CustID = @cid";
                        cmdCust.Parameters.Clear();
                        cmdCust.Parameters.AddWithValue("@cid", currentCust.id);
                        cmdCust.Connection = conCust;
                        int statusCust = cmdCust.ExecuteNonQuery();
                        conCust.Close();
                        MessageBox.Show("Customer deleted.", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Customer not deleted.", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Select a customer to delete.", "Customer Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e) // Disable editing and clear all changes
        {
            int index = dgvCustomers.SelectedRows[0].Index;
            refresh(); 
            dgvCustomers.ClearSelection();
            dgvCustomers.CurrentCell = dgvCustomers.Rows[index].Cells[0];
            dgvCustomers[0, index].Selected = true;
            dgvCustomers.FirstDisplayedScrollingRowIndex = index;
            dgvCustomers.Focus();
            refreshCustomerInfo(index);
        }
        // Validation
        
        private bool validName(string text)
        {
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-";

            // Check each character
            foreach (char c in text)
            {
                bool found = false;
                for (int i = 0; i < allowedCharacters.Length; i++)
                {
                    if (c == allowedCharacters[i])
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    MessageBox.Show("Input valid details in all fields.", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return found;
                }
            }

            return true;
        }
        private bool validContactInfo()
        {
            // Checks if there is at least a phone number or email address entered.
            // Checks that any inputs are valid.
            if (!string.IsNullOrWhiteSpace(tbxEmailAdd.Text) && !string.IsNullOrWhiteSpace(tbxPhoneNum.Text)) // If both fields have inputs in, both need to be validated
            {
                if (!validEmailAddress(tbxEmailAdd.Text))
                {
                    return false;
                }
                if (!validPhoneNumber(tbxPhoneNum.Text))
                {
                    return false;
                }
                return true;
            }
            else if (!string.IsNullOrWhiteSpace(tbxEmailAdd.Text))
            {
                if (!validEmailAddress(tbxEmailAdd.Text))
                {
                    return false;
                }
                return true;
            }
            else if (!string.IsNullOrWhiteSpace(tbxPhoneNum.Text))
            {
                if (!validPhoneNumber(tbxPhoneNum.Text))
                {
                    return false;
                }
                return true;
            }
            else
            {
                // No inputs for both fields
                return false;
            }
        }
        private bool validEmailAddress(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch
            {
                MessageBox.Show("Enter a valid email address.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool validPhoneNumber(string phoneNumber)
        {
            // Checks that the phone number entered is of a valid length i.e. longer than 7
            // Checks that the phone number entered does not consist of any letters
            // Uses a regular expression to check all characters in the inputted phone number are valid
            string validCharacters = @"^[0-9+\s\-\(\)]+$";
            if (phoneNumber.Length > 7)
            {
                // Allows digits, plus signs, spaces, dashes, opening and closing parentheses
                if (Regex.Match(phoneNumber, validCharacters).Success)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Enter a valid phone number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Suppliers are often international, so validating all phone numbers for all international phone numbers would require the use of an external API

            }
            else
            {
                MessageBox.Show("Phone number must be longer than 7 characters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool validNumber(string str)
        {
            if (!uint.TryParse(str, out uint result)) // Checks if the string can be converted into a positive integer
            {
                MessageBox.Show("Enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAddSave_Click(object sender, EventArgs e) // Add a new customer or save changes made to customer details
        {
            if (!editMode)
            {
                NewCustomer formNewCustomer = new NewCustomer();
                formNewCustomer.ShowDialog();
                refresh();
            }
            if (editMode)
            {
                //editMode is set to true when the user uses the context menu strip and clicks edit
                //editMode is set to false whenever the form refreshes (after deleting, adding or editing a record) or when the user clicks on another customer
                if (string.IsNullOrWhiteSpace(tbxForename.Text) || string.IsNullOrWhiteSpace(tbxSurname.Text) || (string.IsNullOrWhiteSpace(tbxEmailAdd.Text) && string.IsNullOrWhiteSpace(tbxPhoneNum.Text))) // Checks that name fields are filled in and one of phone number or email address is filled in
                {
                    MessageBox.Show("Enter values in all required fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!validContactInfo() || !validNumber(tbxTotalStars.Text) || !validNumber(tbxVouchers.Text) || !validName(tbxForename.Text) || !validName(tbxSurname.Text))
                {
                    // Message boxes are shown when the subroutines are called
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(tbxEmailAdd.Text))
                    {
                        tbxEmailAdd.Text = "N/A";
                    }
                    if (string.IsNullOrWhiteSpace(tbxPhoneNum.Text))
                    {
                        tbxPhoneNum.Text = "N/A";
                    }
                    if (string.IsNullOrWhiteSpace(tbxTotalStars.Text))
                    {
                        tbxTotalStars.Text = "0";
                    }
                    if (string.IsNullOrWhiteSpace(cbxMemType.Text))
                    {
                        cbxMemType.Text = "Bronze"; // Sets the customer's membership status to bronze by default.
                    }
                    if (string.IsNullOrWhiteSpace(tbxVouchers.Text))
                    {
                        tbxVouchers.Text = "0";
                    }
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    connection.Open();
                    cmd.CommandText = "UPDATE TableCustomers SET FirstName = @fn, Surname = @sn, PhoneNum = @pn, EmailAddress = @ea, MemType = @mt, TotalStars = @ts, VoucherNum = @va WHERE CustID = @cid";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@fn", tbxForename.Text);
                    cmd.Parameters.AddWithValue("@sn", tbxSurname.Text);
                    cmd.Parameters.AddWithValue("@pn", tbxPhoneNum.Text);
                    cmd.Parameters.AddWithValue("@ea", tbxEmailAdd.Text);
                    cmd.Parameters.AddWithValue("@mt", cbxMemType.Text);
                    cmd.Parameters.AddWithValue("@ts", tbxTotalStars.Text);
                    cmd.Parameters.AddWithValue("@va", tbxVouchers.Text);
                    cmd.Parameters.AddWithValue("@cid", currentCust.id);
                    cmd.Connection = connection;
                    int status = cmd.ExecuteNonQuery();
                    connection.Close();
                    disableEditing();
                    MessageBox.Show("Customer edited successfully.", "Edit Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int index = dgvCustomers.SelectedRows[0].Index;
                    refresh();
                    refreshCustomerInfo(index);
                    dgvCustomers.ClearSelection();
                    dgvCustomers.CurrentCell = dgvCustomers.Rows[0].Cells[0];
                    dgvCustomers.Rows[index].Selected = true;
                }
            }

        }

    }
}
