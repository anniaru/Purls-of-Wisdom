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
    public partial class NewCustomer : Form
    {
        List<string> memTypes = new List<string>();
        bool existingEmailAddress = false;
        bool existingPhoneNumber = false;
        // Make form draggable
        bool drag = false;
        Point dragCursor;
        Point dragForm;

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
            DialogResult result = MessageBox.Show("Are you sure you want to discard all changes?", "Discard Creator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        public NewCustomer()
        {
            Visible = false;
            InitializeComponent();
        }
        private void FormNewCustomer_Load(object sender, EventArgs e)
        {
            Visible = true;
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
                MessageBox.Show("Enter a valid email address.", "Invalid Input",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
        private void tbxEmailAdd_TextChanged(object sender, EventArgs e)
        {
            // Checks if there is an existing customer with the contact details.

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = "SELECT * FROM TableCustomers WHERE EmailAddress = @ea";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ea", tbxEmailAdd.Text);
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                existingEmailAddress = true;
                btnAdd.Enabled = false;
                lblExisting.Visible = true;
            }
            else
            {
                existingEmailAddress = false;
                if (!existingPhoneNumber)
                {
                    btnAdd.Enabled = true;
                    lblExisting.Visible = false;
                }
            }
            connection.Close();
        }
        private void tbxPhoneNum_TextChanged(object sender, EventArgs e)
        {
            // Checks if there is an existing customer with the contact details.

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = "SELECT * FROM TableCustomers WHERE PhoneNum = @pn";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@pn", tbxPhoneNum.Text);
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                existingPhoneNumber = true;
                btnAdd.Enabled = false;
                lblExisting.Visible = true;
            }
            else
            {
                existingPhoneNumber = false;
                if (!existingEmailAddress)
                {
                    btnAdd.Enabled = true;
                    lblExisting.Visible = false;
                }
            }
            connection.Close();
        }
        // Save
        private void btnAddSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbxForename.Text) || string.IsNullOrWhiteSpace(tbxSurname.Text) || (string.IsNullOrWhiteSpace(tbxEmailAdd.Text) && string.IsNullOrWhiteSpace(tbxPhoneNum.Text))) // Checks that name fields are filled in and one of phone number or email address is filled in
            {
                MessageBox.Show("Enter values in all required fields.", "Enter All Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!tbxForename.Text.All(char.IsLetter) || !tbxSurname.Text.All(char.IsLetter))
            {
                MessageBox.Show("Input valid details in all fields.", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!validContactInfo() || !validNumber(tbxTotalStars.Text) || !validNumber(tbxVouchers.Text) || !validName(tbxForename.Text)||!validName(tbxSurname.Text))
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
                cmd.CommandText = "INSERT INTO TableCustomers(FirstName, Surname, PhoneNum, EmailAddress, MemType, TotalStars, VoucherNum) VALUES(@fn,@sn,@pn,@ea,@mt,@ts,@va)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fn", tbxForename.Text);
                cmd.Parameters.AddWithValue("@sn", tbxSurname.Text);
                cmd.Parameters.AddWithValue("@pn", tbxPhoneNum.Text);
                cmd.Parameters.AddWithValue("@ea", tbxEmailAdd.Text);
                cmd.Parameters.AddWithValue("@mt", cbxMemType.Text);
                cmd.Parameters.AddWithValue("@ts", tbxTotalStars.Text);
                cmd.Parameters.AddWithValue("@va", tbxVouchers.Text);
                cmd.Connection = connection;
                int status = cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("New customer added successfully.", "New Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

        }
        private void btnClear_Click(object sender, EventArgs e) // Clears whole form
        {
            tbxForename.Text = "";
            tbxEmailAdd.Text = "";
            tbxSurname.Text = "";
            tbxMemType.Text = "";
            tbxPhoneNum.Text = "";
            tbxVouchers.Text = "";
            tbxTotalStars.Text = "";
            cbxMemType.SelectedIndex = 0;
        }
    }
}
