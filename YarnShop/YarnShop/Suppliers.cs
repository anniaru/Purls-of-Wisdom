using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public partial class Suppliers : Form
    {
        int index;
        Supplier currentSupplier;
        bool editMode = false;

        // Make form draggable
        bool drag = false;
        Point dragCursor;
        Point dragForm;

        public Suppliers()
        {
            Visible = false;
            InitializeComponent();
        }

        // CUSTOM DRAGGABLE FORM BORDER
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
                DialogResult result = MessageBox.Show("Are you sure you want to discard all changes?", "Discard Edits", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
        
        // VIEW ALL SUPPLIER INFORMATION
        private void FormSuppliers_Load(object sender, EventArgs e)
        {
            refresh();
            Visible = true;
        }
        private void refresh()
        {
            //ensures textboxes cannot be edited until editmode is true

            disableEditing();
            editMode = false;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = "SELECT * FROM TableSuppliers WHERE SupplierName <> 'Deleted' AND EmailAddress <> 'Deleted'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = reader;
            dgvSuppliers.DataSource = bindingSource;
            connection.Close();

            //ensures there is always something in the textboxes so null values don't appear when you edit another supplier straight after
            refreshSupplierInfo(0);

        }
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
            {

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableSuppliers WHERE SupplierName LIKE @sn AND (SupplierName <> 'Deleted' AND EmailAddress <> 'Deleted')";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sn", "%" + tbxSearch.Text + "%");
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvSuppliers.DataSource = bindingSource;
                    refreshSupplierInfo(0);
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
                cmd.CommandText = "SELECT * FROM TableSuppliers WHERE (SupplierName <> 'Deleted' AND EmailAddress <> 'Deleted')";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvSuppliers.DataSource = bindingSource;
                connection.Close();
                refreshSupplierInfo(0);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)// Search for the supplier by name
        {
            if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
            {

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableSuppliers WHERE SupplierName LIKE @sn AND (SupplierName <> 'Deleted' AND EmailAddress <> 'Deleted')";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sn", "%" + tbxSearch.Text + "%");
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvSuppliers.DataSource = bindingSource;
                    refreshSupplierInfo(0);
                }
                else
                {
                    MessageBox.Show("No suppliers found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cmd.CommandText = "SELECT * FROM TableSuppliers WHERE (SupplierName <> 'Deleted' AND EmailAddress <> 'Deleted')";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvSuppliers.DataSource = bindingSource;
                connection.Close();
                refreshSupplierInfo(0);
            }
        }
        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            disableEditing();
            editMode = false;
            index = e.RowIndex;
            refreshSupplierInfo(index);
        }
        private void refreshSupplierInfo(int index)
        {
            if (index < 0) // ensures index is non negative
            {
                index = 0;
            }
            DataGridViewRow selectedRow = dgvSuppliers.Rows[index];
            currentSupplier = new Supplier(Convert.ToInt32(selectedRow.Cells[0].Value), selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[2].Value.ToString(), selectedRow.Cells[3].Value.ToString(), selectedRow.Cells[4].Value.ToString(), selectedRow.Cells[5].Value.ToString(), selectedRow.Cells[6].Value.ToString());
            tbxSupplierID.Text = currentSupplier.id.ToString();
            tbxSupplierName.Text = currentSupplier.supplierName;
            tbxPhoneNum.Text = currentSupplier.phoneNum;
            tbxEmailAdd.Text = currentSupplier.emailAddress;
            tbxPostcode.Text = currentSupplier.postcode;
            tbxAddress.Text = currentSupplier.address;
            tbxURL.Text = currentSupplier.url;
        }

        // ADDING, EDITING AND DELETING
        private void disableEditing()
        {
            btnAddSave.Text = "Add New Supplier";
            tbxSupplierID.ReadOnly = true;
            tbxSupplierName.ReadOnly = true;
            tbxEmailAdd.ReadOnly = true;
            tbxPhoneNum.ReadOnly = true;
            tbxAddress.ReadOnly = true;
            tbxPostcode.ReadOnly = true;
            tbxURL.ReadOnly = true;
            tbxSearch.ReadOnly = false;
            btnCancel.Visible = false;
            tbxSupplierID.BackColor = SystemColors.ControlLightLight;
            tbxSupplierName.BackColor = SystemColors.ControlLightLight;
            tbxEmailAdd.BackColor = SystemColors.ControlLightLight;
            tbxPhoneNum.BackColor = SystemColors.ControlLightLight;
            tbxAddress.BackColor = SystemColors.ControlLightLight;
            tbxPostcode.BackColor = SystemColors.ControlLightLight;
            tbxURL.BackColor = SystemColors.ControlLightLight;
            tbxSupplierID.BorderStyle = BorderStyle.None;
            tbxSupplierName.BorderStyle = BorderStyle.None;
            tbxEmailAdd.BorderStyle = BorderStyle.None;
            tbxPhoneNum.BorderStyle = BorderStyle.None;
            tbxAddress.BorderStyle = BorderStyle.None;
            tbxPostcode.BorderStyle = BorderStyle.None;
            tbxURL.BorderStyle = BorderStyle.None;
        }
        private void enableEditing()
        {
            tbxSupplierName.BackColor = Color.White;
            tbxEmailAdd.BackColor = Color.White;
            tbxPhoneNum.BackColor = Color.White;
            tbxAddress.BackColor = Color.White;
            tbxPostcode.BackColor = Color.White;
            tbxURL.BackColor = Color.White;
            tbxSupplierName.BorderStyle = BorderStyle.Fixed3D;
            tbxEmailAdd.BorderStyle = BorderStyle.Fixed3D;
            tbxPhoneNum.BorderStyle = BorderStyle.Fixed3D;
            tbxAddress.BorderStyle = BorderStyle.Fixed3D;
            tbxPostcode.BorderStyle = BorderStyle.Fixed3D;
            tbxURL.BorderStyle = BorderStyle.Fixed3D;
            tbxSupplierName.ReadOnly = false;
            tbxEmailAdd.ReadOnly = false;
            tbxPhoneNum.ReadOnly = false;
            tbxAddress.ReadOnly = false;
            tbxPostcode.ReadOnly = false;
            tbxURL.ReadOnly = false;
            tbxSearch.ReadOnly = true;
            btnCancel.Visible = true;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e) // Edit all supplier details
        {
            //changes the add button to a save button
            editMode = true;
            enableEditing();
            btnAddSave.Text = "Save";
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) // Delete supplier data from the system
        {
            // The supplier record is set to a 'deleted state' to maintain referential integrity
            if (dgvSuppliers.SelectedRows != null)
            {
                //ensures user does not accidentally delete supplier
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this supplier?", "Delete Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    bool openOrders = false;
                    OleDbConnection con = new OleDbConnection();
                    con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = con.CreateCommand();
                    OleDbDataReader reader;
                    con.Open();
                    cmd.CommandText = "SELECT * FROM TableSupplierOrders WHERE SupplierID = @sid AND (DeliveryStatus = 'Order Made' OR DeliveryStatus = 'Out For Delivery')";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@sid", currentSupplier.id);
                    cmd.Connection = con;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        openOrders = true;
                    }
                    con.Close();
                    if (openOrders)
                    {
                        MessageBox.Show("Review all open orders before deleting supplier data.", "Open Orders", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Discontinues all products by the supplier
                        OleDbConnection conProducts = new OleDbConnection();
                        conProducts.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmdProducts = conProducts.CreateCommand();
                        conProducts.Open();
                        cmdProducts.CommandText = "UPDATE TableProducts SET Discontinued = True WHERE SupplierID = @sid";
                        cmdProducts.Parameters.Clear();
                        cmdProducts.Parameters.AddWithValue("@sid", currentSupplier.id);
                        cmdProducts.Connection = conProducts;
                        int status = cmdProducts.ExecuteNonQuery();
                        conProducts.Close();

                        OleDbConnection conSuppliers = new OleDbConnection();
                        conSuppliers.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmdSuppliers = conSuppliers.CreateCommand();
                        conSuppliers.Open();
                        cmdSuppliers.CommandText = "UPDATE TableSuppliers SET SupplierName = 'Deleted', EmailAddress = 'N/A', PhoneNum = 'N/A', Address = 'N/A',Postcode = 'N/A', URL = 'N/A' WHERE SupplierID = @sid";
                        cmdSuppliers.Parameters.Clear();
                        cmdSuppliers.Parameters.AddWithValue("@sid", currentSupplier.id);
                        cmdSuppliers.Connection = conSuppliers;
                        int status1 = cmdSuppliers.ExecuteNonQuery();
                        conSuppliers.Close();

                        MessageBox.Show("Supplier deleted.", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                }
                else
                {
                    MessageBox.Show("Supplier not deleted.", "Delete Suppliier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Select a supplier to delete.", "Supplier Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            int index = dgvSuppliers.SelectedRows[0].Index;
            refresh();
            refreshSupplierInfo(index);
        }
        // Validation
        private bool validString(string text) // Checks if the string is valid i.e. only contains valid alphanumerical characters and certain special characters
        {

            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -_.,&/():'";

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
        private void btnAddSave_Click(object sender, EventArgs e) // Add a new supplier or save changes made to supplier details
        {
            if (!editMode)
            {
                NewSupplier formNewSupplier = new NewSupplier();
                formNewSupplier.ShowDialog();
                refresh();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbxSupplierName.Text) || (string.IsNullOrWhiteSpace(tbxEmailAdd.Text) && string.IsNullOrWhiteSpace(tbxPhoneNum.Text))) // Checks that name fields are filled in and one of phone number or email address is filled in
                {
                    MessageBox.Show("Enter values in all required fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(!validContactInfo() || !validString(tbxSupplierName.Text) || !validString(tbxAddress.Text) || !validString(tbxPostcode.Text))
                {

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
                    if (string.IsNullOrWhiteSpace(tbxAddress.Text))
                    {
                        tbxAddress.Text = "N/A";
                    }
                    if (string.IsNullOrWhiteSpace(tbxPostcode.Text))
                    {
                        tbxPostcode.Text = "N/A";
                    }
                    if (string.IsNullOrWhiteSpace(tbxURL.Text))
                    {
                        tbxURL.Text = "N/A";
                    }

                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    connection.Open();
                    cmd.CommandText = "UPDATE TableSuppliers SET SupplierName = @sn, PhoneNum = @pn, EmailAddress = @ea, Address = @ad, Postcode = @pc, URL = @url WHERE SupplierID = @ssid";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@sn", tbxSupplierName.Text);
                    cmd.Parameters.AddWithValue("@pn", tbxPhoneNum.Text);
                    cmd.Parameters.AddWithValue("@ea", tbxEmailAdd.Text);
                    cmd.Parameters.AddWithValue("@ad", tbxAddress.Text);
                    cmd.Parameters.AddWithValue("@pc", tbxPostcode.Text);
                    cmd.Parameters.AddWithValue("@url", tbxURL.Text);
                    cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
                    cmd.Connection = connection;
                    int status = cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Supplier edited successfully.", "Edit Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    editMode = false;
                    int index = dgvSuppliers.SelectedRows[0].Index;
                    refresh();
                    refreshSupplierInfo(index);
                    dgvSuppliers.ClearSelection();
                    dgvSuppliers.CurrentCell = dgvSuppliers.Rows[0].Cells[0];
                    dgvSuppliers.Rows[index].Selected = true;
                }
            }
        }

    }
}